using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        CarTest();
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetAll();
        foreach (var VARIABLE in result)
        {
            Console.WriteLine($"{VARIABLE.Id} {VARIABLE.Description} {VARIABLE.DailyPrice} ");
        }
    }
}