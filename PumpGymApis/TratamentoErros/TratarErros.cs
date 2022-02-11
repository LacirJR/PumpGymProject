using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpGymApis.TratamentoErros
{
    public class TratarErros
    {
        public void Cadastro(Entidades.Cliente cliente)
        {
            cliente.Cpf.Replace("-", "").Replace(".", "").Replace(" ", "");
            cliente.EnderecoCep.Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ", "");
           
            long i;

            if (string.IsNullOrEmpty(cliente.Cpf) || cliente.Cpf.Length != 11)
                throw new InvalidOperationException("O CPF DEVE CONTER 11 DIGITOS");

            if (long.TryParse(cliente.Cpf, out i) == false)
                throw new InvalidOperationException("DIGITE UM CPF VÁLIDO");

            if (string.IsNullOrEmpty(cliente.EnderecoCep) || cliente.EnderecoCep.Length != 8)
                throw new InvalidOperationException("O CEP DEVE CONTER 8 DIGITOS");

            if (long.TryParse(cliente.EnderecoCep, out i) == false)
                throw new InvalidOperationException("DIGITE UM CEP VÁLIDO");

            if (cliente.EnderecoCep == null)
                throw new Exception("CEP INVALIDO TENTE NOVAMENTE");

            
        }
    }
}
