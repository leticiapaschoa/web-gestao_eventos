using ProjetoEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEventos.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult CadastrarCliente()
        {
            if (Request.HttpMethod == "POST")
            {                
                string nomeCliente = Request.Form["nomeCliente"].ToString();
                string cpfCliente = Request.Form["cpfCliente"].ToString();
                string emailCliente = Request.Form["emailCliente"].ToString();
                string telCliente = Request.Form["telCliente"].ToString();

                Cliente cliente = new Cliente();
                cliente.nomePessoa = nomeCliente;
                cliente.cpfPessoa = cpfCliente;
                cliente.email = emailCliente;
                cliente.telefone = telCliente;

                if (cliente.ValidaCliente())
                {
                    cliente.CadastraCliente(cliente);
                    ViewBag.Mensagem = "Cliente cadastrado com sucesso";
                }
                else
                {
                    ViewBag.Mensagem = string.Format("Erro não mapeado ao cadastrar o evento. Consulte o TI.");
                }
            }
                return View();
        }
    }
}