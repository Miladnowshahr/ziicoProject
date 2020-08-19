using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.TagVM
{
    public class TagValueViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TagShowViewModel Tag { get; set; }
        public string Creator { get; set; }

        public string CreateDate { get; set; }

        public string LastModifier { get; set; }

        public string LastModifyDate { get; set; }

        public State State { get; set; }
    }
}
