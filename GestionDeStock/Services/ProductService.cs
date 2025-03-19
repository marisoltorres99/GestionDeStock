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

        public async Task<ProductDTO> Add(ProductInsertDTO productInsertDTO)
        {
            var product = _mapper.Map<Product>(productInsertDTO);

            await _productRepository.Add(product);

            // se guardan los datos en BD
            await _productRepository.Save();

            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _productRepository.Get();

            return products.Select(p => _mapper.Map<ProductDTO>(p));
        }

        public Task<ProductDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
