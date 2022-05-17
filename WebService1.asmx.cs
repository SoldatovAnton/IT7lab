using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace IT7lab
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public void AddGuest(String name, String email, String phone, Boolean agree)
        {
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                object people;
                string sql0 = "SELECT * FROM [People] WHERE ([Email] like " + "'" + email + "')";
                using (SqlCommand cmd = new SqlCommand(sql0, con))
                {
                    people = cmd.ExecuteScalar();
                }
                               
                if (people != null)
                {
                    string sql = string.Format("UPDATE People SET Name = @Name, Phone = @Phone, WillAttend = @WillAttend WHERE (Email = " + "'" + email + "'" + ")");
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@WillAttend", agree);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = string.Format("INSERT INTO People" + "(Name, Email, Phone, WillAttend) VALUES (@Name, @Email, @Phone, @WillAttend)");
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@WillAttend", agree);
                        cmd.ExecuteNonQuery();
                    }
                }

                
            }

        }
    }
}
