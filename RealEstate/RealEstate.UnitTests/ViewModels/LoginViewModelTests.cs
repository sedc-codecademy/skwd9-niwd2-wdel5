using NSubstitute;
using NUnit.Framework;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.ViewModels;

namespace RealEstate.UnitTests.ViewModels
{
    [TestFixture()]
    public class LoginViewModelTests
    {
        private IEstatesServices _estatesService;
        private IPlatformService _platformService;
        private INavigationService _navigationService;
        private LoginViewModel _sut;

        [SetUp]
        public void Setup()
        {
            _estatesService = Substitute.For<IEstatesServices>();
            _platformService = Substitute.For<IPlatformService>();
            _navigationService = Substitute.For<INavigationService>();

            _sut = new LoginViewModel(_estatesService, _platformService, _navigationService);
        }

        [Test]
        public void WhenLoginButtonIsPressed_LoginIsCalledInEstatesService()
        {
            _sut.Username = "User";
            _sut.Password = "Password";

            _sut.LoginCommand.Execute(null);

            _estatesService.Received(1).Login(Arg.Is<AuthenticateModel>(
                (x) => x.Username == _sut.Username && x.Password == _sut.Password));
        }

        [Test]
        public void WhenCorrectCredentialsAreEntered_NavigateToListPageIsCalled()
        {
            AuthenticateModel authenticateModel = new AuthenticateModel { Username = "User", Password = "Pass" };
            _estatesService.Login(Arg.Is<AuthenticateModel>(
                (x) => x.Username == authenticateModel.Username && x.Password == authenticateModel.Password))
                .Returns(new User { Id = 1, FirstName = "test", LastName = "test", Username = "User" });
            _sut.Username = authenticateModel.Username;
            _sut.Password = authenticateModel.Password;

            _sut.LoginCommand.Execute(null);

            _navigationService.Received(1).NavigateToAsync("//ListPage");
        }
    }
}
