﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.GroupVM
{
    public class EditGroupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }
        public string State { get; set; }
    }
}
