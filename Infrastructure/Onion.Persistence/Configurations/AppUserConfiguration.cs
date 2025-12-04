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
            //HasOne ve WithOne metotları kullanıldıgı icin Foreign Key olsa bile otomatik birebir ve unique bir ilişki kurulacak. Ve aynı zamanda Id management serbestligi de kazanacaksınız.

            //AppUser                       //Profile
            //1  - winterex                1 - Cagri Yolyapar AppUserId(1)
            //2  - xc12                    2 - Assd asd AppUser(1) engellenir
        }
    }
}
