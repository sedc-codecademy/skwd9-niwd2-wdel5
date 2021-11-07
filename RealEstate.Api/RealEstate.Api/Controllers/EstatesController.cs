using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EstatesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRepository<Estate> _estatesRepository;

        public EstatesController(IUserService userService,
                                IRepository<Estate> estatesRepository)
        {
            _userService = userService;
            _estatesRepository = estatesRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { messaga = "Username or password incorect" });

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Estates()
        {
            try
            {
                return Ok(await _estatesRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Estates(int id)
        {
            try
            {
                return Ok(await _estatesRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Estate estate)
        {
            try
            {
                return Ok(await _estatesRepository.Insert(estate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] Estate estate)
        {
            try
            {
                return Ok(await _estatesRepository.Update(estate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete/{id?}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _estatesRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
