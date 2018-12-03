
using System;

[AttributeUsage(AttributeTargets.Field)]
public class ItemDataAttribute : Attribute
{
    public Type item { get; set; }
}