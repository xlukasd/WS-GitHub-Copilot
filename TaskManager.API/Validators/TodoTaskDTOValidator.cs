using TaskManager.API.Contract;
using TaskManager.API.Exception;

namespace TaskManager.API.Validators
{
    internal class TodoTaskDTOValidator
    {
        public static void EnsureValid(TodoTaskDTO todoTaskDTO)
        {
            if (todoTaskDTO == null)
            {
                throw new TaskValidationException("Task cannot be null");
            }

            if (todoTaskDTO.DueDate < DateTime.Now)
            {
                throw new TaskValidationException("Due date cannot be in the past");
            }

            if (string.IsNullOrWhiteSpace(todoTaskDTO.Title))
            {
                throw new TaskValidationException("Title cannot be empty");
            }
        }
    }
}
