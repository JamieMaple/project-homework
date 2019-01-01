using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using GraphQL;
using Dapper;
using Dapper.FastCrud;

namespace DotNetCoreBackend.DAL
{
    public class BaseRepository
    {
        private readonly IConfiguration Configuration;

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(Configuration.GetConnectionString("MySqlConnection"));
            }
        }

        public long GetTime()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        private void Delete<T>(int id)
        {
            using (var conn = Connection)
            {
                conn.UpdateFields<T>(new { Id = id, Delete_at = GetTime() });
            }
        }

        public async Task<List<T>> GetList<T>(int offset, int limit) where T : Base
        {
            using (var conn = Connection)
            {
                var result = await conn.FindAsync<T>(s => s.Where($"{nameof(Base.DeleteAt):C}=0 or {nameof(Base.DeleteAt):C}=null").Skip(offset).Top(limit));
                return result.ToList();
            }
        }

        public async Task<bool> Delete(int id, string tableName)
        {
            using (var conn = Connection)
            {
                var sql = string.Format("UPDATE {0} set delete_at={1} where id={2}", tableName, GetTime(), id);
                return await conn.ExecuteAsync(sql) >= 1;
            }
        }

        protected bool isNotExist(Base obj)
        {
            return obj == null || obj.DeleteAt != 0;
        }

        protected void Error(string message)
        {
            throw new Exception(message);
        }
    }

    public static class BaseRepositoryExtension
    {
        /// <summary>
        /// Updates table T with the values in param.
        /// The table must have a key named "Id" and the value of id must be included in the "param" anon object. The Id value is used as the "where" clause in the generated SQL
        /// </summary>
        /// <typeparam name="T">Type to update. Translates to table name</typeparam>
        /// <param name="connection"></param>
        /// <param name="param">An anonymous object with key=value types</param>
        /// <returns>The Id of the updated row. If no row was updated or id was not part of fields, returns null</returns>
        public static object UpdateFields<T>(this IDbConnection connection, object param, IDbTransaction transaction = null, int? commandTimeOut = null, CommandType? commandType = null)
        {
            var names = new List<string>();
            object id = null;

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(param))
            {
                if (!"Id".Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    //string result = string.Concat(prp.Select((x,i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())); 
                    names.Add(property.Name);
                }
                else
                {
                    id = property.GetValue(param);
                }
            }

            if (id != null && names.Count > 0)
            {
                var sql = string.Format("UPDATE {1} SET {0} WHERE Id=@Id", string.Join(",", names.Select(t => { t = t + "=@" + t; return t; })), typeof(T).Name);
                Console.WriteLine(sql);
                if (Debugger.IsAttached)
                    Trace.WriteLine(string.Format("UpdateFields: {0}", sql));
                return connection.Execute(sql, param, transaction, commandTimeOut, commandType) > 0 ? id : null;
                return null;
            }
            return null;
        }

        public static object UpdateFields<T>(this IDbConnection connection, object fields, CommandDefinition commandDefinition)
        {
            return UpdateFields<T>(connection, fields, commandDefinition.Transaction, commandDefinition.CommandTimeout, commandDefinition.CommandType);
        }
    }
}
