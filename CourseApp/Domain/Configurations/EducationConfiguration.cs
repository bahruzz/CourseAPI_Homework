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
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
    
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }
    }
}
