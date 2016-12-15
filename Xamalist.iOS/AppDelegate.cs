using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.MobileServices;
using Prism;
using Prism.Unity;
using UIKit;
using Xamalist.Services;
using Xamalist.iOS.Services;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Xamalist.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Azure Mobile Service の初期化
            CurrentPlatform.Init();

            // Mobile Center 用
            MobileCenter.Start(appSecret: Consts.MobileCenterAppSecretIos,
                               services: new Type[] { typeof(Analytics), typeof(Crashes) });

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFileUploadService, FileUploadService>(new ContainerControlledLifetimeManager() /* これでシングルトンにする */);
        }
    }
}
