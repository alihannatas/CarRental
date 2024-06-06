using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private IBranDal _branDal;
    public BrandManager(IBranDal branDal)
    {
        _branDal = branDal;
    }
    public List<Brand> GetAll()
    {
        return _branDal.GetAll().ToList();
    }

    public Brand GetById(int id)
    {
        return _branDal.Get(p => p.Id == id);
    }

    public void Add(Brand brand)
    {
        _branDal.Add(brand);
    }
    

    public void Update(Brand brand)
    {
        _branDal.Update(brand);
    }

    public void Delete(Brand brand)
    {
        _branDal.Delete(brand);
    }
}