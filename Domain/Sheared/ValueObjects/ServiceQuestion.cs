

namespace Domain.Sheared.ValueObjects
{
    public class ServiceQuestion
    {
        public List<string> Question {  get; private set; } = new List<string>();

        public ServiceQuestion() { }

        public ServiceQuestion( List<string> question)
        {
            Question = question;
        }   
    }
}
