using System;
using System.Collections.Generic;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RealEstate.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = new DetailsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = (DetailsViewModel)BindingContext;

            var position = new Position(viewModel.Lattitude, viewModel.Longitude);

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = viewModel.EstateName,
                Address = viewModel.Address
            };

            myMap.Pins.Add(pin);

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(10)));
        }
    }
}
