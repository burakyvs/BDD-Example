using ECommerce.Business;
using ECommerce.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public sealed class ECommerceStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly ECommerceOperations _eCommerceOperations;
        private Product _selectedItem;

        public ECommerceStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _eCommerceOperations = new ECommerceOperations();
        }

        [Given("user has products to select")]
        public void GivenUserHasProductsToSelect()
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            //_scenarioContext.Pending();

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Kalem",
                    Quantity = 50,
                    Price = 2
                },
                new Product()
                {
                    Name = "Silgi",
                    Quantity = 50,
                    Price = 1
                },
                new Product()
                {
                    Name = "Kalemtiras",
                    Quantity = 10,
                    Price = 3,
                }
            };

            _eCommerceOperations._products = products;
        }

        [When("user selects one product and adds to the basket")]
        public void WhenUserAddsProductToBasket()
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            //_scenarioContext.Pending();
            _selectedItem = _eCommerceOperations._products[0];
            _eCommerceOperations._basket.AddToBasket(_selectedItem, 1);
        }

        [Then("the basket should contains the product")]
        public void ThenTheResultShouldBe()
        {
            //TODO: implement assert (verification) logic

            //_scenarioContext.Pending();

            _eCommerceOperations._basket.CountBasket().Should().BeGreaterThan(0);
            _eCommerceOperations._basket.FindInBasket(_selectedItem).Should().BeTrue();
        }

        // SCENARIO #2

        [Given("system already has (.*) Kalem products")]
        public void GivenSystemAlreadyHasKalemProducts(int quantity)
        {

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Kalem",
                    Quantity = quantity,
                    Price = 2
                },
                new Product()
                {
                    Name = "Silgi",
                    Quantity = 50,
                    Price = 1
                },
                new Product()
                {
                    Name = "Kalemtiras",
                    Quantity = 10,
                    Price = 3,
                }
            };

            _eCommerceOperations._products = products;
        }

        [When("admin adds a new Kalem product with quantity (.*)")]
        public void WhenAdminAddsNewKalemProduct(int quantity)
        {
            Product newKalem = new Product()
            {
                Name = "Kalem",
                Quantity = quantity,
                Price = 2,

            };
            _eCommerceOperations.AddProduct(newKalem);
        }

        [Then("Kalem quantity should be (.*)")]
        public void ThenTheQuantityShouldBe(int quantity)
        {
            Product kalem = _eCommerceOperations._products.Where(i => i.Name == "Kalem").FirstOrDefault();
            kalem.Should().NotBeNull();
            kalem.Quantity.Should().Be(quantity);
        }

        // SCENARIO #3

        [Given("the system has Kalem, Silgi and Kalemtiras, the prices are (.*) , (.*) , (.*)")]
        public void GivenSystemHasProducts(int price1, int price2, int price3)
        {

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Kalem",
                    Quantity = 50,
                    Price = price1
                },
                new Product()
                {
                    Name = "Silgi",
                    Quantity = 50,
                    Price = price2
                },
                new Product()
                {
                    Name = "Kalemtiras",
                    Quantity = 50,
                    Price = price3
                }
            };

            _eCommerceOperations._products = products;
        }

        [When("user adds (.*) Kalem, (.*) Silgi and (.*) Kalemtiras to the basket")]
        public void WhenUserAddsItemsToTheBasket(int count1, int count2, int count3)
        {
            _eCommerceOperations._basket.AddToBasket(_eCommerceOperations._products[0], count1);
            _eCommerceOperations._basket.AddToBasket(_eCommerceOperations._products[1], count2);
            _eCommerceOperations._basket.AddToBasket(_eCommerceOperations._products[2], count3);
        }

        [Then("total price of the basket should be (.*)")]
        public void ThenTotalPriceShouldBe(int totalPrice)
        {
            _eCommerceOperations._basket.TotalPrice.Should().Be(totalPrice);
        }
    }
}
