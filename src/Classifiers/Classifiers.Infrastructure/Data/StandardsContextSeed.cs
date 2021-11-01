using Microsoft.EntityFrameworkCore;
using CDPN.Classifiers.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        public static async Task SeedAsync(ClassifiersContext ClassifiersContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = 0;
            try
            {
                // TODO: Only run this if using a real database
                // catalogContext.Database.Migrate();
                if (!await ClassifiersContext.Currencies.AnyAsync())
                {
                    await ClassifiersContext.Currencies.AddRangeAsync(GetPreconfiguredCurrencies());

                    await ClassifiersContext.SaveChangesAsync();
                }

                if (!await ClassifiersContext.Countries.AnyAsync())
                {
                    //var c = GetPreconfiguredCountries()
                    //      .GroupBy(x => x.Alpha3)
                    //      .Where(g => g.Count() > 1)
                    //      .Select(y => y.Key)
                    //      .ToList();
                    await ClassifiersContext.Countries.AddRangeAsync(GetPreconfiguredCountries());

                    await ClassifiersContext.SaveChangesAsync();
                }

                if (!await ClassifiersContext.RegionLevels.AnyAsync())
                {
                    await ClassifiersContext.RegionLevels.AddRangeAsync(GetPreconfiguredRegionLevels());

                    await ClassifiersContext.SaveChangesAsync();
                }

                if (!await ClassifiersContext.Regions.AnyAsync())
                {
                    await ClassifiersContext.Regions.AddRangeAsync(GetPreconfiguredRegions());

                    await ClassifiersContext.SaveChangesAsync();
                }

                if (!await ClassifiersContext.PaperSizes.AnyAsync())
                {
                    await ClassifiersContext.PaperSizes.AddRangeAsync(GetPreconfiguredPaperSizes());

                    await ClassifiersContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < retry)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ClassifiersContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(ClassifiersContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

    }
}
