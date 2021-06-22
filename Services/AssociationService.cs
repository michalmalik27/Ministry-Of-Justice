using Microsoft.Extensions.Options;
using MinistryOfJustice.Models;
using MinistryOfJustice.Models.Repository;
using MinistryOfJustice.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MinistryOfJustice.Services
{
    public class AssociationService : IAssociationService
    {
        private readonly IAssociationRepository _associationRepository;
        private readonly IMailService _mailService;
        private readonly MailSettings _mailSettings;

        const int MIN_DONATION_AMOUNT_SEND_EMAIL = 10000;

        public AssociationService(
            IAssociationRepository associationRepository, 
            IMailService mailService,
            IOptions<MailSettings> mailSettings)
        {
            _associationRepository = associationRepository;
            _mailService = mailService;
            _mailSettings = mailSettings.Value;
        }

        public IEnumerable<Association> GetAll()
        {
            return _associationRepository.GetAll();
        }

        public Association Get(int id)
        {
            return _associationRepository.Get(id);
        }

        public void Add(Association association)
        {
            if (!Validate(association, out ICollection<ValidationResult> results))
                throw new Exception(string.Join("\n", results.Select(o => o.ErrorMessage)));

            _associationRepository.Add(association);

            if(association.DonationAmount > MIN_DONATION_AMOUNT_SEND_EMAIL)
                _mailService.SendEmailAsync(new MailRequest
                {
                    Body = $"מספר התרומה: {association.AssociationId}, סכום: {association.DonationAmount}",
                    Subject = "התראה על תרומה גבוהה",
                    ToEmail = _mailSettings.Mail
                });
        }

        public void Update(Association association)
        {
            if (!Validate(association, out ICollection<ValidationResult> results))
                throw new Exception(string.Join("\n", results.Select(o => o.ErrorMessage)));

            if (association.DonationAmount > MIN_DONATION_AMOUNT_SEND_EMAIL)
                _mailService.SendEmailAsync(new MailRequest
                {
                    Body = $"מספר התרומה: {association.AssociationId}, סכום: {association.DonationAmount}",
                    Subject = "התראה על תרומה גבוהה",
                    ToEmail = _mailSettings.Mail
                });

            _associationRepository.Update(association);
        }

        public void Delete(int id)
        {
            _associationRepository.Delete(id);
        }

        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
