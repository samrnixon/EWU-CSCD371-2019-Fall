using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor)
        {
            switch(actor)
            {
                case Sheldon sheldon:
                    return sheldon.Speak();
                case Penny penny:
                    return penny.Speak();
                case Raj raj:
                    if(raj.WomenAreAround is true)
                    {
                        return raj.Mumble();
                    }
                    else
                    {
                        return raj.Speak();
                    }
                default:
                    throw new ArgumentNullException("No correct actor");
            }
        }
    }
}
