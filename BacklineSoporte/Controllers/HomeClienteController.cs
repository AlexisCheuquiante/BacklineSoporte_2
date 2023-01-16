﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BacklineSoporte.Controllers
{
    public class HomeClienteController : Controller
    {
        // GET: HomeCliente
        public ActionResult Index()
        {
            BacklineSoporte.Models.HomeClienteModel model = new Models.HomeClienteModel();
            model.NombreCliente = SessionH.Usuario.NombreCompleto;
            return View(model);
        }
    }
}