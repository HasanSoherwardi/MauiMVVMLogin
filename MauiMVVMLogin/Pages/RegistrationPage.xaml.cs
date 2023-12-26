using System;
using System.IO;
using System.Text;
using static SQLite.SQLite3;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using MauiMVVMLogin.Services;
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
        Initialize();
    }
    public async void Initialize()
    {
        //await operation
       
    }
}