using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.Carts;

public interface ICartService
{
    ResultDto Add (long productId , Guid deviceId);  
    ResultDto IncreaseCartItemCount (long cartItemId, Guid deviceId);  
    ResultDto DecreaseCartItemCount (long cartItemId , Guid deviceId);  
    ResultDto<CartDto> GetMyCart(Guid deviceUserId);  
    ResultDto RemoveFromCart(long cartItem, Guid deviceId);  
    ResultDto RemoveCart(Guid deviceId);  
}