using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Carts;

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

    /// <summary>
    ///     اضاف کردن به سبد خرید در صورت نبود ساختن سبد و اضافه کردن آن
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="deviceId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public ResultDto Add(long productId, Guid deviceId, long? userId = null)
    {
        // پیدا کردن سبد خرید
        var cart = Context.Carts.Where
        (x => (x.DeviceId == deviceId || (x.UserId == userId && userId != null))
              && !x.Finished && !x.IsRemoved).FirstOrDefault();
        // در صورت پیدا نشدن ساختن سبد خرید
        if (cart == null)
        {
            cart = new Cart(deviceId);
            if (userId != null) cart.SetUserId((long)userId);
            Context.Carts.Add(cart);
            Context.SaveChanges();
        }

        // محصول خریداری شده
        var product = Context.Products.Where(x => x.Id == productId).FirstOrDefault();
        // کارت آیتم سبد خرید
        var cartItem = Context.CartItems
            .Where(x => x.ProductId == productId)
            .Where(x => x.CartId == cart.Id)
            .FirstOrDefault(x => !x.IsRemoved);
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
        var result = GetCartItem(cartItemId, deviceId, userId);
        if (!result.IsSuccess)
        {
            Result = new ResultDto
            {
                Message = "همچین کارت آیتمی پیدا نشد",
                IsSuccess = false
            };
            return Result;
        }

        var cartItem = result.Data;
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
        var result = GetCartItem(cartItemId, deviceId, userId);
        if (!result.IsSuccess)
        {
            Result = new ResultDto
            {
                Message = "همچین کارت آیتمی پیدا نشد",
                IsSuccess = false
            };
            return Result;
        }

        var cartItem = result.Data;
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
        // اگر کارتی نبود یک نتیجه خالی برمیگردد که نتیجه زیر است در غیر این صورت حساب میکند
        var result = new ResultDto<CartDto>(new CartDto
        {
            CartItemDtos = new List<CartItemDto>()
        });

        var cartItems
            = Context.Carts
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Images)
                .Where(x => x.DeviceId == deviceUserId)
                .Where(x => userId != null ? x.UserId == userId : true).FirstOrDefault(x => !x.IsRemoved);

        if (cartItems != null)
        {
            if (cartItems.UserId == null && userId != null)
            {
                cartItems.SetUserId((long)userId);
                Context.SaveChanges();
            }

            var cartItemList = cartItems!.CartItems.Where(x => !x.IsRemoved).Select(c => new CartItemDto
            {
                Count = c.Count,
                Price = c.Product.Price,
                ProductName = c.Product.Name,
                ProductImage = c.Product.Images.Select(x => x.Src).FirstOrDefault() ?? "",
                Id = c.Id
            });
            var cartDto = new CartDto
            {
                TotalPrice = cartItems.CartItems.Where(x => !x.IsRemoved).Sum(x => x.Price * x.Count),
                Count = cartItems.CartItems.Where(x => !x.IsRemoved).Count(),
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

    private ResultDto<CartItem> GetCartItem(long cartItemId, Guid deviceId, long? userId = null)
    {
        ResultDto<CartItem> result;
        var queryCartItem = Context.CartItems.Include(x => x.Cart).AsQueryable();
        if (userId != null)
            queryCartItem = queryCartItem.Where(x => x.Cart.UserId == userId && userId != null);
        else
            queryCartItem = queryCartItem.Where(x => x.Cart.DeviceId == deviceId);
        var cartItem = queryCartItem.Where(x => x.Id == cartItemId).FirstOrDefault();
        if (cartItem == null)
        {
            result = new ResultDto<CartItem>(null)
            {
                IsSuccess = false
            };
            return result;
        }

        result = new ResultDto<CartItem>(cartItem)
        {
            IsSuccess = true
        };
        return result;
    }
}