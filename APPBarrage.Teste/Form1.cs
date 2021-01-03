using AppBarragem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPBarrage.Teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnMensagem_ClickAsync(object sender, EventArgs e)
        {
            await EnviarNotificacao.ParaTodos(txtTitulo.Text, txtMensagem.Text);
        }
    }
}
