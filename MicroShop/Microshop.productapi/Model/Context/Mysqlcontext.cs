using Microsoft.EntityFrameworkCore;

namespace Microshop.productapi.Model.Context
{
    public class Mysqlcontext : DbContext
    {
        public Mysqlcontext() 
        {

        }
        public Mysqlcontext(DbContextOptions<Mysqlcontext> options) : base(options)
        {

        }

        public DbSet<Productc> Productcs { get; set; }
        
    }
}
