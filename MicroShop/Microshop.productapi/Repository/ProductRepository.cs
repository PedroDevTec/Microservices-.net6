using AutoMapper;
using Microshop.productapi.Config;
using Microshop.productapi.Data.ValueObjects;
using Microshop.productapi.Model;
using Microshop.productapi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace Microshop.productapi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Mysqlcontext _context;
        private IMapper _mapper;

        public ProductRepository(Mysqlcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Productc> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Productc product =
             await _context.Products.Where(p => p.Id == id)
             .FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Productc product = _mapper.Map<Productc>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            Productc product = _mapper.Map<Productc>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Productc product =
                 await _context.Products.Where(p => p.Id == id)
                 .FirstOrDefaultAsync();
                if (product == null) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
