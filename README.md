ClearMapper :)

how to use?

step 1:
crete two classes with blow names.
FirstClass
SecondClass
```C#
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
```

step 2:
create Profile class For configure of map for ClearMapper
```C#

public class Profile : ClearMapperProfile
{
    public Profile1(ClearMapperOption option) : base(option)
    {

        option.AddConfiguration<FirstClass, ThirdClass>(i => new ThirdClass()
        {
            ThirdClassID = i.FistClassID,
            Name = i.Title,
        });

        option.AddConfiguration<FirstClass, SecondClass>(i => new SecondClass()
        {
            SecondClassID = i.FistClassID,
            FullName = i.Title,
        });
    }
}

```


step 2:
create insatance of CLearMapper of inject it from IOC.
and call Map for map my class to another class.
```C#

            var mapper = new ClearMapper();

            //define some objection for mapping process
            var firstClass = new FirstClass() { FistClassID = 10 };
            List<FirstClass> listOfFistClass = new List<FirstClass>() { firstClass };

            //Map List To Another List
            var listOfSecondClass = mapper.Map<FirstClass, SecondClass>(listOfFistClass);

            //Map List To Another List
            var listOfThirdClass = mapper.Map<FirstClass, ThirdClass>(listOfFistClass);

            //Map single class to another single class
            var secondClass = mapper.Map<FirstClass, SecondClass>(firstClass);

```

step 4:
SMILE :)

bye
