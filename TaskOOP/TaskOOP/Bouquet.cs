using System;
using System.Collections.Generic;

namespace FlowerShop
{
    internal class Bouquet : IHasPrice
    {
        List<Flower> flowers;
        List<Accessory> accessories;
        int quantityOfFlowers, quantityOfAccessories;
        public double TotalPrice { get; private set; }
        public Bouquet(int quantityOftheFlowers, int quantityOfTheAccessories)
        {
            quantityOfAccessories = quantityOfTheAccessories;
            accessories = new List<Accessory>(quantityOfAccessories);
            quantityOfFlowers = quantityOftheFlowers;
            flowers = new List<Flower>(quantityOfFlowers);
            AddElementsToBouquet(quantityOfTheAccessories, ref quantityOfAccessories, flowers);
            AddElementsToBouquet(quantityOftheFlowers, ref quantityOfAccessories, accessories);
        }
        public Flower? FindFlowerOfCertainDiapasonOfStemLengthOrNull(int start, int end)
        {
            foreach (Flower flower in flowers)
            {
                if (flower.LengthOfStemInSm >= start && flower.LengthOfStemInSm <= end)
                {
                    return flower;
                }
            }
            return null;
        }
        public void MakeSortByFreshness()
        {
            flowers.Sort();
        }
        private void AddElementsToBouquet(int totalQuant, ref int quantityOfAccessories, List<Accessory> arrayOfTheElements)
        {
            byte choice;
            for (int i = 0; i < quantityOfAccessories; i++)
            {
                Console.WriteLine("Pick the accessory:\n0 - ribbon\n1 -package:");
                if (!byte.TryParse(Console.ReadLine(), out choice))
                {
                    throw new ArgumentException("Wrong value of choice");
                }
                else
                 {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine($"Pick the color of the ribbon:\n0 - {ColorRibbon.Colors.Red}\n1 - {ColorRibbon.Colors.Yellow}\n2 - {ColorRibbon.Colors.Green}:");
                            if (!byte.TryParse(Console.ReadLine(), out choice))
                            {
                                throw new ArgumentException("Wrong value of choice");
                            }
                            switch (choice)
                            {
                                case 0:
                                    var red = new ColorRibbon(ColorRibbon.Colors.Red);
                                    arrayOfTheElements.Add(red);
                                    TotalPrice += red.TotalPrice;
                                    break;
                                case 1:
                                    var yellow = new ColorRibbon(ColorRibbon.Colors.Yellow);
                                    arrayOfTheElements.Add(yellow);
                                    TotalPrice += yellow.TotalPrice;
                                    break;
                                case 2:
                                    var green = new ColorRibbon(ColorRibbon.Colors.Green);
                                    arrayOfTheElements.Add(green);
                                    TotalPrice += green.TotalPrice;
                                    break;
                            }
                            break;
                        case 1:
                            Console.WriteLine($"Pick the color of the package:\n0 - {Package.Colors.Red}\n1 - {Package.Colors.Yellow}\n2 - {Package.Colors.Blue}:");
                            if (!byte.TryParse(Console.ReadLine(), out choice))
                            {
                                throw new ArgumentException("Wrong value of choice");
                            }
                            switch (choice)
                            {
                                case 0:
                                    var red = new Package(Package.Colors.Red);
                                    arrayOfTheElements.Add(red);
                                    TotalPrice += red.TotalPrice;
                                    break;
                                case 1:
                                    var yellow = new Package(Package.Colors.Yellow);
                                    arrayOfTheElements.Add(yellow);
                                    TotalPrice += yellow.TotalPrice;
                                    break;
                                case 2:
                                    var blue = new Package(Package.Colors.Blue);
                                    arrayOfTheElements.Add(blue);
                                    TotalPrice += blue.TotalPrice;
                                    break;
                            }
                            break;
                    }
                }
            }

        }
        private void AddElementsToBouquet(int totalQuant, ref int quantityOfFlowers, List<Flower> arrayOfTheElements)
        {
            byte choice;
            for (int i = 0; i < quantityOfFlowers; i++)
            {
                Console.WriteLine("Pick the flower:\n0 - lily\n1 - chrisanthemum\n2 - rose:");
                if (!byte.TryParse(Console.ReadLine(), out choice))
                {
                    throw new ArgumentException("Wrong value of choice");
                }
                else
                {
                    switch (choice)
                    {
                        case 0:
                            var lily = new Lily();
                            arrayOfTheElements.Add(lily);
                            TotalPrice += lily.TotalPrice;
                            break;
                        case 1:
                            var chrysantemum = new Chrysanthemum();
                            arrayOfTheElements.Add(chrysantemum);
                            TotalPrice += chrysantemum.TotalPrice;
                            break;
                        case 2:
                            var rose = new Rose();
                            arrayOfTheElements.Add(rose);
                            TotalPrice += rose.TotalPrice;
                            break;
                        default:
                            throw new ArgumentException("Wrong number of choice");
                    }
                }
            }

        }
        public void MakeMarkup(double quantityOfPercents)
        {
            if (quantityOfPercents < 0)
            {
                throw new ArgumentException("Wronng percent of markup");
            }
            else
            {
                TotalPrice += TotalPrice * quantityOfPercents / 100;
            }
        }
        public void MakeDiscount(double quantityOfPercents)
        {
            if (quantityOfPercents < 0 || quantityOfPercents > 100)
            {
                throw new ArgumentException("Wronng percent of discount");
            }
            else
            {
                TotalPrice -= TotalPrice * quantityOfPercents / 100;
            }
        }
    }


}
