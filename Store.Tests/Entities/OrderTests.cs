using Newtonsoft.Json.Linq;
using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new("Gustavo", "Monteiro");
        private readonly Product _product = new("Produto 1", 10, true);
        private readonly Discount _discount = new(0, DateTime.Now);

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenNewOrderShouldReturnOneNumberWith8Characters()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            // Act
            // Assert
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenNewOrderShouldPaymentStatusPendent()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            // Act
            // Assert
            Assert.AreEqual(Domain.Enums.EOrderStatus.WaitingPayment, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenOrderIsPaidShouldStatusIsWaitingDelivery()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            order.AddItem(_product, 1);
            order.Pay(order.Total());
            // Act
            // Assert
            Assert.AreEqual(Domain.Enums.EOrderStatus.WaitingDelivery, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenOrderIsCanceledShouldStatusIsCanceled()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            order.Cancel();
            // Act
            // Assert
            Assert.AreEqual(Domain.Enums.EOrderStatus.Canceled, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenNewTtemWithoutProductIsGivenShouldNotBeAdded()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            order.AddItem(null, 0);
            // Act
            // Assert
            Assert.AreEqual(false, order.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenNewItemWithQuantityZeroOrLessIsGivenShouldBeNotAdded()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            order.AddItem(_product, 0);
            // Assert
            Assert.AreEqual(false, order.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void WhenNewValidOrderIsCreatedTotalShouldBe50()
        {
            // Arrange
            Order order = new(_customer, _discount, 0);
            order.AddItem(_product, 5);
            // Assert
            Assert.AreEqual(50, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void GivenAnExpiredDiscountTheOrderValueShouldBe60()
        {
            Discount discountExpired = new(10, DateTime.Parse("04/09/2023"));
            // Arrange
            Order order = new(_customer, discountExpired, 0);
            order.AddItem(_product, 6);
            // Assert
            Assert.AreEqual(60, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void GivenAInvalidDiscountTheOrderValueShouldBe60()
        {
            // Arrange
            Order order = new(_customer, null, 0);
            order.AddItem(_product, 6);
            // Assert
            Assert.AreEqual(60, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void GivenADiscountOf10TheOrderValueShouldBe50()
        {
            Discount discount = new(10, DateTime.Now.AddDays(5));
            // Arrange
            Order order = new(_customer, discount, 0);
            order.AddItem(_product, 6);
            // Assert
            Assert.AreEqual(50, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void GivenADeliveryFeeOf10TheOrderValueShouldBe60()
        {
            // Arrange
            Order order = new(_customer, _discount, 10);
            order.AddItem(_product, 5);
            // Assert
            Assert.AreEqual(60, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void GivenAOrderWithoutClientShouldBeInvalid()
        {
            // Arrange
            Order order = new(null, _discount, 10);
            order.AddItem(_product, 5);
            // Assert
            Assert.AreEqual(false, order.IsValid);
        }
    }
}