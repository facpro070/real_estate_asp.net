﻿using MediatR;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.CQRS.Queries
{
    public class GetEstateListQuery : IRequest<List<EstateViewModel>>
    {
        // As this lists all Properties it doesnt take in any parameter
    }
}
