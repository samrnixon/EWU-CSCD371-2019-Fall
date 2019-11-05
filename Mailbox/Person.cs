using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }
        
        public bool Equals(Person other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person?);
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }

        public override string? ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public static bool operator ==(Person a, Person b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Person a, Person b) => !(a == b);

    }


}