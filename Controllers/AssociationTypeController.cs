using MinistryOfJustice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MinistryOfJustice.Models.Repository;
using MinistryOfJustice.ApiErrors;

namespace MinistryOfJustice.Controller
{
    [Route("api/association-type")]
    [ApiController]
    public class AssociationTypeController : ControllerBase
    {
        private readonly IAssociationTypeRepository _associationTypeRepository;

        public AssociationTypeController(IAssociationTypeRepository associationTypeRepository)
        {
            _associationTypeRepository = associationTypeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var associationTypes = _associationTypeRepository.GetAll();
                return Ok(associationTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));

            }
        }
    }
}
