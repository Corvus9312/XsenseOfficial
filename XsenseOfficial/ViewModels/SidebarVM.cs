using XsenseOfficial.Models;

namespace XsenseOfficial.ViewModels;

public class SidebarVM : SidebarModel
{
    public List<SidebarModel>? SubSidebars { get; set; }
}
