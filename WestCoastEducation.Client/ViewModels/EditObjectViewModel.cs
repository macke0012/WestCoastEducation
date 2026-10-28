using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WestCoastEducation.Client.Enums;
using WestCoastEducation.Client.Messages;
using WestCoastEducation.Core;
using WestCoastEducation.Core.Models;
using WestCoastEducation.Core.Models.Course;
using WestCoastEducation.Core.Models.People;
using WestCoastEducation.Core.Models.People.Staff;

namespace WestCoastEducation.Client.ViewModels;

public partial class EditObjectViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<EditableField> Fields { get; set; }
    private readonly object _obj;
    private readonly School _school;
    public EditObjectViewModel(object obj, School school)
    {
        _school = school;
        _obj = obj;
        Console.WriteLine("EditObjectViewModel:");
        PageTitle = _obj.GetType().GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? obj.GetType().Name;
        LoadData();
    }
    
    void LoadData()
    {
        List<EditableField> fields = new();
        var allprops = _obj.GetType().GetProperties();
        var props = _obj.GetType().GetProperties()
            .Where(p => p is { CanWrite: true} && EditableType(p))
            .Where(p => p.GetCustomAttribute<EditableAttribute>()?.AllowEdit != false)
            .ToList();
        
        
        foreach (var prop in props)
        {
            if (prop.PropertyType == typeof(Adress))
            {
                var adressprops = prop.PropertyType.GetProperties().ToList();

                foreach (var adressprop in adressprops)
                {
                    fields.Add(new EditableField
                    {
                        Property = adressprop,
                        Label = adressprop.GetCustomAttribute<DisplayAttribute>()?.Name ?? adressprop.Name,
                        Value = adressprop.GetValue(_obj)?.ToString() ?? string.Empty,
                        Type = adressprop.PropertyType,
                        PropertyName = prop.Name
                        
                    });
                }
                continue;
            }
            
            fields.Add(new EditableField
            {
                Property = prop,
                Label = prop.GetCustomAttribute<DisplayAttribute>()?.Name ?? prop.Name,
                Value = prop.GetValue(_obj)?.ToString() ?? string.Empty,
                Type = prop.PropertyType,
                PropertyName = prop.Name
                
            });


        }

        
        Fields = new(fields);
        OnPropertyChanged(nameof(Fields));
    }

    private static bool EditableType(PropertyInfo prop)
    {
        return prop.PropertyType == typeof(string) || prop.PropertyType == typeof(int) ||
               prop.PropertyType == typeof(double) || prop.PropertyType == typeof(DateTime) ||
               prop.PropertyType == typeof(Adress) || /*prop.PropertyType == typeof(List<BaseCourse>) ||*/
               prop.PropertyType == typeof(Teacher);
    }
    
    
    
    [RelayCommand]
    public async void Save()
    {
        ProcessFieldValue();

        PageViewsEnum page = _obj switch //Kollar vilken sida vi ska tillbaka till
        {
            BaseStaff  => PageViewsEnum.STAFF,
            Student    => PageViewsEnum.STUDENT,
            BaseCourse => PageViewsEnum.COURSES,
            _ => throw new InvalidOperationException("Det finns ingen sida att navigera till")
        };
        switch (_obj)
        {
            case Person person:
                Console.WriteLine("Updating person");
                await _school.UpdatePerson(person);
                break;
            case BaseCourse course:
                Console.WriteLine("Updating course");
                await _school.UpdateCourse(course);
                break;
            default:
                throw new InvalidCastException("Detta objektet går inte att uppdatera");
        }
        WeakReferenceMessenger.Default.Send(new NavigateMessage(page));
        
    }

    private void ProcessFieldValue()
    {
        foreach (var prop in Fields)
        {
            if (prop.Type == typeof(DateTime))
            {
                DateTime.TryParse(prop.Value, out DateTime date);
                prop.Property.SetValue(_obj, date);
                continue;
            }
            if (prop.Type == typeof(Adress))
            {
                string[] adress = prop.Value?.Split("\n") ?? [];
                var newadress = new Adress
                {
                    Street = adress[0],
                    ZipCode = adress[1],
                    Town = adress[2],
                    Country = adress[3]
                };
                prop.Property.SetValue(_obj, newadress);
                continue;
            }

            
            prop.Property.SetValue(_obj, prop.Value);
        }
    }
}