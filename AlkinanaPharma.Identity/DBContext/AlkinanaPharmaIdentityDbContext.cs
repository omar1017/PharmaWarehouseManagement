using AlkinanaPharma.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharma.Identity.DBContext;

public class AlkinanaPharmaIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AlkinanaPharmaIdentityDbContext(DbContextOptions<AlkinanaPharmaIdentityDbContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AlkinanaPharmaIdentityDbContext).Assembly);
        
    }
}



