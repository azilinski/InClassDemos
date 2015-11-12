using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using RevertSystem.DAL;
using RevertSystem.Entities;
using System.ComponentModel;
#endregion

namespace RevertSystem.BLL
{
    public class AdminController
    {

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Employee> EntityList()
        {
            using(RevertContext context = new RevertContext())
            {
                return context.Employees.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Employee> QueryNav_List()
        {
            using (RevertContext context = new RevertContext())
            {
                var results = from item in context.EmployeeSkills
                              where item.SkillID == 8
                              select item.Employee;
                return results.ToList();
            }
        }

    }
}
