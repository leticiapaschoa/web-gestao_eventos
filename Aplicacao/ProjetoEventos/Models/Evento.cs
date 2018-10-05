using ProjetoEventos.Enum;
using System;
using System.Collections.Generic;
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
    }
}