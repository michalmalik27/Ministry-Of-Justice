using MinistryOfJustice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MinistryOfJustice.Services;
using MinistryOfJustice.ApiErrors;

namespace MinistryOfJustice.Controller
{
    [Route("api/association")]
    [ApiController]
    public class AssociationController : ControllerBase
    {
        private readonly IAssociationService _associationService;

        public AssociationController(IAssociationService associationService)
        {
            _associationService = associationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var associations = _associationService.GetAll();
                return Ok(associations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));

            }
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                Association association = _associationService.Get(id);
                if (association == null)
                {
                    return NotFound(new NotFoundError("The association not exists."));
                }
                return Ok(association);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));
            }
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _associationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Association association)
        {
            try
            {
                if (association == null)
                {
                    return BadRequest(new BadRequestError("Association is null."));
                }

                _associationService.Add(association);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Association association)
        {
            try
            {
                if (association == null)
                {
                    return BadRequest(new BadRequestError("Association is null."));
                }

                _associationService.Update(association);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));
            }
        }
    }
}
