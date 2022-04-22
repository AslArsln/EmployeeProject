using EmployeeProject.DataAccess;
using EmployeeProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeProject
{
    public partial class PersonTracking : Form
    {
        public PersonTracking()
        {
            InitializeComponent();
        }
        ViewUnitEmployeeDal unitemployeedal = new ViewUnitEmployeeDal();
        UnitDal unıtdal = new UnitDal();
        Employee p = new Employee();
        EmployeeDal employeedal = new EmployeeDal();
       
        public void Refresh()
        {
            dataGridView1.DataSource = unitemployeedal.Getlist();
          
            unit.DataSource = unıtdal.Getlist();
        }

        void ClearDataBinding()
        {
            foreach(Control item in this.Controls)
            {
                item.DataBindings.Clear();
            }
        }

        void Data_Binding(Employee person)
        {
            ClearDataBinding();
            this.p = person;
            employee.DataBindings.Add("Text", p, "PersonelID");
            name.DataBindings.Add("Text", p, "AdiSoyadi");
            phone.DataBindings.Add("Text", p, "Telefon");
            address.DataBindings.Add("Text", p, "Adres");
            emaill.DataBindings.Add("Text", p, "Email");
            date.DataBindings.Add("Text", p, "Tarih",true);
            situation.DataBindings.Add("CheckState", p, "IsActive",true);
            unit.DataBindings.Add("SelectedValue", p, "BirimID",true);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
            Data_Binding(new Employee());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = unitemployeedal.Getlist(eu => eu.AdiSoyadi.Contains(search.Text));
            
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int employeeid = int.Parse(dataGridView1.CurrentRow.Cells["PersonelID"].Value.ToString());
            Data_Binding(employeedal.GetByFilter(eu => eu.PersonelID == employeeid));
        }

        private void newrecord_Click(object sender, EventArgs e)
        {
            Data_Binding(new Employee());
        }

        private void save_Click(object sender, EventArgs e)
        {
            employeedal.AddorUpdate(p);
            employeedal.Save();
            Refresh();
            Data_Binding(new Employee());
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int employeeid = int.Parse(dataGridView1.CurrentRow.Cells["PersonelID"].Value.ToString());
            employeedal.Delete(d=>d.PersonelID == employeeid);
            employeedal.Save();
            Refresh();
            Data_Binding(new Employee());
        }
    }
}
