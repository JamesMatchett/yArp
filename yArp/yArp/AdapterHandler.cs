using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    class AdapterHandler
    {
        public static bool GetAdapters(ListBox AdapterList)
        {
            //returns a boolean if adapters were successfully found
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (!AdapterList.Items.Contains(nic.Name))
                {
                    AdapterList.Items.Add(nic.Name);
                }
            }
            return AdapterList.Items.Count > 0;
        }
    }
}
