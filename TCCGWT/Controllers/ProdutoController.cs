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
    public class ProdutoController : Controller
    {
        // GET: Produto
        string baseurl = "http://20.114.208.185";
        public async Task<ActionResult> Produto()
        {
            List<Produto> ProdInfo = new List<Produto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("api/produto");
                if (Res.IsSuccessStatusCode)
                {
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    if (ProdResponse == null)
                    {
                        throw new InvalidOperationException();
                    }
                    ProdInfo = JsonConvert.DeserializeObject<List<Produto>>(ProdResponse);
                }
                return View(ProdInfo);
            }
        }
    }
}