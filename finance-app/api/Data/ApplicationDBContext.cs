using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)// dbContextOptions is just sent to DbContext constructor
        {
            
        }
    
        public DbSet<Stock> Stocks { get; set; } = null!; // its like getting the table what it does is that it gets data from DB and proovides so i can do soemthing with it used to manipulate the table in the database
        public DbSet<Comment> Comments { get; set; } = null!;
        // public DbSet<User> Users { get; set; } = null!;
        // public DbSet<WatchList> WatchLists { get; set; } = null!;
        // public DbSet<Transaction> Transactions { get; set; } = null!;
         
    }
}