using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeQLTest.Pages
{
    public class _06_03_01Model : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Input { get; set; }

        public void OnGet()
        {
        }
    }
}
