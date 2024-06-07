using Business.Abstract;
using Business.Consonants;
using Core.Utilities.Results.DataResult;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private IBranDal _branDal;

    public BrandManager(IBranDal branDal)
    {
        _branDal = branDal;
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_branDal.GetAll().ToList(), Messages.BrandsListed);
    }

    public IDataResult<Brand> GetById(int id)
    {
        return new SuccessDataResult<Brand>(_branDal.Get(p => p.Id == id), Messages.BrandListedById);
    }

    public IResult Add(Brand brand)
    {
        _branDal.Add(brand);
        return new SuccesResult(Messages.BrandAdded);
    }


    public IResult Update(Brand brand)
    {
        _branDal.Update(brand);
        return new SuccesResult(Messages.BrandUpdated);
    }

    public IResult Delete(Brand brand)
    {
        _branDal.Delete(brand);
        return new SuccesResult(Messages.BrandDeleted);
    }
}