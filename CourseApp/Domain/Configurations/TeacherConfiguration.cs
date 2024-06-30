using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Surname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Salary).IsRequired();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.HasCheckConstraint("CK_Teacher_Age_MinLength", "[Age] >= 30 AND [Age] <=75 ");
        }
    }
}
