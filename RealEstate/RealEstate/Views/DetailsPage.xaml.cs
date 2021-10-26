using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        void ChipView_ChipDeleted(object sender, EventArgs e)
        {
            flexLayout.Children.Remove((View)sender);
        }
    }
}
