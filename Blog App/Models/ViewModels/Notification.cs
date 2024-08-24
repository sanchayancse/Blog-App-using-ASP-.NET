using Blog_App.Enums;

namespace Blog_App.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }
        public NotifiationType Type { get; set; }
    }
}
