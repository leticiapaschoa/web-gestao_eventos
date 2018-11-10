using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEventos.Models
{
    public class EstatisticaQntEventos
    {
        public String Mes { get; set; }
        public int Quantidade { get; set; }

        public List<EstatisticaQntEventos> BuscaDados()
        {
            var stringConnexao = "Server=tcp:unimetrocamp-project.database.windows.net,1433;Initial Catalog=GestaoEvento;Persist Security Info=False;User ID=leticiaps;Password=leticia_paschoa18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var listaDados = new List<EstatisticaQntEventos>();

            try
            {               
                var connection = new SqlConnection(stringConnexao);
                SqlDataReader reader;
                connection.Open();

                var cmd = new SqlCommand("BUSCA_DADOS_GRAFICO_MES", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var dado = new EstatisticaQntEventos();
                    dado.Mes = reader["MES"].ToString();
                    dado.Quantidade = Convert.ToInt16(reader["QUANTIDADE"]);

                    listaDados.Add(dado);
                }

                reader.Close();
                
            }
            catch (Exception ex)
            {
            }
            return listaDados;
        }
    }
}