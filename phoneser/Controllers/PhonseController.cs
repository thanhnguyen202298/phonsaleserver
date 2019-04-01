using System.Web.Http;
using System.Data;
using System.Data.OleDb;

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

            DataTable dt = Ql.getTableSP("GetProductBy", param);

            return Ok(new { status = 1, sms = "thanhss", data = dt });
        }

        [HttpGet]
        [Route("getorder")]
        public IHttpActionResult getorder(string allorid, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@orderid", allorid);
            param[1] = new OleDbParameter("@page", page);

            DataTable dt = Ql.getTableSP("GetOrder", param);

            return Ok(new { status = 1, sms = "thanhss", data = dt });
        }

        [HttpGet]
        [Route("getorderdtl")]
        public IHttpActionResult getorderdtl(string allorid)
        {
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@orderid", allorid);
            DataTable dt = Ql.getTableSP("GetOrderDetail", param);

            return Ok(new { status = 1, sms = "thanhss", data = dt });
        }
        //
        [HttpGet]
        [Route("getpromotion")]
        public IHttpActionResult getpromotion(string allorid, int page=1)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@orderid", allorid);
            param[1] = new OleDbParameter("@page", page);

            DataTable dt = Ql.getTableSP("GetPromotion", param);

            return Ok(new { status = 1, sms = "thanhss", data = dt });
        }

        [HttpGet]
        [Route("getpromotionbydate")]
        public IHttpActionResult getpromotionbydate(string fromdate, string todate, int page = 1)
        {
            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@fromdate", fromdate);
            param[1] = new OleDbParameter("@todate", todate);
            param[2] = new OleDbParameter("@page", page);

            DataTable dt = Ql.getTableSP("GetPromotioinByDate", param);

            return Ok(new { status = 1, sms = "thanhss", data = dt });
        }
    }
}
