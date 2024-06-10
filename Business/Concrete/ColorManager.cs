using Business.Abstract;
using Business.Consonants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.DataResult;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public IDataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll().ToList(), Messages.ColorsListed);
    }

    public IDataResult<Color> GetById(int id)
    {
        return new SuccessDataResult<Color>(_colorDal.Get(p => p.Id == id), Messages.ColorListedById);
    }

    [ValidationAspect(typeof(ColorValidator))]
    public IResult Add(Color color)
    {
        _colorDal.Add(color);
        return new SuccesResult(Messages.ColorAdded);
    }

    [ValidationAspect(typeof(ColorValidator))]
    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccesResult(Messages.ColorUpdated);
    }

    [ValidationAspect(typeof(ColorValidator))]
    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccesResult(Messages.ColorDeleted);
    }
}