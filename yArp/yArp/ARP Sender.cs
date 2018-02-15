using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace yArp
{
    class ARP_Sender
    {
         //in prog
       public static EthernetPacket MakeArpRequest(PhysicalAddress InterfaceMacAddress, IPAddress destinationIP, IPAddress senderIP, string FakeMac)
        {
            try
            {
                PhysicalAddress fakeBroadcastMAC = PhysicalAddress.Parse(FakeMac);

                EthernetPacket ethernetpacket = new EthernetPacket(InterfaceMacAddress,
                fakeBroadcastMAC, EthernetPacketType.Arp);

                ARPPacket arppacket = new ARPPacket(ARPOperation.InARPRequest, fakeBroadcastMAC,
                destinationIP, InterfaceMacAddress, senderIP);

                ethernetpacket.PayloadPacket = arppacket;

                return ethernetpacket;
            }
            catch
            {
                return null;
            }
        }
    } 
    }
}
