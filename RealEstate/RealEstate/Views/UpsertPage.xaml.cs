using System;
using System.Collections.Generic;
using RealEstate.Interfaces;
using RealEstate.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Views
{
    public partial class UpsertPage : ContentPage
    {
        public UpsertPage()
        {
            InitializeComponent();
            BindingContext = new UpsertViewModel(Startup.ServiceProvider.GetService<IEstatesServices>());
        }
    }
}
