using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration
{
    public class BrandService : BaseService<BrandDTO, IBrandRepository, InputIdentityViewBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand>
    {
        public BrandService(IBrandRepository repository) : base(repository) { }
    }
}
