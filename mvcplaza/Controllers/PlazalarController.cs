using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvcplaza.Models;

namespace mvcplaza.Models
{
    public class PlazalarController : Controller
    {
        // GET: Plazalar
        public ActionResult Index()
        {
                IEnumerable<Plazalar> listele;
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Plazalars").Result;
                listele = response.Content.ReadAsAsync<IEnumerable<Plazalar>>().Result;
                return View(listele);
           
        }

        public ActionResult EY(int id = 0)
        {
            if (id==0)
            {
                return View(new Plazalar());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Plazalars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Plazalar>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(Plazalar plazas)
        {
            if (plazas.PlazaNo==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Plazalars", plazas).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Plazalars/" + plazas.PlazaNo, plazas).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Plazalars/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}