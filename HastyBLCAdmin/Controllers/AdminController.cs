﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastyBLCAdmin.Controllers
{
    [Authorize(Roles = "User1")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}