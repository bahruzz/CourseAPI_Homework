using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllWithGroupsAsync();
        Task<Student> GetByIdWithAsync(int? id);
        Task<IEnumerable<Student>> SearchByNameOrSurname(string str);


    }
}
