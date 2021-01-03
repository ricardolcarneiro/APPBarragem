using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeNerd.DAL.Context;

namespace AppBarragem.WEB.ADM.Models
{
    public class MoradorAdmViewModel
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Uf { get; set; }

        public string Municipio { get; set; }

        public string Distrito { get; set; }

        public string Subdistrito { get; set; }

        public string Setor { get; set; }

        public string NumeroQuadra { get; set; }

        public string NumeroFace { get; set; }

        public string SeqEndereco { get; set; }

        public string SeqColetivo { get; set; }

        public string SeqEspecie { get; set; }

        public TipoEspecieDomicilioOcupado TipoEspecieDomicilioOcupado { get; set; }
        public int? TipoEspecieDomicilioOcupadoId { get; set; }

        public TipoDomicilio TipoDomicilio { get; set; }
        public int? TipoDomicilioId { get; set; }

        public int? QuantidadePessoasDomicilio { get; set; }

        public TipoSexo TipoSexo { get; set; }
        public int? TipoSexoId { get; set; }


        public System.DateTime? DataNascimento { get; set; }
        public TipoParantesco TipoParantesco { get; set; }
        public int? TipoParantescoId { get; set; }

        public TipoEtinoRacial TipoEtinoRacial { get; set; }
        public int? TipoEtinoRacialId { get; set; }


        public TipoPessoaIndigena TipoPessoaIndigena { get; set; }
        public int? TipoPessoaIndigenaId { get; set; }

        public string Etinia { get; set; }

        public TipoFalaLinguaIndigena TipoFalaLinguaIndigena { get; set; }
        public int? TipoFalaLinguaIndigenaId { get; set; }

        public string LinguaIndigenaPrimeira { get; set; }

        public string LinguaIndigenaSegunda { get; set; }

        public TipoLinguaPortuquesa TipoLinguaPortuquesa { get; set; }
        public int? TipoLinguaPortuquesaId { get; set; }

        public TipoQuilombolas TipoQuilombolas { get; set; }
        public int? TipoQuilombolasId { get; set; }

        public TipoRegistroCivil TipoRegistroCivil { get; set; }
        public int? TipoRegistroCivilId { get; set; }


        public TipoEducacao TipoEducacao { get; set; }
        public int? TipoEducacaoId { get; set; }

        public string NomeComunidade { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Email { get; set; }

        public string Arquivo { get; set; }

        public string Telefone { get; set; }




        public HttpPostedFileBase File { get; set; }


        public MoradorAdmViewModel()
        {

            DataNascimento = DateTime.Now;

        }
    }


}

