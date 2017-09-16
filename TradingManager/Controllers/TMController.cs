using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TradingManager.Controllers
{

    public class TMController : Controller
    {
        // GET api/values
        [HttpGet]
        public int Get(int id, int id2)
        {
            return id + id2;
        }

   
    }
}
