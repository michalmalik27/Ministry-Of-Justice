using Microsoft.EntityFrameworkCore;
using MinistryOfJustice.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MinistryOfJustice.Models.DataManager
{
    public class AssociationTypeManager : IAssociationTypeRepository
    {
        readonly MinistryOfJusticeContext _context;

        public AssociationTypeManager(MinistryOfJusticeContext context)
        {
            _context = context;
        }

        public IEnumerable<AssociationType> GetAll()
        {
            return _context.AssociationTypes
                .ToList();
        }
    }
}
