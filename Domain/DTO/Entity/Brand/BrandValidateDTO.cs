﻿using Arguments.Argument.Registration.Brand;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.Brand
{
    public class BrandValidateDTO : BaseValidateDTO
    {
        public InputCreateBrand InputCreate { get; private set; }
        public string? ExistingCode { get; private set; }
        public InputCreateBrand? RepeatedCode { get; private set; }

        public InputUpdateBrand InputUpdate { get; private set; }
        public BrandDTO OriginalBrand { get; set; }

        public InputIdentityUpdateBrand InputIdentityUpdateBrand { get; private set; }
        public InputIdentityUpdateBrand? RepeatedCodeUpdate { get; private set; }

        public InputIdentityDeleteBrand InputIdentityDeleteBrand { get; private set; }
        public long? OriginalBrandId { get; set; }
        public BrandValidateDTO() { }

        public BrandValidateDTO ValidateCreate(InputCreateBrand inputCreate, string? existingCode, InputCreateBrand repeatedCode)
        {
            InputCreate = inputCreate;
            ExistingCode = existingCode;
            RepeatedCode = repeatedCode;
            return this;
        }

        public BrandValidateDTO ValidateUpdate(InputUpdateBrand inputUpdate, BrandDTO originalBrand, string? existingCode, InputIdentityUpdateBrand repeatedCodeUpdate)
        {
            InputUpdate = inputUpdate;
            OriginalBrand = originalBrand;
            ExistingCode = existingCode;
            RepeatedCodeUpdate = repeatedCodeUpdate;
            return this;
        }

        public BrandValidateDTO ValidateDelete(InputIdentityDeleteBrand inputIdentityDeleteBrand, long? originalBrandId)
        {
            InputIdentityDeleteBrand = inputIdentityDeleteBrand;
            OriginalBrandId = originalBrandId;
            return this;
        }
    }
}