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
    public class StudentRepository :BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Student>> GetAllWithGroupsAsync()
        {
            return await _context.Students.AsNoTracking().Include(m => m.StudentGroups).ThenInclude(m=>m.Group).ToListAsync();
        }
    }
}
