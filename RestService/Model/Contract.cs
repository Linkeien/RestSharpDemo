namespace RestService.Model
{
    public enum Product
    {
        P1 = 1,
        P2 = 2,
        P3 = 3
    }

    public class Contract
    {
        public Contract(int contractNumber, string name, string street, string city, Product product)
        {
            ContractNumber = contractNumber;
            CustomerAddress = new Address
            {
                Name = name,
                Street = street,
                City = city
            };
            Product = product;
        }

        public int ContractNumber { get; set; }
        public Address CustomerAddress { get; set; }
        public Product Product { get; set; }
    }
}