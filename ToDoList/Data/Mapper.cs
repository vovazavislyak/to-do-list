using ToDoList.ViewModels;

namespace ToDoList.Data
{
    public static class Mapper
    {
        public static ToDoItemViewModel Map(ToDoItem item)
        {
            return new ToDoItemViewModel(item.Id, item.Name, item.Description, item.Deadline, item.IsCompleted);
        }
        
        public static ToDoItem Map(ToDoItemViewModel viewModel)
        {
            return new ToDoItem(viewModel.Id, viewModel.Name, viewModel.Description, viewModel.Deadline, viewModel.IsCompleted);
        }
    }
}