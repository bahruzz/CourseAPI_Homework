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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.HasCheckConstraint("CK_Room_SeatCount_MinLength", "[SeatCount] >= 0 AND [SeatCount] <=25 ");
        }
    }
}
