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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "16ddca1c-6b97-423d-89e0-6027bf06a8f7",
                        Name = "CustomerAccount",
                        NormalizedName = "CUSTOMERACCOUNT"
                    },
                    new IdentityRole
                    {
                        Id = "c0129f08-509b-4731-ac4a-507b6a092aa7",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                );
        }
    }
}
