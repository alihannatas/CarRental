using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal cardal)
    {
        _carDal = cardal;
    }

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public Car GetById(int id)
    {
        return _carDal.Get(p => p.Id == id);
    }

    public void Add(Car car)
    {
        _carDal.Add(car);
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }
}