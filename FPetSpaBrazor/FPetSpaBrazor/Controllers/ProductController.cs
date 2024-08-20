using FPetSpaBrazor.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FPetSpaBrazor.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> getAllProduct()
        {
            var list = _unitOfWork.ProductRepository.GetAll();
            if(list != null)
            {
                return Ok(list);
            }
                return BadRequest("Something went wrong!!!");
        }
    }
}
