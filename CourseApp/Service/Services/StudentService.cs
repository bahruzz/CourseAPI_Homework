using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Data;
using Repository.Repostories.Interfaces;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;
        private readonly AppDbContext _context;

        public StudentService(IGroupRepository groupRepo,
                              IStudentRepository studentRepo,
                              IMapper mapper,
                               ILogger<StudentService> logger,
                               AppDbContext context)
        {
            _groupRepo = groupRepo;
            _studentRepo = studentRepo;
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }
        public async Task CreateAsync(StudentCreateDto model)
        {
            var existGroup = await _groupRepo.GetById(model.GroupId);
            if (existGroup is null)
            {
                _logger.LogWarning($"Group is not found -{model.GroupId + "-" + DateTime.Now.ToString()}");
                throw new NotFoundException($"id-{model.GroupId} Group not found");
            }
            if (model == null) throw new ArgumentNullException();
           

            Student student = _mapper.Map<Student>(model);
            student.StudentGroups.Add(new StudentGroup
            {
                GroupId = model.GroupId,
                StudentId = student.Id
            });

            await _studentRepo.CreateAsync(student);

        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var data = await _studentRepo.GetById((int)id);
            await _studentRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, StudentEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _studentRepo.GetByIdWithAsync(id);

            if (data is null) throw new NotFoundException("Student not found");

            _context.StudentGroups.RemoveRange(data.StudentGroups);
            foreach (var groupId in model.GroupId)
            {
                data.StudentGroups.Add(new StudentGroup { StudentId = data.Id, GroupId = groupId });
            }
            var editData = _mapper.Map(model, data);
            await _studentRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<StudentDto>> GetAllWithGroupsAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _studentRepo.GetAllWithGroupsAsync());
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var data = _studentRepo.FindBy(m => m.Id == id, m => m.StudentGroups);

            return _mapper.Map<StudentDto>(data.FirstOrDefault());
        }

        public async Task<IEnumerable<StudentDto>> SearchByNameOrSurname(string nameOrSurname)
        {
            if (nameOrSurname == null) throw new NotFoundException("Name or surname is null");
            var data = _mapper.Map<IEnumerable<StudentDto>>(await _studentRepo.SearchByNameOrSurname(nameOrSurname));

            return data;
        }
    }
}
