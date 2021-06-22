using System.Collections.Generic;

namespace MinistryOfJustice.Models.Repository
{
    public interface IAssociationTypeRepository
    {
        IEnumerable<AssociationType> GetAll();
    }
}
