using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestPictureDemo.Database.SQLiteSettings.DbEntities;
using TestPictureDemo.Database.SQLiteSettings.DbServices.Abstract;
using Xamarin.Forms;

namespace TestPictureDemo.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddPostViewModel : ViewModelBase
    {
        public IUnitOfWork unitOfWork;
        public ICommand SavePost { get; set; }

        public string TextComment { get; set; } = "";
        public AddPostViewModel(INavigationService navigationService, IUnitOfWork _unitOfWork)
            : base(navigationService)
        {
            unitOfWork = _unitOfWork;
            RegisterCommands();
        }

        public void RegisterCommands()
        {

            SavePost = new Command(async () => await SavePostToDb());

        }

        private async Task SavePostToDb()
        {
            if (TextComment == null || TextComment == string.Empty || TextComment == "")
            {
                return;
            }
            var PictureArray = new string[3] { "Agera.jpg", "Bugatti.jpg", "Pagani.jpg" };
            var rnd = new Random();
            var postObject = new PrincipalPost()
            {
                UserIcon = "StevenProfilePicture.jpg",
                PictureComment = PictureArray[rnd.Next(0,2)],
                Name = "Steven Checo",
                Date = DateTime.Now,
                Comment = TextComment,
                Funny = false,
                Like = true,
                Love = false,
                TotalComents = "0 comments"
            };
           await unitOfWork.TDPrincipalPost.SaveItemAsync(postObject);
           await NavigationService.GoBackAsync();
        }
    }
}
