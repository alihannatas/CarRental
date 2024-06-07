using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        //CarTest();
        //ColorTest();
        //BrandTest();
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
}