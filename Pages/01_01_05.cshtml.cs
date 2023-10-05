using CodeQLTest.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeQLTest.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public BAMUser User { get; set; }

        public void OnGet()
        {
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