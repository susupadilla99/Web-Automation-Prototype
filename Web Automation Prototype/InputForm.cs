using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Automation_Prototype
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public string getSession()
        { return sessionInput.Text; } 

        public string getYear()
        { return yearInput.Text; }

        public string getTitle()
        { return titleInput.Text; }

        public string getContent()
        { return contentInput.Text; }
    }
}
