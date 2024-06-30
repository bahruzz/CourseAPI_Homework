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
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Teacher>> GetAllWithGroupsAsync()
        {
            return await _context.Teachers.AsNoTracking().Include(m => m.GroupTeachers).ThenInclude(m => m.Group).ToListAsync();
        }

        public async Task<Teacher> GetByIdWithAsync(int? id)
        {

            if (id == null) { throw new ArgumentNullException(nameof(id));}

            var data = await _context.Teachers.AsNoTracking().Include(s => s.GroupTeachers)

            .ThenInclude(gs => gs.Group).FirstOrDefaultAsync(m => m.Id == id);

            return data;
        }

        public async Task<IEnumerable<Teacher>> SearchByNameOrSurname(string str)
        {
            var data = await _context.Teachers.Where(m => m.Name.Trim().Contains(str.Trim()) || m.Surname.Contains(str.Trim())).ToListAsync();
            return data;
        }
    }

}
