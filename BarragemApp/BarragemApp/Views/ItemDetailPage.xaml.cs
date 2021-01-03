using System.ComponentModel;
using Xamarin.Forms;
using BarragemApp.ViewModels;

namespace BarragemApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}