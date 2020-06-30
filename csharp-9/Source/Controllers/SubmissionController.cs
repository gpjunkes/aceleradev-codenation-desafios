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
    public class SubmissionController : ControllerBase
    {
        private ISubmissionService _submissionService;
        private IMapper _mapper;

        public SubmissionController(ISubmissionService submissionService, IMapper mapper)
        {
            _submissionService = submissionService;
            _mapper = mapper;
        }

        // GET api/submission/higherScore
        [HttpGet("submission/higherScore")]
        public ActionResult<decimal> GetHigherScore(int? challengeId)
        {
            if (challengeId == null)
                return NoContent();

            var result = _submissionService.FindHigherScoreByChallengeId(challengeId.Value);
            return Ok(result);
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if (challengeId == null && accelerationId == null)
                return NoContent();
                        
            var result = _submissionService.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value);
            return Ok(_mapper.Map<IEnumerable<SubmissionDTO>>(result).ToList());
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            var dados = _mapper.Map<Submission>(value);
            var registroSalvo = _submissionService.Save(dados);

            return Ok(_mapper.Map<SubmissionDTO>(registroSalvo));
        }
    }
}
