using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
   public  class RepositoryBase<Entity,Context>
        where Entity:class,new()
       where Context: DbContext,new()

    {
        Context db = new Context();
        public void AddorUpdate(Entity entity)
        {
            db.Set<Entity>().AddOrUpdate(entity);
        }

        public void Delete(Expression<Func<Entity,bool>> obj)
        {
            var model = db.Set<Entity>().FirstOrDefault(obj);
            db.Set <Entity>().Remove(model);
        
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public List<Entity>Getlist(Expression<Func<Entity,bool>> obj=null)
        {
            List<Entity> List;
            if (obj == null)
                
              List = db.Set<Entity>().ToList();
           
         else
                List = db.Set<Entity>().Where(obj).ToList();
            return List;

        }
        public Entity GetByFilter( Expression<Func<Entity, bool>> obj = null)
        {
            return db.Set<Entity>().FirstOrDefault(obj);
        }

        
    }
}
