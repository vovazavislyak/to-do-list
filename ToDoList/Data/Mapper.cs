using ToDoList.Models;

namespace ToDoList.Data
{
    public static class Mapper
    {
        public static ToDoItemModel Map(ToDoItem item)
        {
            return new ToDoItemModel(item.Id, item.Name, item.Description, item.Deadline, item.IsCompleted);;
        }
        
        public static ToDoItem Map(ToDoItemModel item)
        {
            return new ToDoItem(item.Id, item.Name, item.Description, item.Deadline);
        }
    }
}