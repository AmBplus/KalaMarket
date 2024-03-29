﻿using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Validations.Category;
using KalaMarket.Application.Utility;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.EditCategory;

public class EditCategoryService : IEditCategoryService
{
    #region Constructor

    public EditCategoryService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion

    #region Property

    private IKalaMarketContext Context { get; }

    #endregion /Property

    #region Methods

    public ResultDto Execute(RequestEditCategoryDto request)
    {
        var result = new ResultDto();
        // Check Valid request
        if (ValidateRequestEditCategoryDto(request, result)) return result;
        // Edit category
        var category = UpdateCategory(request);
        // Try save changes
        try
        {
            if (Context.SaveChanges() > 0)
            {
                result.Message = Messages.OperationDoneSuccessfully;
                result.IsSuccess = true;
            }
        }
        catch (Exception e)
        {
            result.Message = ErrorMessages.ProblemOccurred;
        }

        // return
        return result;
    }

    private Category UpdateCategory(RequestEditCategoryDto request)
    {
        var category = Context.Categories.FirstOrDefault(x => x.Id == request.id);
        if (category.ParentCategoryId != request.ParentCategoryId)
        {
            var parentCategory = Context.Categories.FirstOrDefault(x => x.Id == request.ParentCategoryId);
            if (parentCategory != null)
            {
                category.UpdateCategory(request.Name, parentCategory.Id, parentCategory.CategoryType,
                    parentCategory.Name);
                return category;
            }
        }

        category.UpdateCategory(request.Name);
        return category;
    }

    private bool ValidateRequestEditCategoryDto(RequestEditCategoryDto request, ResultDto resultDto)
    {
        var validation = new EditCategoryDtoValidation();
        var validateResult = validation.Validate(request);
        return validateResult.ValidateResultHasError(resultDto);
    }

    #endregion /Methods
}