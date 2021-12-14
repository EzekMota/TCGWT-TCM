using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TCCGWT.Models;

namespace TCCGWT.Controllers
{
    public class ComandaController : Controller
    {
        // GET: Comanda
        string baseurl = "http://20.114.208.185";
        public async Task<ActionResult> Comandas()
        {
            List<Comanda> ComandaInfo = new List<Comanda>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("api/comanda");
                if (Res.IsSuccessStatusCode)
                {
                    var ComandaRes = Res.Content.ReadAsStringAsync().Result;

                    if (ComandaRes == null)
                    {
                        throw new InvalidOperationException();
                    }
                    ComandaInfo = JsonConvert.DeserializeObject<List<Comanda>>(ComandaRes);
                }
                return View(ComandaInfo);
            }
        }
    }
}