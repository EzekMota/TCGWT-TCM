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
    public class ReservaController : Controller
    {
        // GET: Reserva
        string baseurl = "http://20.114.208.185";

        public async Task<ActionResult> Reservas()
        {
            List<ReservaModel> reservaInfo = new List<ReservaModel>();
            string id = Request.Cookies["userId"].Value.ToString();
            int currentId = int.Parse(id);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("api/reserva");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    if (CliResponse == null)
                    {
                        throw new InvalidOperationException();
                    }
                    var allBookings = JsonConvert.DeserializeObject<List<ReservaModel>>(CliResponse);
                    var bookingsFromCurrentCustomer = allBookings.Where(booking => booking.IdCli == currentId);
                    return View(bookingsFromCurrentCustomer);
                }

                ModelState.AddModelError(string.Empty, "404");
                return View();
            }
        }
    }
}