using System.Web.Http;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing.Imaging;
using System;
using phoneser.Models;

namespace phoneser.Controllers
{
    [RoutePrefix("Api")]
    public class PhonseController : ApiController
    {
        private HawkQL Ql;

        public PhonseController()
        {
            Ql = new HawkQL();
        }

        [HttpPost]
        [Route("saveProduct")]
        public IHttpActionResult saveNotice(Product prod)
        {
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
            param[10]= new OleDbParameter("@ImageUrl", prod.ImageUrl);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            if (prod.ProductCode == null)
            {
                prod.ProductCode = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@NoticeId", prod.ProductCode);
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
            return Ok(new { status = state, sms = smstr, data = dt });
        }



        [HttpPost]
        [Route("saveOrder")]
        public IHttpActionResult saveOrder(Order o)
        {
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

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
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
            return Ok(new { status = state, sms = smstr, data = dt });
        }


        [HttpPost]
        [Route("saveNotice")]
        public IHttpActionResult saveNotice(Notice noti)
        {
            OleDbParameter[] param = new OleDbParameter[8];
            param[0] = new OleDbParameter("@NoticeId", noti.NoticeId);
            param[1] = new OleDbParameter("@FromUser", noti.FromUser);
            param[2] = new OleDbParameter("@ToUser", noti.ToUser);
            param[3] = new OleDbParameter("@ContentMsg", noti.ContentMsg);
            param[4] = new OleDbParameter("@FileMsg", noti.FileMsg);
            param[5] = new OleDbParameter("@CreateOn", noti.CreateOn);
            param[6] = new OleDbParameter("@ImageUrl", noti.ImageUrl);
            param[7] = new OleDbParameter("@NoticeName", noti.NoticeName);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
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
            return Ok(new { status = state, sms = smstr, data = dt });
        }


        [HttpPost]
        [Route("saveChat")]
        public IHttpActionResult saveChat(ChatM chatM)
        {
            OleDbParameter[] param = new OleDbParameter[8];
            param[0] = new OleDbParameter("@ChatId", chatM.ChatId);
            param[1] = new OleDbParameter("@FromUser", chatM.FromUser);
            param[2] = new OleDbParameter("@ToUser", chatM.ToUser);
            param[3] = new OleDbParameter("@ContentMsg", chatM.ContentMsg);
            param[4] = new OleDbParameter("@FileMsg", chatM.FileMsg);
            param[5] = new OleDbParameter("@ImageMsg", chatM.ImageMsg);
            param[6] = new OleDbParameter("@CreateOn", chatM.CreateOn);
            param[7] = new OleDbParameter("@Replying", chatM.Replying);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
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
            return Ok(new { status = state, sms = smstr, data = dt });
        }


        [HttpPost]
        [Route("saveBrand")]
        public IHttpActionResult saveBrand(Brandy bra)
        {
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@BrandId", bra.BrandId);
            param[1] = new OleDbParameter("@BrandName", bra.BrandName);
            param[2] = new OleDbParameter("@Description", bra.Description);
            param[3] = new OleDbParameter("@ImgUrl", bra.ImgUrl);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
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
            return Ok(new { status = state, sms = smstr, data = dt });
        }


        [HttpPost]
        [Route("saveuser")]
        public IHttpActionResult saveUser(User u)
        {
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

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
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
            return Ok(new { status = state, sms = smstr, data = dt });
        }


        [HttpPost]
        public IHttpActionResult login(string user, string pas)
        {
            string date = DateTime.Now.ToShortDateString();
            byte[] byt = Encoding.UTF8.GetBytes(date.ToCharArray());
            date = Convert.ToBase64String(byt);

            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@key", date);
            param[1] = new OleDbParameter("@user", user);
            param[2] = new OleDbParameter("@pass", pas);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                int n = Ql.executeSp("savekeytoken", param);
                if (n > 0)
                {
                    dt = Ql.getTableSP("getlogin", param);
                    state = 1; smstr = "success";
                }
                else smstr = "user is not available";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getproduct")]
        public IHttpActionResult getproduct(string allorid, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@m_product", allorid);
            param[1] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetProductBy", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getproductbybrand")]
        public IHttpActionResult getproductbybrand(string allorid, int page = 1, int pagesize = 30)
        {
            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@m_product", allorid);
            param[1] = new OleDbParameter("@page", page);
            param[2] = new OleDbParameter("@page_size", pagesize);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetProductByBrand", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getorder")]
        public IHttpActionResult getorder(string allorid, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@orderid", allorid);
            param[1] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetOrder", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getorderdtl")]
        public IHttpActionResult getorderdtl(string allorid)
        {
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@orderid", allorid);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetOrderDetail", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        //
        [HttpGet]
        [Route("getpromotion")]
        public IHttpActionResult getpromotion(string allorid, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@orderid", allorid);
            param[1] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetPromotion", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getpromotionbydate")]
        public IHttpActionResult getpromotionbydate(string fromdate, string todate, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@fromdate", fromdate);
            param[1] = new OleDbParameter("@todate", todate);
            param[2] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetPromotioinByDate", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getbrand")]
        public IHttpActionResult getbrand(string allorid, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@onid", allorid);
            param[1] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("GetBrandPhone", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getSpeakInform")]
        public IHttpActionResult getSpeakInform(string allorid, string fromdate = "", string todate = "", int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@allorid", allorid);
            param[1] = new OleDbParameter("@fromdate", fromdate);
            param[2] = new OleDbParameter("@todate", todate);
            param[3] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("getSpeakInform", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getChatMsg")]
        public IHttpActionResult getChatMsg(string allorid, string fromdate = "", int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@user_code", allorid);
            param[1] = new OleDbParameter("@fromdate", fromdate);
            param[2] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("getChatMsg", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getSchadule")]
        public IHttpActionResult getSchadule(string allorid, string fromdate = "", string todate = "", int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@allorid", allorid);
            param[1] = new OleDbParameter("@fromdate", fromdate);
            param[2] = new OleDbParameter("@todate", todate);
            param[3] = new OleDbParameter("@page", page);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            try
            {
                dt = Ql.getTableSP("getSchadulePhone", param);
                state = 1; smstr = "success";
            }
            catch (Exception ex) { smstr = ex.Message; }
            return Ok(new { status = state, sms = smstr, data = dt });
        }


        [HttpPost]
        [Route("saveImg")]
        public IHttpActionResult saveImg(byte[] file, string filename)
        {
            string howst = System.Web.Hosting.HostingEnvironment.MapPath("/Upload/Product/Image/");
            if (file != null)
            {
                MemoryStream tmpStream = new MemoryStream();
                tmpStream.Write(file, 0, file.Length);
                Image m = Image.FromStream(tmpStream);

                howst += $"{System.DateTime.Now.ToString("ddmmyyyyhhmmss")}" + filename;
                m.Save(howst);
            }

            OleDbParameter[] param = new OleDbParameter[1];
            OleDbParameter par = new OleDbParameter();
            par.ParameterName = "payload";
            par.Value = howst;
            param[0] = par;

            int n = Ql.executeQl("insert into BrandPhone(BrandImage) values(?)", param);
            return Ok(new { status = n, sms = "thanhss", data = howst });
        }

    }
}
