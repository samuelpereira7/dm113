using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServicoEstoque;

namespace EstoqueServiceHost
{
    class Program
    {
         static void Main(string[] args)
         {
            ServiceHost productsServiceHost = new ServiceHost(typeof(EstoqueService));
            productsServiceHost.Open();
            Console.WriteLine("Service Running");
            Console.ReadLine();
            Console.WriteLine("Service Stopping");
            productsServiceHost.Close();
        }
    }
}
