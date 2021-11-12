using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.Services;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DetailsViewModel : BaseViewModel
    {
        private IEstatesServices _estatesService;

        private Estate _estate;

        public event Action InitializationFinished;

        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = Uri.UnescapeDataString(value);
                Task.Run(async () => await Initialize(long.Parse(Id)));
            }
        }

        private string _estateName;
        public string EstateName
        {
            get => _estateName;
            set
            {
                _estateName = value;
                OnPropertyChanged(nameof(EstateName));
            }
        }

        private string _contactPersonName;
        public string ContactPersonName
        {
            get => _contactPersonName;
            set
            {
                _contactPersonName = value;
                OnPropertyChanged(nameof(ContactPersonName));
            }
        }

        private string _contactPersonPhone;
        public string ContactPersonPhone
        {
            get => _contactPersonPhone;
            set
            {
                _contactPersonPhone = value;
                OnPropertyChanged(nameof(ContactPersonPhone));
            }
        }

        private string _contactPersonEmail;
        public string ContactPersonEmail
        {
            get => _contactPersonEmail;
            set
            {
                _contactPersonEmail = value;
                OnPropertyChanged(nameof(ContactPersonEmail));
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _photoUrl;
        public string PhotoUrl
        {
            get => _photoUrl;
            set
            {
                _photoUrl = value;
                OnPropertyChanged(nameof(PhotoUrl));
            }
        }

        public double Lattitude { get; set; }

        public double Longitude { get; set; }

        public ICommand UpsertCommand => new Command((action) =>
        {
            Shell.Current.GoToAsync($"UpsertPage?Action={action}&EstateString={JsonConvert.SerializeObject(_estate)}");
        });

        public DetailsViewModel(IEstatesServices estatesServices)
        {
            _estatesService = estatesServices;
        }

        private async Task Initialize(long id)
        {
            _estate = await _estatesService.GetEstate(id);

            if (_estate != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    EstateName = _estate.EstateName;
                    ContactPersonName = _estate.ContactPersonName;
                    ContactPersonPhone = _estate.ContactPersonPhone;
                    ContactPersonEmail = _estate.ContactPersonEmail;
                    Address = _estate.Address;
                    PhotoUrl = _estate.PhotoUrl;
                    Lattitude = _estate.Latitude;
                    Longitude = _estate.Longitude;

                    InitializationFinished?.Invoke();
                });
            }
        }
    }
}
