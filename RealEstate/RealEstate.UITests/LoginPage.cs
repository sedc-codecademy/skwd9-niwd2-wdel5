using System;
using Xamarin.UITest;

namespace RealEstate.UITests
{
    public class LoginPage
    {
        IApp _app;

        string usernameEntry, passwordEntry, loginButton;

        public LoginPage(IApp app)
        {
            _app = app;

            usernameEntry = "usernameEntry";
            passwordEntry = "passwordEntry";
            loginButton = "loginButton";
        }

        public void EnterUsername(string username)
        {
            _app.EnterText(usernameEntry, username);
            _app.DismissKeyboard();
            _app.Screenshot("Entered username");
        }

        public void EnterPassword(string password)
        {
            _app.EnterText(passwordEntry, password);
            _app.DismissKeyboard();
            _app.Screenshot("Entered Password");
        }

        public void PressLogin()
        {
            _app.Tap(loginButton);
            _app.Screenshot("Pressed login");
        }
    }
}
