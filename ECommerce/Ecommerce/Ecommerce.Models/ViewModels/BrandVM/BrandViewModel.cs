using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Models.ViewModels.BrandVM
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }

        public string Creator { get; set; }

        public string CreateDate { get; set; }

        public string LastModifier { get; set; }

        public string LastModifyDate { get; set; }

        public State State { get; set; }

    }
}
