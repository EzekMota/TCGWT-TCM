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
    public class LoginFuncController : Controller
    {
        // GET: LoginFunc
        public ActionResult LoginFunc()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginFunc(LoginFuncModel login)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://20.114.208.185/api/funcionario/login");

                var result = await client.PostAsJsonAsync<LoginFuncModel>("login", login);

                if (result.IsSuccessStatusCode)
                {
                    var ApiResponse = await result.Content.ReadAsStringAsync();

                    var res = JsonConvert.DeserializeObject<FuncModel>(ApiResponse);
                    if (res.IdFunc == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                        return View();
                    }
                    Response.Cookies["FuncName"].Value = res.NomeFunc.ToString();
                    Response.Cookies["FuncId"].Value = res.IdFunc.ToString();

                    if(res.IdFunc == 1)
                    {
                        return RedirectToAction("IndexLogadoMan", "Home");
                    }
                    return RedirectToAction("IndexLogadoFunc", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Servidor off ");

            return View();

        }
    }
}