using ClearMapperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asdfasdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var mapper = new ClearMapperLibrary.ClearMapper(option =>
            {
                option.AddConfiguration<FirstClass, SeccondClass>(i => new SeccondClass() { Id = i.Id });

                option.AddConfiguration<FirstClass, SeccondClass>(i => new SeccondClass() { Id = i.Id });

                option.AddConfiguration<SeccondClass, ThirdClass>(i => new ThirdClass() { Id = i.Id });

                option.AddConfiguration<FirstClass, ThirdClass>(i => new ThirdClass() { Id = i.Id });
            });



            // mapper.HealthCheck();

            var fc = new FirstClass() { Id = 10 };
            List<FirstClass> source = new List<FirstClass>() { fc };

            var r = mapper.Map<FirstClass, SeccondClass>(source).ToList();

            var rd = mapper.Map<FirstClass, ThirdClass>(source).ToList();

            var rr = mapper.Map<FirstClass, SeccondClass>(fc);

            Console.ReadLine();

        }
    }
}




public class FirstClass
{
    public int Id { get; set; }
}

public class SeccondClass
{
    public int Id { get; set; }
}

public class ThirdClass
{
    public int Id { get; set; }
}