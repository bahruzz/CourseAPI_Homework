using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IRoomService
    {
        Task CreateAsync(RoomCreateDto model);
        
        Task<IEnumerable<RoomDto>> GetAllWithAsync();

        Task<RoomDto> GetByIdAsync(int? id);
        Task DeleteAsync(int id);

        Task EditAsync(int id, RoomEditDto model);
        Task<IEnumerable<RoomDto>> SearchtByName(string name);
    }
}
