using System.Threading.Tasks;
using Cnblogs.Fluss.Web.Features;
using Cnblogs.Fluss.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cnblogs.Fluss.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        public async Task<IActionResult> Home()
        {
            var blog = await _mediator.Send(new GetBlogSite(1));
            var posts = await _mediator.Send(new GetBlogHomePosts(1, 15, 1));
            var page = new HomeBlogPage(1, posts, blog) {PageTitle = blog.Title, PageFooter = blog.FooterText};
            return View(page);
        }

        [Route("p/{postId}.html")]
        public async Task<IActionResult> PostDetail(int postId)
        {
            var postDetailModel = await _mediator.Send(new GetBlogPostDetail(1, postId));
            var page = new PostDetailBlogPage(postDetailModel) {PageTitle = postDetailModel.Title};
            return View(page);
        }
    }
}