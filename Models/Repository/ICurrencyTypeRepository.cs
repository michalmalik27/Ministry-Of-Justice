using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryOfJustice.Models.Repository
{
    public interface ICurrencyTypeRepository
    {
        IEnumerable<CurrencyType> GetAll();
    }
}
