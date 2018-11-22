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

        public async Task<bool> ChangeRoomStatus(int roomId, RoomStatus status)
        {
            try
            {
                return await _roomRepository.ChangeRoomStatus(roomId, status);
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
        Task<bool> ChangeRoomStatus(int roomId, RoomStatus status);
    }
}
