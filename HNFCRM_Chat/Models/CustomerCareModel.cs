using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace HNFCRM_Chat.Models
{
    public class CustomerCareModel
    {
        public List<STAFF> staff;
        public IPagedList<CUSTOMER> customer;
        public List<CONTRACT> contract;
        public List<CUSTOMERCAREDETAIL> customercaredetail;
        public List<CUSTOMERCARE> customercare;
    }
}