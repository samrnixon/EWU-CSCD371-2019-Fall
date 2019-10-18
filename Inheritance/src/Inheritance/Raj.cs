using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenAreAround { get; set; }
        public string Speak() => "Hello I am Raj";
        public string Mumble() => "*mumbles";
    }
}
