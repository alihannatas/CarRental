using Business.Abstract;
using Business.Consonants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.DataResult;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal cardal)
    {
        _carDal = cardal;
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
    }

    public IDataResult<Car> GetById(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.CarListedById);
    }
    
    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
        _carDal.Add(car);
        return new SuccesResult(Messages.CarAdded);
    }
    
    [ValidationAspect(typeof(CarValidator))]
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccesResult(Messages.CarUpdated);
    }
    
    [ValidationAspect(typeof(CarValidator))]
    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccesResult(Messages.CarDeleted);
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.BrandId == id).ToList(), Messages.CarsListedByBrandId);
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.ColorId == id).ToList(), Messages.CarsListedByColorId);
    }

    public IDataResult<List<CarDetailsDto>> GetCarsDetails()
    {
        return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails().ToList(), Messages.CarsListedWithDetails);
    }
}