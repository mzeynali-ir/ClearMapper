# ClearMapper :)

## how to use?

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
install 'ClearMapper' from NUGET.

step 3:
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


step 4:
create insatance of CLearMapper of inject it from IOC.
and call Map for map my class to another class.
```C#
            
            var mapper = new ClearMapper();

            //define some objection for mapping process
            var firstClass = new FirstClass() {
                 FistClassID = 10
            };
            var listOfFistClass = new List<FirstClass>();
            listOfFistClass.Add(firstClass);

            //map list of FirstClass to list of SecondClass
            var listOfSecondClass = mapper.Map<FirstClass, SecondClass>(listOfFistClass);

            //map list of FirstClass to list of ThirdClass
            var listOfThirdClass = mapper.Map<FirstClass, ThirdClass>(listOfFistClass);

            //Map single of FirstClass to another single of SecondClass
            var secondClass = mapper.Map<FirstClass, SecondClass>(firstClass);

```

step 5:
SMILE :)

bye

how to inject in program.cs:
install 'ClearMapper.DependencyInjection' from NUGET.
and write below code in program.cs
```c#

builder.Services.UseClearMapper()

```

