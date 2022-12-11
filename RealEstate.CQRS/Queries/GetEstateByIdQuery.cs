﻿using MediatR;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.CQRS.Queries
{
    public class GetEstateByIdQuery : IRequest<EstateViewModel>
    {
        public int Id { get; set; }

        public GetEstateByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
