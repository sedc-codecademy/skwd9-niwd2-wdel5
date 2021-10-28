using System.Linq;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Estate estate = e.CurrentSelection.FirstOrDefault() as Estate;

            if (estate == null)
                return;

            Navigation.PushAsync(new DetailsPage(estate));

            collectionView.SelectedItem = null;
        }
    }
}
