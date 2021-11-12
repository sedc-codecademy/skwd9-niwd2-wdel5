using System.Linq;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Interfaces;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListViewModel(Startup.ServiceProvider.GetService<IEstatesServices>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (ListViewModel)BindingContext;
            await viewModel.InitializeAsync();
        }
    }
}
