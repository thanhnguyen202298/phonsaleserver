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
        private RetreiveData Rtdata;

        public PhonseController()
        {
            Ql = new HawkQL();
            Rtdata = new RetreiveData();
        }


        [HttpPost]
        [Route("saveProduct")]
        public IHttpActionResult saveProduct([FromBody] Product prod)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveProduct(prod, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("savePromotion")]
        public IHttpActionResult savePromotion([FromBody] Promotion prod)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.savePromotion(prod, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("saveSchadule")]
        public IHttpActionResult saveSchadule([FromBody] Schadule prod)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveSchadule(prod, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("saveOrder")]
        public IHttpActionResult saveOrder([FromBody] Order o)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveOrder(o, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("saveNotice")]
        public IHttpActionResult saveNotice([FromBody] Notice noti)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveNotice(noti, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("saveChat")]
        public IHttpActionResult saveChat([FromBody] ChatM chatM)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveChat(chatM, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("saveBrand")]
        public IHttpActionResult saveBrand([FromBody] Brandy bra)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveBrandy(bra, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("saveuser")]
        public IHttpActionResult saveUser([FromBody] User u)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            Rtdata.saveUser(u, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult login([FromBody] User user)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;

            dt = Rtdata.login(user.UserName, user.Pass, out smstr, out state);
            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getproduct")]
        public IHttpActionResult getproduct(string allorid, int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            dt = Rtdata.getproduct(allorid, page, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getproductbybrand")]
        public IHttpActionResult getproductbybrand(string allorid, int page = 1, int pagesize = 30)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = null;
            dt = Rtdata.getproductbybrand(allorid, page, pagesize, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getorder")]
        public IHttpActionResult getorder(string allorid, int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getorder(allorid, page, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getorderdtl")]
        public IHttpActionResult getorderdtl(string allorid)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getorderdtl(allorid, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        //
        [HttpGet]
        [Route("getpromotion")]
        public IHttpActionResult getpromotion(string allorid, int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getpromotion(allorid, page, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getpromotionbydate")]
        public IHttpActionResult getpromotionbydate(string fromdate, string todate, int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getpromotionbydate(fromdate, todate, page, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getbrand")]
        public IHttpActionResult getbrand(string allorid)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getbrand(allorid, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getSpeakInform")]
        public IHttpActionResult getSpeakInform(string allorid, string fromdate = "", string todate = "", int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getSpeakInform(allorid, fromdate, todate, page, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getChatMsg")]
        public IHttpActionResult getChatMsg(string allorid, string fromdate = "", int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getChatMsg(allorid, fromdate, page, out smstr, out state);

            return Ok(new { status = state, sms = smstr, data = dt });
        }

        [HttpGet]
        [Route("getSchadule")]
        public IHttpActionResult getSchadule(string allorid, string fromdate = "", string todate = "", int page = 1)
        {
            int state = 0; string smstr = "Fail";
            DataTable dt = Rtdata.getSchadule(allorid, fromdate, todate, page, out smstr, out state);

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
