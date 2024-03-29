﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.HttpClients
{
    public class CustomerHttpClient : ICustomerHttpClient
    {
        private HttpClient _httpClient;
        private readonly Uri URI_CUSTOMER = new Uri("https://localhost:5001/api/customers/");

        public CustomerHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = URI_CUSTOMER;
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<CustomerVM> ReadAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerVM>(id);
        }

        public async Task<string> CreateAsync(CustomerVM customer)
        {
            var request = await _httpClient.PostAsJsonAsync<CustomerCreateRequest>("",
                new CustomerCreateRequest(customer.Firstname, customer.Lastname));

            return await request.Content.ReadAsStringAsync();
        }
    }
}
