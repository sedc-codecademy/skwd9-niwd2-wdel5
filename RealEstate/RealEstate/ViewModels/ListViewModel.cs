using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using RealEstate.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private readonly int PageSize = 30;

        private readonly int ValidLocalEstateDataInMinutes;

        private bool IsLocalDataValid => DateTime.Now < Preferences.Get(PreferencesKeys.LastEsateUpdateTime,
            default(DateTime)).AddMinutes(ValidLocalEstateDataInMinutes);

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
            //EstateCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullPath = Path.Combine(path, "estate_data.txt");

            List<Estate> estates;

            if (File.Exists(fullPath) && IsLocalDataValid)
            {
                estates = JsonConvert.DeserializeObject<List<Estate>>(File.ReadAllText(fullPath));
            }
            else
            {
                estates = EstateGenerator.Estates;
                File.WriteAllText(fullPath, JsonConvert.SerializeObject(estates));
                Preferences.Set(PreferencesKeys.LastEsateUpdateTime, DateTime.Now);
            }

            EstateCollection = new ObservableCollection<Estate>(estates);
        }

        public ICommand SelectionChangedCommand => new Command(async (arg) =>
        {
            var estate = (Estate)arg;
            await Shell.Current.GoToAsync($"DetailsPage?Id={estate.Id}");
        });
    }
}
