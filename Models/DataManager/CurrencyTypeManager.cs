using Microsoft.EntityFrameworkCore;
using MinistryOfJustice.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MinistryOfJustice.Models.DataManager
{
    public class CurrencyTypeManager : ICurrencyTypeRepository
    {
        readonly MinistryOfJusticeContext _context;

        public CurrencyTypeManager(MinistryOfJusticeContext context)
        {
            _context = context;
        }

        public IEnumerable<CurrencyType> GetAll()
        {
            return _context.CurrencyTypes
                .ToList();
        }
    }
}
