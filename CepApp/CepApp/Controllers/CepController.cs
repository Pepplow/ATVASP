// André Cantarin do Rosário, Anderson Dos Santos Sanji, Giovani Augusto dos Santos Pepplow, Leonardo Cordeiro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CepApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebService.Models;

namespace CepApp.Controllers
{
    public class CepController : Controller
    {
        private readonly Context _context;
        public CepController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.CEP.ToList());
        }

        public IActionResult ConsultarCep(int? cepNumero)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/"+cepNumero+"/json/");
            CEP cep = JsonConvert.DeserializeObject<CEP>(json);
            _context.Add(cep);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}