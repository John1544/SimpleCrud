using DataConnection;
using Model.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Rep
{

    public partial class Form1 : Form
    {
        Connection Conn = new Connection();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            PersonsModel model = new PersonsModel();
            model.FirstName = FirstName.Text;
            model.LastName = LastName.Text;
            /*model.TypeId = TypeId.*/

            Conn.AddEmployee(model);
            loadPersons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadPersons();
        }

        private void loadPersons()
        {
            DataGridViewPersons.DataSource = null;
            DataGridViewPersons.DataSource = Conn.GetAllPersons();
        }
    }
}
