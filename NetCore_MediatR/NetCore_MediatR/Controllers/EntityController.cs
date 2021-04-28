using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_MediatR.Controllers
{
    public class EntityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
