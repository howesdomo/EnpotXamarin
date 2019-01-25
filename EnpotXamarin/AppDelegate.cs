using System;
using Foundation;
using UIKit;

namespace EnpotXamarin
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Start 注册全局异常捕获事件
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            // End

            if(wechat == null) { wechat = new WeChatAPI(); }
            wechat.Log("wxd66c092941a6aabf");


            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            // Code to start the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        #region iOS 全局异常捕获

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string msg = "{0}".FormatWith(e.ExceptionObject.ToString());
            System.Diagnostics.Debug.WriteLine(msg);
            // DisplayCrashReport();
            HandleException(new Exception(msg));
        }

        private void TaskScheduler_UnobservedTaskException(object sender, System.Threading.Tasks.UnobservedTaskExceptionEventArgs e)
        {
            string msg = "{0}".FormatWith(e.Exception.GetFullInfo());
            System.Diagnostics.Debug.WriteLine(msg);
            // DisplayCrashReport();
            HandleException(e.Exception);
        }

        /// <summary>
        /// 遍历文件夹，获取该文件结构
        /// </summary>
        /// <param name="dirPath">Dir path.</param>
        /// <param name="level">Level.</param>
        private void getDir(string dirPath, int level)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(dirPath);
                string[] directories = System.IO.Directory.GetDirectories(dirPath);

                foreach (var item in directories)
                {
                    string msg = "|{0}{1}".FormatWith("".PadLeft(level, '_'), item);
                    System.Diagnostics.Debug.WriteLine(msg);
                    getDir(item, level + 1);
                }

                foreach (var item in files)
                {
                    string msg = "|{0}{1}".FormatWith("".PadLeft(level, '_'), item);
                    System.Diagnostics.Debug.WriteLine(msg);
                }
            }
            catch(Exception ex)
            {
                string msg = ex.GetFullInfo();
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        private void HandleException(Exception ex)
        {
#if DEBUG
            System.Diagnostics.Debugger.Break();
#endif

            try
            {
                const string errorFilename = "Fatal.log";
                var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
                var errorFilePath = System.IO.Path.Combine(libraryPath, errorFilename);

                string[] directories = System.IO.Directory.GetDirectories(libraryPath);

                //if (System.IO.Directory.Exists(libraryPath) == true)
                //{
                //    getDir(libraryPath, 1);
                //}

                if (System.IO.File.Exists(errorFilePath) == true)
                {
                    var errorText = System.IO.File.ReadAllText(errorFilePath);
                    System.Diagnostics.Debug.WriteLine(errorText);
                }




                //var alert = UIAlertController.Create("捕获全局异常", ex.GetFullInfo(), UIAlertControllerStyle.Alert);
                //alert.AddAction(UIAlertAction.Create("Yes",
                //    UIAlertActionStyle.Default,
                //    null
                //    // TODO 将错误信息发送到服务器
                //    //action => 
                //    //{
                //    //    // throw new Exception("Throw Exception By Howe"); 
                //    //}
                // ));
                //Window.RootViewController.PresentViewController(viewControllerToPresent: alert, animated: false, completionHandler: null);


                var alertView = new UIAlertView
                (
                    title: "Crash Report",
                    message: ex.GetFullInfo(),
                    del: null,
                    cancelButtonTitle: "关闭",
                    otherButtons: "Clear"
                );

                alertView.UserInteractionEnabled = true;

                alertView.Clicked += (sender, args) =>
                {
                    System.Diagnostics.Debug.WriteLine("Click alterView");
                };

                alertView.Show();
            }
            catch (Exception ex2)
            {
                System.Diagnostics.Debug.WriteLine(ex2.GetFullInfo());
            }
        }


        #endregion

        WeChatAPI wechat { get; set; }

        public override bool HandleOpenURL(UIApplication application, NSUrl url)
        {
            var result = wechat.Open(url);
            return result;
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            var result = wechat.Open(url);
            return result;
        }

    }
}

