using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using DAL;
 

namespace Zadatak
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string CreateRequest(string queryString)
        {
            string UrlRequest = " http://jsonplaceholder.typicode.com/users?email="+queryString;
                                  
            return (UrlRequest);
        }


        public static RootObject MakeRequest(string requestUrl)
        {
            try
            {
                    RootObject data1 = null;  
                    var syncClient = new WebClient();
                    string content = syncClient.DownloadString(requestUrl);
                    var data = JsonConvert.DeserializeObject<RootObject[]>(content);
                    if (data.Length > 0)
                    {
                          data1 = data[0];
                    }
                    return data1;
                 
                   
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string lRequest = CreateRequest(txtEmail.Text);
                RootObject lResponse = MakeRequest(lRequest);
                if (lResponse == null)
                {
                    JsonRData d = new JsonRData();
                    d.Name = txtName.Text;
                    d.Username = txtUsername.Text;
                    d.Email = txtEmail.Text;

                    Data t = new Data();
                    t.Insert(d);
                }
                else
                {
                    Mapper m = new Mapper();

                    JsonRData c = m.toData(lResponse);

                    Data r = new Data();
                    r.Insert(c);

                    Mail t = new Mail();
                    t.sendMail(lResponse);
                    
                }
            }
            catch (Exception ec)
            {
                Label1.Text = "Error";
            }

        }
 
        

    }
}