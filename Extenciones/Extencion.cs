using Radzen;

namespace PF2022_03_BlazorApp.Extenciones{
    public static class Extencion{
          public static void ShowNotification(this NotificationService notifier, string mensaje, NotificationSeverity severity = NotificationSeverity.Success)
        {
            var message = new NotificationMessage
            {
                Severity = severity,
                Summary = mensaje
            };

            notifier.Notify(message);
        }
    }
}