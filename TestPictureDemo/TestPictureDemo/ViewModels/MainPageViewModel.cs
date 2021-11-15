using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestPictureDemo.Database.SQLiteSettings.DbEntities;
using TestPictureDemo.Database.SQLiteSettings.DbServices.Abstract;
using TestPictureDemo.Models;
using TestPictureDemo.Views;
using Xamarin.Forms;

namespace TestPictureDemo.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<PrincipalPost> principalComents { get; set; } = new ObservableCollection<PrincipalPost>();
        public ICommand GoToAddPost { get; set; }

        public ICommand LoadPost { get; set; }

        public IUnitOfWork unitOfWork;

        public ICommand RefreshCommand { get; set; }
        public bool IsRefreshing { get; set; }
        public MainPageViewModel(INavigationService navigationService, IUnitOfWork _unitOfWork)
            : base(navigationService)
        {
            Title = "Main Page";

            unitOfWork = _unitOfWork;
            RegisterCommands();
            LoadPost.Execute(null);


        }

        public void RegisterCommands()
        {

            LoadPost = new Command(async () => await LoadPostFromDb());
            GoToAddPost = new Command(async () => {
                await NavigationService.NavigateAsync(nameof(AddPost));
            });

            RefreshCommand = new Command(async()=> await ExecuteRefreshCommand());
        }

        private async Task LoadPostFromDb()
        {
            var results = await unitOfWork.TDPrincipalPost.GetAllAsync();

            foreach (var result in results) {
                principalComents.Add(result);
            }
        }


        async Task ExecuteRefreshCommand()
        {
            principalComents.Clear();
            var results = await unitOfWork.TDPrincipalPost.GetAllAsync();

            foreach (var result in results)
            {
                principalComents.Add(result);
            }

            // Stop refreshing
            IsRefreshing = false;
        }
    }
}
