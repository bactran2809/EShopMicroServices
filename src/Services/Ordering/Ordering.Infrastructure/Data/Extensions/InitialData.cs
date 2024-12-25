namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers => 
            new List<Customer>()
            {
                Customer.Create(CustomerId.Of(new Guid("5de7b731-5649-4885-bc6e-a8b98bcd4137")), "Bac", "bac@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("dd3200ec-abb4-4b6e-b9fc-ff0bad1666d4")), "Bac 1", "bac1@gmail.com")
            }; 
        public static IEnumerable<Product> Products => 
            new List<Product>()
            {
                Product.Create(ProductId.Of(new Guid("beaa26c9-c453-47d8-94c3-d4f8d05e7134")), "Book 1", 1000000),
                Product.Create(ProductId.Of(new Guid("1ca32593-2120-4957-9fde-2a35a7bae0ba")), "Book 2", 2000000),
                Product.Create(ProductId.Of(new Guid("1b008ba4-a1be-42e7-a546-d1375fe83275")), "Book 3", 3000000),
                Product.Create(ProductId.Of(new Guid("45e90fd6-aa99-480f-9e80-639cb6bc1e4f")), "Book 4", 4000000)
            };

        public static IEnumerable<Order> OrderAndItems
        {
            get
            {
                var address1 = Address.Of("Bac", "Tran", "bac@gmail.com", "Bui Van Ba, P Tan Thuan Dong, Q7, TP HCM", "VN", "VN", "12345");
                var address2 = Address.Of("Bac 1", "Tran", "bac@gmail.com", "Bui Van Ba, P Tan Thuan Dong, Q7, TP HCM", "VN", "VN", "12345");

                var payment1 = Payment.Of("Card1", "999555666", "12/25", "123", 1);
                var payment2 = Payment.Of("Card2", "444222666", "12/25", "123", 2);

                var order1 = Order.Create(
                        OrderId.Of(Guid.NewGuid()),
                        CustomerId.Of(new Guid("5de7b731-5649-4885-bc6e-a8b98bcd4137")),
                        OrderName.Of("ORD1"),
                        address1,
                        address1,
                        payment1
                    );

                order1.Add(ProductId.Of(new Guid("beaa26c9-c453-47d8-94c3-d4f8d05e7134")), 2, 1000000);
                order1.Add(ProductId.Of(new Guid("1ca32593-2120-4957-9fde-2a35a7bae0ba")), 1, 2000000);

                var order2 = Order.Create(
                      OrderId.Of(Guid.NewGuid()),
                      CustomerId.Of(new Guid("dd3200ec-abb4-4b6e-b9fc-ff0bad1666d4")),
                      OrderName.Of("ORD2"),
                      address2,
                      address2,
                      payment2
                  );

                order1.Add(ProductId.Of(new Guid("1b008ba4-a1be-42e7-a546-d1375fe83275")), 2, 3000000);
                order1.Add(ProductId.Of(new Guid("45e90fd6-aa99-480f-9e80-639cb6bc1e4f")), 1, 4000000);

                return [order1, order2];  

            }
        }
    }
}