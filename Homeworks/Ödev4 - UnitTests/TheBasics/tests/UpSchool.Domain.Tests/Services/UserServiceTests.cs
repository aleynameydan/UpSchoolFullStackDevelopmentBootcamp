using FakeItEasy;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;
using UpSchool.Domain.Utilities;

namespace UpSchool.Domain.Tests.Services;

public class UserServiceTests
{
    [Fact]
    public async void GetUser_ShouldGetUserWithCorrectId(){
        
        var userRepositoryMock = A.Fake<IUserRepository>();

        Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

        var cancellationSource = new CancellationTokenSource();

        var expectedUser = new User()
        {
            Id = userId
        };

        A.CallTo(() => userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
            .Returns(Task.FromResult(expectedUser));

        IUserService userService = new UserManager(userRepositoryMock);

        var user = await userService.GetByIdAsync(userId, cancellationSource.Token);
        
        Assert.Equal(expectedUser, user);
    }

    [Fact]
    public async void AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
    {
   
        var userRepositoryMock = A.Fake<IUserRepository>();
        var cancellationSource = new CancellationTokenSource();

        var expectedUser = new User()
        {
            Id = new Guid(),
            FirstName = "Aleyna",
            LastName = "Meydan",
            Age = 23,
            Email = String.Empty
        };
        
        IUserService userService = new UserManager(userRepositoryMock);

        var user = await userService.AddAsync(expectedUser.FirstName, expectedUser.LastName, expectedUser.Age, expectedUser.Email,cancellationSource.Token);

        Assert.Throws<ArgumentException>(() => user);

    }

    [Fact]
    public async void DeleteAsync_ShouldReturnTrue_WhenUserExists()
    {
        
    }
    
    
    [Fact]
    public async void DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
    {
        
        var userRepositoryMock = A.Fake<IUserRepository>();
        var cancellationSource = new CancellationTokenSource();
        
        
        IUserService userService = new UserManager(userRepositoryMock);
        
        var isDeleted =userService.DeleteAsync(Guid.NewGuid(), cancellationSource.Token);
   
        await Assert.ThrowsAsync<ArgumentException>(()=>isDeleted);

    }

    [Fact]
    public async void UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        var cancellationSource = new CancellationTokenSource();
        
        var expectedUser = new User()
        {
            Id = Guid.Empty,
            FirstName = "Aleyna",
            LastName = "Meydan",
            Age = 23,
            Email = "ajsdfjksfkja"
        };
        
        IUserService userService = new UserManager(userRepositoryMock);

        var user = await userService.UpdateAsync(expectedUser,cancellationSource.Token);
        
        Assert.Throws<ArgumentException>(() => user);
    }

    [Fact]
    public async void UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        var cancellationSource = new CancellationTokenSource();

        Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");
        
        var expectedUser = new User()
        {
            Id = userId,
            FirstName = "Aleyna",
            LastName = "Meydan",
            Age = 23,
            Email = String.Empty
        };
        
        IUserService userService = new UserManager(userRepositoryMock);

        var user = await userService.UpdateAsync(expectedUser,cancellationSource.Token);

        Assert.Throws<ArgumentException>(() => user);

    }

    [Fact]
    public async void GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        var cancellationSource = new CancellationTokenSource();

        List<User> userList = new List<User>()
        {
            new User()
            {
                Id = new Guid()
            },
            new User()
            {
                Id = new Guid()
            }
        };
        
        A.CallTo(() =>  userRepositoryMock.GetAllAsync(cancellationSource.Token))
            .Returns(Task.FromResult(userList));
        
        IUserService userService = new UserManager(userRepositoryMock);
        
        var expectedUserList = await userService.GetAllAsync(cancellationSource.Token);
            
        Assert.True(expectedUserList.Count >= 2);
    }
    
    
    
}