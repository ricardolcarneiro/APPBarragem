


using AppBarragem.Services;
using BarragemApp.App.ViewModels;
using Jarvis.Utils;
using Jarvis.Utils.Extensions;
using System;
using System.Windows.Forms;

namespace BarragemApp.Services.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await AppBarragem.Services.EnviarNotificacao.ParaUm(textBoxTitulo.Text, textBoxMensagem.Text, textBoxID.Text);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await AppBarragem.Services.EnviarNotificacao.ParaTodos(textBoxTitulo.Text, textBoxMensagem.Text);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var motoboyPlayerId = "8b8cff9e-c0e7-41fd-85e9-441beb6ddecb";

            await AppBarragem.Services.EnviarNotificacao.ParaUm("Nova corrida", "Nova corrida solicitada", motoboyPlayerId);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var loc = new AppBarragem.Services.LocalizacaoFirebase()
            {
                Id = 31,
                Nome = "TESTE",
                Lat = -12.953602,
                Lng = -38.444921,
                DataAtualizacao = DateTime.Now.ToDateTime()
            };

            await AppBarragem.Services.FirebaseService.EnviarLocalizacao(loc);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var list = await AppBarragem.Services.FirebaseService.BuscarLocalizacao();

            ;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var motoboy = await FirebaseService.BuscarMaisProximo(-12.9367, -38.3608);

            ;
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var id = 1;
            await AppBarragem.Services.FirebaseService.DeletarUm(id);
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            await FirebaseService.DeletarTodos();
        }
    }
}