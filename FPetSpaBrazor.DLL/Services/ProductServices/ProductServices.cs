using FPetSpaBrazor.DAL;
using FPetSpaBrazor.DAL.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPetSpaBrazor.DLL.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;    
        }

        public async Task<List<Product>> getAll()
        {
            await Task.Delay(1000); 

            var list = _unitOfWork.ProductRepository.GetAll();
            if (!list.IsNullOrEmpty())
            {
                return list;
            }
            else if (list.Count == 0)
            {
                return new List<Product>();
            }
            return null;
        }
    }
}
