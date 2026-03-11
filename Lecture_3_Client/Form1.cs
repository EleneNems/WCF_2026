using Lecture_3_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_3_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new Service1Client();
            string result = client.GetData(5);
            this.label1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BasicHttpBinding binding= new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://localhost:53568/Service1.svc/AddNew");
            ChannelFactory<IService1> channelFactory = new ChannelFactory<IService1>(binding, endpoint);
            IService1 channel = channelFactory.CreateChannel();
            string result = channel.GetData(5);
            this.label2.Text = result;
            channelFactory.Close();
        }
    }
}
