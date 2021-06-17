using System;
using System.Collections.Generic;

namespace DynamicPdfCoreSuite.Example
{
    public static class MaterialRepository
    {
        public static List<Material> GetMaterialList()
        {

            var randomNumberGenerator = new Random();

            return
                new List<Material>()
                {
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "8"+'"'+ " CMU Wall",
                        Unit = "ft",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    },
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "10"+'"'+ " CMU Wall",
                        Unit = "ft",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    },
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "12"+'"'+ " CMU Wall",
                        Unit = "ft",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    },
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "14"+'"'+ " CMU Wall",
                        Unit = "ft",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    },
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "6-1/2"+'"'+"x8"+'"'+" Cast Stone WaterTable",
                        Unit = "ft",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    },
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "#8 Bare Copper Wire",
                        Unit = "lf",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    },
                    new Material()
                    {
                        Id = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Amount = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}"),
                        Name = "30"+'"'+" Mega Lug for Ductile Iron Pipe",
                        Unit = "ft",
                        Value = int.Parse($@"{Math.Round(double.Parse($@"{randomNumberGenerator.Next(1, 1000)}"), 0)}")
                    }
                };
        }
    }
}
