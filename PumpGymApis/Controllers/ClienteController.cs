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
        public IActionResult CadastrarCliente(Entidades.Cliente cliente)
        {
            var logEntrada = new ConsumindoAPIs.ApiLog.Entidade.Erro();
            logEntrada.NomeAplicacao = "PumpGymApis";
            logEntrada.NomeMaquina = Environment.MachineName;
            logEntrada.Usuario = Environment.UserName;
            try
            {
                var senha = new RegrasDeNegocio.Criptografia.SenhaCriptografada();
               cliente.Senha = senha.HashValue(cliente.Senha);
                
                var tratamentoErros = new TratamentoErros.TratarErros();
                tratamentoErros.Cadastro(cliente);

                

                _sql.CadastrarCliente(cliente);

                return StatusCode(200);
            }
            catch(InvalidOperationException ex)
            {
                logEntrada.MensagemErro = ex.Message;
                logEntrada.RastreioErro = ex.StackTrace;
                logEntrada.DataHora = DateTime.Now;
                var request = ConsumindoAPIs.ExecutarApi.LogErro<ConsumindoAPIs.ApiLog.Entidade.Erro>("https://logaplicacao.aiur.com.br/v1/Logs", logEntrada);
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                logEntrada.MensagemErro = ex.Message;
                logEntrada.RastreioErro = ex.StackTrace;
                logEntrada.DataHora = DateTime.Now;
                var request = ConsumindoAPIs.ExecutarApi.LogErro<ConsumindoAPIs.ApiLog.Entidade.Erro>("https://logaplicacao.aiur.com.br/v1/Logs", logEntrada);
                return StatusCode(404, ex.Message);
            }
    }

        [HttpPost("v1/Login")]
        public void ValidacaoLogin(string cpf, string senha)
        {
            var criptografia = new RegrasDeNegocio.Criptografia.SenhaCriptografada();

            senha = criptografia.HashValue(senha);
        
        }

    }
}
