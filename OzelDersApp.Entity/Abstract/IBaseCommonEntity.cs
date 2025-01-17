﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Entity.Abstract
{
    public interface IBaseCommonEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
