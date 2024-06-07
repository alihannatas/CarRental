using Core.Utilities.Results.DataResult;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IRentalService
{
    IDataResult<List<Rental>> GetAll();
    IDataResult<Rental> GetById(int id);
    IResult Add(Rental rental);
    IResult Update(Rental rental);
    IResult Delete(Rental rental);
    IResult CheckReturnDateIsEmpty(int carId);
    IResult UpdateReturnDate(int carId);
    IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
    IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int carId);
}