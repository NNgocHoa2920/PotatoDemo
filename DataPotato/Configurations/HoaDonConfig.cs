using DataPotato.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCpotato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPotato.Configurations
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {

            builder.HasKey(x => x.Id); // config khoa chinh
            //confog khoa ngoai
            builder.HasOne(p => p.User).WithMany(p => p.HoaDons)
                .HasForeignKey(p => p.UserId).HasConstraintName("FK_User_HD");
            // voi moi user co nhieu hoa don, khoa ngoai la cot userId 
            //ten khoa ngoai la  FK_User_HD
        }
    }
}
