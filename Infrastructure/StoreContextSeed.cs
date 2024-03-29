﻿using Core.Context;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task AsyncSeed(StoreDbContext context , ILoggerFactory loggerFactory)
        {
			try
			{
				if(context.ProductBrands != null && !context.ProductBrands.Any())
				{
					var brandsData = File.ReadAllText("../Infrastructure/SeedData/brands.json");

					var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands is not null)
                    {
                        foreach (var brand in brands)
                            await context.ProductBrands.AddAsync(brand);

                        await context.SaveChangesAsync();

                    }

                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if (types is not null)
                    {
                        foreach (var type in types)
                            await context.ProductTypes.AddAsync(type);

                        await context.SaveChangesAsync();
                    }

                }
                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products is not null)
                    {
                        foreach (var product in products)
                            await context.Products.AddAsync(product);

                        await context.SaveChangesAsync();
                    }

                }
                if (context.DeliveryMethods != null && !context.DeliveryMethods.Any())
                {
                    var deliveryMethodsData = File.ReadAllText("../Infrastructure/SeedData/delivery.json");

                    var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodsData);

                    if (deliveryMethods is not null)
                    {
                        foreach (var product in deliveryMethods)
                            await context.DeliveryMethods.AddAsync(product);

                        await context.SaveChangesAsync();
                    }

                }
            }
			catch (Exception ex)
			{
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
				
			}
        }
    }
}
