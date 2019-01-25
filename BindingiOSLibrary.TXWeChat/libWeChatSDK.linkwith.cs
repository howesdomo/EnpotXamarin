// WARNING: This feature is deprecated. Use the "Native References" folder instead.
// Right-click on the "Native References" folder, select "Add Native Reference",
// and then select the static library or framework that you'd like to bind.
//
// Once you've added your static library or framework, right-click the library or
// framework and select "Properties" to change the LinkWith values.

using ObjCRuntime;

//[assembly: LinkWith ("libWeChatSDK.a", SmartLink = true, ForceLoad = true)]
[assembly: LinkWith(
    "libWeChatSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator
    , SmartLink = true
    , ForceLoad = true
// Frameworks = "SystemConfiguration.framework, libz.dylib, libsqlite3.0.dylib, libc++.dylib, Security.framework, CoreTelephony.framework, CFNetwork.framework",
// , LinkerFlags = "-l\"libz\" -Objc -all_load"
    , LinkerFlags = "-l'sqlite3' -l'z' -l'c++' -framework 'SystemConfiguration' -framework 'Security' -framework 'CoreTelephony' -framework 'CFNetwork' -Objc -all_load"
)]
