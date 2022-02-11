using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpGymApis.ConsumindoAPIs.ApiLog.Entidade
{
    public class Erro
    { 
            public DateTime DataHora { get; set; }
            public string MensagemErro { get; set; }
            public string RastreioErro { get; set; }
            public string NomeMaquina { get; set; }
            public string NomeAplicacao { get; set; }
            public string Usuario { get; set; }

    }
}
