using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEventos.Models
{
    public class Cliente : Pessoa
    {
        public string email { get; set; }
        public string telefone { get; set; }

        public bool ValidaCliente()
        {
            return true;
        }

        public void CadastraCliente(Cliente cliente)
        {
            var stringConnexao = "Server=tcp:unimetrocamp-project.database.windows.net,1433;Initial Catalog=GestaoEvento;Persist Security Info=False;User ID=leticiaps;Password=leticia_paschoa18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                        
            try
            {
                var connection = new SqlConnection(stringConnexao);

                connection.Open();

                //CADASTRA O CLIENTE
                var cmd = new SqlCommand("CADASTRO_I_CLIENTE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cpf ", SqlDbType.VarChar).Value = cliente.cpfPessoa;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.nomePessoa;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.email;
                cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = cliente.telefone;               

                cmd.ExecuteNonQuery();
                
                connection.Close();
               
            }
            catch (Exception ex)
            {
               
            }            
        }
    }
}