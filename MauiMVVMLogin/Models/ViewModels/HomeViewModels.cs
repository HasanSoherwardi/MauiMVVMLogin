using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMVVMLogin.Services;
using System.Windows.Input;

namespace MauiMVVMLogin.Models.ViewModels
{
    internal partial class HomeViewModels : ObservableObject
    {
        //private ObservableCollection<User> usersCollection = new ObservableCollection<User>(users);

        [ObservableProperty]
        private User user = new();

        [ObservableProperty]
        private List<User> users = new List<User>();

        [ObservableProperty]
        private Microsoft.Maui.Controls.ImageSource imgSource = ImageSource.FromFile("man.png");

        public ICommand EditUser => new Command<User>(ExecuteEditUser);
        public ICommand DeleteUser => new Command<User>(ExecuteDeleteUser);

        public HomeViewModels(User LoginUser)
        {
            User = LoginUser;
            Initialize().SafeFireAndForget();
        }
        private async Task Initialize()
        {
            //await operation
            SQLite_Android Obj = new SQLite_Android();
            Users = Obj.GetUsers(User).ToList();
        }

        
        [RelayCommand]
        private async void ExecuteEditUser(User LoginUser)
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage(LoginUser));
            MessagingCenter.Unsubscribe<User>(this, "ReciveData");
            MessagingCenter.Subscribe<User>(this, "ReciveData", (value) =>
            {
                User = value;
                Initialize().SafeFireAndForget();
            });
        }

        [RelayCommand]
        private async void ExecuteDeleteUser(User LoginUser)
        {
            if (User != null)
            {
                var msgResult = await App.Current.MainPage.DisplayActionSheet("Alert", "Cancel", "Ok", "Are you sure to delete?");
                switch (msgResult)
                {
                    case "Ok":
                        SQLite_Android Obj = new SQLite_Android();
                        bool response = Obj.DeleteUser(LoginUser.id);
                        if (response)
                        {
                            await App.Current.MainPage.DisplayAlert("Deleted", "Deleted Successfully.", "OK");
                            await App.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Deletion Failed.", "OK");
                        }
                    break;
                }
            }
        }
    }
}
