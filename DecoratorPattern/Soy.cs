namespace DecoratorPattern
{
    public class Soy : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => $"{_beverage.Description}, Soy";

        public override decimal Cost => _beverage.Size switch
        {
            Size.TALL => _beverage.Cost + 0.10m,
            Size.GRANDE => _beverage.Cost + 0.15m,
            Size.VENTI => _beverage.Cost + 0.2m,
            _ => _beverage.Cost + 0.15m
        };
    }
}