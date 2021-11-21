using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Linq;

namespace ServicoEstoque
{
    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(
    RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EstoqueService : IEstoqueService, IEstoqueServiceV2
    {
        public List<String> ListarProdutos()
        {
            List<String> productsList = new List<String>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> products = (from product in database.Products
                                                     select product).ToList();
                    foreach (ProdutoEstoque product in products)
                    {
                        productsList.Add(product.NomeProduto + " - " + product.EstoqueProduto);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return productsList;
        }

        public bool IncluirProduto(ProductData Produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();

                    produtoEstoque.NumeroProduto = Produto.NumeroProduto;
                    produtoEstoque.NomeProduto = Produto.NomeProduto;
                    produtoEstoque.DescricaoProduto = Produto.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = Produto.EstoqueProduto;

                    database.Products.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    database.Products.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            int estoqueProduto = 0;

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    estoqueProduto = produtoEstoque.EstoqueProduto;
                }
            }
            catch
            {
            }

            return estoqueProduto;
        }

        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto + Quantidade;

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto - Quantidade;

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public ProductData VerProduto(string NumeroProduto)
        {
            ProductData productData = null;

            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.Products.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    productData = new ProductData()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NomeProduto = matchingProduct.NomeProduto,
                        DescricaoProduto = matchingProduct.DescricaoProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
            }
            
            return productData;
        }

    }
}