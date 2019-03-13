using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    //This is where the fun beginss
    class DCONHandler
    {
        public static void DCON(ListView Devices, bool AutoDetect, TextBox subnetTextBox, ListBox AdapterList)
        {
            //check valid config
            if (Devices.CheckedItems.Count > 0)
            {
                if ((AutoDetect || ValidIP(subnetTextBox.Text)) && AdapterList.SelectedItems.Count > 1)
                {
                    foreach (ListViewItem LV in Devices.CheckedItems)
                    {
                        string targetIP = LV.SubItems[0].Text; //IP
                        string targetMAC = LV.SubItems[2].Text;

                        EthernetPacket Q = ARP_Sender.MakeArpRequest(PhysicalAddress.Parse("ABABABAB"), IPAddress.Parse(targetIP), IPAddress.Parse(subnetTextBox.Text), targetMAC);
                        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                        {
                            if ((string)AdapterList.SelectedItem == (nic.Name))
                            {
                                //send packet q using some voodoo
                            }
                        }

                    }
                }
            }
        }

        private static bool ValidIP(string input)
        {
            return (IPAddress.TryParse(input, out IPAddress temp));
        }
    }
}
