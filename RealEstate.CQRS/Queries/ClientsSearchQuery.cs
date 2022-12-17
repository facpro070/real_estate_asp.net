﻿using MediatR;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.CQRS.Queries
{
    public class ClientsSearchQuery : IRequest<SearchViewModel>
    {
        public ClientsSearchQuery(string query)
        {
            Query = query;
        }

        public string? Query { get; set; }
    }
}
