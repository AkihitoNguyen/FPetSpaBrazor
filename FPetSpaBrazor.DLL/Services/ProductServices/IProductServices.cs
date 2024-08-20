using FPetSpaBrazor.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPetSpaBrazor.DLL.Services.ProductServices
{
    public interface IProductServices
    {
        public Task<List<Product>> getAll();

    }
}
