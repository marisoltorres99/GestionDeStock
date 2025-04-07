using AutoMapper;
using GestionDeStock.DTOs;
using GestionDeStock.Models;
using GestionDeStock.Repository;

namespace GestionDeStock.Services
{
    public class ProductService : ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO>
    {
        private IRepository<Product> _productRepository;
        private IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            //Errors = new List<string>();
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _productRepository.Get();

            return products.Select(p => _mapper.Map<ProductDTO>(p));
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _productRepository.GetById(id);

            if (product != null)
            {
                var productDTO = _mapper.Map<ProductDTO>(product);

                return productDTO;
            }

            return null;
        }
        public async Task<ProductDTO> Add(ProductInsertDTO productInsertDTO)
        {
            var product = _mapper.Map<Product>(productInsertDTO);

            await _productRepository.Add(product);

            // se guardan los datos en BD
            await _productRepository.Save();

            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }
        public async Task<ProductDTO> Update(int id, ProductUpdateDTO productUpdateDTO)
        {
            var product = await _productRepository.GetById(id);

            if (product != null)
            {
                product = _mapper.Map<ProductUpdateDTO, Product>(productUpdateDTO, product);

                _productRepository.Update(product);
                await _productRepository.Save();

                var productDTO = _mapper.Map<ProductDTO>(product);

                return productDTO;
            }

            return null;
        }
        public async Task<ProductDTO> Delete(int id)
        {
            var product = await _productRepository.GetById(id);

            if (product != null)
            {
                var productDTO = _mapper.Map<ProductDTO>(product);

                _productRepository.Delete(product);
                await _productRepository.Save();

                return productDTO;
            }

            return null;
        }
    }
}
