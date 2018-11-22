using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreBackend.DAL
{
    [Table("category")]
    public class Category : Base
    {
        public string Name { get; set; }
    }
}
