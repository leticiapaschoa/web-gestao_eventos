using ProjetoEventos.Enum;
using ProjetoEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEventos.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult NovoEvento()
        {
            if (Request.HttpMethod == "POST")
            {
                ETiposEvento tipoEvento = (ETiposEvento)Convert.ToInt16(Request.Form["tipoEvento"]);
                DateTime dataEvento = Convert.ToDateTime(Request.Form["dataEvento"]);
                String cepEvento = Request.Form["cep"].ToString();
                int qtdConvidados =  Convert.ToUInt16(Request.Form["qnt"]);
                String cpfEvento = Request.Form["cpf"];

                Evento evento = new Evento();
                evento.TipoEvento = tipoEvento;
                evento.DataEvento = dataEvento;
                evento.CEP = cepEvento;
                evento.QntPessoas = qtdConvidados;
                evento.CPFCliente = cpfEvento;
                

                if (string.IsNullOrEmpty(evento.ValidaEvento(evento)))
                {
                    evento.CadastraEvento(evento);
                    ViewBag.Mensagem = "Evento Cadastrado com sucesso";                    
                }
                else
                {
                    ViewBag.Mensagem = "Erro ao cadastrar evento";
                }
            }

            return View();
        }
    }
}