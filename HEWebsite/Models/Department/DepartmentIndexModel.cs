using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Models.Department
{
    public class DepartmentIndexModel
    {
        public IEnumerable<DepartmentListingModel> DepartmentList { get; set; }
    }
}
