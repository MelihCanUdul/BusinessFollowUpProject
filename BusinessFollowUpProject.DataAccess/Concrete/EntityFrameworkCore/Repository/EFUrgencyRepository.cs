using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EFUrgencyRepository :EFGenericRepository<Urgency>,IUrgency
    {
    }
}
