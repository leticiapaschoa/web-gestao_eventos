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
        public List<string> Servicos { get; set; }


        public bool CadastraEvento(Evento evento)
        {
            var stringConnexao = "Server=tcp:unimetrocamp-project.database.windows.net,1433;Initial Catalog=GestaoEvento;Persist Security Info=False;User ID=leticiaps;Password=leticia_paschoa18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            bool eventoCadastrado = false;
            try
            {
                var connection = new SqlConnection(stringConnexao);
                
                connection.Open();

                //CADASTRA O EVENTO
                var cmd = new SqlCommand("CADASTRO_I_EVENTO", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tipo_evento ", SqlDbType.VarChar).Value = evento.TipoEvento;
                cmd.Parameters.Add("@data_evento", SqlDbType.DateTime).Value = evento.DataEvento;
                cmd.Parameters.Add("@cep_evento", SqlDbType.VarChar).Value = evento.CEP;
                cmd.Parameters.Add("@qnt_pessoas_evento", SqlDbType.Int).Value = evento.QntPessoas;
                cmd.Parameters.Add("@cpf_cliente", SqlDbType.VarChar).Value = evento.CPFCliente;

               cmd.ExecuteNonQuery();

                //CADASTRA OS SERVIÇOS
                cmd = new SqlCommand("CADASTRO_I_EVENTO_SERVICO", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in evento.Servicos)
                {
                    cmd.Parameters.Add("@desc_servico", SqlDbType.VarChar).Value = item;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                
                connection.Close();
                eventoCadastrado = true;
            }
            catch (Exception ex)
            {
                eventoCadastrado = false;
            }

            return eventoCadastrado;
        }

        public String ValidaEvento(Evento evento)
        {
            String validacao = string.Empty;

            if (evento.DataEvento <= DateTime.Now)
                return "Data do evento deve ser superior a data de hoje.";

            if (!evento.Servicos.Any())
                return "Necessário contratar ao menos um serviço";

            if (evento.QntPessoas <= 0)
                return "Necessário ter ao menos uma pessoa no evento";

            return validacao;
        }
    }

    
}