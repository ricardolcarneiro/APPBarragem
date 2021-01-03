using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBarragem.WEB.ADM.Controllers
{
    public class AlertaController : Controller
    {
        // GET: Alerta
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChamarAlerta(FormCollection formCollection)
        {
            string nome = formCollection["name"];
            string mensagem = formCollection["message"];

            AppBarragem.Services.EnviarNotificacao.ParaTodos(nome, mensagem);

            return RedirectToAction("Index");
        }
        
        // GET: Alerta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alerta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alerta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alerta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alerta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alerta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alerta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
