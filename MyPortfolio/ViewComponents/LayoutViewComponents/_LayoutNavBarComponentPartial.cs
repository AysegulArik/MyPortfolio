using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavBarComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _LayoutNavBarComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.toDoListCount = _context.ToDoLists.Where(x => x.Status == false).Count();
            var value=_context.ToDoLists.Where(x => x.Status == false).ToList();
            return View(value);
        }
    }
}
