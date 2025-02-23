

using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistance.EntityTypeConfig
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Gender)
                .HasConversion<EnumToStringConverter<Gender>>()
                .IsRequired();
        }
    }
}
