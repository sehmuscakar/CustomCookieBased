using CustomCookieBased.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCookieBased.Configurations
{
    public interface IAppUserConfigurations
    {
        void Configure(EntityTypeBuilder<AppRole> builder);
        void Configure(EntityTypeBuilder<AppUser> builder);
    }
}