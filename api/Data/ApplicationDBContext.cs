using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Data
{
    public class ApplicationDBContext :DbContext //inheret from the DbContext
    {
        //this is how we are creating our tables in the database       
        public ApplicationDBContext(DbContextOptions dbContextOptions ) : base(dbContextOptions)
        {
            
        } 
        public DbSet<Stock> Stocks {get;set;}
        public DbSet<Comment> Comments {get;set;}
    }
}