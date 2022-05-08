using Microsoft.AspNetCore.Components;
using MVVMNy.Models;

namespace MVVMNy.ViewModel
{
    public interface ICustomerViewModel
    {
        void NewCustomer();
        List<Customer> customers { get; }

        Customer SelectedCustomer { get; set; }

        Task<Customer> CustomerSelected(ChangeEventArgs args);

        Task<Customer> GetCustomer(int id);
        Task UpdateSelectedCustomer();
        Task AddCustomer();
        Task DeleteSelectedCustomer();
    }
}
