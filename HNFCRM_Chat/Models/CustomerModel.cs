﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace HNFCRM_Chat.Models
{
    public class CustomerModel
    {
        public CUSTOMER Customer;
        public REQUIREPRODUCT RequireProduct;
        public List<STAFF> staff;
        public List<STAFF> liststaff;
        public List<CONTRACT> contract;
        public IPagedList<CUSTOMER> customer;
    }
}