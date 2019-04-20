using System.Web.Http;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing.Imaging;
using System;

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
        [Route("saveuser")]
        public IHttpActionResult saveUser(string UserName, string Phone, string Pass, string Address, string Email, string UserCode = null, string ModifyBy = null, int Staffin = 0, string FullName = "ngtha f a")
        {
            OleDbParameter[] param = new OleDbParameter[10];
            param[0] = new OleDbParameter("@UserCode", UserCode);
            param[1] = new OleDbParameter("@UserName", UserName);
            param[2] = new OleDbParameter("@Phone", Phone);
            param[3] = new OleDbParameter("@Pass", Pass);
            param[4] = new OleDbParameter("@Address", Address);
            param[5] = new OleDbParameter("@Email", Email);
            param[6] = new OleDbParameter("@Staffin", Staffin);
            param[7] = new OleDbParameter("@ModifyBy", ModifyBy);
            param[8] = new OleDbParameter("@ModifyOn", DateTime.Now);
            param[9] = new OleDbParameter("@FullName", FullName);

            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            if (UserCode == null)
            {
                UserCode = Guid.NewGuid().ToString();
                param[0] = new OleDbParameter("@UserCode", UserCode);
                try
                {
                    int n = Ql.executeSp("saveUser", param);
                    if (n > 0)
                    {
                        state = 1; smstr = "success";
                    }
                    else smstr += "save: data was wrong";
                }
                catch (Exception ex) { smstr ="save: "+ ex.Message; }
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
