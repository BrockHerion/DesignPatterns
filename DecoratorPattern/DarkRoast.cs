namespace DecoratorPattern
{
    public class DarkRoast : Beverage
    {
        public override string Description => "Dark Roast";

        public override decimal Cost => 0.99m;
    }
}