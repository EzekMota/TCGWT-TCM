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
    public class ClienteController : Controller
    {
        // GET: Cliente
        string baseurl = "http://20.114.208.185";
        public async Task<ActionResult> Clientes()
        {
            List<ClienteModel> CliInfo = new List<ClienteModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("api/cliente");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    if(CliResponse == null)
                    {
                        throw new InvalidOperationException();
                    }
                    CliInfo = JsonConvert.DeserializeObject<List<ClienteModel>>(CliResponse);
                }
                return View(CliInfo);
            }
            
        }
    }
}