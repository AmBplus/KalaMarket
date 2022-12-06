using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithAllParent;

public class GetCategoryAllParentService : IGetCategoryWithAllParentService
{
    public GetCategoryAllParentService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }

    public ResultDto<GetCategoryWithAllParentServiceDto> Execute(long categoryId)
    {
        var result =
            new ResultDto<GetCategoryWithAllParentServiceDto>(new GetCategoryWithAllParentServiceDto());
        var category = Context.Categories.Where(x => x.Id == categoryId).Select(x => new
        {
            parentType = x.CategoryType
        }).FirstOrDefault();
        if (category == null)
        {
            result.Message = string.Format(ErrorMessages.NotFind, PropertiesName.Category);
            return result;
        }

        if (category.parentType == KalaMarketConstants.CategoryType.Category)
            result.Message = ErrorMessages.ItsSelfFather;
        else if (category.parentType == KalaMarketConstants.CategoryType.SubCategory) GetCategory(categoryId, result);

        #region Can Use If Needed Other Category Type

        //else if (category.parentType == KalaMarketConstants.CategoryType.DepartmentCategory)
        //{
        //    GetSubCategory(categoryId, result);
        //}
        //else if (category.parentType == KalaMarketConstants.CategoryType.SubDepartmentCategory)
        //{
        //    GetDepartment(categoryId, result);
        //}

        #endregion

        return result;
    }

    private void GetCategory(long categoryId, ResultDto<GetCategoryWithAllParentServiceDto> result)
    {
        result.Data = Context.Categories.Where(x => x.Id == categoryId).Include(x => x.ParentCategory)
            .Select(x => new GetCategoryWithAllParentServiceDto
            {
                Name = x.Name,
                Id = x.Id,
                ParentId = x.ParentCategoryId,
                CategoryType = x.CategoryType,
                Parent = new GetCategoryWithAllParentServiceDto
                {
                    Name = x.ParentCategory.Name,
                    Id = x.Id,
                    Parent = null,
                    ParentId = x.ParentCategoryId,
                    CategoryType = x.CategoryType
                }
            }).FirstOrDefault();
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
    }


    #region Can Use If Needed Other Category Type Need Refactor

    //private void GetDepartment(long categoryId, ResultDto<GetCategoryWithAllParentServiceDto> result)
    //{
    //    result.Data = Context.Categories.Where(x => x.Id == categoryId)
    //        .Include(x => x.ParentCategory).ThenInclude(x => x.ParentCategory)
    //        .Select(x => new GetCategoryWithAllParentServiceDto
    //        {
    //            Name = x.Name,
    //            Id = x.Id,
    //            ParentId = x.ParentCategoryId,
    //            ParentType = x.ParentType,
    //            Parent = new GetCategoryWithAllParentServiceDto()
    //            {
    //                Name = x.ParentCategory.Name,
    //                Id = x.ParentCategory.Id,
    //                ParentId = x.ParentCategoryId,
    //                ParentType = x.ParentType,
    //                Parent = new GetCategoryWithAllParentServiceDto()
    //                {
    //                    Name = x.ParentCategory.ParentCategory.Name,
    //                    Id = x.ParentCategory.Id,
    //                    ParentId = x.ParentCategory.ParentCategoryId,
    //                    ParentType = x.ParentCategory.ParentCategory.ParentType,
    //                    Parent = new GetCategoryWithAllParentServiceDto()
    //                    {
    //                        ParentType = x.ParentCategory.ParentCategory.ParentCategory.ParentType,
    //                        Name = x.ParentCategory.ParentCategory.ParentCategory.Name,
    //                        Id = x.ParentCategory.ParentCategory.ParentCategory.Id,
    //                    }
    //                }
    //            }
    //        }).FirstOrDefault();
    //    result.IsSuccess = true;
    //    result.Message = Messages.OperationDoneSuccessfully;
    //}

    //private void GetSubCategory(long categoryId, ResultDto<GetCategoryWithAllParentServiceDto> result)
    //{
    //    result.Data = Context.Categories.Where(x => x.Id == categoryId)
    //        .Include(x => x.ParentCategory).ThenInclude(x=>x.ParentCategory)
    //        .Select(x => new GetCategoryWithAllParentServiceDto
    //        {
    //            Name = x.Name,
    //            Id = x.Id,
    //            ParentId = x.ParentCategoryId,
    //            ParentType = x.ParentType,
    //            Parent = new GetCategoryWithAllParentServiceDto()
    //            {
    //                Name = x.ParentCategory.Name,
    //                Id = x.ParentCategory.Id,
    //                ParentId = x.ParentCategoryId,
    //                ParentType = x.ParentType,
    //                Parent =  new GetCategoryWithAllParentServiceDto()
    //                {
    //                    Name = x.ParentCategory.ParentCategory.Name,
    //                    Id = x.ParentCategory.Id,
    //                    ParentId = x.ParentCategory.ParentCategoryId,
    //                    ParentType = x.ParentCategory.ParentCategory.ParentType,
    //                }
    //            }
    //        }).FirstOrDefault();
    //    result.IsSuccess = true;
    //    result.Message = Messages.OperationDoneSuccessfully;
    //} 

    #endregion /Can Use If Needed Other Category Type
}