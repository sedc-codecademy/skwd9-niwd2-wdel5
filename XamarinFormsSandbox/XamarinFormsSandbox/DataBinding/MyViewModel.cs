using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsSandbox.DataBinding
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _labelText;
        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                OnPropertyChanged(nameof(LabelText));
            }
        }

        public MyViewModel()
        {
            LabelText = "Some text";
            Task.Run(CowntdownDelay);
        }

        private async Task CowntdownDelay()
        {
            for (int i = 5; i>0; i--)
            {
                await Task.Delay(1000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    LabelText = i.ToString();
                });
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                LabelText = "Time is up!";
            });
        } 
    }
}
