using Business.Abstract;
using Business.Consonants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResult;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    private IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IDataResult<Rental> GetById(int id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
    }
    
    [ValidationAspect(typeof(RentalValidator))]
    public IResult Add(Rental rental)
    {
        var result = CheckReturnDateIsEmpty(rental.CarId);
        if (result.Success)
        {
            return new ErrorResult(Messages.RentalAlreadyRented);
        }
        _rentalDal.Add(rental);
        return new SuccesResult(Messages.RentalRented);
    }
    
    [ValidationAspect(typeof(RentalValidator))]
    public IResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccesResult();
    }
    
    [ValidationAspect(typeof(RentalValidator))]
    public IResult Delete(Rental rental)
    {
        _rentalDal.Delete(rental);
        return new SuccesResult();
    }

    public IResult CheckReturnDateIsEmpty(int carId)
    {
        var result = _rentalDal.GetAll().LastOrDefault(p => p.CarId == carId);
        if (result == null)
        {
            return new SuccesResult();
        }

        return new ErrorResult(Messages.RentalAlreadyRented);
    }
    
    public IResult UpdateReturnDate(int carId)
    {
        var updatedRental = _rentalDal.GetAll().LastOrDefault(p => p.CarId == carId);
        if (updatedRental.ReturnDate != null)
        {
            return new ErrorResult(Messages.RentalUpdateError);
        }

        updatedRental.ReturnDate = DateTime.Now;
        _rentalDal.Update(updatedRental);
        return new SuccesResult(Messages.RentalUpdateSuccesfully);
    }

    public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
    {
        return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
    }

    public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int carId)
    {
        return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p => p.CarId == carId));
    }
}