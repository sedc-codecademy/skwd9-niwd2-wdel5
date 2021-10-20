using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinFormsSandbox.XAML
{
    public partial class OnPlatform : ContentPage
    {
        public OnPlatform()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                label.Text = "iOS text from code";
            }
            else
            {
                label.Text = "Android text from code";
            }
            
        }
    }
}
