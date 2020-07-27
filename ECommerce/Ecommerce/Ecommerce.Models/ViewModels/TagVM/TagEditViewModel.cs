using ECommerce.Models.Model.Products.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.TagVM
{
    public class TagEditViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public State State { get; set; }
    }
}
