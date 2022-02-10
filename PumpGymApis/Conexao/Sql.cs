using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PumpGymApis.Conexao
{
    public class Sql
    {
        private readonly SqlConnection _sql;

        public Sql()
        {
            var conexao = File.ReadAllText(@"C:\Users\Nagib\Desktop\Exercicios\PumpGym\Conexao.txt");
            _sql = new SqlConnection(conexao);
        }

        public void CadastrarCliente(Entidades.Cliente cliente)
        {
            try
            {
                _sql.Open();
                string query = "INSERT INTO Clientes (Cpf," +
                                                    " Senha," +
                                                    " NomeCompleto," +
                                                    " Email," +
                                                    " EnderecoRua," +
                                                    " EnderecoNumero," +
                                                    " EnderecoBairro," +
                                                    " EnderecoCidade," +
                                                    " EnderecoEstado," +
                                                    " EnderecoEstadoCode," +
                                                    " EnderecoPais," +
                                                    " EnderecoCep) " +

                                       "VALUES (@Cpf," +
                                                    " @Senha," +
                                                    " @NomeCompleto," +
                                                    " @Email," +
                                                    " @EnderecoRua," +
                                                    " @EnderecoNumero," +
                                                    " @EnderecoBairro," +
                                                    " @EnderecoCidade," +
                                                    " @EnderecoEstado," +
                                                    " @EnderecoEstadoCode," +
                                                    " @EnderecoPais," +
                                                    " @EnderecoCep);";

                using (SqlCommand cmd = new SqlCommand(query, _sql))
                {
                    cmd.Parameters.AddWithValue("Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("Senha", cliente.Senha);
                    cmd.Parameters.AddWithValue("NomeCompleto", cliente.NomeCompleto);
                    cmd.Parameters.AddWithValue("Email", cliente.Email);
                    cmd.Parameters.AddWithValue("EnderecoRua", cliente.EnderecoRua);
                    cmd.Parameters.AddWithValue("EnderecoNumero", cliente.EnderecoNumero);
                    cmd.Parameters.AddWithValue("EnderecoBairro", cliente.EnderecoBairro);
                    cmd.Parameters.AddWithValue("EnderecoCidade", cliente.EnderecoCidade);
                    cmd.Parameters.AddWithValue("EnderecoEstado", cliente.EnderecoEstado);
                    cmd.Parameters.AddWithValue("EnderecoEstadoCode", cliente.EnderecoEstadoCode);
                    cmd.Parameters.AddWithValue("EnderecoPais", cliente.EnderecoPais);
                    cmd.Parameters.AddWithValue("EnderecoCep", cliente.EnderecoCep);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _sql.Close();
            }
        }
    }
}
