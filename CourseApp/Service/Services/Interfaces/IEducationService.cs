using Service.DTOs.Admin.Educations;
using Service.DTOs.Admin.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        Task CreateAsync(EducationCreateDto model);
        Task<IEnumerable<EducationDto>> GetAllWithAsync();

        Task<EducationDto> GetByIdAsync(int? id);
        Task DeleteAsync(int id);

        Task EditAsync(int id, EducationEditDto model);

        Task<IEnumerable<EducationDto>> SearchByName(string name);

    }
}
