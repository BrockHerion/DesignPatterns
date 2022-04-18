namespace DecoratorPattern
{
    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => $"{_beverage.Description}, Whip";
        
        public override decimal Cost => _beverage.Size switch
        {
            Size.TALL => _beverage.Cost + 0.05m,
            Size.GRANDE => _beverage.Cost + 0.1m,
            Size.VENTI => _beverage.Cost + 0.15m,
            _ => _beverage.Cost + 0.1m
        };
    }
}