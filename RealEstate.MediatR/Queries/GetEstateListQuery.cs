﻿using MediatR;
using RealEstate.Models.DTOs.Estates;

namespace RealEstate.MediatR.Queries
{
    public class GetEstateListQuery : IRequest<List<EstateDTO>>
    {
        // As this lists all Properties it doesnt take in any parameter
    }
}
