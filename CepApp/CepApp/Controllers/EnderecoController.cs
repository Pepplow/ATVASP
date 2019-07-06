﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CepApp.Models;
using WebService.Models;

namespace CepApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly Context _context;

        public EnderecoController(Context context)
        {
            _context = context;
        }

        //Redireciona para endereco/enderecos
        [HttpGet("Enderecos")]
        public IEnumerable<CEP> GetCEP()
        {
            return _context.CEP;
        }
        //Listar por Cep *cep deve ser escrito da seguinte forma: xxxxx-xxx*
        [HttpGet("Enderecos/{cep}")]
        public CEP Enderecos(string cep)
        {
            return _context.CEP.Where(e => e.Cep == cep).FirstOrDefault();
        }
    

    }
}