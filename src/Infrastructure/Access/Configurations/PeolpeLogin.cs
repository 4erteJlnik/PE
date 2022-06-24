using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Post.
    /// </summary>
    public class PeopleloginConfiguration : IEntityTypeConfiguration<Peoplelogin>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Peoplelogin> builder)
        {
            builder.HasOne<Peopledto>(p=>p.orig).WithOne(p=>p.Peoplelogin).HasForeignKey<Peopledto>(p=>p.ID).IsRequired(false);
        }
    }
}