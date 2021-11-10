using System.Linq;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (ListViewModel)BindingContext;
            await viewModel.InitializeAsync();
        }
    }
}
