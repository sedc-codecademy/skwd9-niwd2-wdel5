using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsSandbox.DataBinding;

namespace XamarinFormsSandbox.WorkingWithData
{
    public class RestClientViewModel : BaseViewModel
    {
        private readonly RestClientService _restClientService;

        public ICommand GetCommand => new Command(async () =>
        {
            List<Post> list = await _restClientService.GetAsync<List<Post>>("posts");
        });

        public ICommand PostCommand => new Command(async () =>
        {
            Post post = new Post
            {
                UserId = 500,
                Title = "My new Post",
                Body = "My new post body"
            };

            ResultLabel = await _restClientService.PostAsync("posts", post);
        });

        public ICommand PatchCommand => new Command(async () =>
        {
            Post post = new Post
            {
                Id = 10,
                UserId = 500,
                Title = "My updated Post",
                Body = "My updated post body"
            };

            ResultLabel = await _restClientService.PatchAsync($"posts/{post.Id}", post);
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            ResultLabel = await _restClientService.DeleteAsync("posts/1");
        });

        private string _resultLabel;
        public string ResultLabel
        {
            get => _resultLabel;
            set
            {
                _resultLabel = value;
                OnPropertyChanged(nameof(ResultLabel));
            }
        }

        public RestClientViewModel()
        {
            ResultLabel = "Result Label";
            _restClientService = new RestClientService();
        }
    }
}
