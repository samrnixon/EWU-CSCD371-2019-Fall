using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Sizes Size { get; }
        public (int, int) Location { get; set; }
        public Person Owner { get; }

        public Mailbox(Person owner, (int, int) loc, Sizes size)
        {
            Owner = owner;
            Location = loc;
            Size = size;
        }

        public override string? ToString()
        {
            string defaultPrint = $"{Owner.ToString()} {Location.Item1},{Location.Item2}";
            string sizeValuePrint = $"{Owner.ToString()} {Location.Item1},{Location.Item2} {Size.ToString()}";

            if(Size > Sizes.None && Size < Sizes.Premium) return sizeValuePrint;
            if(Size == Sizes.PremiumSmall) return (defaultPrint + $" {Sizes.Small}" + " Premium");
            if(Size == Sizes.PremiumMedium) return (defaultPrint + $" {Sizes.Medium}" + " Premium");
            if(Size == Sizes.PremiumLarge) return (defaultPrint + $" {Sizes.Large}" + " Premium");

            return defaultPrint;
        }
    }
}
