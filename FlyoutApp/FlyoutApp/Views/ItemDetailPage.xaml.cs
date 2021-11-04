using System.ComponentModel;
using Xamarin.Forms;
using FlyoutApp.ViewModels;

namespace FlyoutApp.Views
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
