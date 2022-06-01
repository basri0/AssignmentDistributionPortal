using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private IUserOperationClaimService UserOperationClaimService { get; }

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            UserOperationClaimService = userOperationClaimService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            var result = UserOperationClaimService.Add(userOperationClaim);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(UserOperationClaim userOperationClaim)
        {
            var result = UserOperationClaimService.Delete(userOperationClaim);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(UserOperationClaim  userOperationClaim)
        {
            var result = UserOperationClaimService.Update(userOperationClaim);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-user-operation-claims")]
        public IActionResult GetUserOperationClaims()
        {
            var result = UserOperationClaimService.GetUserOperationClaims();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = UserOperationClaimService.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("[action]/{userEmail}")]
        public IActionResult GetByUserEmail(string userEmail)
        {
            var result = UserOperationClaimService.GetByUserEmail(userEmail);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-by-user-id{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = UserOperationClaimService.GetByUserId(userId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
