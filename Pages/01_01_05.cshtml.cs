using System.ComponentModel.DataAnnotations;
using CodeQLTest.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeQLTest.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public BAMUser User { get; set; }

        public void OnGet(string input)
        {
            var context = new DatabaseContext();
            context.Users.FromSqlRaw("SELECT * FROM Users WHERE FirstName = '" + input + "'");
        }

        public void OnPost()
        {
            var context = new DatabaseContext();
            context.Users.Add(User);
            context.SaveChanges();
        }
    }

    public class BAMUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public bool IsAdmin { get; set; }
    }
}

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=Test; User Id=test; Password=test; TrustServerCertificate=True;");

    public DbSet<BAMUser> Users { get; set; }
}