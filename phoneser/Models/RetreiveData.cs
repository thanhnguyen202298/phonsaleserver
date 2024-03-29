﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;

namespace phoneser.Models
{
    public class RetreiveData
    {
        private static HawkQL Ql;

        public RetreiveData()
        {
            Ql = new HawkQL();
        }

        public void saveProduct(Product prod, out string smstr, out int state)
        {
            smstr = "save product";
            state = 0;
            
            OleDbParameter[] param = new OleDbParameter[11];
            param[0] = new OleDbParameter("@ProductCode", prod.ProductCode);
            param[1] = new OleDbParameter("@ProductName", prod.ProductName);
            param[2] = new OleDbParameter("@Price", prod.Price);
            param[3] = new OleDbParameter("@ProductType", prod.ProductType);
            param[4] = new OleDbParameter("@Color", prod.Color);
            param[5] = new OleDbParameter("@Detail", prod.Detail);
            param[6] = new OleDbParameter("@ModifyBy", prod.ModifyBy);
            param[7] = new OleDbParameter("@ModifyOn", prod.ModifyOn);
            param[8] = new OleDbParameter("@CreateOn", prod.CreateOn);
            param[9] = new OleDbParameter("@BrandId", prod.BrandId);
            param[10] = new OleDbParameter("@ImageUrl", prod.ImageUrl);

            if (prod.ProductCode == null)
            {
                prod.ProductCode = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@ProductCode", prod.ProductCode);
                try
                {
                    int n = Ql.executeSp("saveProduct", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updateProduct", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }
        //public void saveProduct(Product prod, out string smstr, out int state)

        public void savePromotion(Promotion prod, out string smstr, out int state)
        {
            smstr = "savePromotion";
            state = 0;

            OleDbParameter[] param = new OleDbParameter[14];
            param[0] = new OleDbParameter("@PromotionCode", prod.PromotionCode);
            param[1] = new OleDbParameter("@Name", prod.Name);
            param[2] = new OleDbParameter("@ProductRange", prod.ProductRange);
            param[3] = new OleDbParameter("@Quantity", prod.Quantity);
            param[4] = new OleDbParameter("@Discount", prod.Discount);
            param[5] = new OleDbParameter("@DiscountPercent", prod.DiscountPercent);
            param[6] = new OleDbParameter("@ProductMustBuy", prod.ProductMustBuy);
            param[7] = new OleDbParameter("@ProductAllowBuy", prod.ProductAllowBuy);
            param[8] = new OleDbParameter("@ModifyBy", prod.ModifyBy);
            param[9] = new OleDbParameter("@ModifyOn", prod.ModifyOn);
            param[10] = new OleDbParameter("@CreateOn", prod.CreateOn);
            param[11] = new OleDbParameter("@FromDate", prod.FromDate);
            param[12] = new OleDbParameter("@ToDate", prod.ToDate);
            param[13] = new OleDbParameter("@ImageUrl", prod.ImageUrl);

            if (prod.PromotionCode == null)
            {
                prod.PromotionCode = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@PromotionCode", prod.PromotionCode);
                try
                {
                    int n = Ql.executeSp("savePromotion", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updatePromotion", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }

        public void saveSchadule(Schadule prod, out string smstr, out int state)
        {
            smstr = "save schadule";
            state = 0;

            OleDbParameter[] param = new OleDbParameter[7];
            param[0] = new OleDbParameter("@SchaduleId", prod.SchaduleId);
            param[1] = new OleDbParameter("@FromUser", prod.FromUser);
            param[2] = new OleDbParameter("@ToUser", prod.ToUser);
            param[3] = new OleDbParameter("@ContentMsg", prod.ContentMsg);
            param[4] = new OleDbParameter("@CreateOn", prod.CreateOn);
            param[5] = new OleDbParameter("@DateOnSchadule", prod.DateOnSchadule);
            param[6] = new OleDbParameter("@SchaduleName", prod.SchaduleName);

            if (prod.SchaduleId == null)
            {
                prod.SchaduleId = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@SchaduleId", prod.SchaduleId);
                try
                {
                    int n = Ql.executeSp("saveSchadule", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updateSchadule", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }

        public void saveOrder(Order o, out string smstr, out int state)
        {
            smstr = "save order";
            state = 0;

            OleDbParameter[] param = new OleDbParameter[21];
            param[0] = new OleDbParameter("@OrderCode", o.OrderCode);
            param[1] = new OleDbParameter("@OrderType", o.OrderType);
            param[2] = new OleDbParameter("@UserCode", o.UserCode);
            param[3] = new OleDbParameter("@Promotion", o.Promotion);
            param[4] = new OleDbParameter("@Amount", o.Amount);
            param[5] = new OleDbParameter("@Status", o.Status);
            param[6] = new OleDbParameter("@AddressTo", o.AddressTo);
            param[7] = new OleDbParameter("@ShopCode", o.ShopCode);
            param[8] = new OleDbParameter("@ShopName", o.ShopName);
            param[9] = new OleDbParameter("@ShopPhone", o.ShopPhone);
            param[10] = new OleDbParameter("@SyncUser", o.SyncUser);
            param[11] = new OleDbParameter("@SyncShop", o.SyncShop);
            param[12] = new OleDbParameter("@SyncPostMan", o.SyncPostMan);
            param[13] = new OleDbParameter("@PostMan", o.PostMan);
            param[14] = new OleDbParameter("@BookTime", o.BookTime);
            param[15] = new OleDbParameter("@ShipTime", o.ShipTime);
            param[16] = new OleDbParameter("@StatusTime", o.StatusTime);
            param[17] = new OleDbParameter("@CreateOn", o.CreateOn);
            param[18] = new OleDbParameter("@ModifyBy", o.ModifyBy);
            param[19] = new OleDbParameter("@ModifyOn", o.ModifyOn);
            param[20] = new OleDbParameter("@Ranking", o.Ranking);

            if (o.OrderCode == null)
            {
                o.OrderCode = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@OrderCode", o.OrderCode);
                try
                {
                    int n = Ql.executeSp("saveOrder", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updateOrder", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }

        public void saveNotice(Notice noti, out string smstr, out int state)
        {
            smstr = "save notice";state = 0;


            OleDbParameter[] param = new OleDbParameter[8];
            param[0] = new OleDbParameter("@NoticeId", noti.NoticeId);
            param[1] = new OleDbParameter("@FromUser", noti.FromUser);
            param[2] = new OleDbParameter("@ToUser", noti.ToUser);
            param[3] = new OleDbParameter("@ContentMsg", noti.ContentMsg);
            param[4] = new OleDbParameter("@FileMsg", noti.FileMsg);
            param[5] = new OleDbParameter("@CreateOn", noti.CreateOn);
            param[6] = new OleDbParameter("@ImageUrl", noti.ImageUrl);
            param[7] = new OleDbParameter("@NoticeName", noti.NoticeName);

            if (noti.NoticeId == null)
            {
                noti.NoticeId = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@NoticeId", noti.NoticeId);
                try
                {
                    int n = Ql.executeSp("saveInformSpeak", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updateInformSpeak", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }

        public void saveChat(ChatM chatM, out string smstr, out int state)
        {
            smstr = "save chat"; state = 0;

            OleDbParameter[] param = new OleDbParameter[8];
            param[0] = new OleDbParameter("@ChatId", chatM.ChatId);
            param[1] = new OleDbParameter("@FromUser", chatM.FromUser);
            param[2] = new OleDbParameter("@ToUser", chatM.ToUser);
            param[3] = new OleDbParameter("@ContentMsg", chatM.ContentMsg);
            param[4] = new OleDbParameter("@FileMsg", chatM.FileMsg);
            param[5] = new OleDbParameter("@ImageMsg", chatM.ImageMsg);
            param[6] = new OleDbParameter("@CreateOn", chatM.CreateOn);
            param[7] = new OleDbParameter("@Replying", chatM.Replying);

            if (chatM.ChatId == null)
            {
                chatM.ChatId = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@ChatId", chatM.ChatId);
                try
                {
                    int n = Ql.executeSp("savechat", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updatechat", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }

        public string saveBrandy(Brandy bra, out string smstr, out int state)
        {
            smstr = "save user"; state = 0;

            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@BrandId", bra.BrandId);
            param[1] = new OleDbParameter("@BrandName", bra.BrandName);
            param[2] = new OleDbParameter("@Description", bra.Description);
            param[3] = new OleDbParameter("@ImgUrl", bra.ImgUrl);

            if (bra.BrandId == null)
            {
                bra.BrandId = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@BrandId", bra.BrandId);
                try
                {
                    int n = Ql.executeSp("savebrand", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updatebrand", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
            return bra.BrandId;
        }

        public void saveUser(User u, out string smstr, out int state)
        {
            smstr = "save user";
            state = 0;


            OleDbParameter[] param = new OleDbParameter[10];
            param[0] = new OleDbParameter("@UserCode", u.UserCode);
            param[1] = new OleDbParameter("@UserName", u.UserName);
            param[2] = new OleDbParameter("@Phone", u.Phone);
            param[3] = new OleDbParameter("@Pass", u.Pass);
            param[4] = new OleDbParameter("@Address", u.Address);
            param[5] = new OleDbParameter("@Email", u.Email);
            param[6] = new OleDbParameter("@Staffin", u.Staffin);
            param[7] = new OleDbParameter("@ModifyBy", u.ModifyBy);
            param[8] = new OleDbParameter("@ModifyOn", DateTime.Now);
            param[9] = new OleDbParameter("@FullName", u.FullName);

            if (u.UserCode == null)
            {
                u.UserCode = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@UserCode", u.UserCode);
                try
                {
                    int n = Ql.executeSp("saveUser", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr = "save: " + ex.Message; }
            }
            else
            {
                try
                {
                    int n = Ql.executeSp("updateuser", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "update: data was wrong";
                }
                catch (Exception ex) { smstr = "update: " + ex.Message; }
            }
        }

        #region getdata
        public DataTable login(string usn, string pass, out string smstr, out int state)
        {
            smstr = "save user";
            state = 0;
            DataTable dt = null;
            
            string date = DateTime.Now.ToShortDateString();
            byte[] byt = Encoding.UTF8.GetBytes(date.ToCharArray());
            date = Convert.ToBase64String(byt);

            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@key", date);
            param[1] = new OleDbParameter("@user", usn);
            param[2] = new OleDbParameter("@pass", pass);

            try
            {
                int n = Ql.executeSp("savekeytoken", param);
                if (n > 0)
                {
                    n = 0;
                    dt = Ql.getTableSP("getlogin", param);
                    state = 1; smstr = "success";
                }
                else smstr = "user is not available";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return dt;
        }

        public DataTable getproduct(string allorid, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@m_product", allorid);
            param[1] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("GetProductBy", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return dt;
        }


        public DataTable getproductbybrand(string allorid, int page, int pagesize, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@m_brand", allorid);
            param[1] = new OleDbParameter("@page", page);
            param[2] = new OleDbParameter("@page_size", pagesize);

            try
            {
                dt = Ql.getTableSP("GetProductByBrand", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return dt;
        }

        public DataTable getorder(string allorid, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@orderid", allorid);
            param[1] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("GetOrder", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }

            return dt;
        }


        public DataTable getorderdtl(string allorid, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;
            
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@orderid", allorid);

            try
            {
                dt = Ql.getTableSP("GetOrderDetail", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }

            return dt;
        }

        public DataTable getpromotion(string allorid, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;
            
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@promid", allorid);
            param[1] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("GetPromotion", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }

            return dt;
        }

        public DataTable getpromotionbydate(string fromdate, string todate, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@fromdate", fromdate);
            param[1] = new OleDbParameter("@todate", todate);
            param[2] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("GetPromotioinByDate", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }

            return dt;
        }

        public DataTable getbrand(string allorid, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@onid", allorid);

            try
            {
                dt = Ql.getTableSP("GetBrandPhone", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }

            return dt;
        }


        public DataTable getSpeakInform(string allorid, string fromdate, string todate, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@allorid", allorid);
            param[1] = new OleDbParameter("@fromdate", fromdate);
            param[2] = new OleDbParameter("@todate", todate);
            param[3] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("getSpeakInform", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }

            return dt;
        }


        public DataTable getChatMsg(string allorid, string fromdate, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@user_code", allorid);
            param[1] = new OleDbParameter("@fromdate", fromdate);
            param[2] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("getChatMsg", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return dt;
        }

        public DataTable getSchadule(string allorid, string fromdate, string todate, int page, out string smstr, out int state)
        {
            smstr = "";
            state = 0;
            DataTable dt = null;

            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@allorid", allorid);
            param[1] = new OleDbParameter("@fromdate", fromdate);
            param[2] = new OleDbParameter("@todate", todate);
            param[3] = new OleDbParameter("@page", page);

            try
            {
                dt = Ql.getTableSP("getSchadulePhone", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return dt;
        }
        #endregion
    }

}