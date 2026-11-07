using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ToDoListController(MyPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.ToDoLists.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Status = false;
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult DeleteToDoList(int id)
        {
            var values = _context.ToDoLists.Find(id);
            _context.ToDoLists.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateToDoList(int id)
        {
            var values = _context.ToDoLists.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToDoListStatusToTrue(int id)
        {
            var values = _context.ToDoLists.Find(id);
            values.Status = true;
            _context.ToDoLists.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult ChangeToDoListStatusToFalse(int id)
        {
            var values = _context.ToDoLists.Find(id);
            values.Status = false;
            _context.ToDoLists.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
