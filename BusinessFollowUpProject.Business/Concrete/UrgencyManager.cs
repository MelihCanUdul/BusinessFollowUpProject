using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgency _urgency;
        public UrgencyManager(IUrgency urgency)
        {
            _urgency = urgency;
        }
        public void Delete(Urgency table)
        {
            _urgency.Delete(table);
        }

        public List<Urgency> GetAll()
        {
            return _urgency.GetAll();
        }

        public Urgency GetId(int id)
        {
            return _urgency.GetId(id);
        }

        public void Save(Urgency table)
        {
            _urgency.Save(table);
        }

        public void Update(Urgency table)
        {
            _urgency.Update(table);
        }
    }
}
