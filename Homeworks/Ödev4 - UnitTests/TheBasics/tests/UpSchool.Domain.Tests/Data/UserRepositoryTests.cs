// using FakeItEasy;
// using UpSchool.Domain.Data;
// using UpSchool.Domain.Dtos;
// using UpSchool.Domain.Entities;
// using UpSchool.Domain.Services;
//
// namespace UpSchool.Domain.Tests.Data;
//
// public class UserRepositoryTests
// {
//     [Fact]
//     public async void AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
//     {
//         //Arrange
//         
//         var userRepositoryMock = A.Fake<IUserRepository>();
//
//         Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");
//         
//         var cancellationSource = new CancellationTokenSource();
//         
//         
//         var expectedUser = new User()
//         {
//             Id = userId,
//             Email = string.Empty
//         };
//         
//         //Act
//
//         UserRepository userRepository = new UserRepository();
//         
//         var newuser = new UserRepository().AddAsync(expectedUser, cancellationSource.Token);
//         
//         //Assert
//         Assert.ThrowsAsync<ArgumentException>();
//     }
//     
//     [Fact]
//     public async void DeleteAsync_ShouldReturnTrue_WhenUserExists()
//     {
//         
//     }
//     
//     [Fact]
//     public async void DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
//     {
//         
//     }
//     
//     [Fact]
//     public async void UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
//     {
//         
//     }
//     
//     [Fact]
//     public async void UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
//     {
//         
//     }
//     
//     [Fact]
//     public async void GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
//     {
//         
//     }
//     
// }