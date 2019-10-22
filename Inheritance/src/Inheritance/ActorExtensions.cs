using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor) =>
            actor switch
            {
                Sheldon sheldon => sheldon.Speak(),
                Penny penny => penny.Speak(),
                Raj raj => (raj.WomenAreAround ? raj.Mumble() : raj.Speak())
            };
    }
}
