using Microsoft.EntityFrameworkCore;
using animeWebApi.Models;

namespace animeWebApi.Data
{
    /*
     * 
     * to use Dbcontext you need to install EntityFrameworkCore
     * you need to install entity framework core design for migrations
     * and install entity framework core sql to manage the db
     * 
     * to install entity ef dotnet  tool install --global dotnet-ef
     * 
     * dotnet ef migrations add name to genete the migrations file
     * 
     * dotnet ef database update to create the data base
    */
    public class DataCharacterContext : DbContext
    {
        public DataCharacterContext(DbContextOptions<DataCharacterContext> options) : base(options) { }

        public DbSet<Characters> Characters { get; set; }
    }
}
