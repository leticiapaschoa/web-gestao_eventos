using ProjetoEventos.Enum;
using ProjetoEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                int qtdConvidados =  Convert.ToUInt16(Request.Form["qntConvidados"]);
                List<string> servicos = Request.Form["servicos"].Split(',').ToList();
                String cepEvento = Request.Form["cep"].ToString();
                String cpfEvento = Request.Form["cpf"];             
                               
                Evento evento = new Evento();
                evento.TipoEvento = tipoEvento;
                evento.DataEvento = dataEvento;
                evento.CEP = cepEvento;
                evento.QntPessoas = qtdConvidados;
                evento.CPFCliente = cpfEvento;
                evento.Servicos = servicos;

                string validaEvento = evento.ValidaEvento(evento);

                if (string.IsNullOrEmpty(validaEvento))
                {
                    if (evento.CadastraEvento(evento))
                    {
                        ViewBag.Mensagem = "Evento Cadastrado com sucesso";
                    }
                    else
                    {
                        ViewBag.Mensagem = string.Format("Erro não mapeado ao cadastrar o evento. Consulte o TI.");
                    }
                }
                else
                {
                    ViewBag.Mensagem = string.Format("Erro ao cadastrar evento: {0}", validaEvento);
                }
            }

            return View();
        }
    }
}