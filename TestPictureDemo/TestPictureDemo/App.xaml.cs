using Prism;
using Prism.Ioc;
using TestPictureDemo.Database.SQLiteSettings.DbServices;
using TestPictureDemo.Database.SQLiteSettings.DbServices.Abstract;
using TestPictureDemo.ViewModels;
using TestPictureDemo.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TestPictureDemo
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AddPost, AddPostViewModel>();

            /*UnitOfWork*/
            containerRegistry.RegisterSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
