
// Test code - records
var personR1 = new RecordsDemo.Person("John", "Smith");
var personR2 = new RecordsDemo.Person("Jane", "Smith");
var personR3 = new RecordsDemo.Person("John", "Smith");
Console.WriteLine(personR1);                        // records toString() implemenation is auto generated
Console.WriteLine(personR2);
Console.WriteLine(personR3);
Console.WriteLine(personR1 == personR2);
Console.WriteLine(personR1 == personR3);            // value based equality - so true because attribute values are same

//personR1.FirstName = "Jack";                      // records properties are by-default init only, so cannot reassign

Console.WriteLine(personR1.Equals(personR2));
Console.WriteLine(personR1.Equals(personR3));
Console.WriteLine(personR1.GetHashCode());                        
Console.WriteLine(personR2.GetHashCode());
Console.WriteLine(personR3.GetHashCode());

Console.WriteLine(personR1.GetHashCode() == personR3.GetHashCode());            // same hash code 2 record instances with same property values



//// Test code - classes
//var personC1 = new ClassDemo.Person { FirstName = "John", LastName = "Smith" };
//var personC2 = new ClassDemo.Person { FirstName = "Jane", LastName = "Smith" };
//var personC3 = new ClassDemo.Person { FirstName = "John", LastName = "Smith" };
//Console.WriteLine(personC1);                        // classes toString() implemenation is Not auto generated
//Console.WriteLine(personC2);
//Console.WriteLine(personC3);

//Console.WriteLine(personC1 == personC2);
//Console.WriteLine(personC1 == personC3);            // reference based equality - so false even though the attribute values are same

//personC1.FirstName = "Test";                        // classes attributes can be reassigned

namespace RecordsDemo 
{
    //public record Person(string FirstName, string LastName);

    // above is short hand notation for
    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}


namespace ClassDemo
{
    public class Person
    { 
        public required string FirstName { get; set; } 
        public required string LastName { get; set; }
    }
}
