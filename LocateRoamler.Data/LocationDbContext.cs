using LocateRoamler.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocateRoamler.Data
{
    public class LocationDbContext : IdentityDbContext
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options)
            : base(options) { }

        public DbSet<LocationModel> Locations { get; set; }
    }
}
