using CustomCookieBased.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCookieBased.Configurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new AppUser
            {
                Id = 1,
                UserName = "Yavuz",
                Password = "1",
            });
            builder.Property(x => x.Password).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.UserName).HasMaxLength(250).IsRequired();
          
        
        }
    
    }
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole()
            {
                Id = 1,
                Definition = "Admin",
            });

            builder.Property(x=>x.Definition).HasMaxLength(200).IsRequired();
        }
    }

    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole()
            {
                RoleId= 1,
                UserId=1,
            });

           builder.HasKey(x=> new {x.UserId,x.RoleId});//UserId,x.RoleId bu ikisi berber primary key 
            builder.HasOne(x => x.AppRole).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);//hangi tablodaki configrasyondaysan hasoneyi onunn üzerinden yap ve forenkey onun tablosundan olur 
            builder.HasOne(x => x.AppUser).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
        }
    }

}
