// See https://aka.ms/new-console-template for more information

using System.Runtime.Intrinsics.X86;
using System;

var list = new List<int> { -5, -2, 0, 4, 6, 9 };

Predicate<int> wherePositivePredicate = x => x > 0;
var positiveList = list.Where(x => wherePositivePredicate(x)).ToList();
Console.WriteLine(string.Join(", ", positiveList.ToArray()));

Func<int, bool> whereNegativeFunc = x => x < 0;
var negativeList = list.Where(whereNegativeFunc).ToList();
Console.WriteLine(string.Join(", ", negativeList.ToArray()));

//The difference between Func and Action is simply whether you want the delegate to return a value (use Func) or not (use Action).

//Func is probably most commonly used in LINQ - for example in projections:

// list.Select(x => x.SomeProperty)
//or filtering:

// list.Where(x => x.SomeValue == someOtherValue)
//or key selection:

// list.Join(otherList, x => x.FirstKey, y => y.SecondKey, ...)
//Action is more commonly used for things like List<T>.ForEach: execute the given action for each item in the list. I use this less often than Func, although I do sometimes use the parameterless version for things like Control.BeginInvoke and Dispatcher.BeginInvoke.

//Predicate is just a special cased Func<T, bool> really, introduced before all of the Func and most of the Action delegates came along. I suspect that if we'd already had Func and Action in their various guises, Predicate wouldn't have been introduced... although it does impart a certain meaning to the use of the delegate, whereas Func and Action are used for widely disparate purposes.

//Predicate is mostly used in List<T> for methods like FindAll and RemoveAll.
