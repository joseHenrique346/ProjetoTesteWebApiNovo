using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Product;
using Arguments.Conversor;
using Domain.DTO.Entity.Product;
using Domain.Interface.Repository;
using Domain.Interface.Service.Product;
using Domain.Service.Base;
using Domain.Utils.Helper;
using System.Reflection;

namespace Domain.Service.Registration.Product
{
    public class ProductService : BaseService<ProductDTO, IProductRepository, InputIdentityViewProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, ProductValidateDTO, OutputProduct>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductValidateService _validate;
        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository, IProductValidateService validate) : base(productRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _validate = validate;
        }

        public override async Task<BaseResult<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct)
        {
            var listOriginalBrand = await _brandRepository.GetListByListId(listInputCreateProduct.Select(i => i.BrandId).ToList());
            var listOriginalCategory = await _categoryRepository.GetListByListId(listInputCreateProduct.Select(i => i.CategoryId).ToList());

            var newListProductToValidate = (from i in listInputCreateProduct
                                            select new
                                            {
                                                InputCreate = i,
                                                OriginalBrand = listOriginalBrand.FirstOrDefault(j => i.BrandId == i.BrandId),
                                                OriginalCategory = listOriginalCategory.FirstOrDefault(j => i.CategoryId == i.CategoryId)
                                            }).ToList();

            var newListProductValidateDTO = newListProductToValidate.Select(i => new ProductValidateDTO().ValidateCreate(i.InputCreate, i.OriginalBrand, i.OriginalCategory)).ToList();
            _validate.Update(newListProductValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputProduct>>.Failure(listNotification);

            var validListProduct = (from i in RemoveInvalid(newListProductValidateDTO) where !i.Invalid select i).ToList();
            var newListProductToCreate = (from i in validListProduct
                                          let create = i.InputCreateProduct
                                          select new ProductDTO(create.Code, create.Description, create.BrandId, create.CategoryId, create.Price, create.Stock)).ToList();

            await _productRepository.Create(newListProductToCreate);
            return BaseResult<List<OutputProduct>>.Success(Conversor.GenericConvertList<OutputProduct, ProductDTO>(newListProductToCreate), listNotification);
        }

        public override async Task<BaseResult<List<OutputProduct>>> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct)
        {
            var listOriginalProduct = await _productRepository.GetListByListId(listInputIdentityUpdateProduct.Select(i => i.Id).ToList());
            var listOriginalBrand = await _brandRepository.GetListByListId(listInputIdentityUpdateProduct.Select(i => i.InputUpdateProduct.BrandId).ToList());
            var listOriginalCategory = await _categoryRepository.GetListByListId(listInputIdentityUpdateProduct.Select(i => i.InputUpdateProduct.CategoryId).ToList());

            var newListProductToValidate = (from i in listInputIdentityUpdateProduct
                                            select new
                                            {
                                                InputUpdate = i.InputUpdateProduct,
                                                OriginalProduct = listOriginalProduct.FirstOrDefault(j => i.Id == j.Id),
                                                OriginalBrand = listOriginalBrand.FirstOrDefault(j => i.InputUpdateProduct.BrandId == j.Id),
                                                OriginalCategory = listOriginalCategory.FirstOrDefault(j => i.InputUpdateProduct.CategoryId == j.Id)
                                            }).ToList();

            var newListProductValidateDTO = newListProductToValidate.Select(i => new ProductValidateDTO().ValidateUpdate(i.InputUpdate, i.OriginalProduct, i.OriginalBrand, i.OriginalCategory)).ToList();
            _validate.Update(newListProductValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputProduct>>.Failure(listNotification);

            var validListProduct = (from i in RemoveInvalid(newListProductValidateDTO) where !i.Invalid select i).ToList();
            
            (from i in validListProduct
             select UpdateDTO<ProductDTO, InputUpdateProduct>(i.OriginalProduct, i.InputUpdate)).ToList();

            var originalProductListToUpdate = validListProduct.Select(i => i.OriginalProduct).ToList();

            await _productRepository.Update(originalProductListToUpdate);
            return BaseResult<List<OutputProduct>>.Success(Conversor.GenericConvertList<OutputProduct, ProductDTO>(originalProductListToUpdate), listNotification);
        }

        public override async Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteProduct> listInputIdentityDeleteProduct)
        {
            var listOriginalProduct = await _productRepository.GetListByListId(listInputIdentityDeleteProduct.Select(i => i.Id).ToList());
            var newListProductsToValidate = (from i in listInputIdentityDeleteProduct
                                             select new
                                             {
                                                 InputDelete = i,
                                                 OriginalProduct = listOriginalProduct.FirstOrDefault(j => j.Id == i.Id)
                                             }).ToList();

            var newListProductValidateDTO = newListProductsToValidate.Select(i => new ProductValidateDTO().ValidateDelete(i.InputDelete, i.OriginalProduct)).ToList();
            _validate.Delete(newListProductValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<bool>.Failure(listNotification);

            var validListProduct = (from i in RemoveInvalid(newListProductValidateDTO) where !i.Invalid select i).ToList();
            await _productRepository.Delete(Conversor.GenericConvertList<ProductDTO, ProductValidateDTO>(validListProduct));

            return BaseResult<bool>.Success(true, listNotification);
        }

        public Task<List<ProductDTO>> GetListByListId(List<InputIdentityViewProduct> listInputIdentityView)
        {
            throw new NotImplementedException();
        }

        public static TOutput setValue<TOutput>(PropertyInfo property, TOutput output, object? value)
        {
            property.SetValue(output, value);
            return output;
        }
    }
}