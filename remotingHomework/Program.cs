using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using General;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

 
namespace remotingHomework
{
    public class Program
    {

        
       public static SqlConnection connection;
       public static void connFunc(){
           try
            {

                connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Asususer\Documents\Visual Studio 2013\Projects\paperIndexing\remotingHomework\remotingHomework_db.mdf;Integrated Security=True;Connect Timeout=30");
                connection.Open();
                MessageBox.Show("Connection Established");
              
                               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }
            

           
        }
        
    

        


        //String sql = "SELECT (title_col , authorsNum_col, authorsNames_col, jornalTitle_col, publishingYear_col, volNum_col, issueNum_col, pagesOnJornal_col, abstract_col, keyword_col) FROM paperInfo";
                    



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
      public static void Main() {


       

            connFunc();
       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new client());
          
               

        }
    }
}
