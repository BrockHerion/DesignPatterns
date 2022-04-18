namespace DecoratorPattern
{
    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => $"{_beverage.Description}, Mocha";

        public override decimal Cost => _beverage.Cost + 0.2m;
    }
}