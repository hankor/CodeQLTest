using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            System.IO.File.WriteAllText("C:\\tmp\\01_01_05.txt", JsonSerializer.Serialize(User));
        }
    }

    public class BAMUser
    {
        public string FirstName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
