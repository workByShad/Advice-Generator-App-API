using advice_generator_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace advice_generator_app_api.Data
{
    public class AdviceItemContext : DbContext
    {
        public AdviceItemContext(DbContextOptions<AdviceItemContext> options) : base(options) { }
        public DbSet<AdviceItem> AdviceItems { get; set; } = null!;
    }
}
