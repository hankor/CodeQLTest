﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeQLTest.Controllers
{
    [Route("06_02_06")]
    public class BAM06_02_06Controller : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index([FromQuery] string input)
        {
            var context = new DatabaseContext();
            var result = await context.Users.FromSqlRaw("SELECT * FROM Users WHERE FirstName = '" + input + "'").ToListAsync();
            return Ok(result);
        }
    }
}
