using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        //CarTest();
        //ColorTest();
        //BrandTest();
        //UserTest();
        //CustomerTest();
        //RentalTest(); 
        //RentalAddTest();
         RentalManager rentalManager = new RentalManager(new EfRentalDal());
        var result= rentalManager.UpdateReturnDate(5);
        Console.WriteLine(result.Message, result.Success);  
    }

    private static void  RentalAddTest()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        var result = rentalManager.Add(new Rental {CarId = 5, CustomerId = 48, RentDate = DateTime.Now, });
        Console.WriteLine(result.Message, result.Success);
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarsDetails();
        Console.WriteLine(result.Message);
        foreach (var VARIABLE in result.Data)
        {
            Console.WriteLine($"{VARIABLE.CarName} {VARIABLE.BrandName} {VARIABLE.ColorName} {VARIABLE.DailyPrice} ");
        }
    }

    private static void ColorTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        var result = colorManager.GetAll();
        Console.WriteLine(result.Message);
        foreach (var VARIABLE in result.Data)
        {
            Console.WriteLine($"{VARIABLE.Id} {VARIABLE.Name} ");
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        var result = brandManager.GetAll();
        Console.WriteLine(result.Message);
        foreach (var VARIABLE in result.Data)
        {
            Console.WriteLine($"{VARIABLE.Id} {VARIABLE.Name} ");
        }
    }

    private static void UserTest()
    {
        UserManager userManager = new UserManager(new EfUserDal());
        var result = userManager.GetAll();
        Console.WriteLine(result.Message);
        foreach (var VARIABLE in result.Data)
        {
            Console.WriteLine($"{VARIABLE.Id} {VARIABLE.FirstName} {VARIABLE.LastName}  {VARIABLE.Email}  ");
        }
    }

    private static void CustomerTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        var result = customerManager.GetAll();
        Console.WriteLine(result.Message);
        foreach (var VARIABLE in result.Data)
        {
            Console.WriteLine($"{VARIABLE.Id} {VARIABLE.UserId} {VARIABLE.CompanyName}");
        }
    }

    private static void RentalTest()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        var result = rentalManager.GetAll();
        Console.WriteLine(result.Message);
        foreach (var VARIABLE in result.Data)
        {
            Console.WriteLine(
                $"{VARIABLE.Id} {VARIABLE.CarId} {VARIABLE.CustomerId} {VARIABLE.RentDate} {VARIABLE.ReturnDate}");
        }
    }
}