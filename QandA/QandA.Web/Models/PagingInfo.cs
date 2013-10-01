using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA.Web.Models
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}