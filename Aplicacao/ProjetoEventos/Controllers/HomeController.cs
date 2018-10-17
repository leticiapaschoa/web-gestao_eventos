using ProjetoEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEventos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
            {
                ViewBag.Usuario = Session["Usuario"].ToString();
            }

            if (Request.HttpMethod == "POST")
            {
                String Usuario = Request.Form["usuario"].ToString();
                String Senha = Request.Form["senha"].ToString();

                Funcionario funcionario = new Funcionario();
                funcionario.Usuario = Usuario;
                funcionario.Senha = Senha;

                if (funcionario.RealizarLogin(funcionario))
                {
                    Session["Usuario"] = Usuario;
                    Response.Redirect("Index");
                    ViewBag.Usuario = Usuario;
                }
                else
                {
                    ViewBag.Mensagem = "Usuário ou senha incorretos";
                }
            }

            return View();
        }       

    }
}