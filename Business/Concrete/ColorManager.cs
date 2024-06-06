using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public List<Color> GetAll()
    {
        return _colorDal.GetAll().ToList();
    }

    public Color GetById(int id)
    {
        return _colorDal.Get(p => p.Id == id);
    }

    public void Add(Color color)
    {
        _colorDal.Add(color);
    }


    public void Update(Color color)
    {
        _colorDal.Update(color);
    }

    public void Delete(Color color)
    {
        _colorDal.Delete(color);
    }
}