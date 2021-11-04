using System;
using System.Linq;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DetailsViewModel : BaseViewModel
    {
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = Uri.UnescapeDataString(value);
                Initialize(EstateGenerator.Estates.FirstOrDefault(x => x.Id == long.Parse(Id)));
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

        private void Initialize(Estate estate)
        {
            EstateName = estate.EstateName;
            ContactPersonName = estate.ContactPersonName;
            ContactPersonPhone = estate.ContactPersonPhone;
            ContactPersonEmail = estate.ContactPersonEmail;
            Address = estate.Address;
            PhotoUrl = estate.PhotoUrl;
            Lattitude = estate.Latitude;
            Longitude = estate.Longitude;
        }
    }
}
