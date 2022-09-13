using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Validations.Category;
using KalaMarket.Application.Validations.Utility;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.CategoryServices.Commands.AddNewCategory;

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
        if(ValidateRequest(result,request)) return result;
        // Create Category
        Domain.Entities.CategoryAgg.Category category = CreateCategory(request.Name, request.ParentCategoryId);
        // Add To Db
        Context.Categories.Add(category);
        // Try Save To Db
        try
        {
            if (Context.SaveChanges() >0)
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

    private Domain.Entities.CategoryAgg.Category CreateCategory(string name, long? parentCategoryId)
    {
        Domain.Entities.CategoryAgg.Category category = new Domain.Entities.CategoryAgg.Category(name, parentCategoryId);
        if (parentCategoryId != null || parentCategoryId > 0)
        {
            var parentCategory = Context.Categories.FirstOrDefault(x => x.Id == parentCategoryId);
            if (parentCategory != null) category.SetParentCategory(parentCategory);
        }
        return category;
    }

    private bool ValidateRequest(ResultDto result ,RequestAddNewCategoryDto request)
    {
        AddCategoryDtoValidation dtoValidation = new AddCategoryDtoValidation();
        var validateResult =dtoValidation.Validate(request);
        if (validateResult.Errors.Count > 0)
        {
            result.Message = validateResult.Errors.ToStringError();
            return true;
        }

        return false;
    }

    #endregion /Methods
}