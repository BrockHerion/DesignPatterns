namespace DecoratorPattern
{
    public class Espresso : Beverage
    {
        public override string Description => "Espresso";
        
        public override decimal Cost => 1.99m;
    }
}