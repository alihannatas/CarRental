using Core.Entities;

namespace Entities.DTOs;

public class RentalDetailDto : IDto
{
    public int RentalId { get; set; }
    public int CarId { get; set; }
    public string CarDescription { get; set; }
    public string BrandName { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; }

}