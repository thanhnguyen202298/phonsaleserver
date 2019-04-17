using System.Web.Http;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
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


        //       []
        //-- Add the parameters for the stored procedure here

        //   @allorid nvarchar(50),
        //@ Varchar(30),
        //@ Varchar(30),
        //@page int = 1


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
            OleDbParameter[] param = new OleDbParameter[4];
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

        //[HttpGet]
        //[Route("onlytest")]
        //public IHttpActionResult getbrand1()
        //{
        //    OleDbParameter[] param = new OleDbParameter[2];
        //    param[0] = new OleDbParameter("@onid", "all");
        //    param[1] = new OleDbParameter("@page", 1);

        //    DataTable dt = Ql.getTableSP("GetBrandPhone", param);

        //    byte[] imgBytes = (byte[])dt.Rows[0][3];
        //    MemoryStream tmpStream = new MemoryStream();
        //    tmpStream.Write(imgBytes, 0, imgBytes.Length);
        //    Image m = Image.FromStream(tmpStream);

        //    return Ok(new { status = 1, sms = "thanhss", data = imgBytes });
        //}
    }
}
