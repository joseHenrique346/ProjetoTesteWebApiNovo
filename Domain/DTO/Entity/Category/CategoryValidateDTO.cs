﻿using Arguments.Argument.Registration.Category;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.Category
{
    public class CategoryValidateDTO : BaseValidateDTO_1<InputCreateCategory, InputUpdateCategory, InputIdentityDeleteCategory>
    {
        public InputCreateCategory InputCreateCategory { get; private set; }
        public string? RepeatedCode { get; set; }

        public InputUpdateCategory InputUpdate { get; private set; }
        public CategoryDTO? OriginalCategory { get; set; }

        public InputIdentityUpdateCategory InputIdentityUpdateCategory { get; private set; }

        public InputIdentityDeleteCategory InputIdentityDeleteCategory { get; private set; }
        public long? OriginalCategoryId { get; set; }

        public CategoryValidateDTO() { }

        public CategoryValidateDTO ValidateCreate(InputCreateCategory inputCreateCategory, string repeatedCode)
        {
            InputCreateCategory = inputCreateCategory;
            RepeatedCode = repeatedCode;
            return this;
        }

        public CategoryValidateDTO ValidateUpdate(InputUpdateCategory inputUpdate, CategoryDTO originalCategory)
        {
            InputUpdate = inputUpdate;
            OriginalCategory = originalCategory;
            return this;
        }

        public CategoryValidateDTO ValidateDelete(InputIdentityDeleteCategory inputIdentityDeleteCategory, long? originalCategoryId)
        {
            InputIdentityDeleteCategory = inputIdentityDeleteCategory;
            OriginalCategoryId = originalCategoryId;
            return this;
        }
    }
}