using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpGymApis.Entidades
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string EnderecoRua { get; set; }
        public int EnderecoNumero { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
        public string EnderecoEstadoCode { get; set; }
        public string EnderecoPais { get; set; }
        public string EnderecoCep { get; set; }


    }
}
