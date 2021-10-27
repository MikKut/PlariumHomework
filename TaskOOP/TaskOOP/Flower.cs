
﻿using System;
using System.ComponentModel;

namespace FlowerShop
{
    internal abstract class Flower : Plant, IHasPrice, IComparable
    {
        int _lengthOfStemInSm;
        double _basePrice, _additionalPricePerEachSm, _totalPrice;
        protected bool IsFresh { get; set; }
        readonly DateTime _periodOfLife;
        public new DateTime PeriodOfLife { get => _periodOfLife; }
        DateTime EndOfLife { get; set; }
        public int LengthOfStemInSm
        {
            get => _lengthOfStemInSm;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Wrong length of stem ({value}).");
                }
                _lengthOfStemInSm = value;
            }
        }
        public new DateTime TimeOfBeingCollected { get; private set; }
        public double TotalPrice
        {
            get => _totalPrice;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total price less than zero");
                }
                _totalPrice = value;
            }
        }
        public double AdditionalPrice //the longer the stem, the higer the price
        {
            get => _additionalPricePerEachSm;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Wrong additional price per each sm of stem ({value}).");
                }
                _additionalPricePerEachSm = value;
            }
        }
        public double BasePrice
        {
            get => _basePrice;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Wrong base price ({value}).");
                }
                _basePrice = value;
            }
        }
        public Flower(DateTime timeOfBeingCollected, int lengthOfStem, double basePrice, double additionalPricePerEachSmOfStem)
        {
            try
            {
                TimeOfBeingCollected = timeOfBeingCollected;
                LengthOfStemInSm = lengthOfStem;
                BasePrice = basePrice;
                AdditionalPrice = additionalPricePerEachSmOfStem;
                TotalPrice = BasePrice + AdditionalPrice * LengthOfStemInSm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", try again");
                FillFlowerInfo();
            }
            finally
            {
                DetermineWhetherItIsFresh();
            }
        }
        public Flower()
        {
            try
            {
                FillFlowerInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", try again");
                FillFlowerInfo();
            }
            finally
            {
                DetermineWhetherItIsFresh();
            }
        }
        public bool DetermineWhetherItIsFresh()
        {
            int yearSum = (PeriodOfLife.Year + TimeOfBeingCollected.Year), monthsSum = PeriodOfLife.Month + TimeOfBeingCollected.Month, daysSum = PeriodOfLife.Day + TimeOfBeingCollected.Day;
            if (daysSum > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            {
                daysSum -= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                monthsSum++;
            }
            if (monthsSum > 12)
            {
                monthsSum -= 12;
                yearSum++;
            }
            EndOfLife = new DateTime(yearSum, monthsSum, daysSum);
            if (EndOfLife >= DateTime.Now)
            {
                IsFresh = true;
                return true;
            }
            else
            {
                IsFresh = false;
                return false;
            }
        }
        private void FillFlowerInfo()
        {
            PrintEnterMessage("time of being collected");
            TimeOfBeingCollected = ConvertData<DateTime>(Console.ReadLine(), "time of being collected");
            PrintEnterMessage("length of the stem");
            LengthOfStemInSm = ConvertData<int>(Console.ReadLine(), "length of the stem");
            PrintEnterMessage("base price");
            BasePrice = ConvertData<double>(Console.ReadLine(), "base price");
            PrintEnterMessage("additional price per each sm");
            AdditionalPrice = ConvertData<double>(Console.ReadLine(), "additional price per each sm");
            TotalPrice = BasePrice + AdditionalPrice * LengthOfStemInSm;
        }

        private static void PrintEnterMessage(string nameOfTheData)
        {
            Console.WriteLine($"Enter {nameOfTheData} of the plant");
        }
        private static T ConvertData<T>(string input, string nameOfTheData)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(input);
                }
                else
                {
                    throw new ArgumentNullException($"Null reference at {nameOfTheData}");
                }
            }
            catch (NotSupportedException)
            {
                throw new ArgumentException($"Wrong type of {nameOfTheData}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public int CompareTo(object obj)
        {
            var flower = obj as Flower;
            if (flower != null)
            {
                return this.EndOfLife.CompareTo(flower.EndOfLife);
            }
            else
            {
                throw new InvalidCastException("Cannot cast the obj into flower");
            }
        }
    }
}