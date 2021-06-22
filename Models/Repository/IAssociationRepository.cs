using System.Collections.Generic;

namespace MinistryOfJustice.Models.Repository
{
    public interface IAssociationRepository
    {
        IEnumerable<Association> GetAll();
        Association Get(int id);
        void Add(Association association);
        void Update(Association association);
        void Delete(int id);
    }
}
