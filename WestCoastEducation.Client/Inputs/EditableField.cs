using System;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class EditableField : ObservableObject
{
    public required PropertyInfo Property { get; init; }
    public required string Label { get; init; }
    public required Type Type { get; init; }
    public required object Target { get; init; } //Detta är för adressen så att jag kan mappa rätt prop till rätt input
    [ObservableProperty] public partial object? Value { get; set; }

    public override string ToString()
    {
        return $"{Label}: {Value}";
    }
}

