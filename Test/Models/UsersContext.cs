using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.HolydayModels;
using Test.Models.UsedUrls;

namespace Test.Models
{
    public class UsersContext : DbContext
    {
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<FromDate> fromDates { get; set; }
        public DbSet<ToDate> toDates { get; set; }
        public DbSet<Date> dates { get; set; }
        public DbSet<Holiday> holidays { get; set; }
        public DbSet<Name> names { get; set; }
        public DbSet<UsedUrl> UsedUrls { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
