using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get() => new string[] { "This", "is", "hard", "coded" };
  }
}