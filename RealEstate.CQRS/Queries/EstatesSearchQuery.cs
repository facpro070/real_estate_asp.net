﻿using MediatR;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.CQRS.Queries
{
    public class EstatesSearchQuery : IRequest<SearchViewModel>
    {
        public string? Query { get; set; }

        public string? City { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Sort { get; set; }
    }
}
