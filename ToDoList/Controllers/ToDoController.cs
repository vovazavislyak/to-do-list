using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IActionResult GetAllTask()
        {
            var items = _toDoRepository
                .GetAllTask(GetCurrentUserId())
                .Select(Mapper.Map);

            return View("ShowTasks", items);
        }

        public async Task<IActionResult> AddTask(ToDoItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            
            var item = Mapper.Map(viewModel, GetCurrentUserId());
            await _toDoRepository.AddTaskAsync(item);

            return RedirectToAction(nameof(GetAllTask));
        }

        public async Task<IActionResult> ChangeIsCompleted(int id, bool isCompleted)
        {
            await _toDoRepository.ChangeIsCompletedAsync(id, isCompleted);

            return RedirectToAction(nameof(GetAllTask));
        }

        public async Task<IActionResult> EditTask(ToDoItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            
            await _toDoRepository.EditTaskAsync(Mapper.Map(viewModel, GetCurrentUserId()));

            return RedirectToAction(nameof(GetAllTask));
        }

        public async Task<IActionResult> RemoveTask(int id)
        {
            await _toDoRepository.RemoveAsync(id);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult ResetDeadline(ToDoItemViewModel viewModel)
        {
            viewModel.Deadline = null;

            return RedirectToAction(nameof(EditTask), viewModel);
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.FindFirstValue(nameof(Models.User.Id)));
        }
    }
}