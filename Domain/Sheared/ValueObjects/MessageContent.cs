

using static System.Net.Mime.MediaTypeNames;

namespace Domain.Sheared.ValueObjects
{
    public class MessageContent
    {
        public string? Text { get; set; }
        public string? ImageUrl { get; set; }
        public string? VoiceNoteUrl { get; set; }
    }
}
