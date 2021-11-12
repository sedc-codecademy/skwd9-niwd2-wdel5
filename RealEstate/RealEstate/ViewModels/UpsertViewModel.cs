using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(EstateString), nameof(EstateString))]
    [QueryProperty(nameof(Action), nameof(Action))]
    public class UpsertViewModel : BaseViewModel
    {
        private IEstatesServices _estatesService;

        private string _action;
        public string Action
        {
            get => _action;
            set
            {
                _action = Uri.UnescapeDataString(value);

                if (_action == "Create")
                {
                    ActionText = "Create";
                    UpsertCommand = new Command(async () => await CreateEstate());
                }
                else
                {
                    ActionText = "Update";
                    UpsertCommand = new Command(async () => await UpdateEstate());
                    InitializeForm();
                }
            }
        }

        private Estate _estate;
        private string _estateString;
        public string EstateString
        {
            get => _estateString;
            set
            {
                _estateString = Uri.UnescapeDataString(value);
                _estate = JsonConvert.DeserializeObject<Estate>(_estateString);            }
        }

        private string _actionText;
        public string ActionText
        {
            get => _actionText;
            set
            {
                _actionText = value;
                OnPropertyChanged(nameof(ActionText));
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

        public async Task CreateEstate()
        {
            Estate estate = new Estate
            {
                Id = 255,
                EstateName = EstateName,
                ContactPersonName = ContactPersonName
            };

            Estate result = await _estatesService.CreateEstate(estate);

            if (result != null)
            {
                await Shell.Current.GoToAsync("../..");
            }
        }

        public async Task UpdateEstate()
        {
            _estate.EstateName = EstateName;
            _estate.ContactPersonName = ContactPersonName;

            Estate result = await _estatesService.UpdateEstate(_estate);

            if (result != null)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        private ICommand _upsertCommand;
        public ICommand UpsertCommand
        {
            get => _upsertCommand;
            set
            {
                _upsertCommand = value;
                OnPropertyChanged(nameof(UpsertCommand));
            }
        }

        private void InitializeForm()
        {
            EstateName = _estate.EstateName;
            ContactPersonName = _estate.ContactPersonName;
        }

        public UpsertViewModel(IEstatesServices estatesServices)
        {
            _estatesService = estatesServices;
        }
    }
}
