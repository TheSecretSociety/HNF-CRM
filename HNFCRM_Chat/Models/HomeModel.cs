using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace HNFCRM_Chat.Models
{
    public class HomeModel
    {
        public List<CUSTOMER> Customer;
        public List<CONTRACT> Contract;
        public List<STAFF> Staff;
        public IPagedList<CUSTOMER> customer;
    }


}