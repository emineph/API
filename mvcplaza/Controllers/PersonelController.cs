using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcplaza.Models;
using System.Net.Http;

namespace mvcplaza.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            IEnumerable<PersonelModels> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personellers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<PersonelModels>>().Result;
            return View(listele);
        }

        public ActionResult EY(int id = 0)
        {
            if (id==0)
            {
                return View(new PersonelModels());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personellers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<PersonelModels>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(PersonelModels personeller)
        {
            if (personeller.PersonelNo==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Personellers", personeller).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Personellers/" + personeller.PersonelNo, personeller).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Personellers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

    }
}