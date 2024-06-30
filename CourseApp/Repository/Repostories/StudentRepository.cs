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

        public async Task<Student> GetByIdWithAsync(int? id)
        {
            if (id == null) { throw new ArgumentNullException(nameof(id)); }
            var data = await _context.Students.AsNoTracking().Include(m => m.StudentGroups).ThenInclude(m => m.Group).FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }

        public async Task<IEnumerable<Student>> SearchByNameOrSurname(string str)
        {
            var data = await _context.Students.Where(m => m.Name.Trim().Contains(str.Trim()) || m.Surname.Contains(str.Trim())).ToListAsync();
            return data;
        }
    }
}
