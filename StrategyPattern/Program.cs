using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();

            var model = new ModelDuck();
            model.PerformFly();
            model.FlyBehavior = new FlyPoweredRocket();
            model.PerformFly();
        }
    }
}