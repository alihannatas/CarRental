using Core.Utilities.Results.DataResult;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
namespace Business.Abstract;

public interface ICarImageService 
{
    IDataResult<CarImage> GetById(int id);
    IDataResult<List<CarImage>> GetAll();
    IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    IResult Add(IFormFile file, CarImage carImage);
    IResult Update(IFormFile file, CarImage carImage);
    IResult Delete(CarImage carImage);
}