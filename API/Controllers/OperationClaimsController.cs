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
    public class OperationClaimsController : ControllerBase
    {
        private IOperationClaimService OperationClaimService { get; }

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            OperationClaimService = operationClaimService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] OperationClaim operationClaim)
        {
            var result = OperationClaimService.Add(operationClaim);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] OperationClaim operationClaim)
        {
            var result = OperationClaimService.Delete(operationClaim);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] OperationClaim operationClaim)
        {
            var result = OperationClaimService.Update(operationClaim);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getoperationclaims")]
        public IActionResult GetOperationClaims()
        {
            var result = OperationClaimService.GetOperationClaims();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyoperationclaimid/{operationClaimId}")]
        public IActionResult GetByOperationClaimId(int operationClaimId)
        {
            var result = OperationClaimService.GetByOperationClaimId(operationClaimId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
