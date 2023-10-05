using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeQLTest.Controllers
{
    [Route("01_03_07")]
    public class BAM01_03_07Controller : Controller
    {
        [Route("")]
        public async Task<IActionResult> Index([FromQuery] string path)
        {
            if (new FileInfo(path).Exists)
            {
                //Wait for longer operation to complete
                await new DatabaseContext().Users.ToListAsync();
                //Might be deleted already
                System.IO.File.Delete(path);
            }
            return Ok();
        }
    }
}
