using System;

namespace DecoratorPattern
{
    public enum Size
    {
        TALL,
        GRANDE,
        VENTI
    }
    
    public abstract class Beverage
    {
        public virtual string Description { get; protected init;  } = "Unknown Beverage";
        public virtual Size Size { get; set; }

        public abstract decimal Cost { get; }

        public override string ToString()
        {
            return $"{Description} ${Cost}";
        }
    }
}
