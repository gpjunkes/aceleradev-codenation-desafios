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
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;
        private IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            var candidate = _candidateService.FindById(userId, accelerationId, companyId);
            return Ok(_mapper.Map<CandidateDTO>(candidate));
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if ((companyId == null && accelerationId == null)
               || companyId != null && accelerationId != null)
            {
                return NoContent();
            }

            IList<Candidate> result = null;

            if (companyId != null)
            {
                result = _candidateService.FindByCompanyId(companyId.Value);
            }
            if (accelerationId != null)
            {
                result = _candidateService.FindByAccelerationId(accelerationId.Value);
            }

            return Ok(_mapper.Map<IEnumerable<CandidateDTO>>(result).ToList());

        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            var dados = _mapper.Map<Candidate>(value);
            var registroSalvo = _candidateService.Save(dados);

            return Ok(_mapper.Map<CandidateDTO>(registroSalvo));
        }
    }
}
