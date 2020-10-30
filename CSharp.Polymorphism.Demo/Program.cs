using System;

namespace CSharp.Polymorphism.Demo
{
    public static class Program
    {
        public static Double noneDiscountPrice;
        public static Double registeredDiscountPrice;
        public static Double valuedDiscountPrice;
        public static Double mostValuedDiscountPrice;
        public static Double newDiscountPrice;
        public static Double newRegisteredDiscountPrice;
        public static Double newValuedDiscountPrice;
        public static Double newMostValuedDiscountPrice;

        static void Main()
        {
            // Concrete discount calculator
            noneDiscountPrice = ConcreteDiscountedPrice.Calculate(12.95, 0);
            registeredDiscountPrice = ConcreteDiscountedPrice.Calculate(12.95, 1);
            valuedDiscountPrice = ConcreteDiscountedPrice.Calculate(12.95, 2);
            mostValuedDiscountPrice = ConcreteDiscountedPrice.Calculate(12.95, 3);

            Console.WriteLine("Concrete (old)" + noneDiscountPrice);
            Console.WriteLine("Concrete (old)" + registeredDiscountPrice);
            Console.WriteLine("Concrete (old)" + valuedDiscountPrice);
            Console.WriteLine("Concrete (old)" + mostValuedDiscountPrice);

            // Polymorphic discount calculator
            // TODO: Further improve with Factory Pattern
            // and Discount Manager class driven by either
            // account status or transaction incentive
            NoDiscountCalculator ndc = new NoDiscountCalculator();
            newDiscountPrice = ndc.Apply(12.95);

            RegisteredDiscountCalculator rdc = new RegisteredDiscountCalculator();
            newRegisteredDiscountPrice = rdc.Apply(12.95);

            ValuedDiscountCalculator vdc = new ValuedDiscountCalculator();
            newValuedDiscountPrice = vdc.Apply(12.95);

            MostValuedDiscountCalculator mdc = new MostValuedDiscountCalculator();
            newMostValuedDiscountPrice = mdc.Apply(12.95);

            Console.WriteLine("Polymorphic (new)" + newDiscountPrice);
            Console.WriteLine("Polymorphic (new)" + newRegisteredDiscountPrice);
            Console.WriteLine("Polymorphic (new)" + newValuedDiscountPrice);
            Console.WriteLine("Polymorphic (new)" + newMostValuedDiscountPrice);
        }
    }

    /// <summary>
    /// Represents the resulting discounted price consisting of full price times discount percentage.  
    /// </summary>
    /// <remarks>
    /// Concrete class with magic numbers and repeated formulae.
    /// </remarks>
    public static class ConcreteDiscountedPrice 
    { 
        public static double Calculate(double amount, int type)
        {
            double price;

            if (type == 1)
            {
                price = amount * (1 - .10);
            }
            else if (type == 2)
            {
                price = amount * (1 - .15);
            }
            else if (type == 3)
            {
                price = amount * (1 - .2);
            }
            else
            {
                price = amount;
            }

            return price;
        }
    }

    public static class Discount
    {
        public const double None = 0;
        public const double Registered = .1;
        public const double Valued = .15;
        public const double MostValued = .2;
    }

    public interface IDiscount
    {
        double Apply(double amount);
    }

    // No discount.  
    public class NoDiscountCalculator : IDiscount
    {
        public double price;

        public double Apply(double amount)
        {
            price = amount;
            return price;
        }
    }

    public class RegisteredDiscountCalculator : IDiscount
    {
        public double price;

        public double Apply(double amount)
        {
            double price = amount * (1 - Discount.Registered);
            return price;
        }
    }

    public class ValuedDiscountCalculator : IDiscount
    {
        public double price;

        public double Apply(double amount)
        {
            double price = amount * (1 - Discount.Valued);
            return price;
        }
    }

    public class MostValuedDiscountCalculator : IDiscount
    {
        public double price;

        public double Apply(double amount)
        {
            double price = amount * (1 - Discount.MostValued);
            return price;
        }
    }
}
