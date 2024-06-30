using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int RoomId { get; set; }
        public int EducationId { get; set; }

    }
}
