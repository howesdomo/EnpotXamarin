using System;
using CoreLocation;
using UIKit;
using Foundation;
using System.Linq;

namespace EnpotXamarin
{
    public partial class ViewController : UIViewController
    , CoreLocation.ICLLocationManagerDelegate // 定位
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


        private readonly CoreLocation.CLLocationManager locationManager = new CoreLocation.CLLocationManager();


        partial void btnLocationUpInside(UIButton sender)
        {
            // you can set the update threshold and accuracy if you want:
            //locationManager.DistanceFilter = 10d; // move ten meters before updating
            //locationManager.HeadingFilter = 3d; // move 3 degrees before updating

            // you can also set the desired accuracy:
            locationManager.DesiredAccuracy = 1000; // 1000 meters/1 kilometer
            // you can also use presets, which simply evalute to a double value:
            //locationManager.DesiredAccuracy = CLLocation.AccuracyNearestTenMeters;

            locationManager.Delegate = this;
            locationManager.RequestWhenInUseAuthorization();

            if (CoreLocation.CLLocationManager.LocationServicesEnabled)
            {
                locationManager.StartUpdatingLocation();
            }

            if (CoreLocation.CLLocationManager.HeadingAvailable)
            {
                locationManager.StartUpdatingHeading();
            }
        }

        partial void btnStopLocationUpInside(UIButton sender)
        {
            if (CoreLocation.CLLocationManager.LocationServicesEnabled)
            {
                locationManager.StopUpdatingLocation();
            }

            if (CoreLocation.CLLocationManager.HeadingAvailable)
            { 
                locationManager.StopUpdatingHeading();
            }
        }

        #region ICLLocationManagerDelegate

        [Export("locationManager:didUpdateHeading:")]
        public void UpdatedHeading(CLLocationManager manager, CLHeading newHeading)
        {
            //trueHeadingLabel.Text = $"{newHeading.TrueHeading}º";
            //magneticHeadingLabel.Text = $"{newHeading.MagneticHeading}º";
            lblHeading.Text = $"{newHeading.TrueHeading}º";
        }

        [Export("locationManager:didUpdateLocations:")]
        public void LocationsUpdated(CLLocationManager manager, CLLocation[] locations)
        {
            var location = locations.LastOrDefault();
            if (location != null)
            {
                // altitudeLabel.Text = $"{location.Altitude} meters";
                lblLongitude.Text = "Lng:{0}º".FormatWith(location.Coordinate.Longitude);
                lblLatitude.Text = "Lat:{0}º".FormatWith(location.Coordinate.Latitude);
                //courseLabel.Text = $"{location.Course}º";
                //speedLabel.Text = $"{location.Speed} meters/s";

                // get the distance from here to paris
                //distanceLabel.Text = $"{location.DistanceFrom(new CLLocation(48.857, 2.351)) / 1000} km";
            }
        }

        #endregion



    }
}
