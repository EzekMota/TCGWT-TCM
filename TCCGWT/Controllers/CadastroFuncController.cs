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
    public class CadastroFuncController : Controller
    {
        // GET: CadastroFunc
        string baseurl = "http://20.114.208.185";
        public async Task<ActionResult> Funcionarios()
        {
            List<FuncModel> FuncInfo = new List<FuncModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("api/Funcionario");
                if (Res.IsSuccessStatusCode)
                {
                    var FuncResponse = Res.Content.ReadAsStringAsync().Result;

                    if (FuncResponse == null)
                    {
                        throw new InvalidOperationException();
                    }
                    FuncInfo = JsonConvert.DeserializeObject<List<FuncModel>>(FuncResponse);
                }
                return View(FuncInfo);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://20.114.208.185/api/");
                var deletetask = client.DeleteAsync("funcionario/" + id.ToString());
                deletetask.Wait();

                var result = deletetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Funcionarios");
                }

            }

            return RedirectToAction("Funcionarios");
        }
    

        public ActionResult EditFunc(int id)
        {
            FuncModel func = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://20.114.208.185/api/");

                var responsetask = client.GetAsync("funcionario/" + id.ToString());
                responsetask.Wait();

                var result = responsetask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FuncModel>();
                    readTask.Wait();

                    func = readTask.Result;
                }

            }

            return View(func);
        }


        [HttpPost]
        public ActionResult EditFunc(FuncModel funcionario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://20.114.208.185/api/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<FuncModel>("funcionario", funcionario);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Funcionarios");
                }
            }
            return View(funcionario);
        }

        

        public ActionResult CadastroFunc()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CadastroFunc(FuncCadastroModel funcionario)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://20.114.208.185/api/funcionario");
                var result = await client.PostAsJsonAsync<FuncCadastroModel>("funcionario", funcionario);

                if (result.IsSuccessStatusCode)
                {
                    var ApiResponse = await result.Content.ReadAsStringAsync();

                    var res = JsonConvert.DeserializeObject<Int64>(ApiResponse);
                    if (res == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Dados inválidos");
                        return View();
                    }
                    return RedirectToAction("Funcionarios", "CadastroFunc");
                }
            }

            ModelState.AddModelError(string.Empty, "Servidor off ");

            return View();
        }
    }
}
