using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using testcase.API.Models;

namespace testcase.API.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
