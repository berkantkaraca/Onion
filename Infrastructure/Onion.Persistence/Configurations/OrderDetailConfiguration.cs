using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Entities;

namespace Onion.Persistence.Configurations
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);

            //id ignore edilmeden composite index oluşturuldu
            builder.HasIndex(x => new { 
                        x.OrderId, 
                        x.ProductId 
                    })
                    .IsUnique();
        }
    }
}
