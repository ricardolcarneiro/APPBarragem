using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mamelucos.DAL.Context;

namespace Mamelucos.WEB.ADM.Controllers
{
    public class LogEstoquesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: LogEstoques
        public async Task<ActionResult> Index()
        {
            var logEstoque = db.LogEstoque.Include(l => l.EstoqueControle).Include(l => l.Fornecedor).Include(l => l.TipoUnidade);
            return View(await logEstoque.ToListAsync());
        }

        // GET: LogEstoques/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogEstoque logEstoque = await db.LogEstoque.FindAsync(id);
            if (logEstoque == null)
            {
                return HttpNotFound();
            }
            return View(logEstoque);
        }

        // GET: LogEstoques/Create
        public ActionResult Create()
        {
            ViewBag.ControleEstoqueId = new SelectList(db.EstoqueControle, "Id", "Nome");
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome");
            ViewBag.UnidadeId = new SelectList(db.TipoUnidade, "Id", "Descricao");
            return View();
        }

        // POST: LogEstoques/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CodigoProduto,Nf,Quantidade,DataCriacao,DataAtualizacao,ValorUnidade,ValorTotal,FornecedorId,Produto,UnidadeId,DataVencimento,EstoqueAtual,EstoqueSaida,DataSaida,FlagMovimentacao,ControleEstoqueId,EstoquePerda,EstoqueAnterior,UsuarioId")] LogEstoque logEstoque)
        {
            if (ModelState.IsValid)
            {
                db.LogEstoque.Add(logEstoque);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ControleEstoqueId = new SelectList(db.EstoqueControle, "Id", "Nome", logEstoque.ControleEstoqueId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome", logEstoque.FornecedorId);
            ViewBag.UnidadeId = new SelectList(db.TipoUnidade, "Id", "Descricao", logEstoque.UnidadeId);
            return View(logEstoque);
        }

        // GET: LogEstoques/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogEstoque logEstoque = await db.LogEstoque.FindAsync(id);
            if (logEstoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.ControleEstoqueId = new SelectList(db.EstoqueControle, "Id", "Nome", logEstoque.ControleEstoqueId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome", logEstoque.FornecedorId);
            ViewBag.UnidadeId = new SelectList(db.TipoUnidade, "Id", "Descricao", logEstoque.UnidadeId);
            return View(logEstoque);
        }

        // POST: LogEstoques/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CodigoProduto,Nf,Quantidade,DataCriacao,DataAtualizacao,ValorUnidade,ValorTotal,FornecedorId,Produto,UnidadeId,DataVencimento,EstoqueAtual,EstoqueSaida,DataSaida,FlagMovimentacao,ControleEstoqueId,EstoquePerda,EstoqueAnterior,UsuarioId")] LogEstoque logEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logEstoque).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ControleEstoqueId = new SelectList(db.EstoqueControle, "Id", "Nome", logEstoque.ControleEstoqueId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome", logEstoque.FornecedorId);
            ViewBag.UnidadeId = new SelectList(db.TipoUnidade, "Id", "Descricao", logEstoque.UnidadeId);
            return View(logEstoque);
        }

        // GET: LogEstoques/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogEstoque logEstoque = await db.LogEstoque.FindAsync(id);
            if (logEstoque == null)
            {
                return HttpNotFound();
            }
            return View(logEstoque);
        }

        // POST: LogEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LogEstoque logEstoque = await db.LogEstoque.FindAsync(id);
            db.LogEstoque.Remove(logEstoque);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
