using Microsoft.EntityFrameworkCore;
using MinistryOfJustice.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MinistryOfJustice.Models.DataManager
{
    public class AssociationManager : IAssociationRepository
    {
        readonly MinistryOfJusticeContext _context;

        public AssociationManager(MinistryOfJusticeContext context)
        {
            _context = context;
        }

        public IEnumerable<Association> GetAll()
        {
            return _context.Associations
                .Include(p => p.AssociationType)
                .Include(p => p.CurrencyType)
                .ToList();
        }

        public Association Get(int id)
        {
            return _context.Associations
                .Include(p => p.AssociationType)
                .Include(p => p.CurrencyType)
                .FirstOrDefault(c => c.AssociationId == id);
        }

        public void Add(Association association)
        {
            _context.Associations.Add(association);
            _context.SaveChanges();
        }

        public void Update(Association association)
        {
            var _association = Get(association.AssociationId);

            _association.Name = association.Name;
            _association.AssociationTypeId = association.AssociationTypeId;
            _association.ConversionRate = association.ConversionRate;
            _association.CurrencyTypeId = association.CurrencyTypeId;
            _association.DonationTerms = association.DonationPurpose;
            _association.DonationTerms = association.DonationTerms;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var association = Get(id);
            _context.Associations.Remove(association);
            _context.SaveChanges();
        }
    }
}
