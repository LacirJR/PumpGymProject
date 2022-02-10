using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpGymApis.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Conexao.Sql _sql;

        public ClienteController()
        {
            _sql = new Conexao.Sql();
        }

        [HttpPost("v1/CadastrarCliente")]
        public void CadastrarCliente(Entidades.Cliente cliente)
        {
            _sql.CadastrarCliente(cliente);
        }

    }
}
