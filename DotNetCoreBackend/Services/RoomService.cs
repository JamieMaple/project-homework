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

        public async Task<List<Room>> GetAllRooms()
        {
            try
            {
                return await _roomRepository.GetAllRooms();
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }

        public async Task<bool> ChangeRoomStatus(int roomId, int userId, RoomStatus status)
        {
            try
            {
                var room = await _roomRepository.ChangeRoomStatus(roomId, status);
                await _roomRepository.SaveRoomHistory(room, userId);
                return true;
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }


    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();
        Task<bool> ChangeRoomStatus(int roomId, int userId, RoomStatus status);
    }
}
