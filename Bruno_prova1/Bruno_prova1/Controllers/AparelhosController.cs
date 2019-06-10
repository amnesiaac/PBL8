using Bruno_prova1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bruno_prova1.Controllers
{

    public class AparelhosController : Controller
    {
        private Bruno_prova1Context db = new Bruno_prova1Context();
        // GET: Aparelhos
        string uri = "http://localhost:63405/api/Aparelhos";
        public async Task<ActionResult> Index()
        {
            List<Aparelho> Aparelhos;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var Json = await response.Content.ReadAsStringAsync();
                        Aparelhos = JsonConvert.DeserializeObject<Aparelho[]>(Json).ToList();
                        foreach (Aparelho aparelho in Aparelhos)
                        {
                            string comp = aparelho.Nome;

                            var x = db.Aparelhoes.Where(a => a.Nome.Contains(comp)).FirstOrDefault();

                            
                                if (x == null)
                                {

                                    db.Aparelhoes.Add(aparelho);
                                    db.SaveChanges();
                                }

                            
                            
                        }
                        return View(Aparelhos);
                    }
                }
                return null;
            }
        }
    }
}