using System.ComponentModel;
using Xamarin.Forms;
using App.Barrage.ViewModels;

namespace App.Barrage.Views
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