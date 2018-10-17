using ProjetoEventos.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEventos.Models
{
    public class Evento
    {
        public int CodigoEvento { get; set; }
        public String CPFCliente { get; set; }
        public ETiposEvento TipoEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public String CEP { get; set; }
        public int QntPessoas { get; set; }
        public List<EServicos> Servicos { get; set; }


        public void CadastraEvento(Evento evento)
        {
            var stringConnexao = "Server=tcp:unimetrocamp-project.database.windows.net,1433;Initial Catalog=GestaoEvento;Persist Security Info=False;User ID=leticiaps;Password=leticia_paschoa18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlDataReader reader = null;

            bool login = false;
            try
            {
                var connection = new SqlConnection(stringConnexao);
                connection.Open();

                var cmd = new SqlCommand("CADASTRO_I_EVENTO", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tipo_evento ", SqlDbType.VarChar).Value = evento.TipoEvento;
                cmd.Parameters.Add("@data_evento", SqlDbType.DateTime).Value = evento.DataEvento;
                cmd.Parameters.Add("@cep_evento", SqlDbType.VarChar).Value = evento.CEP;
                cmd.Parameters.Add("@qnt_pessoas_evento", SqlDbType.Int).Value = evento.QntPessoas;
                cmd.Parameters.Add("@cpf_cliente", SqlDbType.VarChar).Value = evento.CPFCliente;

                reader = cmd.ExecuteReader();

                login = (reader.HasRows) ? true : false;
                connection.Close();
            }
            catch (Exception ex)
            {


            }

        }

        public String ValidaEvento(Evento evento)
        {
            String validacao = string.Empty;
            

            return validacao;
        }
    }

    
}