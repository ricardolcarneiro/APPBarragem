using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class RelatorioEstoquePeriodoViewModel
    {
        public int Id { get; set; }
        public List<EstoqueControleViewModel> lstControleEstoqueGenero { get; set; }
        public EstoqueControleViewModel controleEstoqueGenero { get; set; }
        private List<RelatorioEstoquePeriodoViewModel> lstRelatorioEstoquePeriodoViewModel;
        public int? controleEstoqueGeneroId { get; set; }

        public string codigoProduto { get; set; }

        public string descricao { get; set; }

        public string unidadeMedida { get; set; }

        public string totalNfEntrada { get; set; }

        public string saldoEstoqueEntrada { get; set; }

        public string saldoEstoqueSaida { get; set; }

        public string perdaSaida { get; set; }

        public string totalSaida { get; set; }

        public string saldoFinal { get; set; }

        public string dataInicio { get; set; }

        public string dataFinal { get; set; }

        public string dataCriacao { get; set; }
        public List<RelatorioEstoquePeriodoViewModel> LstRelatorioEstoquePeriodoViewModel { get => lstRelatorioEstoquePeriodoViewModel; set => lstRelatorioEstoquePeriodoViewModel = value; }

        public RelatorioEstoquePeriodoViewModel()
        {
            LstRelatorioEstoquePeriodoViewModel = new List<RelatorioEstoquePeriodoViewModel>();
            lstControleEstoqueGenero = new List<EstoqueControleViewModel>();
            controleEstoqueGenero = new EstoqueControleViewModel();
        }


        public class EstoqueControleViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }

        }
    }
}