using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.GroupVM
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }
        public string State { get; set; }
        public string Creator { get; set; }

        public string CreateDate { get; set; }

        public string LastModifier { get; set; }

        public string LastModifyDate { get; set; }

    }
}
