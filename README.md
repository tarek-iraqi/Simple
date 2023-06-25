# Simple Extensions
This library provides simple and very direct extensions on some basic types of C#, although it
is simple it covers some functionality we need it all the time in many places which sometimes
casue code duplication due to its simplicity.

My intension is to collect as much as I can of these simple functions and group them in 
single basic libray to help me and others in doing their tasks in an easy way.

This library is open source and covered with unit tests to ensure its stability and to be 
confident to use it in your projects.

In this first release I covered some functions on different C# types and alot is coming
soon as well.

## What covered now:
### String Extensions:
| Method | Description |
| -- | -- |
| IsEmpty() | Return `true` if the value is empty only otherwise return `false` |
| IsNull() | Return `true` if the value is null only otherwise return `false` |
| IsWhiteSpace() | Return `true` if the value is whitespace only otherwise return `false` |
| HasValue() | Return `true` if the string has any value, it is simply a wrapper around `IsNullOrWhiteSpace` without the headache of negation |
| RemoveSpecialCharacters() | Remove any special characters in the string |
| RemoveSpaces() | Remove any spaces in the string |
| RemoveSpecialCharactersAndSpaces() | Remove any special characters or spaces in the string |

### DateTime Extensions:
| Method | Description |
| -- | -- |
| ToUnixTimeStamp() | Convert any `DateTime` to unix timestamp |

### Long Extensions:
| Method | Description |
| -- | -- |
| FromUnixTimeStampToDateTime() | Convert unix timestamp to valid `DateTime` |

### Queryable Extensions:
| Method | Description |
| -- | -- |
| ToPaginatedListAsync\<T> | A very simple method for pagination, it is generic which can work on your main entity or projection type. It takes page number and page size and handle the pagination calculations and returns two objects, the first one is the `IEnumerable<T>` with the specified number of records and meta data object with pagination data |

### Enum Extensions:
| Method | Description |
| -- | -- |
| GetAttribute\<TAttribute> | Direct way to retrieve any attribute data associated with `enum` type whether it is built in attribute as `DescriptionAttribute` or any custom attribute |

You can refer to the unit tests in the repo to see some basic usage for each method.
