using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.User.Services.Users.Commands.EditUser;
using KalaMarket.EndPoint.Areas.Admin.Controllers;
using Moq;

namespace KalaMarket.UnitTest
{
    public class UnitTest1
    {
        
        [Fact]
        public void Test1()
        {
            
            // create mock using test with interface IChangeRemoveUserService 
            var mockChangeRemoveUser = new Mock<IChangeRemoveUserService>();
            var mockEditUser = new Mock<IEditUserService>();
            // create instance of controller
            var controller = new UserController(mockChangeRemoveUser.Object, mockEditUser.Object);
            // call method
            

        }
        
    }
}