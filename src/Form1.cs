using System;
using System.Configuration;
using System.Windows.Forms;

namespace ExternalConnectionStringWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            var settings = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings setting in settings)
            {
                var info = new DisplayInfo(setting);
                this.listBox1.Items.Add(info);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) => this.propertyGrid1.SelectedObject = this.listBox1.SelectedItem;

        private sealed class DisplayInfo
        {
            public DisplayInfo(ConnectionStringSettings setting) => this.Setting = setting;
            public ConnectionStringSettings Setting { get; }
            public override string ToString() => this.Setting.Name;
        }
    }
}
