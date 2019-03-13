using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    class HostScanner
    {
        public static async Task ScanHosts(bool AutoDetect, TextBox subnetTextBox, ListBox AdapterList, ListView Devices)
        {
            if (AutoDetect)
            {
                subnetTextBox.Text = SubnetHandler.GetSubnet(AdapterList);
            }
            string root = subnetTextBox.Text + ".";
            var tasks = new List<Task>();
            for (int i = 0; i <= 255; i++)
            {
                var task = PingAsync(root + i, Devices);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        private static async Task PingAsync(string address, ListView Devices)
        {
            Ping ping = new Ping();
            var reply = await ping.SendPingAsync(address);
            if (reply.Status == IPStatus.Success)
            {
                //get host name
                //IPAddress ip = Dns.GetHostEntry(address).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                string[] rows = { address, "", MAC_Helper.GetMacAddress(address) };
                var listViewItem = new ListViewItem(rows);
                Devices.Items.Add(listViewItem);
            }
        }
    }
}
