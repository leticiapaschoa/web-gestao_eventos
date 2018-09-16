using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEventos.Models
{
    public class Login
    {
        public String Usuario { get; set; }

        public String Senha { get; set; }

        public bool Buscar()
        {
            bool Resultado = false;
            SqlConnection Conexao = new SqlConnection();
            //Conexao.ConnectionString = ConfigurationManager.ConnectionStrings["SENAI"].ConnectionString;

            //Conexao.Open();

            //SqlCommand Comando = new SqlCommand();
            //Comando.Connection = Conexao;

            //Comando.CommandText = "SELECT * FROM USUARIO WHERE USUARIO=@Usuario AND SENHA=@Senha";
            //Comando.Parameters.AddWithValue("@Usuario", this.Usuario);
            //Comando.Parameters.AddWithValue("@Senha", this.Senha);

            //SqlDataReader In = Comando.ExecuteReader();

            //if (In.Read())
            //{
            //    Resultado = true;
            //}            

            //Conexao.Close();

            if(Usuario.Equals("teste") && Senha.Equals("teste")){
                Resultado = true;
            }

            return Resultado;
        }
    }
}