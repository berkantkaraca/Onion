using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Entities;

namespace Onion.Persistence.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.AppUserProfile)
                   .WithOne(x => x.AppUser)
                   .HasForeignKey<AppUserProfile>(x => x.AppUserId);
            //TODO: Nota bak
        }
    }
}
