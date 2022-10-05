using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.Carts;

public interface ICartService
{
    ResultDto Add (long productId , Guid deviceId);  
    ResultDto<CartDto> GetMyCart(Guid deviceUserId);  
    ResultDto RemoveFromCart(long productId , Guid deviceId);  
}