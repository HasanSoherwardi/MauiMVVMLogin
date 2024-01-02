using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMVVMLogin.Helper;
using MauiMVVMLogin.Services;

namespace MauiMVVMLogin.Models.ViewModels
{
    internal partial class RegistrationViewModels : ObservableObject
    {
        [ObservableProperty]
        private User user = new User();

        private string flag = null;

        [ObservableProperty]
        Page window = new();

        [ObservableProperty]
        private string btnContent = "Save";
        
        [ObservableProperty]
        private ImageSource imgSource = ImageSource.FromFile("man.png");
        
        public RegistrationViewModels(User LoginUser)
        {
            this.User = LoginUser;
            Initialize().SafeFireAndForget();
        }

        private async Task InputValidationAsync()
        {
            if (Window != null)
            {
                if (!ValidationHelper.IsFormValid(this.User, Window)) { return; }
                flag = "Success";
            }
        }

        [RelayCommand]
        private async void AddUser()
        {
            try
            {
                await InputValidationAsync();

                if (flag == "Success")
                {
                    if (BtnContent == "Save")
                    {
                        SQLite_Android Obj = new SQLite_Android();
                        bool response = Obj.SaveUser(User);
                        if (response)
                        {
                            await App.Current.MainPage.DisplayAlert("Saved", "Save Successfully.", "OK");
                            await App.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Not Save. Try with different User Id.", "OK");
                        }
                    }
                    else
                    {
                        SQLite_Android Obj = new SQLite_Android();
                        bool response = Obj.UpdateUser(User);
                        if (response)
                        {
                            MessagingCenter.Send<User>(User, "ReciveData");
                            await App.Current.MainPage.DisplayAlert("Update", "Update Successfully.", "OK");
                            await App.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Not Save. Try with different User Id.", "OK");
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Input Error", ex.ToString(), "Ok");
            }
        }

        private async Task Initialize()
        {
            if (User.id > 0)
            {
                if (User.myArray != null)
                {
                    MemoryStream streamRead = new MemoryStream(User.myArray.ToArray());
                    ImgSource = ImageSource.FromStream(() => { return streamRead; });
                }
                BtnContent = "Update";
                App.Current.MainPage.Title = "Edit Info";
            }
            else
            {
                BtnContent = "Save";
                App.Current.MainPage.Title = "Registration";
            }
        }


        [RelayCommand]
        private async Task BrowsePhoto()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick an image"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                User.myArray = memoryStream.ToArray();
                ImgSource = ImageSource.FromStream(() => new MemoryStream(User.myArray.ToArray()));
            }
        }

        [RelayCommand]
        private async Task CapturePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                var photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    // ---------------------------------
                    //string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    //using FileStream localFileStream = File.OpenWrite(localFilePath);
                    //await sourceStream.CopyToAsync(localFileStream);

                    var stream = await photo.OpenReadAsync();
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    User.myArray = memoryStream.ToArray();
                    ImgSource = ImageSource.FromStream(() => new MemoryStream(User.myArray.ToArray()));
                }
            }
        }
    }
}
