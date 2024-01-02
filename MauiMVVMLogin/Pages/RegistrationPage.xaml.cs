using MauiMVVMLogin.Models;
using MauiMVVMLogin.Models.ViewModels;

namespace MauiMVVMLogin;

public partial class RegistrationPage : ContentPage
{
    User UserDetails = new User();
    public RegistrationPage(User user)
	{
        UserDetails = user;
        InitializeComponent();
        var Rvm = new RegistrationViewModels(UserDetails);
        BindingContext = Rvm;
        Rvm.Window = this;
        Initialize();
    }
    public async void Initialize()
    {
        //await operation
       
    }
}