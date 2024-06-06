using Core.Entities;

namespace Entities.DTOs;

public class CarDetailsDto : IDto
{   
    //CarName, BrandName, ColorName, DailyPrice. (İpucu : IDto oluşturup 3 tabloya join yazınız)
    public string CarName { get; set; }
    public string BrandName { get; set; }
    public string ColorName { get; set; }
    public decimal DailyPrice { get; set; }
    
}