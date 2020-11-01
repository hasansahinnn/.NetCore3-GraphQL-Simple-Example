using System;
using System.Collections.Generic;
using System.Linq;
using GraphQLExample.Models;

namespace GraphQLExample.Helpers
{
    public class MarketingContext
    {
        private readonly List<Brand> _brands = new List<Brand>();
        private readonly List<Material> _material = new List<Material>();
        public MarketingContext()
        {
            //TODO: Dummy Brands
            for (int i = 0; i < 15; i++)
            {
                _brands.Add(new Brand
                {
                    Id = i,
                    Name = $"Brand-{i}"
                });
            }
            //TODO: Dummy Materials
            for (int i = 0; i < 50; i++)
            {
                Random random = new Random();
                _material.Add(new Material
                {
                    Id = i,
                    Name = $"Material-{i}",
                    Piece = random.Next(5),
                    Brand = _brands.FirstOrDefault(p => p.Id == random.Next(1, 15))
                });
            }
        }

        public List<Brand> GetBrands()
        {
            return _brands;
        }

        public List<Material> GetMaterials()
        {
            return _material;
        }

        public List<Material> GetMaterialsByBrandId(int brandId)
        {
            return _material.Where(p => p.Brand?.Id == brandId).ToList();
        }
        public List<Brand> GetByBrandId(int brandId)
        {
            return _brands.Where(p => p.Id == brandId).ToList();
        }
        public void AddBrand(Brand brand)
        {
            _brands.Add(brand);
        }
        public Brand RemoveBrand(int brandId)
        {
            Brand deletedUser = _brands.ElementAt(brandId);
            _brands.RemoveAt(brandId);
            return deletedUser;
        }
    }
}