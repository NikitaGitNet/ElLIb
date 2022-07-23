using ElLIb.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElLIb.Models.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;
        public CommentViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.Comment.GetComments()));
        }
    }
}
