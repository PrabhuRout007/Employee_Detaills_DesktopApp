using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eva_DataBase_App
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            if (textBox_id.ReadOnly == false)
            {
                EvaDataBase obj = new EvaDataBase();

                obj.Id = int.Parse(textBox_id.Text);
                obj.FirstName = textBox_firstname.Text;
                obj.SecondName = textBox_lastname.Text;
                obj.PhoneNo = textBox_phone.Text;
                obj.Email = textBox_email.Text;
                obj.DOB = dateTimePicker1.Value;
                obj.BloodGroup = textBox_blood.Text;
                obj.Address = textBox_address.Text;
                obj.Department = textBox_department.Text;

                db.EvaDataBases.InsertOnSubmit(obj);
                db.SubmitChanges();
                MessageBox.Show("Record has been submited.");
            }
            else
            {
                EvaDataBase obj = db.EvaDataBases.SingleOrDefault(E => E.Id == int.Parse(textBox_id.Text));

                obj.FirstName = textBox_firstname.Text;
                obj.SecondName = textBox_lastname.Text;
                obj.PhoneNo = textBox_phone.Text;
                obj.DOB = dateTimePicker1.Value;
                obj.Address = textBox_address.Text;
                obj.BloodGroup = textBox_blood.Text;
                obj.Email = textBox_email.Text;
                obj.Department = textBox_department.Text;
                db.SubmitChanges();
                MessageBox.Show("Record has been Updated");
              
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = ctrl as TextBox;
                    tb.Clear();
                }
            }
            close.Focus();
        }
    }
  }

