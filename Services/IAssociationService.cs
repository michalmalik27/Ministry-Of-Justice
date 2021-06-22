using MinistryOfJustice.Models;
using System.Collections.Generic;

namespace MinistryOfJustice.Services
{
    public interface IAssociationService
    {
        public IEnumerable<Association> GetAll();
        public Association Get(int id);
        public void Add(Association association);
        public void Update(Association association);
        public void Delete(int id);
    }
}
