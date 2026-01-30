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
    public partial class client : Form
    {
       public static int selectedIdVal;
        public client()
        {
            InitializeComponent();
            LoadData();
        }

        public  void  LoadData()
        {
            
            String sql = "SELECT * FROM paperInfo";
            SqlCommand comm = new SqlCommand(sql, Program.connection);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataTable dt = new DataTable();
            da.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            dataGridView1.Columns[0].HeaderText = "Paper ID";
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Author Numbers";
            dataGridView1.Columns[3].HeaderText = "Authors";
            dataGridView1.Columns[4].HeaderText = "Jornal Title";
            dataGridView1.Columns[5].HeaderText = "Publishing Year";
            dataGridView1.Columns[6].HeaderText = "Volume Number";
            dataGridView1.Columns[7].HeaderText = "Issue Number";
            dataGridView1.Columns[8].HeaderText = "Jornal Pages";
            dataGridView1.Columns[9].HeaderText = "Abstract";
            dataGridView1.Columns[10].HeaderText = "Keywords";
            
        }

      

        public static void updateData()
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            operationsForm of1 = new operationsForm();
            of1.Show();
            of1.button2.Text = "Insert";
            TextBox[] tbarray = { of1.textBox1, of1.textBox2, of1.textBox3, of1.textBox4, of1.textBox6, of1.textBox5, of1.textBox8, of1.textBox7, of1.textBox9, of1.textBox10, of1.textBox11, of1.textBox12, of1.textBox14, of1.textBox15 };
         

            for (int i = 0; i < 14; i++)
                tbarray[i].Clear();


                           }




        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(dataGridView1.SelectedCells[0].Value.ToString() == ""))
            {

                selectedIdVal = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                operationsForm of1 = new operationsForm();
                of1.Show();
                of1.button2.Text = "Update";

                of1.textBox1.Text=dataGridView1.SelectedCells[1].Value.ToString();
                of1.textBox2.Text=dataGridView1.SelectedCells[2].Value.ToString();

                String Authrs = dataGridView1.SelectedCells[3].Value.ToString();


                int j = 0;
                int c = 0;
                int b=0;
                char[] authrs = Authrs.ToArray();
                TextBox[] tbArray = {of1.textBox3,of1.textBox4,of1.textBox5,of1.textBox6,of1.textBox8,of1.textBox7 };
                
                for (int i = 0; i < authrs.Length; i++)
                    if (authrs[i].Equals('&'))
                        j=j+1;
               
                int[] indexs = new int[j];

                for (int i = 0; i < authrs.Length; i++)
                    if (authrs[i].Equals('&'))
                    {
                        indexs[c] = i;
                        c++;
                        b=1;
                    }
               
                if(b==0){
                    tbArray[0].Text = Authrs;

                }
                else{
                for (int i = 0; i<=indexs.Length; i++){

                if(i==0)
                tbArray[0].Text=Authrs.Substring(0, indexs[0]-1);

              else if(i==indexs.Length)
                    tbArray[i].Text = Authrs.Substring(indexs[i - 1] + 2, Authrs.Length - (indexs[i - 1] + 2));
                
               else
                    tbArray[i].Text = Authrs.Substring(indexs[i - 1] + 2,indexs[i] -(indexs[i - 1] + 2));
                    
                    
                }               
                }


                of1.textBox9.Text=dataGridView1.SelectedCells[4].Value.ToString();
                of1.textBox10.Text=dataGridView1.SelectedCells[5].Value.ToString();
                of1.textBox11.Text=dataGridView1.SelectedCells[6].Value.ToString();
                of1.textBox12.Text=dataGridView1.SelectedCells[7].Value.ToString();

                String pages=dataGridView1.SelectedCells[8].Value.ToString();
                of1.comboBox1.SelectedItem=pages.Substring(0,2);
                of1.comboBox2.SelectedItem=pages.Substring(3,2);

                of1.textBox14.Text=dataGridView1.SelectedCells[9].Value.ToString();
                of1.textBox15.Text=dataGridView1.SelectedCells[10].Value.ToString();

            }
            else
            {
                MessageBox.Show("Please Click On Rows");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedIdVal = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            String sql = "DELETE FROM paperInfo WHERE paperId_col=" + selectedIdVal;
            SqlCommand comm = new SqlCommand(sql, Program.connection);
            comm.ExecuteNonQuery();
            LoadData();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadData();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.SelectedCells[0].Value.ToString() == ""))
            {
                selectedIdVal = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                operationsForm of1 = new operationsForm();
                of1.Show();
                of1.button2.Text = "Update";

                of1.textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                of1.textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();

                String Authrs = dataGridView1.SelectedCells[3].Value.ToString();


                int j = 0;
                int c = 0;
                int b = 0;
                char[] authrs = Authrs.ToArray();
                TextBox[] tbArray = { of1.textBox3, of1.textBox4, of1.textBox5, of1.textBox6, of1.textBox8, of1.textBox7 };

                for (int i = 0; i < authrs.Length; i++)
                    if (authrs[i].Equals('&'))
                        j = j + 1;

                int[] indexs = new int[j];

                for (int i = 0; i < authrs.Length; i++)
                    if (authrs[i].Equals('&'))
                    {
                        indexs[c] = i;
                        c++;
                        b = 1;
                    }

                if (b == 0)
                {
                    tbArray[0].Text = Authrs;

                }
                else
                {
                    for (int i = 0; i <= indexs.Length; i++)
                    {

                        if (i == 0)
                            tbArray[0].Text = Authrs.Substring(0, indexs[0] - 1);

                        else if (i == indexs.Length)
                            tbArray[i].Text = Authrs.Substring(indexs[i - 1] + 2, Authrs.Length - (indexs[i - 1] + 2));

                        else
                            tbArray[i].Text = Authrs.Substring(indexs[i - 1] + 2, indexs[i] - (indexs[i - 1] + 2));


                    }
                }


                of1.textBox9.Text = dataGridView1.SelectedCells[4].Value.ToString();
                of1.textBox10.Text = dataGridView1.SelectedCells[5].Value.ToString();
                of1.textBox11.Text = dataGridView1.SelectedCells[6].Value.ToString();
                of1.textBox12.Text = dataGridView1.SelectedCells[7].Value.ToString();

                String pages = dataGridView1.SelectedCells[8].Value.ToString();
                of1.comboBox1.SelectedItem = pages.Substring(0, 2);
                of1.comboBox2.SelectedItem = pages.Substring(3, 2);

                of1.textBox14.Text = dataGridView1.SelectedCells[9].Value.ToString();
                of1.textBox15.Text = dataGridView1.SelectedCells[10].Value.ToString();

            }
            else
            {
                MessageBox.Show("Please Click On Rows");
            }
        }
    }
}
