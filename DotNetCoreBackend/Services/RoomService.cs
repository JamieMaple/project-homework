using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository repository)
        {
            _roomRepository = repository;
        }

        public async Task<List<Room>> GetAllRooms(int offset, int limit)
        {
            try
            {
                return await _roomRepository.GetAllRooms(offset, limit);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }

        public async Task<bool> ChangeRoomStatus(int roomId, int userId, RoomStatus status)
        {
            try
            {
                var room = await _roomRepository.ChangeRoomStatus(roomId, status, userId);
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public async Task<bool> AddRoom(Room room) 
        {
            try
            {
                return await _roomRepository.AddRoom(room);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public async Task<bool> UpdateRoomInfo(Room room)
        {
            try
            {
                return await _roomRepository.UpdateRoom(room);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public async Task<bool> DeleteRoomById(int id)
        {
            try
            {
                return await _roomRepository.DeleteRoomById(id);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }


    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms(int offset, int limit);
        Task<bool> AddRoom(Room room);
        Task<bool> ChangeRoomStatus(int roomId, int userId, RoomStatus status);
        Task<bool> DeleteRoomById(int id);
        Task<bool> UpdateRoomInfo(Room room);
    }
}
