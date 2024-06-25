# ClearMapper :)
ClearMapper is a package for map in c#.
<br />
# features:

1. map from all of IEnumerable typr to another IEnumerable type with better performance and spped.
2. map from IQueryable type to another IQueryable type with out roudtrip for database.
3. map from any class to another class.
4. and ...

## how to use?

step 1:
create two classes with below names.
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
install 'ClearMapper' package from NUGET.

step 3:
create Profile class For configure of map for ClearMapper
```C#

public class Profile : ClearMapperProfile
{
    public Profile(ClearMapperOption option) : base(option)
    {
        option.AddConfiguration<FirstClass, SecondClass>(i =>
         new SecondClass()
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
var firstClass = new FirstClass()
{
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


## how to inject in program.cs:
install 'ClearMapper.DependencyInjection' from NUGET.
and write below code in program.cs
```c#

builder.Services.UseClearMapper()

```

and inject IClearMapper in your classes like this:
```C#

public class MyClass
{
    public MyClass(IClearMapper mapper)
    {

    }
}
```

dont forget to share ClearMapper with your friends.
thanks :)

