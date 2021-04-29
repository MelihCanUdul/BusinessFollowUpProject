using BusinessFollowUpProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Interfaces
{
    public interface IGeneric<Table> where Table:class,ITable,new()

    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetId(int id);
        List<Table> GetAll();
    }
}
