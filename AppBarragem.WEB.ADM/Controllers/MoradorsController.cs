using AppBarragem.WEB.ADM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZeNerd.DAL.Context;

namespace AppBarragem.WEB.ADM.Controllers
{
    public class MoradorsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private List<TipoDomicilio> lstTipoDomicilio;
        private List<TipoEducacao> lstTipoEducacao;
        private List<TipoEspecieDomicilioOcupado> lstTipoEspecieDomicilioOcupado;
        private List<TipoEtinoRacial> lstTipoEtinoRacial;
        private List<TipoFalaLinguaIndigena> lstTipoFalaLinguaIndigena;
        private List<TipoLinguaPortuquesa> lstTipoLinguaPortuquesa;
        private List<TipoParantesco> lstTipoParantesco;
        private List<TipoPessoaIndigena> lstTipoPessoaIndigena;
        private List<TipoQuilombolas> lstTipoQuilombolas;
        private List<TipoRegistroCivil> lstTipoRegistroCivil;
        private List<TipoSexo> lstTipoSexo;

        // GET: Moradors
        public async Task<ActionResult> Index()
        {
            var TIPO_ESPECIE_DOMICILIO = from Utils.TIPO_ESPECIE_DOMICILIO e in Enum.GetValues(typeof(Utils.TIPO_ESPECIE_DOMICILIO))
                                         select new
                                         {
                                             ID = (int)e,
                                             Nome = e.ToString()
                                         };

            ViewBag.TIPO_ESPECIE_DOMICILIO = new SelectList(TIPO_ESPECIE_DOMICILIO.AsEnumerable());


            var TIPO_DOMICILIO = from Utils.TIPO_DOMICILIO e in Enum.GetValues(typeof(Utils.TIPO_DOMICILIO))
                                 select new
                                 {
                                     ID = (int)e,
                                     Nome = e.ToString()
                                 };

            ViewBag.TIPO_DOMICILIO = new SelectList(TIPO_DOMICILIO.AsEnumerable());


            var TIPO_SEXO = from Utils.TIPO_SEXO e in Enum.GetValues(typeof(Utils.TIPO_SEXO))
                            select new
                            {
                                ID = (int)e,
                                Nome = e.ToString()
                            };

            ViewBag.TIPO_SEXO = new SelectList(TIPO_SEXO.AsEnumerable());

            var TIPO_PARENTESCO = from Utils.TIPO_PARENTESCO e in Enum.GetValues(typeof(Utils.TIPO_PARENTESCO))
                                  select new
                                  {
                                      ID = (int)e,
                                      Nome = e.ToString()
                                  };

            ViewBag.TIPO_PARENTESCO = new SelectList(TIPO_PARENTESCO.AsEnumerable());


            var TIPO_ETINIA_RACIAL = from Utils.TIPO_ETINIA_RACIAL e in Enum.GetValues(typeof(Utils.TIPO_ETINIA_RACIAL))
                                     select new
                                     {
                                         ID = (int)e,
                                         Nome = e.ToString()
                                     };

            ViewBag.TIPO_ETINIA_RACIAL = new SelectList(TIPO_ETINIA_RACIAL.AsEnumerable());


            var TIPO_PESSOA_INDIGENA = from Utils.TIPO_PESSOA_INDIGENA e in Enum.GetValues(typeof(Utils.TIPO_PESSOA_INDIGENA))
                                       select new
                                       {
                                           ID = (int)e,
                                           Nome = e.ToString()
                                       };

            ViewBag.TIPO_PESSOA_INDIGENA = new SelectList(TIPO_PESSOA_INDIGENA.AsEnumerable());


            var TIPO_FALA_INDIGENA = from Utils.TIPO_FALA_INDIGENA e in Enum.GetValues(typeof(Utils.TIPO_FALA_INDIGENA))
                                     select new
                                     {
                                         ID = (int)e,
                                         Nome = e.ToString()
                                     };

            ViewBag.TIPO_FALA_INDIGENA = new SelectList(TIPO_FALA_INDIGENA.AsEnumerable());


            var TIPO_FALA_PORTUGUES = from Utils.TIPO_FALA_PORTUGUES e in Enum.GetValues(typeof(Utils.TIPO_FALA_PORTUGUES))
                                      select new
                                      {
                                          ID = (int)e,
                                          Nome = e.ToString()
                                      };

            ViewBag.TIPO_FALA_PORTUGUES = new SelectList(TIPO_FALA_PORTUGUES.AsEnumerable());

            var TIPO_QUILOMBOLAS = from Utils.TIPO_QUILOMBOLAS e in Enum.GetValues(typeof(Utils.TIPO_QUILOMBOLAS))
                                   select new
                                   {
                                       ID = (int)e,
                                       Nome = e.ToString()
                                   };

            ViewBag.TIPO_QUILOMBOLAS = new SelectList(TIPO_QUILOMBOLAS.AsEnumerable());


            var TIPO_REGISTRO_CIVIL = from Utils.TIPO_REGISTRO_CIVIL e in Enum.GetValues(typeof(Utils.TIPO_REGISTRO_CIVIL))
                                      select new
                                      {
                                          ID = (int)e,
                                          Nome = e.ToString()
                                      };

            ViewBag.TIPO_REGISTRO_CIVIL = new SelectList(TIPO_REGISTRO_CIVIL.AsEnumerable());


            var TIPO_EDUCACAO = from Utils.TIPO_EDUCACAO e in Enum.GetValues(typeof(Utils.TIPO_EDUCACAO))
                                select new
                                {
                                    ID = (int)e,
                                    Nome = e.ToString()
                                };

            ViewBag.TIPO_EDUCACAO = new SelectList(TIPO_EDUCACAO.AsEnumerable());
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

            //var TIPO_ESPECIE_DOMICILIO = from Utils.TIPO_ESPECIE_DOMICILIO e in Enum.GetValues(typeof(Utils.TIPO_ESPECIE_DOMICILIO))
            //                             select new
            //                             {
            //                                 ID = (int)e,
            //                                 Name = e.ToString()
            //                             };

            //ViewBag.TIPO_ESPECIE_DOMICILIO = new SelectList(TIPO_ESPECIE_DOMICILIO.AsEnumerable(), "ID", "Name");


            //var TIPO_DOMICILIO = from Utils.TIPO_DOMICILIO e in Enum.GetValues(typeof(Utils.TIPO_DOMICILIO))
            //                     select new
            //                     {
            //                         ID = (int)e,
            //                         Name = e.ToString()
            //                     };

            //ViewBag.TIPO_DOMICILIO = new SelectList(TIPO_DOMICILIO.AsEnumerable(), "ID", "Name");


            //var TIPO_SEXO = from Utils.TIPO_SEXO e in Enum.GetValues(typeof(Utils.TIPO_SEXO))
            //                select new
            //                {
            //                    ID = (int)e,
            //                    Name = e.ToString()
            //                };

            //ViewBag.TIPO_SEXO = new SelectList(TIPO_SEXO.AsEnumerable(), "ID", "Name");

            //var TIPO_PARENTESCO = from Utils.TIPO_PARENTESCO e in Enum.GetValues(typeof(Utils.TIPO_PARENTESCO))
            //                      select new
            //                      {
            //                          ID = (int)e,
            //                          Name = e.ToString()
            //                      };

            //ViewBag.TIPO_PARENTESCO = new SelectList(TIPO_PARENTESCO.AsEnumerable(), "ID", "Name");


            //var TIPO_ETINIA_RACIAL = from Utils.TIPO_ETINIA_RACIAL e in Enum.GetValues(typeof(Utils.TIPO_ETINIA_RACIAL))
            //                         select new
            //                         {
            //                             ID = (int)e,
            //                             Name = e.ToString()
            //                         };

            //ViewBag.TIPO_ETINIA_RACIAL = new SelectList(TIPO_ETINIA_RACIAL.AsEnumerable(), "ID", "Name");


            //var TIPO_PESSOA_INDIGENA = from Utils.TIPO_PESSOA_INDIGENA e in Enum.GetValues(typeof(Utils.TIPO_PESSOA_INDIGENA))
            //                           select new
            //                           {
            //                               ID = (int)e,
            //                               Name = e.ToString()
            //                           };

            //ViewBag.TIPO_PESSOA_INDIGENA = new SelectList(TIPO_PESSOA_INDIGENA.AsEnumerable(), "ID", "Name");


            //var TIPO_FALA_INDIGENA = from Utils.TIPO_FALA_INDIGENA e in Enum.GetValues(typeof(Utils.TIPO_FALA_INDIGENA))
            //                         select new
            //                         {
            //                             ID = (int)e,
            //                             Name = e.ToString()
            //                         };

            //ViewBag.TIPO_FALA_INDIGENA = new SelectList(TIPO_FALA_INDIGENA.AsEnumerable(), "ID", "Name");


            //var TIPO_FALA_PORTUGUES = from Utils.TIPO_FALA_PORTUGUES e in Enum.GetValues(typeof(Utils.TIPO_FALA_PORTUGUES))
            //                          select new
            //                          {
            //                              ID = (int)e,
            //                              Name = e.ToString()
            //                          };

            //ViewBag.TIPO_FALA_PORTUGUES = new SelectList(TIPO_FALA_PORTUGUES.AsEnumerable(), "ID", "Name");

            //var TIPO_QUILOMBOLAS = from Utils.TIPO_QUILOMBOLAS e in Enum.GetValues(typeof(Utils.TIPO_QUILOMBOLAS))
            //                       select new
            //                       {
            //                           ID = (int)e,
            //                           Name = e.ToString()
            //                       };

            //ViewBag.TIPO_QUILOMBOLAS = new SelectList(TIPO_QUILOMBOLAS.AsEnumerable(), "ID", "Name");


            //var TIPO_REGISTRO_CIVIL = from Utils.TIPO_REGISTRO_CIVIL e in Enum.GetValues(typeof(Utils.TIPO_REGISTRO_CIVIL))
            //                          select new
            //                          {
            //                              ID = (int)e,
            //                              Name = e.ToString()
            //                          };

            //ViewBag.TIPO_REGISTRO_CIVIL = new SelectList(TIPO_REGISTRO_CIVIL.AsEnumerable(), "ID", "Name");


            //var TIPO_EDUCACAO = from Utils.TIPO_EDUCACAO e in Enum.GetValues(typeof(Utils.TIPO_EDUCACAO))
            //                    select new
            //                    {
            //                        ID = (int)e,
            //                        Name = e.ToString()
            //                    };

            //ViewBag.TIPO_EDUCACAO = new SelectList(TIPO_EDUCACAO.AsEnumerable(), "ID", "Name");

            bindDropDownList();

            bindViewBagDropDownlist();

            return View();

        }

        private void bindDropDownList()
        {
            lstTipoDomicilio = new List<TipoDomicilio>();
            lstTipoDomicilio = db.TipoDomicilio.ToList();

            lstTipoEducacao = new List<TipoEducacao>();
            lstTipoEducacao = db.TipoEducacao.ToList();

            lstTipoEspecieDomicilioOcupado = new List<TipoEspecieDomicilioOcupado>();
            lstTipoEspecieDomicilioOcupado = db.TipoEspecieDomicilioOcupado.ToList();


            lstTipoEtinoRacial = new List<TipoEtinoRacial>();
            lstTipoEtinoRacial = db.TipoEtinoRacial.ToList();


            lstTipoFalaLinguaIndigena = new List<TipoFalaLinguaIndigena>();
            lstTipoFalaLinguaIndigena = db.TipoFalaLinguaIndigena.ToList();


            lstTipoLinguaPortuquesa = new List<TipoLinguaPortuquesa>();
            lstTipoLinguaPortuquesa = db.TipoLinguaPortuquesa.ToList();

            lstTipoParantesco = new List<TipoParantesco>();
            lstTipoParantesco = db.TipoParantesco.ToList();

            lstTipoPessoaIndigena = new List<TipoPessoaIndigena>();
            lstTipoPessoaIndigena = db.TipoPessoaIndigena.ToList();

            lstTipoQuilombolas = new List<TipoQuilombolas>();
            lstTipoQuilombolas = db.TipoQuilombolas.ToList();

            lstTipoRegistroCivil = new List<TipoRegistroCivil>();
            lstTipoRegistroCivil = db.TipoRegistroCivil.ToList();

            lstTipoSexo = new List<TipoSexo>();
            lstTipoSexo = db.TipoSexo.ToList();



        }

        private void bindViewBagDropDownlist()
        {
            ViewBag.TipoDomicilio = new SelectList
           (
               lstTipoDomicilio,
               "id",
               "nome"
           );

            ViewBag.TipoEducacao = new SelectList
      (
          lstTipoEducacao,
          "id",
          "nome"
      );

            ViewBag.TipoEspecieDomicilioOcupado = new SelectList
      (
          lstTipoEspecieDomicilioOcupado,
          "id",
          "nome"
      );

            ViewBag.TipoEtinoRacial = new SelectList
      (
          lstTipoEtinoRacial,
          "id",
          "nome"
      );

            ViewBag.TipoFalaLinguaIndigena = new SelectList
      (
          lstTipoFalaLinguaIndigena,
          "id",
          "nome"
      );

            ViewBag.TipoLinguaPortuquesa = new SelectList
      (
          lstTipoLinguaPortuquesa,
          "id",
          "nome"
      );

            ViewBag.TipoParantesco = new SelectList
      (
          lstTipoParantesco,
          "id",
          "nome"
      );

            ViewBag.TipoPessoaIndigena = new SelectList
      (
          lstTipoPessoaIndigena,
          "id",
          "nome"
      );

            ViewBag.TipoQuilombolas = new SelectList
      (
          lstTipoQuilombolas,
          "id",
          "nome"
      );

            ViewBag.TipoRegistroCivil = new SelectList
      (
          lstTipoRegistroCivil,
          "id",
          "nome"
      );

            ViewBag.TipoSexo = new SelectList
      (
          lstTipoSexo,
          "id",
          "nome"
      );




        }

        // POST: Moradors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Uf,Municipio,Distrito,Email, Telefone, Arquivo, File , Subdistrito,Setor,NumeroQuadra,NumeroFace,SeqEndereco,SeqColetivo,SeqEspecie,TipoEspecieDomicilioOcupado,TipoDomicilio,QuantidadePessoasDomicilio,TipoSexo,DataNascimento,TipoParantesco,TipoEtinoRacial,TipoPessoaIndigena,Etinia,TipoFalaLinguaIndigena,LinguaIndigenaPrimeira,LinguaIndigenaSegunda,TipoLinguaPortuquesa,TipoQuilombolas,TipoRegistroCivil,TipoEducacao,NomeComunidade,Latitude,Longitude")] MoradorAdmViewModel morador)
        {
            bindDropDownList();


            string caminhoImagem = "appBarragem" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + morador.File.FileName;

            morador.Arquivo = Utils.Constantes.URL_IMAGEM + caminhoImagem;

            Upload(morador, caminhoImagem);
            List<Morador> lstMorador = db.Morador.ToList();
            int idMorador = 0;

            if (lstMorador.Count() <= 0)
            {
                idMorador = 1;
            }
            else
            {
                idMorador = lstMorador.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            }
            if (ModelState.IsValid)
            {
                Morador objMorador = new Morador()
                {
                    Id = idMorador,
                    Arquivo = morador.Arquivo,
                    DataNascimento = morador.DataNascimento,
                    Distrito = morador.Distrito,
                    Email = morador.Email,
                    Etinia = morador.Etinia,
                    Latitude = morador.Latitude,
                    LinguaIndigenaPrimeira = morador.LinguaIndigenaPrimeira,
                    LinguaIndigenaSegunda = morador.LinguaIndigenaSegunda,
                    Longitude = morador.Longitude,
                    Municipio = morador.Municipio,
                    NomeComunidade = morador.NomeComunidade,
                    Nome = morador.Nome,
                    NumeroQuadra = morador.NumeroQuadra,
                    QuantidadePessoasDomicilio = morador.QuantidadePessoasDomicilio,
                    SeqColetivo = morador.SeqColetivo,
                    SeqEndereco = morador.SeqEndereco,
                    SeqEspecie = morador.SeqEspecie,
                    Setor = morador.Setor,
                    Subdistrito = morador.Subdistrito,
                    Telefone = morador.Telefone,
                    TipoDomicilio = morador.TipoDomicilio.Id,
                    TipoEducacao = morador.TipoEducacao.Id,
                    TipoEspecieDomicilioOcupado = morador.TipoEspecieDomicilioOcupado.Id,
                    TipoEtinoRacial = morador.TipoEtinoRacial.Id,
                    TipoFalaLinguaIndigena = morador.TipoFalaLinguaIndigena.Id,
                    TipoLinguaPortuquesa = morador.TipoLinguaPortuquesa.Id,
                    TipoParantesco = morador.TipoParantesco.Id,
                    TipoQuilombolas = morador.TipoQuilombolas.Id,
                    TipoPessoaIndigena = morador.TipoPessoaIndigena.Id,
                    TipoRegistroCivil = morador.TipoRegistroCivil.Id,
                    TipoSexo = morador.TipoSexo.Id,
                    Uf = morador.Uf,
                    NumeroFace = morador.NumeroFace




                };


                db.Morador.Add(objMorador);
                try
                {
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
            bindViewBagDropDownlist();
            return View(morador);
        }


        [HttpPost]
        private void Upload(MoradorAdmViewModel model, string caminhoImagem)
        {
            if (model.File != null)
            {


                if (model.File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(model.File.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Imagem/"), caminhoImagem);
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

        // GET: Moradors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = await db.Morador.FindAsync(id);

            MoradorAdmViewModel objMorador = new MoradorAdmViewModel()
            {
                Id = morador.Id,
                Arquivo = morador.Arquivo,
                DataNascimento = morador.DataNascimento,
                Distrito = morador.Distrito,
                Email = morador.Email,
                Etinia = morador.Etinia,
                Latitude = morador.Latitude,
                LinguaIndigenaPrimeira = morador.LinguaIndigenaPrimeira,
                LinguaIndigenaSegunda = morador.LinguaIndigenaSegunda,
                Longitude = morador.Longitude,
                Municipio = morador.Municipio,
                NomeComunidade = morador.NomeComunidade,
                Nome = morador.Nome,
                NumeroQuadra = morador.NumeroQuadra,
                QuantidadePessoasDomicilio = morador.QuantidadePessoasDomicilio,
                SeqColetivo = morador.SeqColetivo,
                SeqEndereco = morador.SeqEndereco,
                SeqEspecie = morador.SeqEspecie,
                Setor = morador.Setor,
                Subdistrito = morador.Subdistrito,
                Telefone = morador.Telefone,
                TipoDomicilioId = morador.TipoDomicilio,
                TipoEducacaoId = morador.TipoEducacao,
                TipoEspecieDomicilioOcupadoId = morador.TipoEspecieDomicilioOcupado,
                TipoEtinoRacialId = morador.TipoEtinoRacial,
                TipoFalaLinguaIndigenaId = morador.TipoFalaLinguaIndigena,
                TipoLinguaPortuquesaId = morador.TipoLinguaPortuquesa,
                TipoParantescoId = morador.TipoParantesco,
                TipoQuilombolasId = morador.TipoQuilombolas,
                TipoPessoaIndigenaId = morador.TipoPessoaIndigena,
                TipoRegistroCivilId = morador.TipoRegistroCivil,
                TipoSexoId = morador.TipoSexo,
                Uf = morador.Uf,
                NumeroFace = morador.NumeroFace



            };

            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(objMorador);
        }

        // POST: Moradors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Uf,Municipio,Distrito,Subdistrito,Setor,NumeroQuadra,NumeroFace,SeqEndereco,SeqColetivo,SeqEspecie,TipoEspecieDomicilioOcupado,TipoDomicilio,QuantidadePessoasDomicilio,TipoSexo,DataNascimento,TipoParantesco,TipoEtinoRacial,TipoPessoaIndigena,Etinia,TipoFalaLinguaIndigena,LinguaIndigenaPrimeira,LinguaIndigenaSegunda,TipoLinguaPortuquesa,TipoQuilombolas,TipoRegistroCivil,TipoEducacao,NomeComunidade,Latitude,Longitude")] MoradorAdmViewModel morador)
        {
            if (ModelState.IsValid)
            {
                Morador objMorador = new Morador()
                {
                    Id = morador.Id,
                    Arquivo = morador.Arquivo,
                    DataNascimento = morador.DataNascimento,
                    Distrito = morador.Distrito,
                    Email = morador.Email,
                    Etinia = morador.Etinia,
                    Latitude = morador.Latitude,
                    LinguaIndigenaPrimeira = morador.LinguaIndigenaPrimeira,
                    LinguaIndigenaSegunda = morador.LinguaIndigenaSegunda,
                    Longitude = morador.Longitude,
                    Municipio = morador.Municipio,
                    NomeComunidade = morador.NomeComunidade,
                    Nome = morador.Nome,
                    NumeroQuadra = morador.NumeroQuadra,
                    QuantidadePessoasDomicilio = morador.QuantidadePessoasDomicilio,
                    SeqColetivo = morador.SeqColetivo,
                    SeqEndereco = morador.SeqEndereco,
                    SeqEspecie = morador.SeqEspecie,
                    Setor = morador.Setor,
                    Subdistrito = morador.Subdistrito,
                    Telefone = morador.Telefone,
                    TipoDomicilio = morador.TipoDomicilio.Id,
                    TipoEducacao = morador.TipoEducacao.Id,
                    TipoEspecieDomicilioOcupado = morador.TipoEspecieDomicilioOcupado.Id,
                    TipoEtinoRacial = morador.TipoEtinoRacial.Id,
                    TipoFalaLinguaIndigena = morador.TipoFalaLinguaIndigena.Id,
                    TipoLinguaPortuquesa = morador.TipoLinguaPortuquesa.Id,
                    TipoParantesco = morador.TipoParantesco.Id,
                    TipoQuilombolas = morador.TipoQuilombolas.Id,
                    TipoPessoaIndigena = morador.TipoPessoaIndigena.Id,
                    TipoRegistroCivil = morador.TipoRegistroCivil.Id,
                    TipoSexo = morador.TipoSexo.Id,
                    Uf = morador.Uf,
                    NumeroFace = morador.NumeroFace,
                    TipoDomicilio_TipoDomicilio = morador.TipoDomicilio,
                    TipoEspecieDomicilioOcupado_TipoEspecieDomicilioOcupado = morador.TipoEspecieDomicilioOcupado,
                    TipoEducacao_TipoEducacao = morador.TipoEducacao,
                    TipoEtinoRacial_TipoEtinoRacial = morador.TipoEtinoRacial,
                    TipoFalaLinguaIndigena_TipoFalaLinguaIndigena = morador.TipoFalaLinguaIndigena,
                    TipoLinguaPortuquesa_TipoLinguaPortuquesa = morador.TipoLinguaPortuquesa,
                    TipoParantesco_TipoParantesco = morador.TipoParantesco,
                    TipoPessoaIndigena_TipoPessoaIndigena = morador.TipoPessoaIndigena,
                    TipoQuilombolas_TipoQuilombolas = morador.TipoQuilombolas,
                    TipoRegistroCivil_TipoRegistroCivil = morador.TipoRegistroCivil,
                    TipoSexo_TipoSexo = morador.TipoSexo



                };

                db.Morador.AddOrUpdate(objMorador);
                try
                {
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
