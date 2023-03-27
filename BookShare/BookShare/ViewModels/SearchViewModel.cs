using BookShare.Models;
using BookShare.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookShare.ViewModels
{

    public class SearchViewModel : INotifyPropertyChanged
    {
        private readonly IOperations _postsService;
        private List<Post> _posts;

        public SearchViewModel(IOperations PostsService)
        {
            _postsService = PostsService;
            LoadPosts();
        }
        public ICommand SaveCommand { get; }

        public SearchViewModel()
        {
            SaveCommand = new Command(Save);
        }
        private void Save()
        {
            // Save the data to the database, etc.
        }

        public List<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        private async void LoadPosts()
        {
            Posts = await _postsService.GetAllPosts();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
