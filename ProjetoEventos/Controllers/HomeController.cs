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

                Login login = new Login();
                login.Usuario = Usuario;
                login.Senha = Senha;

                if (login.Buscar())
                {
                    Session["Usuario"] = Usuario;
                    Response.Redirect("Index");
                }
                else
                {
                    ViewBag.Mensagem = "Usuário ou senha incorretos";
                }
            }

            return View();
        }

        public ActionResult Sair()
        {
            Session.Clear();
            Response.Redirect("Index");
            return View();

        }

    }
}