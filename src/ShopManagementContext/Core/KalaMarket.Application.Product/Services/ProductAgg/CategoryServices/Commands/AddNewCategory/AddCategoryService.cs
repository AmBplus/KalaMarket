using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Validations.Category;
using KalaMarket.Application.Utility;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;

public class AddCategoryService : IAddCategoryService
{
    #region Constructor

    public AddCategoryService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Property

    private IKalaMarketContext Context { get; }

    #endregion

    #region Methods

    public ResultDto Execute(RequestAddNewCategoryDto request)
    {
        ResultDto result = new();
        // Check Has Error-es
        if (ValidateRequest(result, request)) return result;
        // Create Category
        var category = CreateCategory(request);
        // Add To Db
        Context.Categories.Add(category);
        // Try Save To Db
        try
        {
            if (Context.SaveChanges() > 0)
            {
                result.IsSuccess = true;
                result.Message = Messages.OperationDoneSuccessfully;
            }
        }
        catch (Exception e)
        {
            result.Message = ErrorMessages.ProblemOccurred;
        }

        // return
        return result;
    }

    private Category CreateCategory(RequestAddNewCategoryDto request)
    {
        Category category;
        if (request.ParentCategoryId != null || request.ParentCategoryId > 0)
        {
            var parentCategory = Context.Categories.FirstOrDefault(x => x.Id == request.ParentCategoryId);
            if (parentCategory != null)
            {
                category = new Category(request.Name,
                    (byte)(parentCategory.CategoryType + KalaMarketConstants.CategoryType.Category),
                    request.ParentCategoryId, parentCategory.Name);
                return category;
            }
        }

        category = new Category(request.Name, request.CategoryType);

        return category;
    }

    private bool ValidateRequest(ResultDto result, RequestAddNewCategoryDto request)
    {
        var dtoValidation = new AddCategoryDtoValidation();
        var validateResult = dtoValidation.Validate(request);
        return validateResult.ValidateResultHasError(result);
    }

    #endregion /Methods
}