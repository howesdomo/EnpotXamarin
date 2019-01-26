// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace EnpotXamarin
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAlter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnStopLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnThrowExcpetion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnWeChat { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHeading { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLatitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLongitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMap { get; set; }

        [Action ("btnAlter_TouchUp:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnAlter_TouchUp (UIKit.UIButton sender);

        [Action ("btnAMap_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnAMap_UpInside (UIKit.UIButton sender);

        [Action ("btnLocationUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnLocationUpInside (UIKit.UIButton sender);

        [Action ("btnStopLocationUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnStopLocationUpInside (UIKit.UIButton sender);

        [Action ("BtnThrowExcpetion_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnThrowExcpetion_TouchUpInside (UIKit.UIButton sender);

        [Action ("btnWeChat_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnWeChat_UpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAlter != null) {
                btnAlter.Dispose ();
                btnAlter = null;
            }

            if (btnAMap != null) {
                btnAMap.Dispose ();
                btnAMap = null;
            }

            if (btnLocation != null) {
                btnLocation.Dispose ();
                btnLocation = null;
            }

            if (btnStopLocation != null) {
                btnStopLocation.Dispose ();
                btnStopLocation = null;
            }

            if (btnThrowExcpetion != null) {
                btnThrowExcpetion.Dispose ();
                btnThrowExcpetion = null;
            }

            if (btnWeChat != null) {
                btnWeChat.Dispose ();
                btnWeChat = null;
            }

            if (lblHeading != null) {
                lblHeading.Dispose ();
                lblHeading = null;
            }

            if (lblLatitude != null) {
                lblLatitude.Dispose ();
                lblLatitude = null;
            }

            if (lblLongitude != null) {
                lblLongitude.Dispose ();
                lblLongitude = null;
            }

            if (viewMap != null) {
                viewMap.Dispose ();
                viewMap = null;
            }
        }
    }
}