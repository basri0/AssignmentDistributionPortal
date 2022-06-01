using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private IAssignmentService AssignmentService { get; }

        public AssignmentsController(IAssignmentService assignmentService)
        {
            AssignmentService = assignmentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Assignment assignment)
        {
            var result = AssignmentService.Add(assignment);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Assignment assignment)
        {
            var result = AssignmentService.Delete(assignment);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Assignment assignment)
        {
            var result = AssignmentService.Update(assignment);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = AssignmentService.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdto-all")]
        public IActionResult GetDtoAll()
        {
            var result = AssignmentService.GetDtoAll();
            if (result.Status)
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdtoby/user-id/{userId}")]
        public IActionResult GetDtoByUserId(int userId)
        {
            var result = AssignmentService.GetDtoByUserId(userId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdtoby/assignment-id/{assignmentId}")]
        public IActionResult GetDtoByAssignmentId(int assignmentId)
        {
            var result = AssignmentService.GetDtoByAssignmentId(assignmentId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
