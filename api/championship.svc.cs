using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace RPS.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(Require­mentsMode = AspNetCompatibilityRequirementsMode.Allo­wed)]

    public class championship : Ichampionship
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["ConnectionStringrps"].ToString();

        

        //public string DoWork()
        //{
        //    //return "hello REST WCF service its fucking me";
        //   return Top();
        //}

        public List<string> Top(int count)
        {
            int counts;

            if (count != 0)
            {
                counts = count;
            }
            else
            {
                counts = 10;
            }
            
            //string RES = "the Score Table is empty.";
            List<string> players = new List<string> { };
            MySqlConnection cn = new MySqlConnection(myconnectionstring);
            MySqlCommand cmd;
            
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandText = "select Name from rps_scores order by Points desc LIMIT @counts";
            cmd.Parameters.AddWithValue("@counts", counts);
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            //DataSet scores = new DataSet();
            DataTable scores = new DataTable();
            adapter.Fill(scores);

            if (scores.Rows.Count != 0)
            {
                //RES = "player= [";
                for (int i=0;i < scores.Rows.Count; i++)
                {
                    DataRow row = scores.Rows[i];                    
                    players.Add(row[0].ToString());

                }
                
            }

            //return RES;            
            return players;
        }

        
         
        //    static string HttpPost(string url,
        //string[] paramName, string[] paramVal)
        //    {
        //        HttpWebRequest req = WebRequest.Create(new Uri(url))
        //                             as HttpWebRequest;
        //        req.Method = "POST";
        //        req.ContentType = "application/x-www-form-urlencoded";

        //        // Build a string with all the params, properly encoded.
        //        // We assume that the arrays paramName and paramVal are
        //        // of equal length:
        //        StringBuilder paramz = new StringBuilder();
        //        for (int i = 0; i < paramName.Length; i++)
        //        {
        //            paramz.Append(paramName[i]);
        //            paramz.Append("=");
        //            paramz.Append(HttpUtility.UrlEncode(paramVal[i]));
        //            paramz.Append("&");
        //        }

        //        // Encode the parameters as form data:
        //        byte[] formData =
        //            UTF8Encoding.UTF8.GetBytes(paramz.ToString());
        //        req.ContentLength = formData.Length;

        //        // Send the request:
        //        using (Stream post = req.GetRequestStream())
        //        {
        //            post.Write(formData, 0, formData.Length);
        //        }

        //        // Pick up the response:
        //        string result = null;
        //        using (HttpWebResponse resp = req.GetResponse()
        //                                      as HttpWebResponse)
        //        {
        //            StreamReader reader =
        //                new StreamReader(resp.GetResponseStream());
        //            result = reader.ReadToEnd();
        //        }

        //        return result;
        //    }


    }
}
