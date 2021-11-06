using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace Products
{
    // Service contract describing the operations provided by the WCF service (v1)
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IEstoqueService
    {
        [OperationContract]
        List<string> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(ProductData Produto);

        [OperationContract]
        bool RemoverProduto(string NumeroProduto);

        [OperationContract]
        int ConsultarEstoque(string NumeroProsuto);

        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        ProductData VerProduto(string NumeroProduto);
    }

    // Service contract describing the operations provided by the WCF service (v2)
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IEstoqueServiceV2
    {
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        int ConsultarEstoque(string NumeroProsuto);
    }

    // Data contract describing the details of a product passed to client applications
    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string NumeroProduto;
        
        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;
    }
}