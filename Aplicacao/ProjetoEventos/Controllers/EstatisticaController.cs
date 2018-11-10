using ProjetoEventos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEventos.Controllers
{
    public class EstatisticaController : Controller
    {
        // GET: Financeiro
        public ActionResult Graficos()
        {
            return View();
        }

        [HttpPost]
        public JsonResult NovoGraficoEventosMes()
        {
            List<object> iDados = new List<object>();
            //Criando dados de exemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("Mês", System.Type.GetType("System.String"));
            dt.Columns.Add("Quantidade", System.Type.GetType("System.Int32"));
            DataRow dr = dt.NewRow();

            var estatistica = new EstatisticaQntEventos();
            List<EstatisticaQntEventos> ListaQuantidade = estatistica.BuscaDados();

            foreach (var item in ListaQuantidade)
            {
                dr = dt.NewRow();
                dr["Mês"] = item.Mes;
                dr["Quantidade"] = item.Quantidade;
                dt.Rows.Add(dr);

            }
            
            //Percorrendo e extraindo cada DataColumn para List<Object>
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iDados.Add(x);
            }
            //Dados retornados no formato JSON
            return Json(iDados, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult NovoGraficoEventosTipo()
        {
            List<object> iDados = new List<object>();
            //Criando dados de exemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo", System.Type.GetType("System.String"));
            dt.Columns.Add("Quantidade", System.Type.GetType("System.Int32"));
            DataRow dr = dt.NewRow();

            var estatistica = new EstatisticaQntEventosTipo();
            List<EstatisticaQntEventosTipo> ListaQuantidade = estatistica.BuscaDados();

            foreach (var item in ListaQuantidade)
            {
                dr = dt.NewRow();
                dr["Tipo"] = item.Tipo;
                dr["Quantidade"] = item.Quantidade;
                dt.Rows.Add(dr);

            }

            //Percorrendo e extraindo cada DataColumn para List<Object>
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iDados.Add(x);
            }
            //Dados retornados no formato JSON
            return Json(iDados, JsonRequestBehavior.AllowGet);
        }
    }
}