using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvcplaza.Models;

namespace mvcplaza.Controllers
{
    public class GorevController : Controller
    {
        // GET: Gorev
        public ActionResult Index()
        {
            IEnumerable<GorevModels> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Gorevlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<GorevModels>>().Result;
            return View(listele);
        }
    }
}