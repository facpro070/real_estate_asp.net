﻿using RealEstate.Models.Entities.BaseEntityModel;
using RealEstate.Models.Entities.Estates;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Entities.Listings
{
    public class Listing : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        public string Name { get; set; }

        public Estate Estate { get; set; }

        public int Price { get; set; }

        public double PricePerSquareMeter
        {
            set
            {
                if (value > 0 && Estate != null)
                {
                    //value = Price / Property.SquareMeters;
                }
            }
        }

        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
