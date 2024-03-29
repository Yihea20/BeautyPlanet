using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.DataAccess
{
    public class BeautyDbContext:DbContext
    {
       public  BeautyDbContext(DbContextOptions<BeautyDbContext> options):base(options) { }
    }
}
