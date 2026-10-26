using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Client.Enums;
using WestCoastEducation.Client.Factories;
using WestCoastEducation.Core;


namespace WestCoastEducation.Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory _pageViewFactory;
    private readonly School _school;
    
    

    [ObservableProperty] public partial ViewModelBase CurrentPage { get; set; } = new();

    public MainWindowViewModel(PageViewFactory pageViewFactory, School school)
    {
        _pageViewFactory = pageViewFactory;
        CurrentPage = _pageViewFactory.LoadPageViewModel(PageViewsEnum.HOME);
        _school = school;
        
        
        
    }
    
    [RelayCommand]
    private void NavigateToStaffPage() => CurrentPage = _pageViewFactory.LoadPageViewModel(PageViewsEnum.STAFF);
    [RelayCommand]
    private void NavigateToStudentsPage() => CurrentPage = _pageViewFactory.LoadPageViewModel(PageViewsEnum.STUDENTS);
    [RelayCommand]
    private void NavigateToCoursesPage() => CurrentPage = _pageViewFactory.LoadPageViewModel(PageViewsEnum.COURSES);
}