using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentGroup
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Group))] public int GroupId { get; set; }
        public Group Group { get; set; }
        [ForeignKey(nameof(Student))] public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
