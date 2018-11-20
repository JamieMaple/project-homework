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
            return await _roomRepository.GetAllRooms();
        }
    }


    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();
    }
}
