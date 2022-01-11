using System;
using System.Collections.Generic;

namespace LetKeyword
{
    public static class ShoppingDB
    {
        public static IEnumerable<Shop> GetShops()
        {
            var result = new List<Shop>()
            {
                new Shop
                {
                    Id    = 1,
                    Name  = "Shop 1",
                    Sales = new List<Sale>()
                    {
                        new Sale{ Id = 1,  Date = new DateTime(2017,01,02), Amount =  1520m },
                        new Sale{ Id = 8,  Date = new DateTime(2017,01,26), Amount =   500m },
                        new Sale{ Id = 25, Date = new DateTime(2017,02,15), Amount =  8900m },
                        new Sale{ Id = 26, Date = new DateTime(2017,02,28), Amount = 40000m },
                        new Sale{ Id = 39, Date = new DateTime(2017,03,02), Amount = 75000m }
                    }
                },
                new Shop
                {
                    Id    = 2,
                    Name  = "Shop 2",
                    Sales = new List<Sale>()
                    {
                        new Sale{ Id = 2,  Date = new DateTime(2017,01,06), Amount =     10m },
                        new Sale{ Id = 3,  Date = new DateTime(2017,01,08), Amount =   3000m },
                        new Sale{ Id = 11, Date = new DateTime(2017,02,11), Amount = 100000m },
                        new Sale{ Id = 12, Date = new DateTime(2017,02,12), Amount = 515000m },
                        new Sale{ Id = 42, Date = new DateTime(2017,03,12), Amount =     25m },
                        new Sale{ Id = 43, Date = new DateTime(2017,03,12), Amount =    200m },
                        new Sale{ Id = 52, Date = new DateTime(2017,03,16), Amount =    300m }
                    }
                },
                new Shop
                {
                    Id    = 3,
                    Name  = "Shop 3",
                    Sales = new List<Sale>()
                    {
                        new Sale{ Id = 13,  Date = new DateTime(2017,02,12), Amount = 2500m },
                        new Sale{ Id = 14,  Date = new DateTime(2017,02,12), Amount = 3000m }
                    }
                },
                new Shop
                {
                    Id    = 4,
                    Name  = "Shop 4",
                    Sales = new List<Sale>()
                    {
                        new Sale{ Id = 15, Date = new DateTime(2017,01,13), Amount =  79000m },
                        new Sale{ Id = 16, Date = new DateTime(2017,01,13), Amount =   6000m },
                        new Sale{ Id = 53, Date = new DateTime(2017,03,17), Amount = 145000m },
                        new Sale{ Id = 54, Date = new DateTime(2017,03,17), Amount =   5000m },
                        new Sale{ Id = 55, Date = new DateTime(2017,03,18), Amount =  37800m },
                        new Sale{ Id = 56, Date = new DateTime(2017,03,19), Amount =  11200m },
                        new Sale{ Id = 57, Date = new DateTime(2017,03,26), Amount =  22580m },
                        new Sale{ Id = 58, Date = new DateTime(2017,04,01), Amount =   1000m },
                        new Sale{ Id = 59, Date = new DateTime(2017,04,02), Amount =   9000m },
                        new Sale{ Id = 60, Date = new DateTime(2017,04,03), Amount = 990000m },
                        new Sale{ Id = 61, Date = new DateTime(2017,04,04), Amount =   8000m },
                        new Sale{ Id = 62, Date = new DateTime(2017,04,05), Amount =  52580m },
                        new Sale{ Id = 63, Date = new DateTime(2017,04,06), Amount = 558900m },
                        new Sale{ Id = 64, Date = new DateTime(2017,04,07), Amount =  88900m }
                    }
                }
            };

            return result;
        }
    }
}