using MySql.Data.MySqlClient;
using ProjetoEventos.Enum;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoEventos.Models
{
    public class Funcionario : Pessoa
    {
        public ETipoPerfil perfil { get; set; }

        public String Usuario { get; set; }

        public String Senha { get; set; }
        

        public bool RealizarLogin(Funcionario func)
        {
            var stringConnexao = "Server=tcp:unimetrocamp-project.database.windows.net,1433;Initial Catalog=GestaoEvento;Persist Security Info=False;User ID=leticiaps;Password=leticia_paschoa18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlDataReader reader =  null;

            bool login = false;
            try { 
                var connection = new SqlConnection(stringConnexao);
                connection.Open();

                var cmd = new SqlCommand("LOGIN_S_FUNCIONARIO", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@usuario ", SqlDbType.VarChar).Value = func.Usuario;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = func.Senha;
                reader = cmd.ExecuteReader();

                login = (reader.HasRows) ? true : false;
                connection.Close();
            }
            catch (Exception ex)
            {
                
                
            }
            
            return login;
        }

    }
}