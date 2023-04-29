using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcplaza.Models;
using System.Net.Http;

namespace mvcplaza.Controllers
{
    public class BlokController : Controller
    {
        // GET: Blok
        public ActionResult Index()
        {
            IEnumerable<BlokModels> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Bloklars").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<BlokModels>>().Result;
            return View(listele);
        }

        public ActionResult EY(int id = 0)
        {
            if (id==0)
            {
                return View(new BlokModels());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Bloklars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<BlokModels>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(BlokModels bloklarss)
        {
            if (bloklarss.BlokNo==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Bloklars", bloklarss).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("BLoklars/" + bloklarss.BlokNo, bloklarss).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.webapiclient.DeleteAsync("Bloklars/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}