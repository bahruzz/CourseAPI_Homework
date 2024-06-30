using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Interfaces
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Task<IEnumerable<Teacher>> GetAllWithGroupsAsync();

        Task<Teacher> GetByIdWithAsync(int? id);      
        Task<IEnumerable<Teacher>> SearchByNameOrSurname(string str);
    }
}
