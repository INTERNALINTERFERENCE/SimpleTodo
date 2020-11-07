using Microsoft.EntityFrameworkCore;
using SimpleTodo.Models;

namespace SimpleTodo.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {}
        
        public DbSet<TodoItem> Items { get; set; }
    }
}