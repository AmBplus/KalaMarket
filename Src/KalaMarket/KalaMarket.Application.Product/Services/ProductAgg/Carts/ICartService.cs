using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.Carts;

public interface ICartService
{
    ResultDto Add (long productId , Guid deviceId , long? userId = null);  
    ResultDto IncreaseCartItemCount (long cartItemId, Guid deviceId , long? userId = null);  
    ResultDto DecreaseCartItemCount (long cartItemId , Guid deviceId , long? userId = null);  
    ResultDto<CartDto> GetMyCart(Guid deviceUserId , long? userId = null);  
    ResultDto RemoveFromCart(long cartItem, Guid deviceId , long? userId = null) ;  
    ResultDto RemoveCart(Guid deviceId, long? userId = null);  
}