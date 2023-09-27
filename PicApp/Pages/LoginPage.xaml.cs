using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string _password;
        string _tempPass = String.Empty;

        public LoginPage()
        {
            _password = Preferences.Get("Password", String.Empty);

            InitializeComponent();
        }

        private void EntryPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_password == String.Empty && _tempPass == String.Empty)
            {
                prompt.Text = $"Введите {passwordField.MaxLength-passwordField.Text.Length} символа для PIN-кода";
                if (passwordField.Text.Length == 4)
                {
                    _tempPass = passwordField.Text;
                    passwordField.Text = String.Empty;
                    prompt.Text = "";
                }
            }
            else if(_password == String.Empty && _tempPass != String.Empty)
            {
                prompt.Text = "Введите PIN-код повторно";

                if (passwordField.Text.Length == 4 && passwordField.Text == _tempPass)
                {
                    Preferences.Set("Password", passwordField.Text);
                    _password = passwordField.Text;
                    passwordField.Text = String.Empty;

                    Navigation.PushAsync(new GalleryPage());
                }
            }
            else
            {
                prompt.Text ="Для доступа к галерее введите пин-код!";

                if(passwordField.Text == _password)
                {
                    passwordField.Text = String.Empty;
                    Navigation.PushAsync(new GalleryPage());

                }

            }
        }
    }
}