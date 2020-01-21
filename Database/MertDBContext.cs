using Microsoft.EntityFrameworkCore;
using net_core_bootcamp_b1_mert.Models;

namespace net_core_bootcamp_b1_mert.Database
{
    public class MertDBContext : DbContext
    {
        public MertDBContext(DbContextOptions<MertDBContext> options) : base(options)
        {
        }

        public DbSet<HWEvent> HWEvent { get; set; }
    }
}
