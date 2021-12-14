using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TCCGWT.Models.formsModels;
using TCCGWT.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TCCGWT.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        
       
        [HttpPost]
        public async Task<ActionResult> Login(loginModel login)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://20.114.208.185/api/cliente/login");

                var result = await client.PostAsJsonAsync<loginModel>("login", login);

                if (result.IsSuccessStatusCode)
                {
                    var ApiResponse = await result.Content.ReadAsStringAsync();
                    
                    var res = JsonConvert.DeserializeObject<ClienteModel>(ApiResponse);
                    if (res.IdCli == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                        return View();
                    }
                    Response.Cookies["userName"].Value = res.NomeCli.ToString();
                    Response.Cookies["userId"].Value = res.IdCli.ToString();

                    return RedirectToAction("IndexLogadoCli", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Servidor off ");

            return View();
        }
    }
}