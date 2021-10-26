using System;
using System.Collections.ObjectModel;
using System.Linq;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        private readonly int PageSize = 30;

        private ObservableCollection<Estate> estatesCollection;

        public ListPage()
        {
            InitializeComponent();
            collectionView.ItemsSource = estatesCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));
        }

        void RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            if (estatesCollection.Count < EstateGenerator.Estates.Count)
            {

                var nexList = EstateGenerator.Estates.Skip(estatesCollection.Count).Take(PageSize);

                foreach (var estate in nexList)
                {
                    estatesCollection.Add(estate);
                }
            }
        }
    }
}
