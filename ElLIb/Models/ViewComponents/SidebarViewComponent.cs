using ElLIb.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElLIb.Models.ViewCompanents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;
        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.Books.GetBooks()));
        }
    }
}
