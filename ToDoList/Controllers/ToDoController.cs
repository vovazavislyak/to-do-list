using System.Linq;
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
            var currentUserId = AccountController.CurrentUserId;
            
            var items = _toDoRepository
                .GetAllTask(currentUserId)
                .Select(Mapper.Map);

            return View("ShowTasks", items);
        }

        public async Task<IActionResult> AddTask(ToDoItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            
            var currentUserId = AccountController.CurrentUserId;
            var item = Mapper.Map(viewModel, currentUserId);
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
            
            var currentUserId = AccountController.CurrentUserId;
            await _toDoRepository.EditTaskAsync(Mapper.Map(viewModel, currentUserId));

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
    }
}