using Core.Utilities.Results.DataResult;
using Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<List<User>> GetAll();
    IDataResult<User> GetById(int id);
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
}