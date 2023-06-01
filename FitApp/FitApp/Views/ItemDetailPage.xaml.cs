using FitApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FitApp.Views
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