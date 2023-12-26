
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMVVMLogin.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMVVMLogin.Models.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User user = new();

        //[ObservableProperty]
        //private ObservableCollection<User> users = new ObservableCollection<User>();

        [RelayCommand]
        private async Task LoginUser()
        {
            if (string.IsNullOrEmpty(User.UserId.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Input Error", "Please enter user name!!!", "OK");
                //UName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(User.Password.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Input Error", "Please enter password!!!", "OK");
                //Password.Focus();
                return;
            }

            SQLite_Android Obj = new SQLite_Android();
            var res = Obj.GetUserLogin(User);
            if (res != null)
            {
                //UserDetails = res;
                await App.Current.MainPage.DisplayAlert("Welcome", "Login Successfully.", "OK");

                await App.Current.MainPage.Navigation.PushAsync(new Home(User));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid Credentials", "OK");
            }
        }

        [RelayCommand]
        private async Task UserRegistration()
        {
            User newUser = new User();
            await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage(newUser));

        }
    }
}
