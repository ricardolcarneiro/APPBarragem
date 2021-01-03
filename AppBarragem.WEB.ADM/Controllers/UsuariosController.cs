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
using System.IO;
using AppBarragem.Utils;
using AppBarragem.WEB.ADM.Filters;
using System.Data.Entity.Migrations;
using AppBarragem.WEB.ADM.Models;
using System.Data.Entity.Validation;

namespace  AppBarragem.WEB.ADM.Controllers
{
    [WebAuthorize(TipoUsuario.Admin, TipoUsuario.SuperAdmin)]
    public class UsuariosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private Usuario objUsuario;
        private UsuarioAdmViewModel objUsuarioAdmViewModel;

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            var enumData = from Utils.TipoUsuario e in Enum.GetValues(typeof(Utils.TipoUsuario))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };

            ViewBag.TipoUsuario = new SelectList(enumData.Where(i => i.ID != (int)Utils.TipoUsuario.Entregador), "ID", "Name");
            return View(await db.Usuario.Where(i => i.TipoUsuario != (int)Utils.TipoUsuario.Entregador).ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var enumData = from Utils.TipoUsuario e in Enum.GetValues(typeof(Utils.TipoUsuario))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };

            ViewBag.TipoUsuario = new SelectList(enumData.Where(i => i.ID != (int)Utils.TipoUsuario.Entregador), "ID", "Name");


            objUsuarioAdmViewModel = new UsuarioAdmViewModel();

            objUsuarioAdmViewModel.DataCriacao = DateTime.Now;
            return View(objUsuarioAdmViewModel);
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Login,Senha,TipoUsuario,Ativo,DataCriacao,File,Foto")] UsuarioAdmViewModel Usuario)
        {
            //List<Usuario> lstEntidade = db.Usuario.ToList();
            //int idEntidade = 0;

            //if (lstEntidade.Count() <= 0)
            //{
            //    idEntidade = 1;
            //}
            //else
            //{
            //    idEntidade = lstEntidade.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            //}

            //Usuario.Id = idEntidade;

            if (ModelState.IsValid)
            {
                var usuario = new Usuario();
                string caminhoImagem = "imgBarrage" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Usuario.File.FileName;

                usuario.Foto = Constantes.URL_IMAGEM + caminhoImagem;


                Upload(Usuario , caminhoImagem);
         

                //usuario.FlagAtivo = Usuario.Ativo;
                //praca.Categoria = Praca.Categoria;
                //usuario.DataAtualizacao = Usuario.DataAtualizacao;
                //usuario.DataCriacao = Usuario.DataCriacao;
                usuario.Email = Usuario.Email;
                usuario.Login = Usuario.Login;
                //usuario.Id = Usuario.Id;
                usuario.TipoUsuario = Usuario.TipoUsuario;
                usuario.Senha = Utils.Constantes.SHA1Encode(Usuario.Senha);
                usuario.Nome = Usuario.Nome;
                usuario.StatusCadastro = 0;
                usuario.Ativo = true;
                usuario.DataCriacao = DateTime.Now;

          
                try
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(Usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            var enumData = from Utils.TipoUsuario e in Enum.GetValues(typeof(Utils.TipoUsuario))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };

            ViewBag.TipoUsuario = new SelectList(enumData.Where(i => i.ID != (int)Utils.TipoUsuario.Entregador), "ID", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario Usuario = await db.Usuario.FindAsync(id);

            var usuario = new UsuarioAdmViewModel();

            //usuario.Ativo = Usuario.Ativo;
            //praca.Categoria = Praca.Categoria;
            usuario.DataAtualizacao = Usuario.DataAtualizacao;
            usuario.DataCriacao = Usuario.DataCriacao;
            usuario.Email = Usuario.Email;
            usuario.Login = Usuario.Login;
            usuario.Senha = string.Empty;
            usuario.Id = Usuario.Id;
            usuario.Nome = Usuario.Nome;
            usuario.TipoUsuario = Usuario.TipoUsuario;
            usuario.Foto = Usuario.Foto;

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Login,Senha,TipoUsuario,Ativo,DataCriacao,File,Foto")] UsuarioAdmViewModel Usuario)
        {
            var usuario = new Usuario();
   
          
            if (Usuario.File != null)
            {
                string caminhoImagem = "imgBarrage" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Usuario.File.FileName;

                usuario.Foto = Constantes.URL_IMAGEM + caminhoImagem;
                Upload(Usuario, caminhoImagem);

            }
            else
            {
                usuario.Foto = Usuario.Foto;
            }

            if (ModelState.IsValid)
            {
                

                usuario.Ativo = Usuario.Ativo;
                //praca.Categoria = Praca.Categoria;
                usuario.DataAtualizacao = Usuario.DataAtualizacao;
                usuario.DataCriacao = Usuario.DataCriacao;
                usuario.Email = Usuario.Email;
                usuario.Senha = Utils.Constantes.SHA1Encode(Usuario.Senha);
                usuario.Id = Usuario.Id;
                usuario.Nome = Usuario.Nome;
                usuario.Login = Usuario.Login;
                usuario.TipoUsuario = Usuario.TipoUsuario;



                db.Usuario.AddOrUpdate(usuario);
                db.SaveChanges();
                    return RedirectToAction("Index");
            }
            return View(usuario);
        }
        [HttpPost]
        public void Upload(UsuarioAdmViewModel model, string nomeArquivo)
        {

            if (model.File != null)
            {


                if (model.File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.File.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Imagem/"), nomeArquivo);
                if (Directory.Exists(Server.MapPath("~/Content/Imagem/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Imagem/"));
                }

                // extract only the fielname

                // store the file inside ~/App_Data/uploads folder
      
                model.File.SaveAs(path);
                
            }

            }
        }
        public void DeleteArquivo(string arquivo)
        {

            var path = Path.Combine(Server.MapPath("~/Content/Imagem/"), arquivo.Replace(Constantes.URL_IMAGEM, ""));
            System.IO.File.Delete(path);

            // extract only the fielname

            // store the file inside ~/App_Data/uploads folder



        }
        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();
            DeleteArquivo(usuario.Foto);
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
