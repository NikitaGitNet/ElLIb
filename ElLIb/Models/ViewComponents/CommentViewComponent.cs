using ElLIb.Domain;
using ElLIb.Models.Comment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public Task<IViewComponentResult> InvokeAsync(ICollection<AddCommentModel> comments)
        {
            return Task.FromResult((IViewComponentResult)View("Default", comments));
        }
    }
}
