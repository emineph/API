using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcplaza.Models;
using System.Net.Http;

namespace mvcplaza.Controllers
{
    public class HizmetlController : Controller
    {
        // GET: Hizmetl
        public ActionResult Index()
        {
            IEnumerable<HizmetModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Hizmetlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<HizmetModel>>().Result;
            return View(listele);
        }
    }
}