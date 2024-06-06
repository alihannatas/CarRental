using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
{
    public List<CarDetailsDto> GetCarDetails()
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var result = from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join color in context.Colors
                    on car.ColorId equals color.Id
                select new CarDetailsDto
                {
                    BrandName = brand.Name, CarName = car.Description, ColorName = color.Name,
                    DailyPrice = car.DailyPrice
                };
            return result.ToList();
        }
    }
}