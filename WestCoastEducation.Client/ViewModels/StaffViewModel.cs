using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastEducation.Core;
using WestCoastEducation.Core.Interfaces;
using WestCoastEducation.Core.Models.People.Staff;
using WestCoastEducation.Core.Services;

namespace WestCoastEducation.Client.ViewModels;

public partial class StaffViewModel : ViewModelBase
{
    private readonly School _school;
    [ObservableProperty] public partial ObservableCollection<PermanentStaff> PermanentStaff { get; set; }
    [ObservableProperty] public partial ObservableCollection<Teacher> Teachers { get; set; }
    
    

    public StaffViewModel(School school)
    {
        _school = school;
        
        Task.Run(LoadStaff).Wait();
    }

    public async Task LoadStaff()
    {
        try
        {
            Console.WriteLine("Loading Staff");
            var staff = await _school.GetAllStaff();
            PermanentStaff = new ObservableCollection<PermanentStaff>(staff.OfType<PermanentStaff>());
            Teachers = new ObservableCollection<Teacher>(staff.OfType<Teacher>());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
        }
    }
}