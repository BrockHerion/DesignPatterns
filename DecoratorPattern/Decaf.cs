namespace DecoratorPattern
{
    public class Decaf : Beverage
    {
        public override string Description => "Decaf";

        public override decimal Cost => 1.05m;
    }
}