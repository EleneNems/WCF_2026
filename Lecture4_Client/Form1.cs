using Classwork_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lecture4_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cient = new ServiceClient();
            string result = client.GetData(5);
            this.label1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BasicHttpBinding binding = new BasicHttpBinding;
            EndpointAdress endpoint = new EndpointAdress("http://localhost:53568/Service1.svc");
            ChannelFactory<IService> channel = new ChannelFactory<IService>(binding, endpoint);
            IService1 service1 = channel.CreateChannel();
            string result = service1.GetData(5);
            this.label2.Text = result;

        }
    }
}
