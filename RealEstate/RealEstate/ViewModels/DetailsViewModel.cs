using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RealEstate.Services;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DetailsViewModel : BaseViewModel
    {
        private EstatesService _estatesService;

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
            Shell.Current.GoToAsync($"UpsertPage?Action={action}");
        });

        public DetailsViewModel()
        {
            _estatesService = new EstatesService();
        }

        private async Task Initialize(long id)
        {
            var estate = await _estatesService.GetEstate(id);

            if (estate != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    EstateName = estate.EstateName;
                    ContactPersonName = estate.ContactPersonName;
                    ContactPersonPhone = estate.ContactPersonPhone;
                    ContactPersonEmail = estate.ContactPersonEmail;
                    Address = estate.Address;
                    PhotoUrl = estate.PhotoUrl;
                    Lattitude = estate.Latitude;
                    Longitude = estate.Longitude;

                    InitializationFinished?.Invoke();
                });
            }
        }
    }
}
