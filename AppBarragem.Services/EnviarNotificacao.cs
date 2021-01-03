using Jarvis.PushNotifications.OneSignal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBarragem.Services
{
    public static class EnviarNotificacao
    {
        private static readonly NotificationBody notification;

        static EnviarNotificacao()
        {
            PushNotification.REST_API_KEY = "OGVlZmM0N2UtMWQzMC00ZmFkLWI2NzktOWQwMjY1MDJkMWQ1";

            notification = new NotificationBody()
            {
                AppId = "b00d5a16-6c5d-4a2d-b9d0-43c37518565e"
            };
        }

        public static async Task<NotificationResponse> ParaTodos(string titulo, string texto)
        {
            notification.IncludePlayerIds.Clear();
            notification.IncludedSegments.Clear();

            notification.Headings.Text = titulo;
            notification.Contents.Text = texto;
            notification.IncludedSegments.Add(Segments.All);

            return await PushNotification.Push(notification);
        }

        public static async Task<NotificationResponse> ParaUm(string titulo, string texto, string id)
        {
            notification.IncludePlayerIds.Clear();
            notification.IncludedSegments.Clear();

            notification.Headings.Text = titulo;
            notification.Contents.Text = texto;
            notification.IncludePlayerIds.Add(id);

            return await PushNotification.Push(notification);
        }
    }
}