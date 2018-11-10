using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEventos.Models
{
    public class EstatisticaQntEventosTipo
    {
        public String Tipo { get; set; }
        public int Quantidade { get; set; }

        public List<EstatisticaQntEventosTipo> BuscaDados()
        {
            var stringConnexao = "Server=tcp:unimetrocamp-project.database.windows.net,1433;Initial Catalog=GestaoEvento;Persist Security Info=False;User ID=leticiaps;Password=leticia_paschoa18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var listaDados = new List<EstatisticaQntEventosTipo>();

            try
            {               
                var connection = new SqlConnection(stringConnexao);
                SqlDataReader reader;
                connection.Open();

                var cmd = new SqlCommand("BUSCA_DADOS_GRAFICO_TIPO", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var dado = new EstatisticaQntEventosTipo();
                    dado.Tipo = reader["TIPO"].ToString();
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