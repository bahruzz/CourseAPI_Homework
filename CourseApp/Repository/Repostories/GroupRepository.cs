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
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Group>> GetAllWithStudentCountAsync()
        {
            return await _context.Groups.AsNoTracking()
                .Include(m => m.StudentGroups)
                .Include(m=>m.GroupTeachers).ThenInclude(m=>m.Teacher)
                .Include(m=>m.Room)
                .Include(m=>m.Education)
                .ToListAsync();
        }

        public async Task<List<Group>> GetByIdWithIncludesAsync(List<int>? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            List<Group> groups = new();
            foreach (var item in id)
            {
                if (!await _context.Groups.AnyAsync(g => g.Id == item))
                {
                    throw new NullReferenceException(nameof(item));

                }
                else
                {
                    groups.Add(await _context.Groups.AsNoTracking().FirstOrDefaultAsync(m => m.Id == item));
                }
            }


            return groups;
        }

        public async Task<IEnumerable<Group>> SearchByName(string name)
        {
            var data = await _context.Groups.Where(m => m.Name.Trim().Contains(name.Trim())).ToListAsync();
            return data;
        }
    }
}
