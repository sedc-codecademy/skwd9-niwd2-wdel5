using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private readonly int PageSize = 30;

        public ICommand RemainingItemsThresholdReachedCommand => new Command(() =>
        {
            if (EstateCollection.Count < EstateGenerator.Estates.Count)
            {

                var nexList = EstateGenerator.Estates.Skip(EstateCollection.Count).Take(PageSize);

                foreach (var estate in nexList)
                {
                    EstateCollection.Add(estate);
                }
            }
        });

        private ObservableCollection<Estate> _estatesCollection;
        public ObservableCollection<Estate> EstateCollection
        {
            get => _estatesCollection;
            set
            {
                _estatesCollection = value;
                OnPropertyChanged(nameof(EstateCollection));
            }
        }

        public ListViewModel()
        {
            EstateCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));
        }
    }
}
