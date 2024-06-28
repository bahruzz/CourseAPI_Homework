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
            return await _context.Groups.AsNoTracking().Include(m => m.StudentGroups).ToListAsync();
        }
    }
}
