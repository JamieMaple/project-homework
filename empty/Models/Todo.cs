namespace empty.Models
{
    public class Todo {
        static int idGen = 0;
        public int id { get; }
        public string content { get; set; }
        public bool isFinished { get; set; }

        public Todo(string content)
        {
            id = idGen++;
            this.content = content;
        }
    }
}
