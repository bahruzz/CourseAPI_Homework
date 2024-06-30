using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllWithStudentCountAsync();

        Task<List<Group>> GetByIdWithIncludesAsync(List<int>? id);
        Task<IEnumerable<Group>> SearchByName(string name);
    }

}
