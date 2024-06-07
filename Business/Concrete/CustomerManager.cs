using Business.Abstract;
using Core.Utilities.Results.DataResult;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    private ICustomerDal _customerDal;
    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }
    
    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
    }

    public IDataResult<Customer> GetById(int id)
    {
        return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == id));
    }

    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccesResult();
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccesResult();
    }

    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccesResult();
    }
}