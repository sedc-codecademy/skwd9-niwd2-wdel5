using RealEstate.Models;

namespace RealEstate.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public string EstateName { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonPhone { get; set; }

        public string ContactPersonEmail { get; set; }

        public string Address { get; set; }

        public string PhotoUrl { get; set; }

        public DetailsViewModel(Estate estate)
        {
            EstateName = estate.EstateName;
            ContactPersonName = estate.ContactPersonName;
            ContactPersonPhone = estate.ContactPersonPhone;
            ContactPersonEmail = estate.ContactPersonEmail;
            Address = estate.Address;
            PhotoUrl = estate.PhotoUrl;
        }
    }
}
