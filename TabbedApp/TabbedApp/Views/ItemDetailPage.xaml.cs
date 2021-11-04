using System.ComponentModel;
using Xamarin.Forms;
using TabbedApp.ViewModels;

namespace TabbedApp.Views
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
