using EF_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DataAccess.FluentConfig
{
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
           
            modelBuilder.HasOne(u => u.Book).WithMany(u => u.BookAuthorMaps).HasForeignKey(u => u.Book_Id);
            modelBuilder.HasOne(u => u.Author).WithMany(u => u.BookAuthorMaps).HasForeignKey(u => u.Author_Id);

        }
    }
}
