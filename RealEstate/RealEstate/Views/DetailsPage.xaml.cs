using System;
using System.Collections.Generic;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Views
{
    public partial class DetailsPage : ContentPage
    {
        private DetailsViewModel _viewModel;

        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = new DetailsViewModel(Startup.ServiceProvider.GetService<IEstatesServices>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel = (DetailsViewModel)BindingContext;
            _viewModel.InitializationFinished += InitializationFinished;
        }

        private void InitializationFinished()
        {
            var position = new Position(_viewModel.Lattitude, _viewModel.Longitude);

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = _viewModel.EstateName,
                Address = _viewModel.Address
            };

            myMap.Pins.Add(pin);

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(10)));
        }
    }
}
