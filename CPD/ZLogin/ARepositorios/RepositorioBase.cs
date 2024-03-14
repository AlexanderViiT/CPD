using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Net.NetworkInformation;
namespace CPD.ZLogin.ARepositorios
{
    public abstract class RepositorioBase
    {
        private readonly string _connectionString;
        public RepositorioBase()
        {
            string macBuscada = "38B1DBB5D7EB";
            string ipAsignada = ObtenerIPPorMAC(macBuscada);
            //_connectionString = "Server=192.168.100.109; User Id=conexion; Password=conexion; Database=CPD; TrustServerCertificate=True";
            if (ipAsignada != null)
            {
                _connectionString = $"Server={ipAsignada}; Integrated Security=true; Database=CPD; TrustServerCertificate=True";
            }
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        private string ObtenerIPPorMAC(string macBuscada)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    if (nic.GetPhysicalAddress().ToString() == macBuscada)
                    {
                        foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            return null; // No se encontró la MAC
        }
    }
}
