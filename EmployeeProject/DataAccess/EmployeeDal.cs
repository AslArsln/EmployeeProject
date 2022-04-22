using EmployeeProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.DataAccess
{
    public class EmployeeDal : RepositoryBase<Employee, ModelEmployeeEntity>
    {
       public object bringStaff(ModelEmployeeEntity db,Expression<Func<Employee,bool>>obj)
        {
            var model = db.Personellers.Where(obj).Join(db.Birimlers, x => x.BirimID, x => x.BirimID, (p, b) => new
            {

                p.AdiSoyadi,
                p.Adres,
                p.BirimID,
                p.Email,
                p.IsActive,
                p.PersonelID,
                p.Tarih,
                p.Telefon,
                p.BirimAdi
            }).ToList();
            return model;
        
        }
    }
}
