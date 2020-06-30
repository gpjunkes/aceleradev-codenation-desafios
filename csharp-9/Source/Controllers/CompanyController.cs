using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        private IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = _companyService.FindById(id);
            return Ok(_mapper.Map<CompanyDTO>(company));
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId == null && userId == null)
               || accelerationId != null && userId != null)
            {
                return NoContent();
            }

            IList<Company> result = null;

            if (accelerationId != null)
            {
                result = _companyService.FindByAccelerationId(accelerationId.Value);
            }
            if (userId != null)
            {
                result = _companyService.FindByUserId(userId.Value);
            }

            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(result).ToList());
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            var dados = _mapper.Map<Company>(value);
            var registroSalvo = _companyService.Save(dados);

            return Ok(_mapper.Map<CompanyDTO>(registroSalvo));
        }
    }
}
