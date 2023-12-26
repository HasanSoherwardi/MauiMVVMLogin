using MauiMVVMLogin.Models;
using MauiMVVMLogin.Models.ViewModels;
using MauiMVVMLogin.Services;

namespace MauiMVVMLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var Mvm = new MainPageViewModel();
            BindingContext = Mvm;
        }
    }
}
