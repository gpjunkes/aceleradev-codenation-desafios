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
    public class AccelerationController : ControllerBase
    {
        private IAccelerationService _accelerationService;
        private IMapper _mapper;

        public AccelerationController(IAccelerationService accelerationService, IMapper mapper)
        {
            _accelerationService = accelerationService;
            _mapper = mapper;
        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var company = _accelerationService.FindById(id);
            return Ok(_mapper.Map<AccelerationDTO>(company));
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == null)
                return NoContent();            

            var result = _accelerationService.FindByCompanyId(companyId.Value);
            return Ok(_mapper.Map<IEnumerable<AccelerationDTO>>(result).ToList());
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] AccelerationDTO value)
        {
            var dados = _mapper.Map<Acceleration>(value);
            var registroSalvo = _accelerationService.Save(dados);

            return Ok(_mapper.Map<AccelerationDTO>(registroSalvo));
        }
    }
}
