using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Eva_DataBase_App
{
    public partial class Form2 : Form
    {
        DataClasses1DataContext db;
        public Form2()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            db = new DataClasses1DataContext();
            datagrid.DataSource = db.EvaDataBases;
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            LoadData();
        }

       

        private void delete_Click(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("are you sure to delete the reccord", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    int eno = Convert.ToInt32(datagrid.SelectedRows[0].Cells[0].Value);
                    EvaDataBase obj = db.EvaDataBases.SingleOrDefault(E => E.Id == eno);
                    db.EvaDataBases.DeleteOnSubmit(obj);
                    db.SubmitChanges();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a operation for Deletion");
            }
        }

        private void close_Click(object sender, EventArgs e)  
        {
            this.Close();  
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0)
            {
                Form1 f = new Form1();
                f.textBox_id.ReadOnly = true;
                f.clear.Enabled = false;
                f.save.Text = "Update";

                f.textBox_id.Text = datagrid.SelectedRows[0].Cells[0].Value.ToString();
                f.textBox_firstname.Text = datagrid.SelectedRows[0].Cells[1].Value.ToString();
                f.textBox_lastname.Text = datagrid.SelectedRows[0].Cells[2].Value.ToString();
                f.textBox_phone.Text = datagrid.SelectedRows[0].Cells[3].Value.ToString();
                f.dateTimePicker1.Value = Convert.ToDateTime(datagrid.SelectedRows[0].Cells[4].Value);
                f.textBox_address.Text = datagrid.SelectedRows[0].Cells[5].Value.ToString();
                f.textBox_blood.Text = datagrid.SelectedRows[0].Cells[6].Value.ToString();
                f.textBox_email.Text = datagrid.SelectedRows[0].Cells[7].Value.ToString();
                f.textBox_address.Text = datagrid.SelectedRows[0].Cells[8].Value.ToString();
                f.ShowDialog();
                LoadData();
            }

        }
     }
}
 