using WestCoastEducation.Client.Enums;
using WestCoastEducation.Core.Interfaces;

namespace WestCoastEducation.Client.Messages;

public record EditObjectMessage(IStorageObject Obj);
public record NavigateMessage(PageViewsEnum Page);