using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
{
    public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var result = from rental in context.Rentals
                join car in context.Cars
                    on rental.CarId equals car.Id
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join customer in context.Customers
                    on rental.CustomerId equals customer.Id
                join user in context.Users
                    on customer.UserId equals user.Id
                select new RentalDetailDto
                {
                    RentalId = rental.Id, CarId = car.Id, CarDescription = car.Description,
                    BrandName = brand.Name, CustomerName = $"{user.FirstName} {user.LastName}",
                    CustomerEmail = user.Email, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate
                };
            return result.ToList();
            
        }
     
    }
}