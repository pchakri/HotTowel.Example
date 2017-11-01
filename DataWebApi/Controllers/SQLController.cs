using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using DataWebApi.Models;

namespace DataWebApi.Controllers
{
    [RoutePrefix("KSObject")]
    public class SQLController : ApiController
    {

        [Route("getDataForPendingEmailsGrid")]
        [HttpGet]
        public List<EmailDeliveryModel> getDataForAngularGrid(HttpRequestMessage request)
        {
            DataTable dt = new DataTable();
            List<EmailDeliveryModel> list = new List<EmailDeliveryModel>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["KS_Object"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                var query = "SP_pendingEmails";
                SqlCommand com = new SqlCommand(query, con); //creating SqlCommand object    
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter adptr = new SqlDataAdapter(com);
                adptr.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmailDeliveryModel emailDelivery = new EmailDeliveryModel();
                    emailDelivery.emailID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    emailDelivery.Application = dt.Rows[i]["Application"].ToString();
                    emailDelivery.eventDescription = dt.Rows[i]["Event Description"].ToString();
                    emailDelivery.emailAccountDescription = dt.Rows[i]["Email Account Description"].ToString();
                    emailDelivery.emailReplyAddress = dt.Rows[i]["Email Reply Address (Optional)"].ToString();
                    emailDelivery.emailAddress = dt.Rows[i]["Email Address"].ToString();
                    emailDelivery.emailCCAddress = dt.Rows[i]["Email CC Address"].ToString();
                    emailDelivery.emailBCCAddress = dt.Rows[i]["Email BCC Address"].ToString();
                    emailDelivery.Subject = dt.Rows[i]["Subject"].ToString();
                    emailDelivery.MessageText = dt.Rows[i]["Message Text"].ToString();
                    emailDelivery.Created = dt.Rows[i]["Created"].ToString();
                    emailDelivery.Error = dt.Rows[i]["Error"].ToString();
                    emailDelivery.ErrorMessage = dt.Rows[i]["Error Message"].ToString();
                    
                    list.Add(emailDelivery);
                }
            }
            catch (Exception e)
            {
            }
            return list;
        }



        [Route("getDataForSentEmailsGrid")]
        [HttpGet]
        public List<EmailDeliveryModel> getDataForSentEmailsGrid(HttpRequestMessage request)
        {
            DataTable dt = new DataTable();
            List<EmailDeliveryModel> list = new List<EmailDeliveryModel>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["KS_Object"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                var query = "SP_sentEmails";
                SqlCommand com = new SqlCommand(query, con); //creating SqlCommand object    
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter adptr = new SqlDataAdapter(com);
                adptr.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmailDeliveryModel emailDelivery = new EmailDeliveryModel();
                    emailDelivery.emailID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    emailDelivery.Application = dt.Rows[i]["Application"].ToString();
                    emailDelivery.eventDescription = dt.Rows[i]["Event Description"].ToString();
                    emailDelivery.emailAccountDescription = dt.Rows[i]["Email Account Description"].ToString();
                    emailDelivery.emailReplyAddress = dt.Rows[i]["Email Reply Address (Optional)"].ToString();
                    emailDelivery.emailAddress = dt.Rows[i]["Email Address"].ToString();
                    emailDelivery.emailCCAddress = dt.Rows[i]["Email CC Address"].ToString();
                    emailDelivery.emailBCCAddress = dt.Rows[i]["Email BCC Address"].ToString();
                    emailDelivery.Subject = dt.Rows[i]["Subject"].ToString();
                    emailDelivery.MessageText = dt.Rows[i]["Message Text"].ToString();
                    emailDelivery.Sent = dt.Rows[i]["Sent"].ToString();
                   

                    list.Add(emailDelivery);
                }
            }
            catch (Exception e)
            {
            }
            return list;
        }


        [Route("getDataForErrorEmailsGrid")]
        [HttpGet]
        public List<EmailDeliveryModel> getDataForErrorEmailsGrid(HttpRequestMessage request)
        {
            DataTable dt = new DataTable();
            List<EmailDeliveryModel> list = new List<EmailDeliveryModel>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["KS_Object"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                var query = "SP_errorEmails";
                SqlCommand com = new SqlCommand(query, con); //creating SqlCommand object    
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter adptr = new SqlDataAdapter(com);
                adptr.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmailDeliveryModel emailDelivery = new EmailDeliveryModel();
                    emailDelivery.emailID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    emailDelivery.Error = dt.Rows[i]["Created"].ToString();
                    emailDelivery.ErrorMessage = dt.Rows[i]["Error Message"].ToString();
                    emailDelivery.Application = dt.Rows[i]["Application"].ToString();
                    emailDelivery.eventDescription = dt.Rows[i]["Event Description"].ToString();
                    emailDelivery.emailAccountDescription = dt.Rows[i]["Email Account Description"].ToString();
                    emailDelivery.emailReplyAddress = dt.Rows[i]["Email Reply Address (Optional)"].ToString();
                    emailDelivery.emailAddress = dt.Rows[i]["Email Address"].ToString();
                    emailDelivery.emailCCAddress = dt.Rows[i]["Email CC Address"].ToString();
                    emailDelivery.emailBCCAddress = dt.Rows[i]["Email BCC Address"].ToString();
                    emailDelivery.Subject = dt.Rows[i]["Subject"].ToString();
                    emailDelivery.MessageText = dt.Rows[i]["Message Text"].ToString();
                    emailDelivery.Created = dt.Rows[i]["Created"].ToString();


                    list.Add(emailDelivery);
                }
            }
            catch (Exception e)
            {
            }
            return list;
        }
    }
}

