using ClearMapperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClearMapperLibrary.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to learn about {nameof(ClearMapper)} library :)");

            // configure without injection (only for test,best practice is injection from IOC)
            //var mapper = new ClearMapper(option =>
            //{
            //    option.AddConfiguration<FirstClass, SecondClass>(i => new SecondClass()
            //    {
            //        SecondClassID = i.FistClassID,
            //        FullName = i.Title,
            //    });

            //    option.AddConfiguration<FirstClass, ThirdClass>(i => new ThirdClass()
            //    {
            //        ThirdClassID = i.FistClassID,
            //        Name = i.Title,
            //    });

            //    option.AddConfiguration<SecondClass, ThirdClass>(i => new ThirdClass()
            //    {
            //        ThirdClassID = i.SecondClassID,
            //        Name = i.FullName,
            //    });
            //});

            //load from profiles
            var mapper = new ClearMapper();




            var firstClass = new FirstClass() { FistClassID = 10 };
            List<FirstClass> listOfFistClass = new List<FirstClass>() { firstClass };

            //Map List To Another List
            var listOfSecondClass = mapper.Map<FirstClass, SecondClass>(listOfFistClass).ToList();

            //Map List To Another List
            var listOfThirdClass = mapper.Map<FirstClass, ThirdClass>(listOfFistClass).ToList();

            //Map single class to another single class
            var secondClass = mapper.Map<FirstClass, SecondClass>(firstClass);

            Console.ReadLine();

        }
    }
}

public class Profile1 : ClearMapperProfile
{
    public Profile1(ClearMapperOption option) : base(option)
    {

        option.AddConfiguration<FirstClass, ThirdClass>(i => new ThirdClass()
        {
            ThirdClassID = i.FistClassID,
            Name = i.Title,
        });


    }
}

public class Profile2 : ClearMapperProfile
{
    public Profile2(ClearMapperOption option) : base(option)
    {
        option.AddConfiguration<FirstClass, SecondClass>(i => new SecondClass()
        {
            SecondClassID = i.FistClassID,
            FullName = i.Title,
        });

    }
}

public class FirstClass
{
    public int FistClassID { get; set; }
    public string Title { get; set; }
}

public class SecondClass
{
    public int SecondClassID { get; set; }
    public string FullName { get; set; }
}

public class ThirdClass
{
    public int ThirdClassID { get; set; }
    public string Name { get; set; }
}