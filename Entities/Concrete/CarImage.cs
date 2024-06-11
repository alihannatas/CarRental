using Core.Entities;

namespace Entities.Concrete;

public class CarImage : IEntity
{
    // (Id,CarId,ImagePath,Date)

    public int Id { get; set; }
    public int CarId { get; set; }
    public string ImagePath { get; set; }
    public DateTime? CreateDate { get; set; }
}