using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace IP_MAC_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> ipToMac = GetLocalIPToMacDictionary();

            Console.WriteLine("IP Address\tMAC Address");
            foreach (var entry in ipToMac)
            {
                Console.WriteLine($"{entry.Key}\t{entry.Value}");
            }
        }

        private static Dictionary<string, string> GetLocalIPToMacDictionary()
        {
            Dictionary<string, string> ipToMac = new Dictionary<string, string>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipToMac[ip.Address.ToString()] = nic.GetPhysicalAddress().ToString();
                        }
                    }
                }
            }

            return ipToMac;
        }
    }
}
