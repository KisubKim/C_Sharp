using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace ConsoleTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Web 관련 Test 진행할것.
            Console.Write("Enter Host Name (ex> www.naver.com) : ");
            string strDomainName = Console.ReadLine();
            IPHostEntry host = null;
            try
            {
                host = Dns.GetHostEntry(strDomainName);
            }
            catch
            {
                Console.WriteLine("Dns.GetHostEntry() function Retuen Error. Check Please.");
            }
            
            Console.WriteLine("------------- 처리 결과 --------------");
            Console.WriteLine("Host Name : " + strDomainName);
            Console.WriteLine("IP Address : ");
            for (int i= 0; i<host.AddressList.Length; i++)
            {
                IPAddress ipAdd = host.AddressList[i];
                Console.WriteLine("[" + i + "] = " + ipAdd.ToString());
            }

            Console.WriteLine("------------- 처리 2 진행 ----------------------");
            Console.Write("Enter Host IP (ex> 192.168.100.100) : ");
            IPAddress ip = IPAddress.Parse(Console.ReadLine());

            
            try
            {
                IAsyncResult iResult = null;
                Dns.EndGetHostEntry(iResult);
                host = Dns.GetHostEntry(ip);

            }
            catch
            {
                Console.WriteLine("Dns.GetHostEntry() function Retuen Error. (In 2nd).");
            }

            Console.WriteLine("Host IP : " + ip);
            Console.WriteLine("Host Name : " + host.HostName);


        }
    }
}
