
using MauiMVVMLogin.Models.ViewModels;

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
