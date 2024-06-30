using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Interfaces
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<IEnumerable<Education>> SearchByName(string name);
    }
}
