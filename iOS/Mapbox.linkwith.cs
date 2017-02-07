using ObjCRuntime;
[assembly: LinkWith ("Mapbox.framework", 
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
