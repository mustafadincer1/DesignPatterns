internal class Program
{
    private static void Main(string[] args)
    {
        Person person1 = new Person();
        person1.age = 21;
        person1.birthday = Convert.ToDateTime("16.11.2002");
        person1.Name = "Mustafa";
        person1.idInfo = new IdInfo(600);
        DisplayValues(person1 );
        Person person2 = person1.ShallowCopy();
        Person person3 = person1.DeepCopy();

        DisplayValues(person2 );
        DisplayValues(person3);

        person1.age = 30;
        person1.idInfo.IdNumber = 1;
        DisplayValues(person1);
        DisplayValues(person2);
        DisplayValues(person3);



    }
    public static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
            p.Name, p.age, p.birthday);
        Console.WriteLine("      ID#: {0:d}", p.idInfo.IdNumber);
    }
}


public class Person
{

    

    public int age { get; set; }
    public string Name { get; set; }
    public DateTime birthday { get; set; }
    public IdInfo  idInfo { get; set; }

    public Person ShallowCopy() { 
        return (Person) this.MemberwiseClone();
        
    }

    public Person DeepCopy() {
        Person clone = (Person) this.MemberwiseClone();
        clone.idInfo =  new IdInfo(idInfo.IdNumber);
        clone.Name = String.Copy(Name);
        return clone;
    }
}

public class IdInfo { 

    public int IdNumber { get; set; }

    public IdInfo(int ıdNumber)
    {
        IdNumber = ıdNumber;
    }

    
}