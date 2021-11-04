using System;
using System.Collections.Generic;
using TabbedApp.ViewModels;
using TabbedApp.Views;
using Xamarin.Forms;

namespace TabbedApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
