using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace remotingHomework
{
    public partial class operationsForm : Form
    {
        public operationsForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            
            int a = 1;
            String authStr = "";
            TextBox[] tbarray = { textBox1, textBox2, textBox9, textBox10, textBox11, textBox12, textBox14, textBox15 };
          
            for(int i=0;i<8;i++)
                if (tbarray[i].Text.Equals(null) || (tbarray[i].Text.Equals("")))
                    a=0;


             if (a!=0)
             {

                 int compYear = (int)DateTime.Now.Year;
                 int publishingYear = int.Parse(textBox10.Text);


                     if (textBox3.Text == "")
                         MessageBox.Show("enter one Author name at least, and start with 1Fst col");

                     else
                     {

                         authStr = textBox3.Text;

                         if (textBox4.Text != "")
                             authStr = authStr + " & " + textBox4.Text;

                         if (textBox6.Text != "")
                             authStr = authStr + " & " + textBox6.Text;

                         if (textBox5.Text != "")
                             authStr = authStr + " & " + textBox5.Text;

                         if (textBox8.Text != "")
                             authStr = authStr + " & " + textBox8.Text;

                         if (textBox7.Text != "")
                             authStr = authStr + " & " + textBox7.Text;


                         if (!(publishingYear > compYear) && !(publishingYear<1940))
                         {


                             ////////////////////////////////////// insert /////////////////////////////////////

                             if (button2.Text == "Insert")
                             {


                                 SqlCommand comm1 = new SqlCommand("insert into paperInfo (title_col , authorsNum_col, authorsNames_col, jornalTitle_col, publishingYear_col, volNum_col, issueNum_col, pagesOnJornal_col, abstract_col, keyword_col) values('" + textBox1.Text + "'," + int.Parse(textBox2.Text) + ",'" + authStr + "','" + textBox9.Text + "','" + textBox10.Text + "'," + int.Parse(textBox11.Text) + "," + int.Parse(textBox12.Text) + ",'" + comboBox1.Text + "-" + comboBox2.Text + "','" + textBox14.Text + "','" + textBox15.Text + "')", Program.connection);
                                 comm1.ExecuteNonQuery();
                                 MessageBox.Show("Data Entered");
                             }

               ////////////////////////////////////// update ///////////////////////////////////

                             else if (button2.Text == "Update")
                             {

                                 client c1 = new client();
                                 

                                  SqlCommand comm1 = new SqlCommand("UPDATE paperInfo SET "
                                   + "title_col='" +
                                   textBox1.Text //text
                                   + "',authorsNum_col=" +
                                   int.Parse(textBox2.Text) //int
                                   + ",authorsNames_col='" +
                                   authStr       //text 3 4 5 6 7 8 textBox
                                   + "',jornalTitle_col='" +
                                   textBox9.Text //text
                                   + "',publishingYear_col='" +
                                   textBox10.Text //text
                                   + "',volNum_col=" +
                                   int.Parse(textBox11.Text)//int
                                   + ",issueNum_col=" +
                                   int.Parse(textBox12.Text) //int
                                   + ",pagesOnJornal_col='" +
                                   comboBox1.Text + "-" + comboBox2.Text //text
                                   + "',abstract_col='" +
                                   textBox14.Text //text
                                   + "',keyword_col='" +
                                   textBox15.Text //text
                                   + "'WHERE paperId_col="+client.selectedIdVal+";", Program.connection);

                                  MessageBox.Show(client.selectedIdVal.ToString());
                             
                                   comm1.ExecuteNonQuery();  
                                   MessageBox.Show("Data Updated");


                             } ///// end if 'update'/////

                         }
                         else
                             MessageBox.Show(" The Publishing Year Must Be Between 1940 And This Year ");

                       } ///// end else for if '1FST Authoe' field /////



            } else // fields empty  //////
                MessageBox.Show("Full Empty Field Please..");
            
               

        }
                
        private void button3_Click(object sender, EventArgs e)
        {
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch!=8)
            e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;

                
            
        }

      
    }
}
