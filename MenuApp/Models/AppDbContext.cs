using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
       
        public DbSet<Itemname> itemnames { get; set; }
        public DbSet<StoreData> storeDatas { get; set; }
     
    }
}
