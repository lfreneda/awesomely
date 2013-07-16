awesomely
=========

"Awesomely" is personal library written in C#.  It's like the Batman's utility belt in C# !
You can think of it as bunch of helpers, functions, code to help us out in our daily development.

What's inside?
---------------------

### StringExtensions

FormatWith
```
"Hello your parameter is {0}".FormatWith("awesomely");
//Hello your parameter is awesomely
```
CreateEnumerable - enables you create an enumerable from a file on disk where each element is a line from file.
```
var lines = @"C:\temp\file.txt".CreateEnumerable();
```

AppendToFile - write/append current string to an file
```
"One more line".AppendToFile(@"C:\temp\file.txt");
```
Append - write/append current string to an file
```
@"C:\temp\file.txt".AppendLine("One more file");
```
### EnumerableExtensions

Each<T> - Alternative to foreach/for
```
items.Each(c => Console.WriteLine(c));
``` 

ToFile<T> - Create a file from an enumerable
```
items.ToFile(@"C:\temp\items.txt");
``` 



