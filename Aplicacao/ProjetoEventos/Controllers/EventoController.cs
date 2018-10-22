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
                string servico = Request.Form["servicos"];
                List<string> servicos = new List<string>();
                String cepEvento = Request.Form["cep"].ToString();
                String cpfEvento = Request.Form["cpf"];

                if (!string.IsNullOrEmpty(servico))
                {
                    servicos = servico.Split(',').ToList();
                }
                               
                Evento evento = new Evento();
                evento.TipoEvento = tipoEvento;
                evento.DataEvento = dataEvento;
                evento.CEP = cepEvento;
                evento.QntPessoas = qtdConvidados;
                evento.CPFCliente = cpfEvento;
                evento.Servicos = servicos;

                string validaEvento = evento.ValidaEvento(evento);
                                
                //CADASTRA EVENTO
                if (string.IsNullOrEmpty(validaEvento))
                {
                    //CALCULA EVENTO
                    var valorCalculado = evento.CalculoEvento(servicos, qtdConvidados);
                    evento.orcamento = valorCalculado;

                    if (evento.CadastraEvento(evento))
                    {
                        ViewBag.MensagemSucesso = string.Format("Evento Cadastrado com sucesso. Orçamento final: R${0}", valorCalculado);
                    }
                    else
                    {
                        ViewBag.MensagemErro = string.Format("Erro não mapeado ao cadastrar o evento. Consulte o TI.");
                    }
                }
                else
                {
                    ViewBag.MensagemErro = string.Format("Erro ao cadastrar evento: {0}", validaEvento);
                }
            }

            return View();
        }
    }
}