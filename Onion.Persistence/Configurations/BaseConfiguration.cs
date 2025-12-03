using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Interfaces;

namespace Onion.Persistence.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //builder.Property(x => x.CreatedDate).HasColumnName("Veri Yaratılma Tarihi");
            //builder.Property(x => x.UpdatedDate).HasColumnName("Veri Güncelleme Tarihi");
            //builder.Property(x => x.DeletedDate).HasColumnName("Veri Silme Tarihi");
            //builder.Property(x => x.Status).HasColumnName("Veri Durumu");

        }
    }
}
