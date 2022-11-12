using System.Security.Cryptography.X509Certificates;
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

    public ResultDto Add(long productId, Guid deviceId, long? userId = null)
    {
        var cart = Context.Carts.Where
        (x => (x.DeviceId == deviceId || (x.UserId == userId && userId != null))
              && !x.Finished && !x.IsRemoved).FirstOrDefault();
        if (cart == null)
        {
            cart = new Cart(deviceId);
            Context.Carts.Add(cart);
            Context.SaveChanges();
        }

        var product = Context.Products.Where(x => x.Id == productId).FirstOrDefault();
        var cartItem = Context.CartItems.Where(x => x.ProductId == productId && x.CartId == cart.Id && !x.IsRemoved)
            .FirstOrDefault();
        if (cartItem != null)
        {
            cartItem.IncreaseCount();
        }
        else
        {
            cartItem = new CartItem(productId, product.Price, 1, cart.Id);
            Context.CartItems.Add(cartItem);
        }

        Context.SaveChanges();
        Result = new ResultDto
        {
            Message = "محصول به سبد اضافه شد",
            IsSuccess = true
        };
        return Result;
    }

    public ResultDto IncreaseCartItemCount(long cartItemId, Guid deviceId, long? userId = null)
    {
        var cartItem = Context.CartItems.Include(x => x.Cart)
            .Where(x => x.Cart.DeviceId == deviceId || (x.Cart.UserId == userId && userId != null))
            .Where(x => x.Id == cartItemId).FirstOrDefault();
        if (cartItem == null)
        {
            Result = new ResultDto
            {
                Message = "همچین کارت آیتمی پیدا نشد",
                IsSuccess = false
            };
            return Result;
        }

        cartItem.IncreaseCount();
        Context.SaveChanges();
        Result = new ResultDto
        {
            Message = "تعداد محصول در سبد افزایش یافت",
            IsSuccess = true
        };
        return Result;
    }

    public ResultDto DecreaseCartItemCount(long cartItemId, Guid deviceId, long? userId = null)
    {
        var cartItem = Context.CartItems.Include(x => x.Cart)
            .Where(x => x.Cart.DeviceId == deviceId || (x.Cart.UserId == userId && userId != null))
            .Where(x => x.Id == cartItemId).FirstOrDefault();
        if (cartItem == null)
        {
            Result = new ResultDto
            {
                Message = "همچین کارت آیتمی پیدا نشد",
                IsSuccess = false
            };
            return Result;
        }

        if (cartItem.DecreaseCount())
        {
            Context.SaveChanges();
            Result = new ResultDto
            {
                Message = "تعداد محصول در سبد افزایش یافت",
                IsSuccess = true
            };
        }
        else
        {
            Result = new ResultDto
            {
                Message = "نمیتوان از صفر کمتر کرد",
                IsSuccess = false
            };
        }

        return Result;
    }

    public ResultDto<CartDto> GetMyCart(Guid deviceUserId, long? userId = null)
    {
        var result = new ResultDto<CartDto>(new CartDto
        {
            CartItemDtos = new List<CartItemDto>()
        });
        var cartItemDto
            = Context.Carts
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Images)
                .Where(x => x.DeviceId == deviceUserId)
                .Where(x => (userId != null) ? (x.UserId == userId) : true).FirstOrDefault(x => !x.IsRemoved);
        if (cartItemDto != null)
        {
            var cartItemList = cartItemDto!.CartItems.Where(x => !x.IsRemoved).Select(c => new CartItemDto
            {
                Count = c.Count,
                Price = c.Price,
                ProductName = c.Product.Name,
                ProductImage = c.Product.Images.Select(x => x.Src).FirstOrDefault() ?? "",
                Id = c.Id
            });
            CartDto cartDto = new CartDto()
            {
                TotalPrice = cartItemDto.CartItems.Where(x => !x.IsRemoved).Sum(x => x.Price),
                Count = cartItemDto.CartItems.Where(x => !x.IsRemoved).Count(),
                CartItemDtos = new List<CartItemDto>(cartItemList)
            };
            result.Data = cartDto;
            result.IsSuccess = true;
            result.Message = Messages.OperationDoneSuccessfully;
        }
        
        return result;
    }

    public ResultDto RemoveFromCart(long cartItemId, Guid deviceId, long? userId = null)
    {
        var cart = Context.CartItems
            .Include(x => x.Cart)
            .Where(x => x.Id == cartItemId &&
                        (x.Cart.DeviceId == deviceId || (x.Cart.UserId == userId && userId != null))).FirstOrDefault();
        if (cart != null)
        {
            cart.ChangeRemoveStatus();
            Context.SaveChanges();
            Result = new ResultDto
            {
                Message = "محصول از سبد شما حذف شد",
                IsSuccess = true
            };
        }
        else
        {
            Result = new ResultDto
            {
                IsSuccess = false,
                Message = "محصول در سبد شما یافت نشد"
            };
        }

        return Result;
    }

    public ResultDto RemoveCart(Guid deviceId, long? userId = null)
    {
        var cart = Context.Carts.Where(x => x.DeviceId == deviceId || (x.UserId == userId && userId != null))
            .FirstOrDefault();
        if (cart == null)
            return new ResultDto
            {
                Message = "سبدی برای حذف وجود نداشت",
                IsSuccess = false
            };

        cart.ChangeRemoveStatus();
        Context.SaveChanges();
        return new ResultDto
        {
            Message = "سبد حذف شد",
            IsSuccess = true
        };
    }
}