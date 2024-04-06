using DbConsoleApp;
using Moq;

namespace MentorshopProgramTest
{
    public class QueryExecutorServiceTests
    {
        [Fact]
        public void GetProducts_ReturnsListOfProducts_WhenQueried()
        {
            // Arrange
            var mockDbConnection = new Mock<IDatabaseConnection>();
            var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 100M },
                new Product { Id = 2, Name = "Product 2", Price = 200M }
            };

            // Setup mock to return expected products when any query is passed
            mockDbConnection.Setup(m => m.GetProducts(It.IsAny<string>())).Returns(expectedProducts);

            var queryExecutorService = new QueryExecutorService(mockDbConnection.Object);

            // Act
            var products = queryExecutorService.FetchProducts();

            // Assert
            Assert.Equal(expectedProducts.Count, products.Count);
            Assert.Equal(expectedProducts[0].Name, products[0].Name); // Sample assertion, add more as needed.
        }
    }
}
