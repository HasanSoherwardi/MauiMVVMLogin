
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Formats.Tar;
using System.Reflection.Metadata;
using System.Text;
using MauiMVVMLogin.Models;
using MauiMVVMLogin.Models.ViewModels;
using MauiMVVMLogin.Services;

namespace MauiMVVMLogin;

public partial class Home 
{
    User UserDetails = new User();
    public Home(User user)
    {
        UserDetails = user;
        InitializeComponent();
        var Hvm = new HomeViewModels(UserDetails);
        BindingContext = Hvm;
        Initialize();
    }
    public async void Initialize()
    {
        //await operation
    }

    private async void EmployeeList_Refreshing(object sender, EventArgs e)
    {
        Initialize();
        EmployeeList.IsRefreshing = false;
    }
}