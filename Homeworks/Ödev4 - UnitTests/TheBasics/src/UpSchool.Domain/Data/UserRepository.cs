using System.Linq.Expressions;
using SQLite;
using UpSchool.Domain.Entities;

namespace UpSchool.Domain.Data;

public class UserRepository:IUserRepository
{
    //DB initialize etmek
    private readonly SQLiteAsyncConnection _database;

    //DB tarafını encapsule etmek
    public UserRepository()
    {
        var dbPath = Path.Combine("/Users/aleynameydan/Desktop", "upschool.db");
        
        _database = new SQLiteAsyncConnection("");
        
        _database.CreateTableAsync<User>().Wait();
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _database.Table<User>().ToListAsync();
    }

    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _database.Table<User>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<int> AddAsync(User user, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("Email cannot be null or empty.");
        }
        
        return _database.InsertAsync(user);
    }

    public Task<int> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        return _database.UpdateAsync(user);
    }

    //bu kısımda yazdığımız expression ile istersek email filtresi ile istersek id filtresi ile silme yapabiliyoruz
    public Task<int> DeleteAsync(Expression<Func<User,bool>> predicate, CancellationToken cancellationToken)
    {
        return _database.Table<User>().DeleteAsync(predicate);
    }

    public Task<string> HowManyProduct(string number, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
} 