using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace phoneser.Controllers
{
    public class QL
    {
        public readonly static string OrderTbl = "[Order]";
        public readonly static string ProductTbl = "[Product]";
        public readonly static string UserTbl = "[User]";
        public readonly static string OrdetailTbl = "[OrderDetail]";
        public readonly static string PromoTbl = "[Promotion]";
        public readonly static string StatusTbl = "[Status]";
        public readonly static string TypeTbl = "[Type]";

        private readonly static string pageget = " desc offset(?-1) rows fetch next ? rows only;";

        public readonly static string getProduct = "select * from " + ProductTbl + " order by [ProductName]" + pageget;
        public readonly static string getUserInfo = "select * from " + UserTbl + " order by [UserName]" + pageget;
        public readonly static string getOrder = "select * from " + OrderTbl + " order by [CreateOn]" + pageget;
        public readonly static string getOrdetail = "select * from " + OrdetailTbl + " order by [OrderCode]" + pageget;
        public readonly static string getPromotion = "select * from " + PromoTbl + " order by [CreateOn]" + pageget;
        public readonly static string getStatus = "select * from " + StatusTbl;
        public readonly static string getType = "select * from " + TypeTbl;
    }
}