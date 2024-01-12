using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepo
    {
        public IEnumerable<Department> GetAllDepartments();
    }
}
