﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFocused.Client;
using BlazorFocused.Store;
using Integration.Shared.Models;
using Integration.ToDo.Models;

namespace Integration.ToDo.Actions
{
    public class GetToDoItems : IActionAsync<ToDoStore>
    {
        private readonly IRestClient restClient;

        public GetToDoItems(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public ToDoStore State { get; set; }

        public async ValueTask<ToDoStore> ExecuteAsync()
        {
            var items = await restClient.GetAsync<IEnumerable<ToDoItem>>("/api/todo");

            State.Items = items;

            return State;
        }
    }
}
