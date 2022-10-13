namespace ToDos
{
    public enum Priority
    {
        LOW, MEDIUM, HIGH
    }
    public enum Status
    {
        OPEN, FINISHED
    }

    public class ToDo{
        public ToDo(){}
        public ToDo(int id, string description, Priority priority, Status status)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
            this.Status = status;
        }
        public int Id {get;set;}
        public string? Description {get;set;}
        public Status? Status  {get;set;}
        public Priority? Priority  {get;set;}
    }

    public class ToDosManagement
    {
        private static int counter = 0;
        private Dictionary<int, ToDo> todos = new Dictionary<int, ToDo>();
        public ToDo Create(string description)
        {
            var newToDo = new ToDo(++counter, description, Priority.MEDIUM, Status.OPEN);
            todos.Add(newToDo.Id, newToDo);
            return newToDo;
        }
        public void UpdateStatus(int id, Status status)
        {
            todos[id].Status = status;
        }
        public void UpdatePriority(int id, Priority priority)
        {
            todos[id].Priority = priority;
        }
        public List<ToDo> OpenToDos()
        {
            return this.todos.Where(p => p.Value.Status == Status.OPEN).Select(p => p.Value).ToList();
        }
        public List<ToDo> FinishedToDos()
        {
            return this.todos.Where(p => p.Value.Status == Status.FINISHED).Select(p => p.Value).ToList();
        }

    }
}