﻿using RealEstate.Core.Mapping;
using RealEstate.Infrastructure.Entities.Clients;

namespace RealEstate.Core.LookupModels
{
    public class EstateLookupModel : IMapFrom<Client>
    {
        public int Id { get; init; }

        public string? Estate_Name { get; set; }

        public int City_Id { get; set; }

        public int Estate_Type_Id { get; set; }

        public decimal Floor_Space { get; set; }

        public int Number_Of_Balconies { get; set; }

        public decimal Balconies_Space { get; set; }

        public int Number_Of_Bedrooms { get; set; }

        public int Number_Of_Bathrooms { get; set; }

        public int Number_Of_Garages { get; set; }

        public int Number_Of_Parking_Spaces { get; set; }

        public bool Pets_Allowed { get; set; }

        public string? Estate_Description { get; set; }

        public string? Estate_Status_Id { get; set; }

        public string Estate_ImageUrl { get; set; }

        public int Estate_Year_Built { get; set; }

        public int Estate_Year_Listed { get; set; }
    }
}
