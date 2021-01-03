using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBarragem.Infra.Rest;
using AppBarragem.VO;
using BarragemApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BarragemApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private List<Usuario> lstUsuario;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            lstUsuario = new List<Usuario>();
           var  teste = new RestUsuario().RestGet();

            if (lstUsuario != null)
            {
                if (lstUsuario.Where(i => i.Email == Email.Text && i.Senha == Password.Text).Count() > 0)
                {
                    Navigation.PushModalAsync(new NavigationPage(new MapaPage()));
                }
                else
                {
                    DisplayAlert("Autenticação", "Usuário ou senha inválidos", "Sair");
                }

            }
        }
    }
}