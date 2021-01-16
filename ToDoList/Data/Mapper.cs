using ToDoList.ViewModels;

namespace ToDoList.Data
{
    public static class Mapper
    {
        public static ToDoItemViewModel Map(ToDoItem item)
        {
            return new ToDoItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Deadline = item.Deadline,
                IsCompleted = item.IsCompleted
            };
        }
        
        public static ToDoItem Map(ToDoItemViewModel viewModel, int userId)
        {
            return new ToDoItem
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Deadline = viewModel.Deadline,
                IsCompleted = viewModel.IsCompleted,
                UserId = userId
            };
        }
    }
}