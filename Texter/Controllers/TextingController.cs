using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texter.Connections;

namespace Texter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextingController : ControllerBase
    {
        readonly TextConnection _connection;

        public TextingController(TextConnection connection)
        {
            _connection = connection;
        }

        [HttpPost("{phoneNumber}")]
        public ActionResult SendMessage(string phoneNumber)
        {
            _connection.SendMessage(phoneNumber);
            return Accepted(phoneNumber);
        }
    }
}

