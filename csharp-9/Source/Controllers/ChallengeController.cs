using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService _challengeService;
        private IMapper _mapper;

        public ChallengeController(IChallengeService challengeService, IMapper mapper)
        {
            _challengeService = challengeService;
            _mapper = mapper;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId == null && userId == null)
            {
                return NoContent();
            }

            var result = _challengeService.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value);

            return Ok(_mapper.Map<IEnumerable<ChallengeDTO>>(result).ToList());
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            var dados = _mapper.Map<Models.Challenge>(value);
            var registroSalvo = _challengeService.Save(dados);

            return Ok(_mapper.Map<ChallengeDTO>(registroSalvo));
        }
    }
}
