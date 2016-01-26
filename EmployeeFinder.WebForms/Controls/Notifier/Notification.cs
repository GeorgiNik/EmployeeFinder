namespace EmployeeFinder.WebForms.Controls.Notifier
{
    using EmployeeFinder.WebForms.Controls.Notifier.Enums;

    public class Notification
    {
        public string Text { get; set; }

        public NotificationType Type { get; set; }

        public bool AutoHide { get; set; }
    }
}