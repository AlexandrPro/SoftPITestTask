using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Model;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'logModelDataSet.Logs' table. You can move, or remove it, as needed.
            this.logsTableAdapter.Fill(this.logModelDataSet.Logs);
            LogModel db = new LogModel();
            var logs = db.Logs.Include(l => l.File).Include(l => l.HTTPMethod).Include(l => l.IPAdress1)
                .Select(l => new DataBindingProjection()
                {
                    IPAdress = l.IPAdress,
                    IPAdressCompanyName = l.IPAdress1.NAme,
                    FileTitle = l.File.PageName,
                    PathAndName = l.File.PathAndName,
                    HTTPMethod = l.HTTPMethod.Name,
                    HTTPStatus = l.HTTPStatus
                });
            dataGridView1.DataSource = logs.ToList();
            dataGridView1.Columns[0].DataPropertyName = "IPAdress";
            dataGridView1.Columns[1].DataPropertyName = "IPAdressCompanyName";
            dataGridView1.Columns[2].DataPropertyName = "FileTitle";
            dataGridView1.Columns[3].DataPropertyName = "PathAndName";
            dataGridView1.Columns[4].DataPropertyName = "HTTPMethod";
            dataGridView1.Columns[5].DataPropertyName = "HTTPStatus";
        }
    }
}
