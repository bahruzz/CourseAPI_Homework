using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories
{
    public class RoomRepository : BaseRepository<Room>,IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
            
        }

 
        public async Task<IEnumerable<Room>> SearchByName(string name)
        {
            var data = await _context.Rooms.Where(m => m.Name.Trim().Contains(name.Trim())).ToListAsync();
            return data;
        }
    }
}
