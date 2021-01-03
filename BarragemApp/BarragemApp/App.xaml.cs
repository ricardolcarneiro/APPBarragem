using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BarragemApp.Services;
using BarragemApp.Views;
using Jarvis.Connections.Http;
using Com.OneSignal;
using System.Collections.Generic;
using Com.OneSignal.Abstractions;
using Jarvis.Utils;
using AppBarragem.Utils;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.LatestVersion;

namespace BarragemApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //HttpAdapter.Token = Token.API;
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            OneSignal.Current.StartInit("b00d5a16-6c5d-4a2d-b9d0-43c37518565e").
               Settings(new Dictionary<string, bool>()
               {
                    { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                    { IOSSettings.kOSSettingsKeyInAppLaunchURL, false }
               }).
               InFocusDisplaying(OSInFocusDisplayOption.Notification).
               UnsubscribeWhenNotificationsAreDisabled(true).
               HandleNotificationOpened((result) =>
               {
                   JarvisLog.Info($"OneSignal Notification Opened => Body: {result.notification.payload.body}");
               }).
               HandleNotificationReceived((notification) =>
               {
                   JarvisLog.Info($"OneSignal Notification Received => Body: {notification.payload.body}");
               }).
               EndInit();

            OneSignal.Current.IdsAvailable((playerID, pushToken) =>
            {
                JarvisLog.Info($"OneSignal => playerID: {playerID} | pushToken: {pushToken}");
            });

            OneSignal.Current.RegisterForPushNotifications();
        }

        protected override async void OnStart()
        {
            try
            {
                var location = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

                if (location != PermissionStatus.Granted)
                {
                    await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                }

                var storage = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

                if (storage != PermissionStatus.Granted)
                {
                    await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
                }
            }
            catch (Exception e)
            {
                JarvisLog.Error($"Exception: {e.Message}");
            }

            try
            {
                if (!await CrossLatestVersion.Current.IsUsingLatestVersion())
                {
                    if (await MainPage.DisplayAlert(null, "Há uma nova versão disponível. Deseja fazer o download agora?", "Sim", "Não"))
                    {
                        await CrossLatestVersion.Current.OpenAppInStore();
                    }
                }
            }
            catch (Exception e)
            {
                JarvisLog.Error($"Exception: {e.Message}");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
