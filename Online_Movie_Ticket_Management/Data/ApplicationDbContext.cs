using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Movie_Ticket_Management.Models;

namespace Online_Movie_Ticket_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Online_Movie_Ticket_Management.Models.Actor> Actor { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.Actor_Movie> Actor_Movie { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.Actress> Actress { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.Movie> Movie { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.Order> Order { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.Producer> Producer { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.OrderItem> OrderItem { get; set; } = default!;
        public DbSet<Online_Movie_Ticket_Management.Models.ShoppingCartItem> ShoppingCartItem { get; set; } = default!;
    }
}
