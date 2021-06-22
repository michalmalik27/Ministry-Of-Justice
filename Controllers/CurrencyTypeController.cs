using MinistryOfJustice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MinistryOfJustice.Models.Repository;
using MinistryOfJustice.ApiErrors;
using MinistryOfJustice.Services;

namespace MinistryOfJustice.Controller
{
    [Route("api/currency-type")]
    [ApiController]
    public class CurrencyTypeController : ControllerBase
    {
        private readonly ICurrencyTypeRepository _currencyTypeRepository;
        private readonly IMailService _mailService;

        public CurrencyTypeController(ICurrencyTypeRepository currencyTypeRepository, IMailService mailService)
        {
            _currencyTypeRepository = currencyTypeRepository;
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var currencyTypes = _currencyTypeRepository.GetAll();
                return Ok(currencyTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));

            }
        }
    }
}
