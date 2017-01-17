﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHairLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrettyHairTests
{
    [TestClass]
    public class Tests
    {
        ProductTypeRepository productRepo = new ProductTypeRepository();

        [TestMethod]
        public void CanAddProduct()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            Assert.AreEqual(product, productRepo.GetProduct(00));
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void CanDeleteProduct()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            productRepo.Delete(product.ID);
            productRepo.GetProduct(00);
        }
        [TestMethod]
        public void CanAdjustPrice()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            productRepo.AdjustPrice(00, 4.99);
            Assert.AreEqual(4.99, productRepo.GetProduct(00).Price);
        }
        [TestMethod]
        public void ToStringReturnsCorrectString()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            Assert.AreEqual("Product ID: " + 00 +
                            "Product description: product" +
                            "Product price: " + 5.99 +
                            "Product amount: " + 10, productRepo.GetProduct(00).ToString());
        }
        [TestMethod]
        public void CanAdjustAmount()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            productRepo.AdjustAmount(00, 5);
            Assert.AreEqual(5, productRepo.GetProduct(00).Amount);
        }
        [TestMethod]
        public void CanAdjustDescription()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            productRepo.AdjustDescription(00, "not a product");
            Assert.AreEqual("not a product", productRepo.GetProduct(00).Description);
        }
        [TestMethod]
        public void CanHaveMultipleProducts()
        {
            ProductType product = new ProductType(00, "product", 5.99, 10);
            productRepo.Add(product);
            ProductType product2 = new ProductType(01, "product2", 10.99, 50);
            productRepo.Add(product2);
            Assert.AreEqual("Product ID: " + 00 +
                            "Product description: product" +
                            "Product price: " + 5.99 +
                            "Product amount: " + 10 +
                            "Product ID: " + 01 +
                            "Product description: product2" +
                            "Product price: " + 10.99 +
                            "Product amount: " + 50, productRepo.GetProduct(00).ToString() +
                            productRepo.GetProduct(01).ToString());
        }
        [TestMethod]
        public void CanTrigerEvent()
        {

        }
        [TestMethod]
        public void CanSendEmail()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Please input a price that is greater than or equal to 0.")]
        public void CanNotHaveNegativePrice()
        {
            ProductType product = new ProductType(00, "product", -5.99, 10);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Please input an amount that is greater than or equal to 0.")]
        public void CanNotHaveNegativeAmount()
        {
            ProductType product = new ProductType(00, "product", 5.99, -10);
        }
        
    }
}
