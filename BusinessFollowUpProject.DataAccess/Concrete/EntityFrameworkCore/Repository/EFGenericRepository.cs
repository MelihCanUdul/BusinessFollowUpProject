using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository
{

    public class EFGenericRepository<Table> : IGeneric<Table> where Table : class,ITable, new()
    {
        public void Delete(Table table)
        {
            using var context = new BusinessFollowUpProjectContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public List<Table> GetAll()
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Set<Table>().ToList();
        }

        public Table GetId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Set<Table>().Find(id);
        }

        public void Save(Table table)
        {
            using var context = new BusinessFollowUpProjectContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Update(Table table)
        {
            using var context = new BusinessFollowUpProjectContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }

        public interface INotice
        {
        }
    }
}
