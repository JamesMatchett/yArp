using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    class SubnetHandler
    {
        public static string GetSubnet(ListBox AdapterList)
        {
            if (AdapterList.SelectedItem == null)
            {
                if (AdapterList.Items.Count == 0)
                {
                    if (!AdapterHandler.GetAdapters(AdapterList))
                    {
                        MessageBox.Show("Can't automatically derive subnet as no adapters could be found");
                        return null;
                    }
                }
                AdapterList.SelectedItem = AdapterList.Items[0];
            }

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                {
                    if (nic.Name == AdapterList.SelectedItem.ToString())
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return FilterToSubnet(ip.Address.ToString());
                        }
                    }
                }
            }
            return "not found";
        }

        private static string FilterToSubnet(string input)
        {
            //example 192.16.0.1 -> 192.16.0.
            return input.Substring(0, input.LastIndexOf("."));
        }
    }
}
