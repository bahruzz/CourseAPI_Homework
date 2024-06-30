using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repostories.Interfaces;
using Service.DTOs.Admin.Rooms;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;

        public RoomService(IRoomRepository roomRepo,
                           IMapper mapper,
                           ILogger<RoomService> logger)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
            _logger = logger;
            
        }
        public async Task CreateAsync(RoomCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();

            await _roomRepo.CreateAsync(_mapper.Map<Room>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var data = await _roomRepo.GetById((int)id);
            await _roomRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, RoomEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _roomRepo.GetById(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _roomRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<RoomDto>> GetAllWithAsync()
        {
            _logger.LogInformation("Get All method is working");

            var data = await _roomRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(data);
        }

        public async Task<RoomDto> GetByIdAsync(int? id)
        {
            return _mapper.Map<RoomDto>(await _roomRepo.GetById((int)id));
        }

       

        public async Task<IEnumerable<RoomDto>> SearchtByName(string name)
        {
            if (name == null) throw new NotFoundException("Name is null");
            var data = _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.SearchByName(name));

            return data;
        }
    }
}
