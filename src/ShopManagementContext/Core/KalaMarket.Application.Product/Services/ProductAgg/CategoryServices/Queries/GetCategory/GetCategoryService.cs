using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategory;

public class GetCategoryService : IGetCategoryService
{
    #region Constructor

    public GetCategoryService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Property

    private IKalaMarketContext Context { get; }

    #endregion /Property

    #region Methods

    public ResultDto<GetCategoryServiceDto> Execute(long id)
    {
        ResultDto<GetCategoryServiceDto> result = new ResultDto<GetCategoryServiceDto>(new GetCategoryServiceDto());
        var category = Context.Categories.FirstOrDefault(x => x.Id == id);
        if (category == null)
        {
            result.Message = string.Format(ErrorMessages.NotFind, PropertiesName.Category);
            return result;
        }

        result.Data.Id = category.Id;
        result.Data.Name = category.Name;
        result.Message = Messages.OperationDoneSuccessfully;
        return result;
    }

    #endregion /Methods
}