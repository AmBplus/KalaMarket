using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Validations;
using KalaMarket.Application.Validations.Utility;
using KalaMarket.Domain.Entities.CategoryAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.Commands.AddNewCategory;

public class AddNewCategory : IAddNewCategory
{
    #region Constructor

    public AddNewCategory(IKalaMarketContext context)
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
        Category category = CreateCategory(request.Name, request.ParentCategoryId);
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

    private Category CreateCategory(string name, long? parentCategoryId)
    {
        Category category = new Category(name, parentCategoryId);
        if (parentCategoryId != null || parentCategoryId > 0)
        {
            var parentCategory = Context.Categories.FirstOrDefault(x => x.Id == parentCategoryId);
            if (parentCategory != null) category.SetParrentCategory(parentCategory);
        }
        return category;
    }

    private bool ValidateRequest(ResultDto result ,RequestAddNewCategoryDto request)
    {
        CategoryValidation validation = new CategoryValidation();
        var validateResult =validation.Validate(request);
        if (validateResult.Errors.Count > 0)
        {
            result.Message = validateResult.Errors.ErrosToString();
            return true;
        }

        return false;
    }

    #endregion /Methods
}