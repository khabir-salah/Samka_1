

namespace Domain.Aggregates.ServiceAggregate.Entities
{
    public class ServiceQuestionResponse
    {
        public Guid ServiceCategoryId { get; private set; }
        public Dictionary<string, string> Answers { get; private set; }


        public ServiceQuestionResponse() { }
        public ServiceQuestionResponse(Guid serviceCategoryId, Dictionary<string, string> answers)
        {
            ServiceCategoryId = serviceCategoryId;
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
        }
    }
}
