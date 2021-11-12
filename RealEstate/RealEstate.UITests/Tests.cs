using NUnit.Framework;
using Xamarin.UITest;

namespace RealEstate.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class LoginTests
    {
        IApp _app;
        private LoginPage _loginPage;
        Platform _platform;

        public LoginTests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
            _loginPage = new LoginPage(_app);
            _app.WaitForElement("LoginPage");
        }

        [Test]
        public void AppLaunches()
        {
            _app.Screenshot("First screen.");
        }

        [Test]
        public void WhenUserLogsInWithRightCredentials_UserIsNavigatedToListPage()
        {
            _loginPage.EnterUsername("User");
            _loginPage.EnterPassword("Test");
            _loginPage.PressLogin();

            _app.WaitForElement("ListPage");
            _app.Screenshot("Navigated to ListPage");
        }
    }
}
