using Business.Abstract;
using Business.Consonants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResult;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    private ICarImageDal _carImageDal;

    public CarImageManager(ICarImageDal carImageDal)
    {   
        _carImageDal = carImageDal;
    }
    
    [ValidationAspect(typeof(CarImageValidator))]
    public IResult Add(IFormFile file, CarImage carImage)
    {
        IResult result = BusinessRules.Run(CheckTheMaximumNumberOfPhotos(carImage.CarId));
        if (result != null)
        {
            return result;
        }

        carImage.ImagePath = FileHelper.Add(file);
        carImage.CreateDate = DateTime.Now;
        _carImageDal.Add(carImage);
        return new SuccesResult();
    }
    
    [ValidationAspect(typeof(CarImageValidator))]
    public IResult Delete(CarImage carImage)
    {
        FileHelper.Delete(carImage.ImagePath);
        _carImageDal.Delete(carImage);
        return new SuccesResult();
    }

    [ValidationAspect(typeof(CarImageValidator))]
    public IResult Update(IFormFile file, CarImage carImage)
    {
        carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
        carImage.CreateDate = DateTime.Now;
        _carImageDal.Update(carImage);
        return new SuccesResult();
    }

    public IDataResult<CarImage> GetById(int id)
    {
        return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
    }

    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }


    public IDataResult<List<CarImage>> GetImagesByCarId(int id)
    {
        return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
    }


    private IResult CheckTheMaximumNumberOfPhotos(int carId)
    {
        var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
        if (result >= 5)
        {
            return new ErrorResult(Messages.MaximumNumberOfPhotosReached);
        }

        return new SuccesResult();
    }

    private List<CarImage> CheckIfCarImageNull(int id)
    {
        string path = @"\Images\default.jpeg";
        var result = _carImageDal.GetAll(c => c.CarId == id).Any();
        if (!result)
        {
            return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, CreateDate = DateTime.Now } };
        }

        return _carImageDal.GetAll(p => p.CarId == id);
    }
}