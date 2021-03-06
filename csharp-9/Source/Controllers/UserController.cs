﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {            
            if ( (string.IsNullOrEmpty(accelerationName) && companyId == null)
               || !string.IsNullOrEmpty(accelerationName) && companyId != null)
            {
                return NoContent();
            }

            IList<User> result = null;

            if (!string.IsNullOrEmpty(accelerationName))
            {
                result = _userService.FindByAccelerationName(accelerationName);
            }
            if (companyId != null)
            {
                result = _userService.FindByCompanyId(companyId.Value);
            }

            return Ok(_mapper.Map<IEnumerable<UserDTO>>(result).ToList());
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userService.FindById(id);
            return Ok(_mapper.Map<UserDTO>(user));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            var dadosUser = _mapper.Map<User>(value);
            var usuarioSalvo = _userService.Save(dadosUser);

            return Ok(_mapper.Map<UserDTO>(usuarioSalvo));


        }   
     
    }
}
