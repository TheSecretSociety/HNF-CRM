﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace HNFCRM_Chat.Models
{
    public class ChatModel
    {
        public IPagedList<CHATINFO> Chat;
        public List<STAFF> Staff;
    }
}