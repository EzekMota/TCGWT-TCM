using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCGWT.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace TCCGWT.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        string baseurl = "http://20.114.208.185";
        public async Task<ActionResult> Carrinho()
        {
            List<carrinhoModel> CarInfo = new List<carrinhoModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("api/carrinho");
                if (Res.IsSuccessStatusCode)
                {
                    var CarResponse = Res.Content.ReadAsStringAsync().Result;

                    if (CarResponse == null)
                    {
                        throw new InvalidOperationException();
                    }
                    CarInfo = JsonConvert.DeserializeObject<List<carrinhoModel>>(CarResponse);
                }
                return View(CarInfo);
            }

        }
    }
}
