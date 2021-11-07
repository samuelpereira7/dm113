using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient.ServicoEstoque;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER quando o serviço for iniciado");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            // Test the operations in the service
            Console.WriteLine("Cliente 1");
            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 1: Adicionar o produto 11");
            ProductData productData = new ProductData()
            {
                NumeroProduto = "1",
                NomeProduto = "Produto 11",
                DescricaoProduto = "Novo produto 11",
                EstoqueProduto = 11
            };

            if (proxy.IncluirProduto(productData))
            {
                Console.WriteLine("Produto incluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao incluir novo produto.");
            }

            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 2: Remover produto 10");
            if (proxy.RemoverProduto("10000"))
            {
                Console.WriteLine("Produto 10 removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao remover produto 10.");
            }

            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 3: Listar todos os produtos");
            List<String> products = proxy.ListarProdutos().ToList();
            foreach (String p in products)
            {
                Console.WriteLine("Nome do produto: {0}", p);
                Console.WriteLine();
            }

            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 4: Mostrar informações do produto 2");
            ProductData product = proxy.VerProduto("2000");
            Console.WriteLine("Número do produto: {0}", product.NumeroProduto);
            Console.WriteLine("Nome do produto: {0}", product.NomeProduto);
            Console.WriteLine("Descrição do produto: {0}", product.DescricaoProduto);
            Console.WriteLine("Estoque de produto: {0}", product.EstoqueProduto);

            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 5: Adicionar estoque para produto 2");
            if (proxy.AdicionarEstoque("2000", 7))
            {
                Console.WriteLine("Estoque adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao adicionar estoque");
            }

            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 6: Verificar estoque do produto 2");
            Console.WriteLine("Estoque produto 2: {0}", proxy.ConsultarEstoque("2000"));
            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 7: Verificar estoque do produto 1");
            Console.WriteLine("Estoque do produto 1: {0}", proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 8: Remover estoque do produto 1");
            if (proxy.RemoverEstoque("1000", 20))
            {
                Console.WriteLine("Estoque removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao remover estoque do produto 1!");
            }

            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 9: Verificar estoque do produto 1 novamente");
            Console.WriteLine("Estoque do produto 1 novamente: {0}", proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            /**********************************************************************/

            Console.WriteLine("Teste 10: Ver informações do produto 1");
            ProductData product1 = proxy.VerProduto("1000");
            Console.WriteLine("Número do produto: {0}", product1.NumeroProduto);
            Console.WriteLine("Nome do produto: {0}", product1.NomeProduto);
            Console.WriteLine("Descrição do produto: {0}", product1.DescricaoProduto);
            Console.WriteLine("Estoque de produto: {0}", product1.EstoqueProduto);

            Console.WriteLine();

            /**********************************************************************/

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
