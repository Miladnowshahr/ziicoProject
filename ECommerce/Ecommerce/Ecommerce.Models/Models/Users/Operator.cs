﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.Model.Users
{
    public class Operator: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
