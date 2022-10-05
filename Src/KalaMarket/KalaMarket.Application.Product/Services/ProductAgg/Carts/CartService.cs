using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Product.Services.ProductAgg.Carts;

public class CartService : ICartService
{

    public CartService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private ResultDto Result { get; set; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ResultDto Add(long productId, Guid deviceId)
    {
        var cart = Context.Carts.Where(x => x.DeviceId == deviceId && !x.Finished).FirstOrDefault();
        if (cart == null)
        {
            cart = new Cart(deviceId);
            Context.Carts.Add(cart);
            Context.SaveChanges();
        }

        var product = Context.Products.Where(x => x.Id == productId).FirstOrDefault();
        var cartItem = Context.CartItems.Where(x => x.ProductId == productId && x.CartId == cart.Id).FirstOrDefault();
        if (cartItem != null)
        {
            cartItem.IncreaseCount();
        }
        else
        {
            cartItem = new CartItem(productId, product.Price, 1, cart.Id);
        }

        Context.SaveChanges();
        Result = new ResultDto()
        {
            Message = "محصول به سبد اضافه شد",
            IsSuccess = true,
        };
        return Result;
    }
    public ResultDto<CartDto> GetMyCart(Guid deviceUserId)
    {
        var result =new ResultDto<CartDto>(new CartDto()
        {
            cartItemDtos = new List<CartItemDto>()
        });
         var listCartItemDto
             = Context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).Where(x => x.DeviceId == deviceUserId)?.Select(x
            =>
            x.CartItems.Select(c =>
                new CartItemDto
                {
                    Count = c.Count,
                    Price = c.Price,
                    ProductName = c.Product.Name,
                })
            ).FirstOrDefault();
         result.Data.cartItemDtos =listCartItemDto;
         result.IsSuccess = true;
         result.Message = Messages.OperationDoneSuccessfully;
         return result;
    }
    public ResultDto RemoveFromCart(long productId, Guid deviceId)
    {
        var cart = Context.CartItems.Where(x => x.Cart.DeviceId == deviceId).FirstOrDefault();
        if (cart != null)
        {
            cart.ChangeRemoveStatus();
            Context.SaveChanges();
            Result = new ResultDto()
            {
                Message = "محصول از سبد شما حذف شد",
                IsSuccess = true,
            };
        }
        else
        {
            Result = new ResultDto()
            {
                IsSuccess = false,
                Message = "محصول یافت نشد",
            };
        }

        return Result;
    }
}