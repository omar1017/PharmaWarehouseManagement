using AlkinanaPharma.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharma.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "16ddca1c-6b97-423d-89e0-6027bf06a8f7",
                        UserId = "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "c0129f08-509b-4731-ac4a-507b6a092aa7",
                        UserId = "6a1508f2-95ea-4496-ab0a-06291adc542f"
                    }
                );
        }
    }
}
