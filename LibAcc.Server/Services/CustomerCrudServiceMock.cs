using LibAcc.Abstractions.Models;

namespace LibAcc.Server.Services
{
    public class CustomerCrudServiceMock : CrudServiceMockBase<Customer>
    {
        private static Customer[] _dataSet =
        {
            new Customer
            {
                CustomerId = 1,
                FirstName = "Ilya",
                LastName = "Ivanov",
                PhoneNumber = "+375-42-678-88-44"
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Nikita",
                LastName = "Sidorenko",
                PhoneNumber = "+375-32-934-13-15"
            },
            new Customer
            {
                CustomerId = 3,
                FirstName = "Igor",
                LastName = "Korneluk",
                PhoneNumber = "+375-45-578-28-36"
            },

        };

        public CustomerCrudServiceMock() : base(_dataSet)
        {
        }
    }
}
