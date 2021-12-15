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

        public ActionResult CadastroProd()
        {
            return View();
        }

        public async Task<ActionResult> CadastroProd(ProdutoCadastro produto)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://20.114.208.185/api/produto");
                var result = await client.PostAsJsonAsync<ProdutoCadastro>("produto", produto);

                if (result.IsSuccessStatusCode)
                {
                    var ApiResponse = await result.Content.ReadAsStringAsync();

                    var res = JsonConvert.DeserializeObject<Int64>(ApiResponse);
                    if (res == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Dados inválidos");
                        return View();
                    }
                    return RedirectToAction("produto", "produto");
                }
            }

            ModelState.AddModelError(string.Empty, "Servidor off ");

            return View();
        }
    }
}