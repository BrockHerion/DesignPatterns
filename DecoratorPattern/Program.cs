using System;
using DecoratorPattern;

// Single Espresso
Beverage beverage = new Espresso();
Console.WriteLine(beverage.ToString());

// Dark roast w/ double mocha and whip
Beverage beverage2 = new DarkRoast();
beverage2 = new Mocha(beverage2);
beverage2 = new Mocha(beverage2);
beverage2 = new Whip(beverage2);
Console.WriteLine(beverage2.ToString());

// House Blend w/ soy, mocha, and whip
Beverage beverage3 = new HouseBlend();
beverage3 = new Soy(beverage3);
beverage3 = new Mocha(beverage3);
beverage3 = new Whip(beverage3);
Console.WriteLine(beverage3.ToString());