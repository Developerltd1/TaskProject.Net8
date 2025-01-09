using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Domain.SubCategory
{
    public class SubCategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ParentCategoryID { get; set; }

        public string Path { get; set; }
        public int CategoryLevel { get; set; }
        public string? Icon { get; set; }





    }
}
