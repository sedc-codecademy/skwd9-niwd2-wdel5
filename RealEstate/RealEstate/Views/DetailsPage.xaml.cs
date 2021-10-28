using System;
using System.Collections.Generic;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Estate estate)
        {
            InitializeComponent();
            BindingContext = new DetailsViewModel(estate);
        }
    }
}
