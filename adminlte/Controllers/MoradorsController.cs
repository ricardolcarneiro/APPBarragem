using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeNerd.DAL.Context;

namespace adminlte.Controllers
{
    public class MoradorsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Moradors
        public async Task<ActionResult> Index()
        {
            return View(await db.Morador.ToListAsync());
        }

        // GET: Moradors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = await db.Morador.FindAsync(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // GET: Moradors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moradors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Uf,Municipio,Distrito,Subdistrito,Setor,NumeroQuadra,NumeroFace,SeqEndereco,SeqColetivo,SeqEspecie,TipoEspecieDomicilioOcupado,TipoDomicilio,QuantidadePessoasDomicilio,TipoSexo,DataNascimento,TipoParantesco,TipoEtinoRacial,TipoPessoaIndigena,TipoEtinia,TipoFalaLinguaIndigena,LinguaIndigenaPrimeira,LinguaIndigenaSegunda,TipoLinguaPortuquesa,TipoQuilombolas,TipoRegistroCivil,TipoEducacao,NomeComunidade,Latitude,Longitude")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                db.Morador.Add(morador);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(morador);
        }

        // GET: Moradors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = await db.Morador.FindAsync(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // POST: Moradors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Uf,Municipio,Distrito,Subdistrito,Setor,NumeroQuadra,NumeroFace,SeqEndereco,SeqColetivo,SeqEspecie,TipoEspecieDomicilioOcupado,TipoDomicilio,QuantidadePessoasDomicilio,TipoSexo,DataNascimento,TipoParantesco,TipoEtinoRacial,TipoPessoaIndigena,TipoEtinia,TipoFalaLinguaIndigena,LinguaIndigenaPrimeira,LinguaIndigenaSegunda,TipoLinguaPortuquesa,TipoQuilombolas,TipoRegistroCivil,TipoEducacao,NomeComunidade,Latitude,Longitude")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(morador).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(morador);
        }

        // GET: Moradors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = await db.Morador.FindAsync(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // POST: Moradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Morador morador = await db.Morador.FindAsync(id);
            db.Morador.Remove(morador);
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
