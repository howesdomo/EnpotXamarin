using System;

using UIKit;

namespace EnpotXamarin
{
    public partial class ViewController : UIViewController
    {
        WeChatAPI weChat { get; set; }


        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Title = "Hello Xamarin.iOS";
            weChat = new WeChatAPI();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void btnAlter_TouchUp(UIButton sender)
        {
            var alert = UIAlertController.Create("Alter", "Hello Xamarin.iOS", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            PresentViewController(viewControllerToPresent: alert, animated: false, completionHandler: null);
        }


        partial void BtnThrowExcpetion_TouchUpInside(UIButton sender)
        {
            var alert = UIAlertController.Create("Warning", "确认抛出异常？", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, action => { throw new Exception("Throw Exception By Howe"); }));
            alert.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, null));
            PresentViewController(viewControllerToPresent: alert, animated: false, completionHandler: null);
        }


        partial void btnWeChat_UpInside(UIButton sender)
        {
            try
            {
                weChat.SendText("Hello Xamarin@Wechat");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.GetFullInfo());
            }
        }

        partial void btnAMap_UpInside(UIButton sender)
        {
            BindingiOSLibrary.AMap.AMapServices.SharedServices.ApiKey = "9c8c5671ecd17ebb1e7d0f43ab06a495";
            BindingiOSLibrary.AMap.AMapServices.SharedServices.EnableHTTPS = true;
            MAMapKit.MAMapView map = new MAMapKit.MAMapView();
            map.Frame = this.View.Bounds;
            viewMap.AddSubview(map);
        }
    }
}
