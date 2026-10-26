using System;
using WestCoastEducation.Client.Enums;
using WestCoastEducation.Client.ViewModels;
using WestCoastEducation.Core;
using WestCoastEducation.Core.Services;


namespace WestCoastEducation.Client.Factories;

public class PageViewFactory(School school)
{
    
    public ViewModelBase LoadPageViewModel(PageViewsEnum page)
    {
        return page switch
        {
            PageViewsEnum.HOME => new HomeViewModel(school),
            PageViewsEnum.STAFF => new StaffViewModel(school), //TODO: Implementera Staff view model
            PageViewsEnum.STUDENTS => throw new NotImplementedException(), //TODO: Implementera Student view model
            PageViewsEnum.COURSES => throw new NotImplementedException(),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha"),
        };
    }
}