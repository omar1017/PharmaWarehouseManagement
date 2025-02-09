using AlkinanaPharmaManagment.Domain.Entities.Customers.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;


namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public class Customer : AggregateRoot
    {
        public CustomerId CustomerId { get; private set; }

        public CustomerName customerName{get; private set; }

        public Pharma pharma {get; private set; }

        public Address address { get; private set; }

        public PhoneNumber Phone { get; private set; }


        public static Customer CreateCustomer(CustomerName customerName, Address address, Pharma pharma, PhoneNumber phone)
        {
            var customer = new Customer(new CustomerId(Guid.NewGuid()),
                customerName,
                pharma,
                address,
                phone);
  
            return customer;
        }

        public Customer()
        {
            
        }

        internal Customer(
                CustomerId customerId,
                CustomerName customerName,
                Pharma pharma,
                Address address,
                PhoneNumber phone
            ) {
            CustomerId = customerId;
            this.customerName = customerName;
            this.pharma = pharma;
            this.address = address;
            this.Phone = phone;
        }

    }
}
