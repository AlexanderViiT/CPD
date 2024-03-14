using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace CPD.ZLogin.ARepositorios
{
    class InformacionRed
    {
        public IPAddress DireccionIP { get; set; }
        public PhysicalAddress DireccionMAC { get; set; }
    }

    class ObtenerServidor
    {
        public static List<InformacionRed> ObtenerInformacionRed()
        {
            List<InformacionRed> informacionRed = new List<InformacionRed>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            InformacionRed info = new InformacionRed();
                            info.DireccionIP = ip.Address;
                            info.DireccionMAC = nic.GetPhysicalAddress();
                            informacionRed.Add(info);
                        }
                    }
                }
            }

            return informacionRed;
        }
    }
}
