using System;
using CoreAnimation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Mapbox
{
	[Static]
	partial interface Constants
	{
		// extern double MapboxVersionNumber;
		[Field("MapboxVersionNumber", "__Internal")]
		double MapboxVersionNumber { get; }

		// extern const unsigned char [] MapboxVersionString;
		[Field("MapboxVersionString", "__Internal")]
		IntPtr MapboxVersionString { get; }

		// extern const NSErrorDomain _Nonnull MGLErrorDomain;
		[Field("MGLErrorDomain", "__Internal")]
		NSString MGLErrorDomain { get; }
	}

	// @interface MGLAnnotationView : UIView <NSSecureCoding>
	[BaseType(typeof(UIView), Name = "MGLAnnotationView")]
	interface AnnotationView : INSSecureCoding
	{
		// -(instancetype _Nonnull)initWithReuseIdentifier:(NSString * _Nullable)reuseIdentifier;
		[Export("initWithReuseIdentifier:")]
		IntPtr Constructor([NullAllowed] string reuseIdentifier);

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (readonly, nonatomic) id<MGLAnnotation> _Nullable annotation;
		[NullAllowed, Export("annotation")]
		IAnnotation Annotation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable reuseIdentifier;
		[NullAllowed, Export("reuseIdentifier")]
		string ReuseIdentifier { get; }

		// @property (nonatomic) CGVector centerOffset;
		[Export("centerOffset", ArgumentSemantic.Assign)]
		CGVector CenterOffset { get; set; }

		// @property (assign, nonatomic) BOOL scalesWithViewingDistance;
		[Export("scalesWithViewingDistance")]
		bool ScalesWithViewingDistance { get; set; }

		// @property (getter = isSelected, assign, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// -(void)setSelected:(BOOL)selected animated:(BOOL)animated;
		[Export("setSelected:animated:")]
		void SetSelected(bool selected, bool animated);

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }

		// @property (getter = isDraggable, assign, nonatomic) BOOL draggable;
		[Export("draggable")]
		bool Draggable { [Bind("isDraggable")] get; set; }

		// @property (readonly, nonatomic) MGLAnnotationViewDragState dragState;
		[Export("dragState")]
		AnnotationViewDragState DragState { get; }

		// -(void)setDragState:(MGLAnnotationViewDragState)dragState animated:(BOOL)animated __attribute__((objc_requires_super));
		[Export("setDragState:animated:")]
		//[RequiresSuper]
		void SetDragState(AnnotationViewDragState dragState, bool animated);
	}

	// @interface MGLAccountManager : NSObject
	[BaseType(typeof(NSObject), Name = "MGLAccountManager")]
	interface AccountManager
	{
		[Static]
		[NullAllowed, Export("accessToken")]
		string AccessToken { [NullAllowed, Export("accessToken")]get; [NullAllowed, Export("setAccessToken:")]set; }

		// +(BOOL)mapboxMetricsEnabledSettingShownInApp __attribute__((deprecated("Telemetry settings are now always shown in the ℹ️ menu.")));
		[Static]
		[Export("mapboxMetricsEnabledSettingShownInApp")]
		bool MetricsEnabledSettingShownInApp { get; }
	}

	interface IAnnotation { }

	// @protocol MGLAnnotation <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface Annotation
	{
		// @required @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Abstract]
		[Export("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		// @optional @property (readonly, copy, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export("title")]
		string Title { get; }

		// @optional @property (readonly, copy, nonatomic) NSString * _Nullable subtitle;
		[NullAllowed, Export("subtitle")]
		string Subtitle { get; }
	}

	// @interface MGLAnnotationImage : NSObject
	[BaseType(typeof(NSObject), Name = "MGLAnnotationImage")]
	interface AnnotationImage : INSSecureCoding
	{
		// +(instancetype _Nonnull)annotationImageWithImage:(UIImage * _Nonnull)image reuseIdentifier:(NSString * _Nonnull)reuseIdentifier;
		[Static]
		[Export("annotationImageWithImage:reuseIdentifier:")]
		AnnotationImage Create(UIImage image, string reuseIdentifier);

		// @property (readonly, nonatomic) UIImage * _Nonnull image;
		[Export("image")]
		UIImage Image { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull reuseIdentifier;
		[Export("reuseIdentifier")]
		string ReuseIdentifier { get; }

		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }
	}

	interface ICalloutView { }

	// @protocol MGLCalloutView <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface CalloutView
	{
		// @required @property (nonatomic, strong) id<MGLAnnotation> _Nonnull representedObject;
		[Abstract]
		[Export("representedObject", ArgumentSemantic.Strong)]
		IAnnotation RepresentedObject { get; set; }

		// @required @property (nonatomic, strong) UIView * _Nonnull leftAccessoryView;
		[Abstract]
		[Export("leftAccessoryView", ArgumentSemantic.Strong)]
		UIView LeftAccessoryView { get; set; }

		// @required @property (nonatomic, strong) UIView * _Nonnull rightAccessoryView;
		[Abstract]
		[Export("rightAccessoryView", ArgumentSemantic.Strong)]
		UIView RightAccessoryView { get; set; }

		// @property (nonatomic, weak) id<MGLCalloutViewDelegate> delegate;
		[Abstract]
		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Weak)]
		ICalloutViewDelegate Delegate { get; set; }

		//[Wrap("WeakDelegate"), Abstract]
		//[NullAllowed]
		//ICalloutViewDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<MGLCalloutViewDelegate> _Nullable delegate;
		//[Abstract]
		//[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		//NSObject WeakDelegate { get; set; }

		// @required -(void)presentCalloutFromRect:(CGRect)rect inView:(UIView * _Nonnull)view constrainedToView:(UIView * _Nonnull)constrainedView animated:(BOOL)animated;
		[Abstract]
		[Export("presentCalloutFromRect:inView:constrainedToView:animated:")]
		void PresentCalloutFromRect(CGRect rect, UIView view, UIView constrainedView, bool animated);

		// @required -(void)dismissCalloutAnimated:(BOOL)animated;
		[Abstract]
		[Export("dismissCalloutAnimated:")]
		void DismissCalloutAnimated(bool animated);

		// @optional @property (readonly, getter = isAnchoredToAnnotation, assign, nonatomic) BOOL anchoredToAnnotation;
		[Export("anchoredToAnnotation")]
		bool AnchoredToAnnotation { [Bind("isAnchoredToAnnotation")] get; }

		// @optional @property (readonly, assign, nonatomic) BOOL dismissesAutomatically;
		[Export("dismissesAutomatically")]
		bool DismissesAutomatically { get; }
	}

	interface ICalloutViewDelegate { }

	// @protocol MGLCalloutViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "MGLCalloutViewDelegate")]
	interface CalloutViewDelegate
	{
		// @optional -(BOOL)calloutViewShouldHighlight:(UIView<MGLCalloutView> * _Nonnull)calloutView;
		[Export("calloutViewShouldHighlight:")]
		bool ShouldHighlight(ICalloutView calloutView);

		// @optional -(void)calloutViewTapped:(UIView<MGLCalloutView> * _Nonnull)calloutView;
		[Export("calloutViewTapped:")]
		void Tapped(ICalloutView calloutView);

		// @optional -(void)calloutViewWillAppear:(UIView<MGLCalloutView> * _Nonnull)calloutView;
		[Export("calloutViewWillAppear:")]
		void WillAppear(ICalloutView calloutView);

		// @optional -(void)calloutViewDidAppear:(UIView<MGLCalloutView> * _Nonnull)calloutView;
		[Export("calloutViewDidAppear:")]
		void DidAppear(ICalloutView calloutView);
	}

	// @interface MGLClockDirectionFormatter : NSFormatter
	[BaseType(typeof(NSFormatter), Name = "MGLClockDirectionFormatter")]
	interface ClockDirectionFormatter
	{
		// @property (nonatomic) NSFormattingUnitStyle unitStyle;
		[Export("unitStyle", ArgumentSemantic.Assign)]
		NSFormattingUnitStyle UnitStyle { get; set; }

		// -(NSString * _Nonnull)stringFromDirection:(CLLocationDirection)direction;
		[Export("stringFromDirection:")]
		string StringFromDirection(double direction);

		// TODO:
		// - (BOOL)getObjectValue:(out id __nullable * __nullable)obj forString:(NSString*)string errorDescription:(out NSString* __nullable * __nullable)error;
		[Export("getObjectValue:forString:errorDescription:")]
		bool GetObjectValue(out NSObject obj, string str, out NSString error);
	}

	// @interface MGLCompassDirectionFormatter : NSFormatter
	[BaseType(typeof(NSFormatter))]
	interface CompassDirectionFormatter
	{
		// @property (nonatomic) NSFormattingUnitStyle unitStyle;
		[Export("unitStyle", ArgumentSemantic.Assign)]
		NSFormattingUnitStyle UnitStyle { get; set; }

		// -(NSString * _Nonnull)stringFromDirection:(CLLocationDirection)direction;
		[Export("stringFromDirection:")]
		string StringFromDirection(double direction);

		// - (BOOL)getObjectValue:(out id __nullable * __nullable)obj forString:(NSString*)string errorDescription:(out NSString* __nullable * __nullable)error;
		[Export("getObjectValue:forString:errorDescription:")]
		bool GetObjectValue(out NSObject obj, string str, out NSString error);
	}

	// @interface MGLCoordinateFormatter : NSFormatter
	[BaseType(typeof(NSFormatter), Name = "MGLCoordinateFormatter")]
	interface CoordinateFormatter
	{
		// @property (nonatomic) BOOL allowsMinutes;
		[Export("allowsMinutes")]
		bool AllowsMinutes { get; set; }

		// @property (nonatomic) BOOL allowsSeconds;
		[Export("allowsSeconds")]
		bool AllowsSeconds { get; set; }

		// @property (nonatomic) NSFormattingUnitStyle unitStyle;
		[Export("unitStyle", ArgumentSemantic.Assign)]
		NSFormattingUnitStyle UnitStyle { get; set; }

		// -(NSString * _Nonnull)stringFromCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export("stringFromCoordinate:")]
		string StringFromCoordinate(CLLocationCoordinate2D coordinate);

		// - (BOOL)getObjectValue:(out id __nullable * __nullable)obj forString:(NSString*)string errorDescription:(out NSString* __nullable * __nullable)error;
		[Export("getObjectValue:forString:errorDescription:")]
		bool GetObjectValue(out NSObject obj, string str, out NSString error);
	}

	// @interface MGLShape : NSObject <MGLAnnotation, NSSecureCoding>
	[BaseType(typeof(NSObject), Name = "MGLShape")]
	interface Shape : Annotation, INSSecureCoding
	{
		// +(MGLShape * _Nullable)shapeWithData:(NSData * _Nonnull)data encoding:(NSStringEncoding)encoding error:(NSError * _Nullable * _Nullable)outError;
		[Static]
		[Export("shapeWithData:encoding:error:")]
		[return: NullAllowed]
		Shape ShapeWithData(NSData data, nuint encoding, [NullAllowed] out NSError outError);

		// @property (copy, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable subtitle;
		[NullAllowed, Export("subtitle")]
		string Subtitle { get; set; }

		// -(NSData * _Nonnull)geoJSONDataUsingEncoding:(NSStringEncoding)encoding;
		[Export("geoJSONDataUsingEncoding:")]
		NSData GeoJSONDataUsingEncoding(nuint encoding);
	}

	// @interface MGLMultiPoint : MGLShape
	[BaseType(typeof(Shape), Name = "MGLMultiPoint")]
	interface MultiPoint
	{
		// @property (readonly, nonatomic) CLLocationCoordinate2D * _Nonnull coordinates __attribute__((objc_returns_inner_pointer));
		[Export("coordinates")]
		CLLocationCoordinate2D Coordinates { get; }

		// @property (readonly, nonatomic) NSUInteger pointCount;
		[Export("pointCount")]
		nuint PointCount { get; }

		// -(void)getCoordinates:(CLLocationCoordinate2D * _Nonnull)coords range:(NSRange)range;
		[Export("getCoordinates:range:")]
		void GetCoordinates(CLLocationCoordinate2D coords, NSRange range);

		// -(void)setCoordinates:(CLLocationCoordinate2D * _Nonnull)coords count:(NSUInteger)count;
		[Export("setCoordinates:count:")]
		void SetCoordinates(CLLocationCoordinate2D coords, nuint count);

		// -(void)insertCoordinates:(const CLLocationCoordinate2D * _Nonnull)coords count:(NSUInteger)count atIndex:(NSUInteger)index;
		[Export("insertCoordinates:count:atIndex:")]
		void InsertCoordinates(CLLocationCoordinate2D coords, nuint count, nuint index);

		// -(void)appendCoordinates:(const CLLocationCoordinate2D * _Nonnull)coords count:(NSUInteger)count;
		[Export("appendCoordinates:count:")]
		void AppendCoordinates(CLLocationCoordinate2D coords, nuint count);

		// -(void)replaceCoordinatesInRange:(NSRange)range withCoordinates:(const CLLocationCoordinate2D * _Nonnull)coords;
		[Export("replaceCoordinatesInRange:withCoordinates:")]
		void ReplaceCoordinatesInRange(NSRange range, CLLocationCoordinate2D coords);

		// -(void)replaceCoordinatesInRange:(NSRange)range withCoordinates:(const CLLocationCoordinate2D * _Nonnull)coords count:(NSUInteger)count;
		[Export("replaceCoordinatesInRange:withCoordinates:count:")]
		void ReplaceCoordinatesInRange(NSRange range, CLLocationCoordinate2D coords, nuint count);

		// -(void)removeCoordinatesInRange:(NSRange)range;
		[Export("removeCoordinatesInRange:")]
		void RemoveCoordinatesInRange(NSRange range);
	}

	//TODO
	/*[Static]
	partial interface CoordinateSpanConstants
	{
		// extern const MGLCoordinateSpan MGLCoordinateSpanZero;
		[Field("MGLCoordinateSpanZero", "__Internal")]
		CoordinateSpan CoordinateSpanZero { get; }
	}*/

	interface IOverlay { }

	// @protocol MGLOverlay <MGLAnnotation>
	[Protocol, Model]
	[BaseType(typeof(Annotation), Name = "MGLOverlay")]
	interface Overlay
	{
		// @required @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		//[Abstract]
		//[Export("coordinate")]
		//CLLocationCoordinate2D Coordinate { get; }

		// @required @property (readonly, nonatomic) MGLCoordinateBounds overlayBounds;
		[Abstract]
		[Export("overlayBounds")]
		CoordinateBounds OverlayBounds { get; }

		// @required -(BOOL)intersectsOverlayBounds:(MGLCoordinateBounds)overlayBounds;
		[Abstract]
		[Export("intersectsOverlayBounds:")]
		bool IntersectsOverlayBounds(CoordinateBounds overlayBounds);
	}

	// @interface MGLPolyline : MGLMultiPoint <MGLOverlay>
	[BaseType(typeof(MultiPoint), Name = "MGLPolyline")]
	interface Polyline : Overlay
	{
		// +(instancetype _Nonnull)polylineWithCoordinates:(CLLocationCoordinate2D * _Nonnull)coords count:(NSUInteger)count;
		[Static]
		[Export("polylineWithCoordinates:count:")]
		Polyline WithCoordinates(IntPtr coords, nuint count);
	}

	// @interface MGLMultiPolyline : MGLShape <MGLOverlay>
	[BaseType(typeof(Shape))]
	interface MultiPolyline : Overlay
	{
		// @property (readonly, copy, nonatomic) NSArray<MGLPolyline *> * _Nonnull polylines;
		[Export("polylines", ArgumentSemantic.Copy)]
		Polyline[] Polylines { get; }

		// +(instancetype _Nonnull)multiPolylineWithPolylines:(NSArray<MGLPolyline *> * _Nonnull)polylines;
		[Static]
		[Export("multiPolylineWithPolylines:")]
		MultiPolyline MultiPolylineWithPolylines(Polyline[] polylines);
	}

	// @interface MGLPolygon : MGLMultiPoint <MGLOverlay>
	[BaseType(typeof(MultiPoint), Name = "MGLPolygon")]
	interface Polygon : Overlay
	{
		// @property (nonatomic, nullable, readonly) NS_ARRAY_OF (MGLPolygon*) *interiorPolygons;
		[Export("interiorPolygons")]
		Polygon[] InteriorPolygons { get; }

		// Need to manually do this since it's an array of coordinates which are a value type
		// and cannot be converted to NSArray, see Additions.cs
		// +(instancetype _Nonnull)polygonWithCoordinates:(CLLocationCoordinate2D * _Nonnull)coords count:(NSUInteger)count;
		[Static]
		[Export("polygonWithCoordinates:count:")]
		Polygon WithCoordinates(IntPtr coords, nuint count);

		// Need to manually do this since it's an array of coordinates which are a value type
		// and cannot be converted to NSArray, see Additions.cs
		// + (instancetype)polygonWithCoordinates:(CLLocationCoordinate2D*)coords count:(NSUInteger)count interiorPolygons:(nullable NS_ARRAY_OF (MGLPolygon*) *)interiorPolygons;
		[Static]
		[Export("polygonWithCoordinates:count:interiorPolygons:")]
		Polygon WithCoordinates(IntPtr coords, nuint count, [NullAllowed]Polygon[] interiorPolygons);
	}

	// @interface MGLMultiPolygon : MGLShape <MGLOverlay>
	[BaseType(typeof(Shape), Name = "MGLMultiPolygon")]
	interface MultiPolygon : Overlay
	{
		// @property (readonly, copy, nonatomic) NSArray<MGLPolygon *> * _Nonnull polygons;
		[Export("polygons", ArgumentSemantic.Copy)]
		Polygon[] Polygons { get; }

		// +(instancetype _Nonnull)multiPolygonWithPolygons:(NSArray<MGLPolygon *> * _Nonnull)polygons;
		[Static]
		[Export("multiPolygonWithPolygons:")]
		MultiPolygon MultiPolygonWithPolygons(Polygon[] polygons);
	}

	// @interface MGLPointAnnotation : MGLShape
	[BaseType(typeof(Shape), Name = "MGLPointAnnotation")]
	interface PointAnnotation
	{
		// @property (assign, nonatomic) CLLocationCoordinate2D coordinate;
		[Export("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; set; }
	}

	// @interface MGLPointCollection : MGLShape <MGLOverlay>
	[BaseType(typeof(Shape))]
	interface PointCollection : Overlay
	{
		// +(instancetype)pointCollectionWithCoordinates:(const CLLocationCoordinate2D *)coords count:(NSUInteger)count;
		[Static]
		[Export("pointCollectionWithCoordinates:count:")]
		PointCollection PointCollectionWithCoordinates(CLLocationCoordinate2D coords, nuint count);

		// @property (readonly, nonatomic) CLLocationCoordinate2D * coordinates __attribute__((objc_returns_inner_pointer));
		[Export("coordinates")]
		CLLocationCoordinate2D Coordinates { get; }

		// @property (readonly, nonatomic) NSUInteger pointCount;
		[Export("pointCount")]
		nuint PointCount { get; }

		// -(void)getCoordinates:(CLLocationCoordinate2D *)coords range:(NSRange)range;
		[Export("getCoordinates:range:")]
		void GetCoordinates(CLLocationCoordinate2D coords, NSRange range);
	}

	// @interface MGLShapeCollection : MGLShape
	[BaseType(typeof(Shape), Name = "MGLShapeCollection")]
	interface ShapeCollection
	{
		// @property (readonly, copy, nonatomic) NSArray<MGLShape *> * _Nonnull shapes;
		[Export("shapes", ArgumentSemantic.Copy)]
		Shape[] Shapes { get; }

		// +(instancetype _Nonnull)shapeCollectionWithShapes:(NSArray<MGLShape *> * _Nonnull)shapes;
		[Static]
		[Export("shapeCollectionWithShapes:")]
		ShapeCollection WithShapes(Shape[] shapes);
	}

	interface IFeature { }

	// @protocol MGLFeature<MGLAnnotation>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "MGLFeature")]
	interface Feature : Annotation
	{
		// @required @property (copy, nonatomic) id _Nullable identifier;
		[Abstract]
		[NullAllowed, Export("identifier", ArgumentSemantic.Copy)]
		NSObject Identifier { get; set; }

		// @required @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
		[Abstract]
		[Export("attributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Attributes { get; set; }

		// @required -(id _Nullable)attributeForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export("attributeForKey:")]
		[return: NullAllowed]
		NSObject AttributeForKey(string key);

		// @required -(NSDictionary<NSString *,id> * _Nonnull)geoJSONDictionary;
		[Abstract]
		[Export("geoJSONDictionary")]
		NSDictionary<NSString, NSObject> GeoJSONDictionary { get; }
	}

	// @interface MGLPointFeature : MGLPointAnnotation <MGLFeature>
	[BaseType(typeof(PointAnnotation), Name = "MGLPointFeature")]
	interface PointFeature : Feature
	{
	}

	// @interface MGLPolylineFeature : MGLPolyline <MGLFeature>
	[BaseType(typeof(Polyline), Name = "MGLPolylineFeature")]
	interface PolylineFeature : Feature
	{
	}

	// @interface MGLPolygonFeature : MGLPolygon <MGLFeature>
	[BaseType(typeof(Polygon), Name = "MGLPolygonFeature")]
	interface PolygonFeature : Feature
	{
	}

	// @interface MGLPointCollectionFeature : MGLPointCollection <MGLFeature>
	[BaseType(typeof(PointCollection))]
	interface PointCollectionFeature : Feature
	{
	}

	// @interface MGLMultiPolylineFeature : MGLMultiPolyline <MGLFeature>
	[BaseType(typeof(MultiPolyline), Name = "MGLMultiPolylineFeature")]
	interface MultiPolylineFeature : Feature
	{
	}

	// @interface MGLMultiPolygonFeature : MGLMultiPolygon <MGLFeature>
	[BaseType(typeof(MultiPolygon), Name = "MGLMultiPolygonFeature")]
	interface MultiPolygonFeature : Feature
	{
	}

	// @interface MGLShapeCollectionFeature : MGLShapeCollection <MGLFeature>
	[BaseType(typeof(ShapeCollection), Name = "MGLShapeCollectionFeature")]
	interface ShapeCollectionFeature : Feature
	{
		// @property (readonly, copy, nonatomic) NSArray<MGLShape<MGLFeature> *> * _Nonnull shapes;
		[Export("shapes", ArgumentSemantic.Copy)]
		Feature[] Shapes { get; }

		// +(instancetype _Nonnull)shapeCollectionWithShapes:(NSArray<MGLShape<MGLFeature> *> * _Nonnull)shapes;
		[Static]
		[Export("shapeCollectionWithShapes:")]
		ShapeCollectionFeature ShapeCollectionWithShapes(Feature[] shapes);
	}

	// @interface MGLMapCamera : NSObject <NSSecureCoding, NSCopying>
	[BaseType(typeof(NSObject), Name = "MGLMapCamera")]
	interface MapCamera : INSSecureCoding, INSCopying
	{
		// @property (nonatomic) CLLocationCoordinate2D centerCoordinate;
		[Export("centerCoordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D CenterCoordinate { get; set; }

		// @property (nonatomic) CLLocationDirection heading;
		[Export("heading")]
		double Heading { get; set; }

		// @property (nonatomic) CGFloat pitch;
		[Export("pitch")]
		nfloat Pitch { get; set; }

		// @property (nonatomic) CLLocationDistance altitude;
		[Export("altitude")]
		double Altitude { get; set; }

		// +(instancetype _Nonnull)camera;
		[Static]
		[Export("camera")]
		MapCamera Camera();

		// +(instancetype _Nonnull)cameraLookingAtCenterCoordinate:(CLLocationCoordinate2D)centerCoordinate fromEyeCoordinate:(CLLocationCoordinate2D)eyeCoordinate eyeAltitude:(CLLocationDistance)eyeAltitude;
		[Static]
		[Export("cameraLookingAtCenterCoordinate:fromEyeCoordinate:eyeAltitude:")]
		MapCamera CameraLookingAtCenterCoordinate(CLLocationCoordinate2D centerCoordinate, CLLocationCoordinate2D eyeCoordinate, double eyeAltitude);

		// +(instancetype _Nonnull)cameraLookingAtCenterCoordinate:(CLLocationCoordinate2D)centerCoordinate fromDistance:(CLLocationDistance)distance pitch:(CGFloat)pitch heading:(CLLocationDirection)heading;
		[Static]
		[Export("cameraLookingAtCenterCoordinate:fromDistance:pitch:heading:")]
		MapCamera CameraLookingAtCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double distance, nfloat pitch, double heading);
	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface MapViewDecelerationRateConstants
	{
		// extern const CGFloat MGLMapViewDecelerationRateNormal;
		[Field("MGLMapViewDecelerationRateNormal", "__Internal")]
		nfloat Normal { get; }

		// extern const CGFloat MGLMapViewDecelerationRateFast;
		[Field("MGLMapViewDecelerationRateFast", "__Internal")]
		nfloat Fast { get; }

		// extern const CGFloat MGLMapViewDecelerationRateImmediate;
		[Field("MGLMapViewDecelerationRateImmediate", "__Internal")]
		nfloat Immediate { get; }
	}

	// @interface MGLMapView : UIView
	[BaseType(typeof(UIView), Name = "MGLMapView")]
	interface MapView
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
		[Export("initWithFrame:")]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame styleURL:(NSURL * _Nullable)styleURL;
		[Export("initWithFrame:styleURL:")]
		IntPtr Constructor(CGRect frame, [NullAllowed] NSUrl styleURL);

		// @property (nonatomic, weak) id<MGLMapViewDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		IMapViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MGLMapViewDelegate> _Nullable delegate __attribute__((iboutlet));
		//[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		//NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) MGLStyle * _Nullable style;
		[NullAllowed, Export("style")]
		Style Style { get; }

		// @property (readonly, nonatomic) NSArray<NSURL *> * _Nonnull bundledStyleURLs __attribute__((deprecated("Call the relevant class method of MGLStyle for the URL of a particular default style.")));
		[Export("bundledStyleURLs")]
		NSUrl[] BundledStyleURLs { get; }

		// @property (nonatomic) NSURL * _Null_unspecified styleURL;
		[Export("styleURL", ArgumentSemantic.Assign)]
		NSUrl StyleURL { get; set; }

		// -(void)reloadStyle:(id _Nonnull)sender __attribute__((ibaction));
		[Export("reloadStyle:")]
		void ReloadStyle(NSObject sender);

		// @property (readonly, nonatomic) UIImageView * _Nonnull compassView;
		[Export("compassView")]
		UIImageView CompassView { get; }

		// @property (readonly, nonatomic) UIImageView * _Nonnull logoView;
		[Export("logoView")]
		UIImageView LogoView { get; }

		// @property (readonly, nonatomic) UIButton * _Nonnull attributionButton;
		[Export("attributionButton")]
		UIButton AttributionButton { get; }

		// @property (nonatomic) NSArray<NSString *> * _Nonnull styleClasses __attribute__((deprecated("Use style.styleClasses.")));
		[Export("styleClasses", ArgumentSemantic.Assign)]
		string[] StyleClasses { get; set; }

		// -(BOOL)hasStyleClass:(NSString * _Nonnull)styleClass __attribute__((deprecated("Use style.hasStyleClass:.")));
		[Export("hasStyleClass:")]
		bool HasStyleClass(string styleClass);

		// -(void)addStyleClass:(NSString * _Nonnull)styleClass __attribute__((deprecated("Use style.addStyleClass:.")));
		[Export("addStyleClass:")]
		void AddStyleClass(string styleClass);

		// -(void)removeStyleClass:(NSString * _Nonnull)styleClass __attribute__((deprecated("Use style.removeStyleClass:.")));
		[Export("removeStyleClass:")]
		void RemoveStyleClass(string styleClass);

		// @property (assign, nonatomic) BOOL showsUserLocation;
		[Export("showsUserLocation")]
		bool ShowsUserLocation { get; set; }

		// @property (readonly, getter = isUserLocationVisible, assign, nonatomic) BOOL userLocationVisible;
		[Export("userLocationVisible")]
		bool UserLocationVisible { [Bind("isUserLocationVisible")] get; }

		// @property (readonly, nonatomic) MGLUserLocation * _Nullable userLocation;
		[NullAllowed, Export("userLocation")]
		UserLocation UserLocation { get; }

		// @property (assign, nonatomic) MGLUserTrackingMode userTrackingMode;
		[Export("userTrackingMode", ArgumentSemantic.Assign)]
		UserTrackingMode UserTrackingMode { get; set; }

		// -(void)setUserTrackingMode:(MGLUserTrackingMode)mode animated:(BOOL)animated;
		[Export("setUserTrackingMode:animated:")]
		void SetUserTrackingMode(UserTrackingMode mode, bool animated);

		// @property (assign, nonatomic) MGLAnnotationVerticalAlignment userLocationVerticalAlignment;
		[Export("userLocationVerticalAlignment", ArgumentSemantic.Assign)]
		AnnotationVerticalAlignment UserLocationVerticalAlignment { get; set; }

		// -(void)setUserLocationVerticalAlignment:(MGLAnnotationVerticalAlignment)alignment animated:(BOOL)animated;
		[Export("setUserLocationVerticalAlignment:animated:")]
		void SetUserLocationVerticalAlignment(AnnotationVerticalAlignment alignment, bool animated);

		// @property (assign, nonatomic) BOOL displayHeadingCalibration;
		[Export("displayHeadingCalibration")]
		bool DisplayHeadingCalibration { get; set; }

		// @property (assign, nonatomic) CLLocationCoordinate2D targetCoordinate;
		[Export("targetCoordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D TargetCoordinate { get; set; }

		// -(void)setTargetCoordinate:(CLLocationCoordinate2D)targetCoordinate animated:(BOOL)animated;
		[Export("setTargetCoordinate:animated:")]
		void SetTargetCoordinate(CLLocationCoordinate2D targetCoordinate, bool animated);

		// @property (getter = isZoomEnabled, nonatomic) BOOL zoomEnabled;
		[Export("zoomEnabled")]
		bool ZoomEnabled { [Bind("isZoomEnabled")] get; set; }

		// @property (getter = isScrollEnabled, nonatomic) BOOL scrollEnabled;
		[Export("scrollEnabled")]
		bool ScrollEnabled { [Bind("isScrollEnabled")] get; set; }

		// @property (getter = isRotateEnabled, nonatomic) BOOL rotateEnabled;
		[Export("rotateEnabled")]
		bool RotateEnabled { [Bind("isRotateEnabled")] get; set; }

		// @property (getter = isPitchEnabled, nonatomic) BOOL pitchEnabled;
		[Export("pitchEnabled")]
		bool PitchEnabled { [Bind("isPitchEnabled")] get; set; }

		// @property (nonatomic) CGFloat decelerationRate;
		[Export("decelerationRate")]
		nfloat DecelerationRate { get; set; }

		// @property (nonatomic) CLLocationCoordinate2D centerCoordinate;
		[Export("centerCoordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D CenterCoordinate { get; set; }

		// -(void)setCenterCoordinate:(CLLocationCoordinate2D)coordinate animated:(BOOL)animated;
		[Export("setCenterCoordinate:animated:")]
		void SetCenterCoordinate(CLLocationCoordinate2D coordinate, bool animated);

		// -(void)setCenterCoordinate:(CLLocationCoordinate2D)centerCoordinate zoomLevel:(double)zoomLevel animated:(BOOL)animated;
		[Export("setCenterCoordinate:zoomLevel:animated:")]
		void SetCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel, bool animated);

		// -(void)setCenterCoordinate:(CLLocationCoordinate2D)centerCoordinate zoomLevel:(double)zoomLevel direction:(CLLocationDirection)direction animated:(BOOL)animated;
		[Export("setCenterCoordinate:zoomLevel:direction:animated:")]
		void SetCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel, double direction, bool animated);

		// -(void)setCenterCoordinate:(CLLocationCoordinate2D)centerCoordinate zoomLevel:(double)zoomLevel direction:(CLLocationDirection)direction animated:(BOOL)animated completionHandler:(void (^ _Nullable)(void))completion;
		[Export("setCenterCoordinate:zoomLevel:direction:animated:completionHandler:")]
		void SetCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel, double direction, bool animated, [NullAllowed] Action completion);

		// @property (nonatomic) double zoomLevel;
		[Export("zoomLevel")]
		double ZoomLevel { get; set; }

		// -(void)setZoomLevel:(double)zoomLevel animated:(BOOL)animated;
		[Export("setZoomLevel:animated:")]
		void SetZoomLevel(double zoomLevel, bool animated);

		// @property (nonatomic) double minimumZoomLevel;
		[Export("minimumZoomLevel")]
		double MinimumZoomLevel { get; set; }

		// @property (nonatomic) double maximumZoomLevel;
		[Export("maximumZoomLevel")]
		double MaximumZoomLevel { get; set; }

		// @property (nonatomic) CLLocationDirection direction;
		[Export("direction")]
		double Direction { get; set; }

		// -(void)setDirection:(CLLocationDirection)direction animated:(BOOL)animated;
		[Export("setDirection:animated:")]
		void SetDirection(double direction, bool animated);

		// -(void)resetNorth __attribute__((ibaction));
		[Export("resetNorth")]
		void ResetNorth();

		// -(void)resetPosition __attribute__((ibaction));
		[Export("resetPosition")]
		void ResetPosition();

		// @property (nonatomic) MGLCoordinateBounds visibleCoordinateBounds;
		[Export("visibleCoordinateBounds", ArgumentSemantic.Assign)]
		CoordinateBounds VisibleCoordinateBounds { get; set; }

		// -(void)setVisibleCoordinateBounds:(MGLCoordinateBounds)bounds animated:(BOOL)animated;
		[Export("setVisibleCoordinateBounds:animated:")]
		void SetVisibleCoordinateBounds(CoordinateBounds bounds, bool animated);

		// -(void)setVisibleCoordinateBounds:(MGLCoordinateBounds)bounds edgePadding:(UIEdgeInsets)insets animated:(BOOL)animated;
		[Export("setVisibleCoordinateBounds:edgePadding:animated:")]
		void SetVisibleCoordinateBounds(CoordinateBounds bounds, UIEdgeInsets insets, bool animated);

		// -(void)setVisibleCoordinates:(CLLocationCoordinate2D * _Nonnull)coordinates count:(NSUInteger)count edgePadding:(UIEdgeInsets)insets animated:(BOOL)animated;
		[Export("setVisibleCoordinates:count:edgePadding:animated:")]
		void SetVisibleCoordinates(IntPtr coordinates, nuint count, UIEdgeInsets insets, bool animated);

		// -(void)setVisibleCoordinates:(CLLocationCoordinate2D * _Nonnull)coordinates count:(NSUInteger)count edgePadding:(UIEdgeInsets)insets direction:(CLLocationDirection)direction duration:(NSTimeInterval)duration animationTimingFunction:(CAMediaTimingFunction * _Nullable)function completionHandler:(void (^ _Nullable)(void))completion;
		[Export("setVisibleCoordinates:count:edgePadding:direction:duration:animationTimingFunction:completionHandler:")]
		void SetVisibleCoordinates(IntPtr coordinates, nuint count, UIEdgeInsets insets, double direction, double duration, [NullAllowed] CAMediaTimingFunction function, [NullAllowed] Action completion);

		// -(void)showAnnotations:(NSArray<id<MGLAnnotation>> * _Nonnull)annotations animated:(BOOL)animated;
		[Export("showAnnotations:animated:")]
		void ShowAnnotations(IAnnotation[] annotations, bool animated);

		// -(void)showAnnotations:(NSArray<id<MGLAnnotation>> * _Nonnull)annotations edgePadding:(UIEdgeInsets)insets animated:(BOOL)animated;
		[Export("showAnnotations:edgePadding:animated:")]
		void ShowAnnotations(IAnnotation[] annotations, UIEdgeInsets insets, bool animated);

		// @property (copy, nonatomic) MGLMapCamera * _Nonnull camera;
		[Export("camera", ArgumentSemantic.Copy)]
		MapCamera Camera { get; set; }

		// -(void)setCamera:(MGLMapCamera * _Nonnull)camera animated:(BOOL)animated;
		[Export("setCamera:animated:")]
		void SetCamera(MapCamera camera, bool animated);

		// -(void)setCamera:(MGLMapCamera * _Nonnull)camera withDuration:(NSTimeInterval)duration animationTimingFunction:(CAMediaTimingFunction * _Nullable)function;
		[Export("setCamera:withDuration:animationTimingFunction:")]
		void SetCamera(MapCamera camera, double duration, [NullAllowed] CAMediaTimingFunction function);

		// -(void)setCamera:(MGLMapCamera * _Nonnull)camera withDuration:(NSTimeInterval)duration animationTimingFunction:(CAMediaTimingFunction * _Nullable)function completionHandler:(void (^ _Nullable)(void))completion;
		[Export("setCamera:withDuration:animationTimingFunction:completionHandler:")]
		void SetCamera(MapCamera camera, double duration, [NullAllowed] CAMediaTimingFunction function, [NullAllowed] Action completion);

		// -(void)flyToCamera:(MGLMapCamera * _Nonnull)camera completionHandler:(void (^ _Nullable)(void))completion;
		[Export("flyToCamera:completionHandler:")]
		void FlyToCamera(MapCamera camera, [NullAllowed] Action completion);

		// -(void)flyToCamera:(MGLMapCamera * _Nonnull)camera withDuration:(NSTimeInterval)duration completionHandler:(void (^ _Nullable)(void))completion;
		[Export("flyToCamera:withDuration:completionHandler:")]
		void FlyToCamera(MapCamera camera, double duration, [NullAllowed] Action completion);

		// -(void)flyToCamera:(MGLMapCamera * _Nonnull)camera withDuration:(NSTimeInterval)duration peakAltitude:(CLLocationDistance)peakAltitude completionHandler:(void (^ _Nullable)(void))completion;
		[Export("flyToCamera:withDuration:peakAltitude:completionHandler:")]
		void FlyToCamera(MapCamera camera, double duration, double peakAltitude, [NullAllowed] Action completion);

		// -(MGLMapCamera * _Nonnull)cameraThatFitsCoordinateBounds:(MGLCoordinateBounds)bounds;
		[Export("cameraThatFitsCoordinateBounds:")]
		MapCamera CameraThatFitsCoordinateBounds(CoordinateBounds bounds);

		// -(MGLMapCamera * _Nonnull)cameraThatFitsCoordinateBounds:(MGLCoordinateBounds)bounds edgePadding:(UIEdgeInsets)insets;
		[Export("cameraThatFitsCoordinateBounds:edgePadding:")]
		MapCamera CameraThatFitsCoordinateBounds(CoordinateBounds bounds, UIEdgeInsets insets);

		// -(CGPoint)anchorPointForGesture:(UIGestureRecognizer * _Nonnull)gesture;
		[Export("anchorPointForGesture:")]
		CGPoint AnchorPointForGesture(UIGestureRecognizer gesture);

		// @property (assign, nonatomic) UIEdgeInsets contentInset;
		[Export("contentInset", ArgumentSemantic.Assign)]
		UIEdgeInsets ContentInset { get; set; }

		// -(void)setContentInset:(UIEdgeInsets)contentInset animated:(BOOL)animated;
		[Export("setContentInset:animated:")]
		void SetContentInset(UIEdgeInsets contentInset, bool animated);

		// -(CLLocationCoordinate2D)convertPoint:(CGPoint)point toCoordinateFromView:(UIView * _Nullable)view;
		[Export("convertPoint:toCoordinateFromView:")]
		CLLocationCoordinate2D ConvertPoint(CGPoint point, [NullAllowed] UIView view);

		// -(CGPoint)convertCoordinate:(CLLocationCoordinate2D)coordinate toPointToView:(UIView * _Nullable)view;
		[Export("convertCoordinate:toPointToView:")]
		CGPoint ConvertCoordinate(CLLocationCoordinate2D coordinate, [NullAllowed] UIView view);

		// -(MGLCoordinateBounds)convertRect:(CGRect)rect toCoordinateBoundsFromView:(UIView * _Nullable)view;
		[Export("convertRect:toCoordinateBoundsFromView:")]
		CoordinateBounds ConvertRect(CGRect rect, [NullAllowed] UIView view);

		// -(CGRect)convertCoordinateBounds:(MGLCoordinateBounds)bounds toRectToView:(UIView * _Nullable)view;
		[Export("convertCoordinateBounds:toRectToView:")]
		CGRect ConvertCoordinateBounds(CoordinateBounds bounds, [NullAllowed] UIView view);

		// -(CLLocationDistance)metersPerPointAtLatitude:(CLLocationDegrees)latitude;
		[Export("metersPerPointAtLatitude:")]
		double MetersPerPointAtLatitude(double latitude);

		// -(CLLocationDistance)metersPerPixelAtLatitude:(CLLocationDegrees)latitude __attribute__((deprecated("Use -metersPerPointAtLatitude:.")));
		[Export("metersPerPixelAtLatitude:")]
		double MetersPerPixelAtLatitude(double latitude);

		// @property (readonly, nonatomic) NSArray<id<MGLAnnotation>> * _Nullable annotations;
		[NullAllowed, Export("annotations")]
		IAnnotation[] Annotations { get; }

		// @property (readonly, nonatomic) NSArray<id<MGLAnnotation>> * _Nullable visibleAnnotations;
		[NullAllowed, Export("visibleAnnotations")]
		IAnnotation[] VisibleAnnotations { get; }

		// -(void)addAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("addAnnotation:")]
		void AddAnnotation(IAnnotation annotation);

		// -(void)addAnnotations:(NSArray<id<MGLAnnotation>> * _Nonnull)annotations;
		[Export("addAnnotations:")]
		void AddAnnotations(IAnnotation[] annotations);

		// -(void)removeAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("removeAnnotation:")]
		void RemoveAnnotation(IAnnotation annotation);

		// -(void)removeAnnotations:(NSArray<id<MGLAnnotation>> * _Nonnull)annotations;
		[Export("removeAnnotations:")]
		void RemoveAnnotations(IAnnotation[] annotations);

		// -(MGLAnnotationView * _Nullable)viewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("viewForAnnotation:")]
		[return: NullAllowed]
		AnnotationView ViewForAnnotation(IAnnotation annotation);

		// -(__kindof MGLAnnotationImage * _Nullable)dequeueReusableAnnotationImageWithIdentifier:(NSString * _Nonnull)identifier;
		[Export("dequeueReusableAnnotationImageWithIdentifier:")]
		AnnotationImage DequeueReusableAnnotationImage(string identifier);

		// -(__kindof MGLAnnotationView * _Nullable)dequeueReusableAnnotationViewWithIdentifier:(NSString * _Nonnull)identifier;
		[Export("dequeueReusableAnnotationViewWithIdentifier:")]
		AnnotationView DequeueReusableAnnotationView(string identifier);

		// -(NSArray<id<MGLAnnotation>> * _Nullable)visibleAnnotationsInRect:(CGRect)rect;
		[Export("visibleAnnotationsInRect:")]
		[return: NullAllowed]
		IAnnotation[] VisibleAnnotationsInRect(CGRect rect);

		// @property (copy, nonatomic) NSArray<id<MGLAnnotation>> * _Nonnull selectedAnnotations;
		[Export("selectedAnnotations", ArgumentSemantic.Copy)]
		IAnnotation[] SelectedAnnotations { get; set; }

		// -(void)selectAnnotation:(id<MGLAnnotation> _Nonnull)annotation animated:(BOOL)animated;
		[Export("selectAnnotation:animated:")]
		void SelectAnnotation(IAnnotation annotation, bool animated);

		// -(void)deselectAnnotation:(id<MGLAnnotation> _Nullable)annotation animated:(BOOL)animated;
		[Export("deselectAnnotation:animated:")]
		void DeselectAnnotation([NullAllowed] IAnnotation annotation, bool animated);

		// -(void)addOverlay:(id<MGLOverlay> _Nonnull)overlay;
		[Export("addOverlay:")]
		void AddOverlay(IOverlay overlay);

		// -(void)addOverlays:(NSArray<id<MGLOverlay>> * _Nonnull)overlays;
		[Export("addOverlays:")]
		void AddOverlays(IOverlay[] overlays);

		// -(void)removeOverlay:(id<MGLOverlay> _Nonnull)overlay;
		[Export("removeOverlay:")]
		void RemoveOverlay(IOverlay overlay);

		// -(void)removeOverlays:(NSArray<id<MGLOverlay>> * _Nonnull)overlays;
		[Export("removeOverlays:")]
		void RemoveOverlays(IOverlay[] overlays);

		// -(NSArray<id<MGLFeature>> * _Nonnull)visibleFeaturesAtPoint:(CGPoint)point;
		[Export("visibleFeaturesAtPoint:")]
		Feature[] VisibleFeaturesAtPoint(CGPoint point);

		// -(NSArray<id<MGLFeature>> * _Nonnull)visibleFeaturesAtPoint:(CGPoint)point inStyleLayersWithIdentifiers:(NSSet<NSString *> * _Nullable)styleLayerIdentifiers;
		[Export("visibleFeaturesAtPoint:inStyleLayersWithIdentifiers:")]
		Feature[] VisibleFeaturesAtPoint(CGPoint point, [NullAllowed] NSSet<NSString> styleLayerIdentifiers);

		// -(NSArray<id<MGLFeature>> * _Nonnull)visibleFeaturesInRect:(CGRect)rect;
		[Export("visibleFeaturesInRect:")]
		Feature[] VisibleFeaturesInRect(CGRect rect);

		// -(NSArray<id<MGLFeature>> * _Nonnull)visibleFeaturesInRect:(CGRect)rect inStyleLayersWithIdentifiers:(NSSet<NSString *> * _Nullable)styleLayerIdentifiers;
		[Export("visibleFeaturesInRect:inStyleLayersWithIdentifiers:")]
		Feature[] VisibleFeaturesInRect(CGRect rect, [NullAllowed] NSSet<NSString> styleLayerIdentifiers);

		//TODO
		// @property (nonatomic) MGLMapDebugMaskOptions debugMask;
		//[Export("debugMask", ArgumentSemantic.Assign)]
		//DebugMaskOptions DebugMask { get; set; }

		// @property (getter = isDebugActive, nonatomic) BOOL debugActive __attribute__((deprecated("Use -debugMask and -setDebugMask:.")));
		[Export("debugActive")]
		bool DebugActive { [Bind("isDebugActive")] get; set; }

		// -(void)toggleDebug __attribute__((deprecated("Use -setDebugMask:.")));
		[Export("toggleDebug")]
		void ToggleDebug();

		// -(void)emptyMemoryCache __attribute__((deprecated("")));
		[Export("emptyMemoryCache")]
		void EmptyMemoryCache();

		// @property (nonatomic) double latitude;
		[Export("latitude")]
		double Latitude { get; set; }

		// @property (nonatomic) double longitude;
		[Export("longitude")]
		double Longitude { get; set; }

		// @property (nonatomic) BOOL allowsZooming;
		[Export("allowsZooming")]
		bool AllowsZooming { get; set; }

		// @property (nonatomic) BOOL allowsScrolling;
		[Export("allowsScrolling")]
		bool AllowsScrolling { get; set; }

		// @property (nonatomic) BOOL allowsRotating;
		[Export("allowsRotating")]
		bool AllowsRotating { get; set; }

		// @property (nonatomic) BOOL allowsTilting;
		[Export("allowsTilting")]
		bool AllowsTilting { get; set; }

	}

	interface IMapViewDelegate { }

	// @protocol MGLMapViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "MGLMapViewDelegate")]
	interface MapViewDelegate
	{
		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView regionWillChangeAnimated:(BOOL)animated;
		[Export("mapView:regionWillChangeAnimated:")]
		void RegionWillChang(MapView mapView, bool animated);

		// @optional -(void)mapViewRegionIsChanging:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewRegionIsChanging:")]
		void RegionIsChanging(MapView mapView);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView regionDidChangeAnimated:(BOOL)animated;
		[Export("mapView:regionDidChangeAnimated:")]
		void RegionDidChange(MapView mapView, bool animated);

		// @optional -(void)mapViewWillStartLoadingMap:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewWillStartLoadingMap:")]
		void WillStartLoadingMap(MapView mapView);

		// @optional -(void)mapViewDidFinishLoadingMap:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewDidFinishLoadingMap:")]
		void DidFinishLoadingMap(MapView mapView);

		// @optional -(void)mapViewDidFailLoadingMap:(MGLMapView * _Nonnull)mapView withError:(NSError * _Nonnull)error;
		[Export("mapViewDidFailLoadingMap:withError:")]
		void FailLoadingMap(MapView mapView, NSError error);

		// @optional -(void)mapViewWillStartRenderingMap:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewWillStartRenderingMap:")]
		void illStartRenderingMap(MapView mapView);

		// @optional -(void)mapViewDidFinishRenderingMap:(MGLMapView * _Nonnull)mapView fullyRendered:(BOOL)fullyRendered;
		[Export("mapViewDidFinishRenderingMap:fullyRendered:")]
		void DidFinishRenderingMap(MapView mapView, bool fullyRendered);

		// @optional -(void)mapViewWillStartRenderingFrame:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewWillStartRenderingFrame:")]
		void WillStartRenderingFrame(MapView mapView);

		// @optional -(void)mapViewDidFinishRenderingFrame:(MGLMapView * _Nonnull)mapView fullyRendered:(BOOL)fullyRendered;
		[Export("mapViewDidFinishRenderingFrame:fullyRendered:")]
		void DidFinishRenderingFrame(MapView mapView, bool fullyRendered);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didFinishLoadingStyle:(MGLStyle * _Nonnull)style;
		[Export("mapView:didFinishLoadingStyle:")]
		void MapView(MapView mapView, Style style);

		// @optional -(void)mapViewWillStartLocatingUser:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewWillStartLocatingUser:")]
		void WillStartLocatingUser(MapView mapView);

		// @optional -(void)mapViewDidStopLocatingUser:(MGLMapView * _Nonnull)mapView;
		[Export("mapViewDidStopLocatingUser:")]
		void DidStopLocatingUser(MapView mapView);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didUpdateUserLocation:(MGLUserLocation * _Nullable)userLocation;
		[Export("mapView:didUpdateUserLocation:")]
		void MapView(MapView mapView, [NullAllowed] UserLocation userLocation);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didFailToLocateUserWithError:(NSError * _Nonnull)error;
		[Export("mapView:didFailToLocateUserWithError:")]
		void MapView(MapView mapView, NSError error);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didChangeUserTrackingMode:(MGLUserTrackingMode)mode animated:(BOOL)animated;
		[Export("mapView:didChangeUserTrackingMode:animated:")]
		void MapView(MapView mapView, UserTrackingMode mode, bool animated);

		// @optional -(MGLAnnotationImage * _Nullable)mapView:(MGLMapView * _Nonnull)mapView imageForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:imageForAnnotation:")]
		[return: NullAllowed]
		AnnotationImage GetImage(MapView mapView, IAnnotation annotation);

		// @optional -(CGFloat)mapView:(MGLMapView * _Nonnull)mapView alphaForShapeAnnotation:(MGLShape * _Nonnull)annotation;
		[Export("mapView:alphaForShapeAnnotation:")]
		nfloat GetAlpha(MapView mapView, Shape annotation);

		// @optional -(UIColor * _Nonnull)mapView:(MGLMapView * _Nonnull)mapView strokeColorForShapeAnnotation:(MGLShape * _Nonnull)annotation;
		[Export("mapView:strokeColorForShapeAnnotation:")]
		UIColor GetStrokeColor(MapView mapView, Shape annotation);

		// @optional -(UIColor * _Nonnull)mapView:(MGLMapView * _Nonnull)mapView fillColorForPolygonAnnotation:(MGLPolygon * _Nonnull)annotation;
		[Export("mapView:fillColorForPolygonAnnotation:")]
		UIColor GetFillColor(MapView mapView, Polygon annotation);

		// @optional -(CGFloat)mapView:(MGLMapView * _Nonnull)mapView lineWidthForPolylineAnnotation:(MGLPolyline * _Nonnull)annotation;
		[Export("mapView:lineWidthForPolylineAnnotation:")]
		nfloat GetLineWidth(MapView mapView, Polyline annotation);

		// @optional -(MGLAnnotationView * _Nullable)mapView:(MGLMapView * _Nonnull)mapView viewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:viewForAnnotation:")]
		[return: NullAllowed]
		AnnotationView GetAnnotationView(MapView mapView, IAnnotation annotation);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didAddAnnotationViews:(NSArray<MGLAnnotationView *> * _Nonnull)annotationViews;
		[Export("mapView:didAddAnnotationViews:")]
		void DidAddAnnotationViews(MapView mapView, AnnotationView[] annotationViews);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didSelectAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:didSelectAnnotation:")]
		void DidSelectAnnotation(MapView mapView, IAnnotation annotation);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didDeselectAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:didDeselectAnnotation:")]
		void DidDeselectAnnotation(MapView mapView, IAnnotation annotation);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didSelectAnnotationView:(MGLAnnotationView * _Nonnull)annotationView;
		[Export("mapView:didSelectAnnotationView:")]
		void DidSelectAnnotationView(MapView mapView, AnnotationView annotationView);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView didDeselectAnnotationView:(MGLAnnotationView * _Nonnull)annotationView;
		[Export("mapView:didDeselectAnnotationView:")]
		void DidDeselectAnnotationView(MapView mapView, AnnotationView annotationView);

		// @optional -(BOOL)mapView:(MGLMapView * _Nonnull)mapView annotationCanShowCallout:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:annotationCanShowCallout:")]
		bool CanShowCallout(MapView mapView, IAnnotation annotation);

		// @optional -(UIView<MGLCalloutView> * _Nullable)mapView:(MGLMapView * _Nonnull)mapView calloutViewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:calloutViewForAnnotation:")]
		[return: NullAllowed]
		ICalloutView GetCalloutView(MapView mapView, IAnnotation annotation);

		// @optional -(UIView * _Nullable)mapView:(MGLMapView * _Nonnull)mapView leftCalloutAccessoryViewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:leftCalloutAccessoryViewForAnnotation:")]
		[return: NullAllowed]
		UIView LeftCalloutAccessoryView(MapView mapView, IAnnotation annotation);

		// @optional -(UIView * _Nullable)mapView:(MGLMapView * _Nonnull)mapView rightCalloutAccessoryViewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:rightCalloutAccessoryViewForAnnotation:")]
		[return: NullAllowed]
		UIView RightCalloutAccessoryView(MapView mapView, IAnnotation annotation);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView annotation:(id<MGLAnnotation> _Nonnull)annotation calloutAccessoryControlTapped:(UIControl * _Nonnull)control;
		[Export("mapView:annotation:calloutAccessoryControlTapped:")]
		void CalloutAccessoryControlTapped(MapView mapView, IAnnotation annotation, UIControl control);

		// @optional -(void)mapView:(MGLMapView * _Nonnull)mapView tapOnCalloutForAnnotation:(id<MGLAnnotation> _Nonnull)annotation;
		[Export("mapView:tapOnCalloutForAnnotation:")]
		void TapOnCallout(MapView mapView, IAnnotation annotation);
	}

	interface IOfflineRegion { }

	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "MGLOfflineRegion")]
	interface OfflineRegion
	{

	}

	// @interface MGLOfflinePack : NSObject
	[BaseType(typeof(NSObject), Name = "MGLOfflinePack")]
	interface OfflinePack
	{
		// @property (readonly, nonatomic) id<MGLOfflineRegion> _Nonnull region;
		[Export("region")]
		IOfflineRegion Region { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull context;
		[Export("context")]
		NSData Context { get; }

		// @property (readonly, nonatomic) MGLOfflinePackState state;
		[Export("state")]
		OfflinePackState State { get; }

		// @property (readonly, nonatomic) MGLOfflinePackProgress progress;
		[Export("progress")]
		OfflinePackProgress Progress { get; }

		// -(void)resume;
		[Export("resume")]
		void Resume();

		// -(void)suspend;
		[Export("suspend")]
		void Suspend();

		// -(void)requestProgress;
		[Export("requestProgress")]
		void RequestProgress();
	}

	[Static]
	partial interface OfflinePackConstants
	{
		// extern const NSNotificationName _Nonnull MGLOfflinePackProgressChangedNotification;
		[Field("MGLOfflinePackProgressChangedNotification", "__Internal")]
		NSString OfflinePackProgressChangedNotification { get; }

		// extern const NSNotificationName _Nonnull MGLOfflinePackErrorNotification;
		[Field("MGLOfflinePackErrorNotification", "__Internal")]
		NSString OfflinePackErrorNotification { get; }

		// extern const NSNotificationName _Nonnull MGLOfflinePackMaximumMapboxTilesReachedNotification;
		[Field("MGLOfflinePackMaximumMapboxTilesReachedNotification", "__Internal")]
		NSString OfflinePackMaximumMapboxTilesReachedNotification { get; }

		// extern const MGLOfflinePackUserInfoKey _Nonnull MGLOfflinePackUserInfoKeyState;
		[Field("MGLOfflinePackUserInfoKeyState", "__Internal")]
		NSString OfflinePackUserInfoKeyState { get; }

		// extern NSString *const _Nonnull MGLOfflinePackStateUserInfoKey __attribute__((deprecated("Use MGLOfflinePackUserInfoKeyState")));
		[Field("MGLOfflinePackStateUserInfoKey", "__Internal")]
		NSString OfflinePackStateUserInfoKey { get; }

		// extern const MGLOfflinePackUserInfoKey _Nonnull MGLOfflinePackUserInfoKeyProgress;
		[Field("MGLOfflinePackUserInfoKeyProgress", "__Internal")]
		NSString OfflinePackUserInfoKeyProgress { get; }

		// extern NSString *const _Nonnull MGLOfflinePackProgressUserInfoKey __attribute__((deprecated("Use MGLOfflinePackUserInfoKeyProgress")));
		[Field("MGLOfflinePackProgressUserInfoKey", "__Internal")]
		NSString OfflinePackProgressUserInfoKey { get; }

		// extern const MGLOfflinePackUserInfoKey _Nonnull MGLOfflinePackUserInfoKeyError;
		[Field("MGLOfflinePackUserInfoKeyError", "__Internal")]
		NSString OfflinePackUserInfoKeyError { get; }

		// extern NSString *const _Nonnull MGLOfflinePackErrorUserInfoKey __attribute__((deprecated("Use MGLOfflinePackUserInfoKeyError")));
		[Field("MGLOfflinePackErrorUserInfoKey", "__Internal")]
		NSString OfflinePackErrorUserInfoKey { get; }

		// extern const MGLOfflinePackUserInfoKey _Nonnull MGLOfflinePackUserInfoKeyMaximumCount;
		[Field("MGLOfflinePackUserInfoKeyMaximumCount", "__Internal")]
		NSString OfflinePackUserInfoKeyMaximumCount { get; }

		// extern NSString *const _Nonnull MGLOfflinePackMaximumCountUserInfoKey __attribute__((deprecated("Use MGLOfflinePackUserInfoKeyMaximumCount")));
		[Field("MGLOfflinePackMaximumCountUserInfoKey", "__Internal")]
		NSString OfflinePackMaximumCountUserInfoKey { get; }
	}

	// typedef void (^MGLOfflinePackAdditionCompletionHandler)(MGLOfflinePack * _Nullable, NSError * _Nullable);
	delegate void OfflinePackAdditionCompletion([NullAllowed] OfflinePack pack, [NullAllowed] NSError error);

	// typedef void (^MGLOfflinePackRemovalCompletionHandler)(NSError * _Nullable);
	delegate void OfflinePackRemovalCompletion([NullAllowed] NSError error);

	// @interface MGLOfflineStorage : NSObject
	[BaseType(typeof(NSObject), Name = "MGLOfflineStorage")]
	interface OfflineStorage
	{
		// +(instancetype _Nonnull)sharedOfflineStorage;
		[Static]
		[Export("sharedOfflineStorage")]
		OfflineStorage Shared { get; }

		// @property (readonly, nonatomic, strong) NSArray<MGLOfflinePack *> * _Nullable packs;
		[NullAllowed]
		[Export("packs", ArgumentSemantic.Strong)]
		OfflinePack[] Packs { get; }

		// -(void)addPackForRegion:(id<MGLOfflineRegion> _Nonnull)region withContext:(NSData * _Nonnull)context completionHandler:(MGLOfflinePackAdditionCompletionHandler _Nullable)completion;
		[Export("addPackForRegion:withContext:completionHandler:")]
		void AddPack(IOfflineRegion region, NSData context, [NullAllowed] OfflinePackAdditionCompletion completionHandler);

		// -(void)removePack:(MGLOfflinePack * _Nonnull)pack withCompletionHandler:(MGLOfflinePackRemovalCompletionHandler _Nullable)completion;
		[Export("removePack:withCompletionHandler:")]
		void RemovePack(OfflinePack pack, [NullAllowed] OfflinePackRemovalCompletion completionHandler);

		// -(void)reloadPacks;
		[Export("reloadPacks")]
		void ReloadPacks();

		// -(void)setMaximumAllowedMapboxTiles:(uint64_t)maximumCount;
		[Export("setMaximumAllowedMapboxTiles:")]
		void SetMaximumAllowedMapboxTiles(ulong maximumCount);

		// @property (readonly, nonatomic) unsigned long long countOfBytesCompleted;
		[Export("countOfBytesCompleted")]
		ulong CountOfBytesCompleted { get; }
	}

	// @interface MGLStyleLayer : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface StyleLayer
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier;
		[Export("initWithIdentifier:")]
		IntPtr Constructor(string identifier);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (getter = isVisible, assign, nonatomic) BOOL visible;
		[Export("visible")]
		bool Visible { [Bind("isVisible")] get; set; }

		// @property (assign, nonatomic) float maximumZoomLevel;
		[Export("maximumZoomLevel")]
		float MaximumZoomLevel { get; set; }

		// @property (assign, nonatomic) float minimumZoomLevel;
		[Export("minimumZoomLevel")]
		float MinimumZoomLevel { get; set; }
	}

	// @interface MGLStyle : NSObject
	[BaseType(typeof(NSObject), Name = "MGLStyle")]
	interface Style
	{
		// +(NSURL * _Nonnull)streetsStyleURL __attribute__((deprecated("Use -streetsStyleURLWithVersion:.")));
		[Static]
		[Export("streetsStyleURL")]
		NSUrl StreetsStyleURL { get; }

		// +(NSURL * _Nonnull)streetsStyleURLWithVersion:(NSInteger)version;
		[Static]
		[Export("streetsStyleURLWithVersion:")]
		NSUrl StreetsStyleURLWithVersion(nint version);

		// +(NSURL * _Nonnull)emeraldStyleURL __attribute__((deprecated("Create an NSURL object with the string “mapbox://styles/mapbox/emerald-v8”.")));
		[Static]
		[Export("emeraldStyleURL")]
		NSUrl EmeraldStyleURL { get; }

		// +(NSURL * _Nonnull)outdoorsStyleURLWithVersion:(NSInteger)version;
		[Static]
		[Export("outdoorsStyleURLWithVersion:")]
		NSUrl OutdoorsStyleURLWithVersion(nint version);

		// +(NSURL * _Nonnull)lightStyleURL __attribute__((deprecated("Use -lightStyleURLWithVersion:.")));
		[Static]
		[Export("lightStyleURL")]
		NSUrl LightStyleURL { get; }

		// +(NSURL * _Nonnull)lightStyleURLWithVersion:(NSInteger)version;
		[Static]
		[Export("lightStyleURLWithVersion:")]
		NSUrl LightStyleURLWithVersion(nint version);

		// +(NSURL * _Nonnull)darkStyleURL __attribute__((deprecated("Use -darkStyleURLWithVersion:.")));
		[Static]
		[Export("darkStyleURL")]
		NSUrl DarkStyleURL { get; }

		// +(NSURL * _Nonnull)darkStyleURLWithVersion:(NSInteger)version;
		[Static]
		[Export("darkStyleURLWithVersion:")]
		NSUrl DarkStyleURLWithVersion(nint version);

		// +(NSURL * _Nonnull)satelliteStyleURL __attribute__((deprecated("Use -satelliteStyleURLWithVersion:.")));
		[Static]
		[Export("satelliteStyleURL")]
		NSUrl SatelliteStyleURL { get; }

		// +(NSURL * _Nonnull)satelliteStyleURLWithVersion:(NSInteger)version;
		[Static]
		[Export("satelliteStyleURLWithVersion:")]
		NSUrl SatelliteStyleURLWithVersion(nint version);

		// +(NSURL * _Nonnull)hybridStyleURL __attribute__((deprecated("Use -satelliteStreetsStyleURLWithVersion:.")));
		[Static]
		[Export("hybridStyleURL")]
		NSUrl HybridStyleURL { get; }

		// +(NSURL * _Nonnull)satelliteStreetsStyleURLWithVersion:(NSInteger)version;
		[Static]
		[Export("satelliteStreetsStyleURLWithVersion:")]
		NSUrl SatelliteStreetsStyleURLWithVersion(nint version);

		// @property (readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		//TODO
		// @property (nonatomic, strong) NSSet<__kindof MGLSource *> * _Nonnull sources;
		//[Export("sources", ArgumentSemantic.Strong)]
		//NSSet<Source> Sources { get; set; }

		// -(MGLSource * _Nullable)sourceWithIdentifier:(NSString * _Nonnull)identifier;
		[Export("sourceWithIdentifier:")]
		[return: NullAllowed]
		Source SourceWithIdentifier(string identifier);

		// -(void)addSource:(MGLSource * _Nonnull)source;
		[Export("addSource:")]
		void AddSource(Source source);

		// -(void)removeSource:(MGLSource * _Nonnull)source;
		[Export("removeSource:")]
		void RemoveSource(Source source);

		// @property (nonatomic, strong) NSArray<__kindof MGLStyleLayer *> * _Nonnull layers;
		[Export("layers", ArgumentSemantic.Strong)]
		StyleLayer[] Layers { get; set; }

		// -(MGLStyleLayer * _Nullable)layerWithIdentifier:(NSString * _Nonnull)identifier;
		[Export("layerWithIdentifier:")]
		[return: NullAllowed]
		StyleLayer LayerWithIdentifier(string identifier);

		// -(void)addLayer:(MGLStyleLayer * _Nonnull)layer;
		[Export("addLayer:")]
		void AddLayer(StyleLayer layer);

		// -(void)insertLayer:(MGLStyleLayer * _Nonnull)layer atIndex:(NSUInteger)index;
		[Export("insertLayer:atIndex:")]
		void InsertLayer(StyleLayer layer, nuint index);

		// -(void)insertLayer:(MGLStyleLayer * _Nonnull)layer belowLayer:(MGLStyleLayer * _Nonnull)sibling;
		[Export("insertLayer:belowLayer:")]
		void InsertLayer(StyleLayer layer, StyleLayer sibling);

		// -(void)insertLayer:(MGLStyleLayer * _Nonnull)layer aboveLayer:(MGLStyleLayer * _Nonnull)sibling;
		[Export("insertLayer:aboveLayer:")]
		void InsertAboveLayer(StyleLayer aboveLayer, StyleLayer sibling);

		// -(void)removeLayer:(MGLStyleLayer * _Nonnull)layer;
		[Export("removeLayer:")]
		void RemoveLayer(StyleLayer layer);

		// @property (nonatomic) NSArray<NSString *> * _Nonnull styleClasses __attribute__((deprecated("This property will be removed in a future release.")));
		[Export("styleClasses", ArgumentSemantic.Assign)]
		string[] StyleClasses { get; set; }

		// -(BOOL)hasStyleClass:(NSString * _Nonnull)styleClass __attribute__((deprecated("This method will be removed in a future release.")));
		[Export("hasStyleClass:")]
		bool HasStyleClass(string styleClass);

		// -(void)addStyleClass:(NSString * _Nonnull)styleClass __attribute__((deprecated("This method will be removed in a future release.")));
		[Export("addStyleClass:")]
		void AddStyleClass(string styleClass);

		// -(void)removeStyleClass:(NSString * _Nonnull)styleClass __attribute__((deprecated("This method will be removed in a future release.")));
		[Export("removeStyleClass:")]
		void RemoveStyleClass(string styleClass);

		// -(UIImage * _Nullable)imageForName:(NSString * _Nonnull)name;
		[Export("imageForName:")]
		[return: NullAllowed]
		UIImage ImageForName(string name);

		// -(void)setImage:(UIImage * _Nonnull)image forName:(NSString * _Nonnull)name;
		[Export("setImage:forName:")]
		void SetImage(UIImage image, string name);

		// -(void)removeImageForName:(NSString * _Nonnull)name;
		[Export("removeImageForName:")]
		void RemoveImageForName(string name);
	}

	// @interface MGLForegroundStyleLayer : MGLStyleLayer
	[BaseType(typeof(StyleLayer))]
	[DisableDefaultCtor]
	interface ForegroundStyleLayer
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:source:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, Source source);

		// @property (readonly, nonatomic) NSString * _Nullable sourceIdentifier;
		[NullAllowed, Export("sourceIdentifier")]
		string SourceIdentifier { get; }
	}

	// @interface MGLVectorStyleLayer : MGLForegroundStyleLayer
	[BaseType(typeof(ForegroundStyleLayer))]
	interface VectorStyleLayer
	{
		// @property (nonatomic) NSString * _Nullable sourceLayerIdentifier;
		[NullAllowed, Export("sourceLayerIdentifier")]
		string SourceLayerIdentifier { get; set; }

		// @property (nonatomic) NSPredicate * _Nullable predicate;
		[NullAllowed, Export("predicate", ArgumentSemantic.Assign)]
		NSPredicate Predicate { get; set; }
	}

	interface IStyleValue { }

	// audit-objc-generics: @interface MGLStyleValue<T> : NSObject
	[BaseType(typeof(NSObject))]
	interface StyleValue
	{
		// +(instancetype _Nonnull)valueWithRawValue:(T _Nonnull)rawValue;
		[Static]
		[Export("valueWithRawValue:")]
		StyleValue ValueWithRawValue(NSObject rawValue);

		//TODO
		// +(instancetype _Nonnull)valueWithStops:(NSDictionary<NSNumber *,MGLStyleValue<T> *> * _Nonnull)stops;
		//[Static]
		//[Export("valueWithStops:")]
		//StyleValue ValueWithStops(NSDictionary<NSNumber, StyleValue<NSObject>> stops);

		// +(instancetype _Nonnull)valueWithInterpolationBase:(CGFloat)interpolationBase stops:(NSDictionary<NSNumber *,MGLStyleValue<T> *> * _Nonnull)stops;
		//[Static]
		//[Export("valueWithInterpolationBase:stops:")]
		//StyleValue ValueWithInterpolationBase(nfloat interpolationBase, NSDictionary<NSNumber, StyleValue<NSObject>> stops);
	}

	// audit-objc-generics: @interface MGLStyleConstantValue<T> : MGLStyleValue
	[BaseType(typeof(StyleValue))]
	[DisableDefaultCtor]
	interface StyleConstantValue
	{
		// +(instancetype _Nonnull)valueWithRawValue:(T _Nonnull)rawValue;
		[Static]
		[Export("valueWithRawValue:")]
		StyleConstantValue ValueWithRawValue(NSObject rawValue);

		// -(instancetype _Nonnull)initWithRawValue:(T _Nonnull)rawValue __attribute__((objc_designated_initializer));
		[Export("initWithRawValue:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSObject rawValue);

		// @property (nonatomic) T _Nonnull rawValue;
		[Export("rawValue", ArgumentSemantic.Assign)]
		NSObject RawValue { get; set; }
	}

	// audit-objc-generics: @interface MGLStyleFunction<T> : MGLStyleValue
	[BaseType(typeof(StyleValue))]
	interface StyleFunction
	{
		//TODO
		// +(instancetype _Nonnull)functionWithStops:(NSDictionary<NSNumber *,MGLStyleValue<T> *> * _Nonnull)stops;
		//[Static]
		//[Export("functionWithStops:")]
		//StyleFunction FunctionWithStops(NSDictionary<NSNumber, StyleValue<NSObject>> stops);

		// +(instancetype _Nonnull)functionWithInterpolationBase:(CGFloat)interpolationBase stops:(NSDictionary<NSNumber *,MGLStyleValue<T> *> * _Nonnull)stops;
		//[Static]
		//[Export("functionWithInterpolationBase:stops:")]
		//StyleFunction FunctionWithInterpolationBase(nfloat interpolationBase, NSDictionary<NSNumber, MGLStyleValue<NSObject>> stops);

		// -(instancetype _Nonnull)initWithInterpolationBase:(CGFloat)interpolationBase stops:(NSDictionary<NSNumber *,MGLStyleValue<T> *> * _Nonnull)stops __attribute__((objc_designated_initializer));
		//[Export("initWithInterpolationBase:stops:")]
		//[DesignatedInitializer]
		//IntPtr Constructor(nfloat interpolationBase, NSDictionary<NSNumber, MGLStyleValue<NSObject>> stops);

		// @property (nonatomic) CGFloat interpolationBase;
		[Export("interpolationBase")]
		nfloat InterpolationBase { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSNumber *,MGLStyleValue<T> *> * _Nonnull stops;
		//[Export("stops", ArgumentSemantic.Copy)]
		//NSDictionary<NSNumber, MGLStyleValue<NSObject>> Stops { get; set; }
	}

	// @interface MGLFillStyleLayer : MGLVectorStyleLayer
	[BaseType(typeof(VectorStyleLayer))]
	interface FillStyleLayer
	{
		//TODO
		// @property (getter = isFillAntialiased, nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified fillAntialiased;
		/*[Export("fillAntialiased", ArgumentSemantic.Assign)]
		StyleValue<NSNumber> FillAntialiased { [Bind("isFillAntialiased")] get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified fillColor;
		[Export("fillColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> FillColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified fillOpacity;
		[Export("fillOpacity", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> FillOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified fillOutlineColor;
		[Export("fillOutlineColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> FillOutlineColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSString *> * _Null_unspecified fillPattern;
		[Export("fillPattern", ArgumentSemantic.Assign)]
		MGLStyleValue<NSString> FillPattern { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified fillTranslation;
		[Export("fillTranslation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> FillTranslation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified fillTranslationAnchor;
		[Export("fillTranslationAnchor", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> FillTranslationAnchor { get; set; }
		*/
	}

	// @interface MGLFillStyleLayerAdditions (NSValue)
	[Category]
	[BaseType(typeof(NSValue))]
	interface NSValue_MGLFillStyleLayerAdditions
	{
		// +(instancetype _Nonnull)valueWithMGLFillTranslationAnchor:(MGLFillTranslationAnchor)fillTranslationAnchor;
		[Static]
		[Export("valueWithMGLFillTranslationAnchor:")]
		NSValue ValueWithMGLFillTranslationAnchor(FillTranslationAnchor fillTranslationAnchor);

		// @property (readonly) MGLFillTranslationAnchor MGLFillTranslationAnchorValue;
		[Static]
		[Export("MGLFillTranslationAnchorValue")]
		FillTranslationAnchor FillTranslationAnchorValue { get; }
	}

	// @interface MGLLineStyleLayer : MGLVectorStyleLayer
	[BaseType(typeof(VectorStyleLayer))]
	interface MGLLineStyleLayer
	{
		//TODO
		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified lineCap;
		/*[Export("lineCap", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> LineCap { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified lineJoin;
		[Export("lineJoin", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> LineJoin { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineMiterLimit;
		[Export("lineMiterLimit", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineMiterLimit { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineRoundLimit;
		[Export("lineRoundLimit", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineRoundLimit { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineBlur;
		[Export("lineBlur", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineBlur { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified lineColor;
		[Export("lineColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> LineColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSArray<NSNumber *> *> * _Null_unspecified lineDashPattern;
		[Export("lineDashPattern", ArgumentSemantic.Assign)]
		MGLStyleValue<NSArray<NSNumber>> LineDashPattern { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineGapWidth;
		[Export("lineGapWidth", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineGapWidth { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineOffset;
		[Export("lineOffset", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineOffset { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineOpacity;
		[Export("lineOpacity", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<NSString *> * _Null_unspecified linePattern;
		[Export("linePattern", ArgumentSemantic.Assign)]
		MGLStyleValue<NSString> LinePattern { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified lineTranslation;
		[Export("lineTranslation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> LineTranslation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified lineTranslationAnchor;
		[Export("lineTranslationAnchor", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> LineTranslationAnchor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified lineWidth;
		[Export("lineWidth", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> LineWidth { get; set; }
		*/
	}

	// @interface MGLLineStyleLayerAdditions (NSValue)
	[Category]
	[BaseType(typeof(NSValue))]
	interface NSValue_MGLLineStyleLayerAdditions
	{
		// +(instancetype _Nonnull)valueWithMGLLineCap:(MGLLineCap)lineCap;
		[Static]
		[Export("valueWithMGLLineCap:")]
		NSValue ValueWithMGLLineCap(LineCap lineCap);

		// @property (readonly) MGLLineCap MGLLineCapValue;
		[Static]
		[Export("MGLLineCapValue")]
		LineCap MGLLineCapValue { get; }

		// +(instancetype _Nonnull)valueWithMGLLineJoin:(MGLLineJoin)lineJoin;
		[Static]
		[Export("valueWithMGLLineJoin:")]
		NSValue ValueWithMGLLineJoin(LineJoin lineJoin);

		// @property (readonly) MGLLineJoin MGLLineJoinValue;
		[Static]
		[Export("MGLLineJoinValue")]
		LineJoin MGLLineJoinValue { get; }

		// +(instancetype _Nonnull)valueWithMGLLineTranslationAnchor:(MGLLineTranslationAnchor)lineTranslationAnchor;
		[Static]
		[Export("valueWithMGLLineTranslationAnchor:")]
		NSValue ValueWithMGLLineTranslationAnchor(LineTranslationAnchor lineTranslationAnchor);

		// @property (readonly) MGLLineTranslationAnchor MGLLineTranslationAnchorValue;
		[Static]
		[Export("MGLLineTranslationAnchorValue")]
		LineTranslationAnchor MGLLineTranslationAnchorValue { get; }
	}

	// @interface MGLSymbolStyleLayer : MGLVectorStyleLayer
	[BaseType(typeof(VectorStyleLayer))]
	interface SymbolStyleLayer
	{
		//TODO
		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconAllowsOverlap;
		/*[Export("iconAllowsOverlap", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconAllowsOverlap { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconIgnoresPlacement;
		[Export("iconIgnoresPlacement", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconIgnoresPlacement { get; set; }

		// @property (nonatomic) MGLStyleValue<NSString *> * _Null_unspecified iconImageName;
		[Export("iconImageName", ArgumentSemantic.Assign)]
		MGLStyleValue<NSString> IconImageName { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified iconOffset;
		[Export("iconOffset", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> IconOffset { get; set; }

		// @property (getter = isIconOptional, nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconOptional;
		[Export("iconOptional", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconOptional { [Bind("isIconOptional")] get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconPadding;
		[Export("iconPadding", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconPadding { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconRotation;
		[Export("iconRotation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconRotation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified iconRotationAlignment;
		[Export("iconRotationAlignment", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> IconRotationAlignment { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconScale;
		[Export("iconScale", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconScale { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified iconTextFit;
		[Export("iconTextFit", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> IconTextFit { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified iconTextFitPadding;
		[Export("iconTextFitPadding", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> IconTextFitPadding { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified keepsIconUpright;
		[Export("keepsIconUpright", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> KeepsIconUpright { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified keepsTextUpright;
		[Export("keepsTextUpright", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> KeepsTextUpright { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified maximumTextAngle;
		[Export("maximumTextAngle", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> MaximumTextAngle { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified maximumTextWidth;
		[Export("maximumTextWidth", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> MaximumTextWidth { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified symbolAvoidsEdges;
		[Export("symbolAvoidsEdges", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> SymbolAvoidsEdges { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified symbolPlacement;
		[Export("symbolPlacement", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> SymbolPlacement { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified symbolSpacing;
		[Export("symbolSpacing", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> SymbolSpacing { get; set; }

		// @property (nonatomic) MGLStyleValue<NSString *> * _Null_unspecified text;
		[Export("text", ArgumentSemantic.Assign)]
		MGLStyleValue<NSString> Text { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textAllowsOverlap;
		[Export("textAllowsOverlap", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextAllowsOverlap { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textAnchor;
		[Export("textAnchor", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextAnchor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSArray<NSString *> *> * _Null_unspecified textFontNames;
		[Export("textFontNames", ArgumentSemantic.Assign)]
		MGLStyleValue<NSArray<NSString>> TextFontNames { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textFontSize;
		[Export("textFontSize", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextFontSize { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textIgnoresPlacement;
		[Export("textIgnoresPlacement", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextIgnoresPlacement { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textJustification;
		[Export("textJustification", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextJustification { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textLetterSpacing;
		[Export("textLetterSpacing", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextLetterSpacing { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textLineHeight;
		[Export("textLineHeight", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextLineHeight { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textOffset;
		[Export("textOffset", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextOffset { get; set; }

		// @property (getter = isTextOptional, nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textOptional;
		[Export("textOptional", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextOptional { [Bind("isTextOptional")] get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textPadding;
		[Export("textPadding", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextPadding { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textPitchAlignment;
		[Export("textPitchAlignment", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextPitchAlignment { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textRotation;
		[Export("textRotation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextRotation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textRotationAlignment;
		[Export("textRotationAlignment", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextRotationAlignment { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textTransform;
		[Export("textTransform", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextTransform { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified iconColor;
		[Export("iconColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> IconColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconHaloBlur;
		[Export("iconHaloBlur", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconHaloBlur { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified iconHaloColor;
		[Export("iconHaloColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> IconHaloColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconHaloWidth;
		[Export("iconHaloWidth", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconHaloWidth { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified iconOpacity;
		[Export("iconOpacity", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> IconOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified iconTranslation;
		[Export("iconTranslation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> IconTranslation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified iconTranslationAnchor;
		[Export("iconTranslationAnchor", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> IconTranslationAnchor { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified textColor;
		[Export("textColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> TextColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textHaloBlur;
		[Export("textHaloBlur", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextHaloBlur { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified textHaloColor;
		[Export("textHaloColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> TextHaloColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textHaloWidth;
		[Export("textHaloWidth", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextHaloWidth { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified textOpacity;
		[Export("textOpacity", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> TextOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textTranslation;
		[Export("textTranslation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextTranslation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified textTranslationAnchor;
		[Export("textTranslationAnchor", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> TextTranslationAnchor { get; set; }
		*/
	}

	// @interface MGLSymbolStyleLayerAdditions (NSValue)
	[Category]
	[BaseType(typeof(NSValue))]
	interface SymbolStyleLayerAdditions
	{
		// +(instancetype _Nonnull)valueWithMGLIconRotationAlignment:(MGLIconRotationAlignment)iconRotationAlignment;
		[Static]
		[Export("valueWithMGLIconRotationAlignment:")]
		NSValue ValueWithMGLIconRotationAlignment(IconRotationAlignment iconRotationAlignment);

		// @property (readonly) MGLIconRotationAlignment MGLIconRotationAlignmentValue;
		[Static]
		[Export("MGLIconRotationAlignmentValue")]
		IconRotationAlignment IconRotationAlignmentValue { get; }

		// +(instancetype _Nonnull)valueWithMGLIconTextFit:(MGLIconTextFit)iconTextFit;
		[Static]
		[Export("valueWithMGLIconTextFit:")]
		NSValue ValueWithMGLIconTextFit(IconTextFit iconTextFit);

		// @property (readonly) MGLIconTextFit MGLIconTextFitValue;
		[Static]
		[Export("MGLIconTextFitValue")]
		IconTextFit IconTextFitValue { get; }

		// +(instancetype _Nonnull)valueWithMGLSymbolPlacement:(MGLSymbolPlacement)symbolPlacement;
		[Static]
		[Export("valueWithMGLSymbolPlacement:")]
		NSValue ValueWithMGLSymbolPlacement(SymbolPlacement symbolPlacement);

		// @property (readonly) MGLSymbolPlacement MGLSymbolPlacementValue;
		[Static]
		[Export("MGLSymbolPlacementValue")]
		SymbolPlacement SymbolPlacementValue { get; }

		// +(instancetype _Nonnull)valueWithMGLTextAnchor:(MGLTextAnchor)textAnchor;
		[Static]
		[Export("valueWithMGLTextAnchor:")]
		NSValue ValueWithMGLTextAnchor(TextAnchor textAnchor);

		// @property (readonly) MGLTextAnchor MGLTextAnchorValue;
		[Static]
		[Export("MGLTextAnchorValue")]
		TextAnchor TextAnchorValue { get; }

		// +(instancetype _Nonnull)valueWithMGLTextJustification:(MGLTextJustification)textJustification;
		[Static]
		[Export("valueWithMGLTextJustification:")]
		NSValue ValueWithMGLTextJustification(TextJustification textJustification);

		// @property (readonly) MGLTextJustification MGLTextJustificationValue;
		[Static]
		[Export("MGLTextJustificationValue")]
		TextJustification MGLTextJustificationValue { get; }

		// +(instancetype _Nonnull)valueWithMGLTextPitchAlignment:(MGLTextPitchAlignment)textPitchAlignment;
		[Static]
		[Export("valueWithMGLTextPitchAlignment:")]
		NSValue ValueWithMGLTextPitchAlignment(TextPitchAlignment textPitchAlignment);

		// @property (readonly) MGLTextPitchAlignment MGLTextPitchAlignmentValue;
		[Static]
		[Export("MGLTextPitchAlignmentValue")]
		TextPitchAlignment TextPitchAlignmentValue { get; }

		// +(instancetype _Nonnull)valueWithMGLTextRotationAlignment:(MGLTextRotationAlignment)textRotationAlignment;
		[Static]
		[Export("valueWithMGLTextRotationAlignment:")]
		NSValue ValueWithMGLTextRotationAlignment(TextRotationAlignment textRotationAlignment);

		// @property (readonly) MGLTextRotationAlignment MGLTextRotationAlignmentValue;
		[Static]
		[Export("MGLTextRotationAlignmentValue")]
		TextRotationAlignment TextRotationAlignmentValue { get; }

		// +(instancetype _Nonnull)valueWithMGLTextTransform:(MGLTextTransform)textTransform;
		[Static]
		[Export("valueWithMGLTextTransform:")]
		NSValue ValueWithMGLTextTransform(TextTransform textTransform);

		// @property (readonly) MGLTextTransform MGLTextTransformValue;
		[Static]
		[Export("MGLTextTransformValue")]
		TextTransform TextTransformValue { get; }

		// +(instancetype _Nonnull)valueWithMGLIconTranslationAnchor:(MGLIconTranslationAnchor)iconTranslationAnchor;
		[Static]
		[Export("valueWithMGLIconTranslationAnchor:")]
		NSValue ValueWithMGLIconTranslationAnchor(IconTranslationAnchor iconTranslationAnchor);

		// @property (readonly) MGLIconTranslationAnchor MGLIconTranslationAnchorValue;
		[Static]
		[Export("MGLIconTranslationAnchorValue")]
		IconTranslationAnchor IconTranslationAnchorValue { get; }

		// +(instancetype _Nonnull)valueWithMGLTextTranslationAnchor:(MGLTextTranslationAnchor)textTranslationAnchor;
		[Static]
		[Export("valueWithMGLTextTranslationAnchor:")]
		NSValue ValueWithMGLTextTranslationAnchor(TextTranslationAnchor textTranslationAnchor);

		// @property (readonly) MGLTextTranslationAnchor MGLTextTranslationAnchorValue;
		[Static]
		[Export("MGLTextTranslationAnchorValue")]
		TextTranslationAnchor TextTranslationAnchorValue { get; }
	}

	// @interface MGLRasterStyleLayer : MGLForegroundStyleLayer
	[BaseType(typeof(ForegroundStyleLayer))]
	interface RasterStyleLayer
	{
		//TODO
		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified maximumRasterBrightness;
		/*[Export("maximumRasterBrightness", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> MaximumRasterBrightness { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified minimumRasterBrightness;
		[Export("minimumRasterBrightness", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> MinimumRasterBrightness { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified rasterContrast;
		[Export("rasterContrast", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> RasterContrast { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified rasterFadeDuration;
		[Export("rasterFadeDuration", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> RasterFadeDuration { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified rasterHueRotation;
		[Export("rasterHueRotation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> RasterHueRotation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified rasterOpacity;
		[Export("rasterOpacity", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> RasterOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified rasterSaturation;
		[Export("rasterSaturation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> RasterSaturation { get; set; }
		*/
	}

	// @interface MGLCircleStyleLayer : MGLVectorStyleLayer
	[BaseType(typeof(VectorStyleLayer))]
	interface CircleStyleLayer
	{
		//TODO
		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified circleBlur;
		/*[Export("circleBlur", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> CircleBlur { get; set; }

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified circleColor;
		[Export("circleColor", ArgumentSemantic.Assign)]
		MGLStyleValue<UIColor> CircleColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified circleOpacity;
		[Export("circleOpacity", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> CircleOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified circleRadius;
		[Export("circleRadius", ArgumentSemantic.Assign)]
		MGLStyleValue<NSNumber> CircleRadius { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified circleScaleAlignment;
		[Export("circleScaleAlignment", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> CircleScaleAlignment { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified circleTranslation;
		[Export("circleTranslation", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> CircleTranslation { get; set; }

		// @property (nonatomic) MGLStyleValue<NSValue *> * _Null_unspecified circleTranslationAnchor;
		[Export("circleTranslationAnchor", ArgumentSemantic.Assign)]
		MGLStyleValue<NSValue> CircleTranslationAnchor { get; set; }
		*/
	}

	// @interface MGLCircleStyleLayerAdditions (NSValue)
	[Category]
	[BaseType(typeof(NSValue))]
	interface CircleStyleLayerAdditions
	{
		//TODO
		// +(instancetype _Nonnull)valueWithMGLCircleScaleAlignment:(MGLCircleScaleAlignment)circleScaleAlignment;
		/*[Static]
		[Export("valueWithMGLCircleScaleAlignment:")]
		NSValue ValueWithMGLCircleScaleAlignment(CircleScaleAlignment circleScaleAlignment);

		// @property (readonly) MGLCircleScaleAlignment MGLCircleScaleAlignmentValue;
		[Export("MGLCircleScaleAlignmentValue")]
		CircleScaleAlignment CircleScaleAlignmentValue { get; }

		// +(instancetype _Nonnull)valueWithMGLCircleTranslationAnchor:(MGLCircleTranslationAnchor)circleTranslationAnchor;
		[Static]
		[Export("valueWithMGLCircleTranslationAnchor:")]
		NSValue ValueWithMGLCircleTranslationAnchor(CircleTranslationAnchor circleTranslationAnchor);

		// @property (readonly) MGLCircleTranslationAnchor MGLCircleTranslationAnchorValue;
		[Export("MGLCircleTranslationAnchorValue")]
		CircleTranslationAnchor CircleTranslationAnchorValue { get; }
		*/
	}

	// @interface MGLBackgroundStyleLayer : MGLStyleLayer
	[BaseType(typeof(StyleLayer))]
	interface BackgroundStyleLayer
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier);

		// @property (nonatomic) MGLStyleValue<UIColor *> * _Null_unspecified backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic) MGLStyleValue<NSNumber *> * _Null_unspecified backgroundOpacity;
		[Export("backgroundOpacity", ArgumentSemantic.Assign)]
		NSNumber BackgroundOpacity { get; set; }

		// @property (nonatomic) MGLStyleValue<NSString *> * _Null_unspecified backgroundPattern;
		[Export("backgroundPattern", ArgumentSemantic.Assign)]
		NSString BackgroundPattern { get; set; }
	}

	// @interface MGLOpenGLStyleLayer : MGLStyleLayer
	[BaseType(typeof(StyleLayer))]
	interface OpenGLStyleLayer
	{
		// @property (readonly, nonatomic, weak) MGLMapView * _Nullable mapView;
		[NullAllowed, Export("mapView", ArgumentSemantic.Weak)]
		MapView MapView { get; }

		// -(void)didMoveToMapView:(MGLMapView * _Nonnull)mapView;
		[Export("didMoveToMapView:")]
		void DidMoveToMapView(MapView mapView);

		// -(void)willMoveFromMapView:(MGLMapView * _Nonnull)mapView;
		[Export("willMoveFromMapView:")]
		void WillMoveFromMapView(MapView mapView);

		// -(void)drawInMapView:(MGLMapView * _Nonnull)mapView withContext:(MGLStyleLayerDrawingContext)context;
		[Export("drawInMapView:withContext:")]
		void DrawInMapView(MapView mapView, StyleLayerDrawingContext context);

		// -(void)setNeedsDisplay;
		[Export("setNeedsDisplay")]
		void SetNeedsDisplay();
	}

	// @interface MGLSource : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface Source
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier;
		[Export("initWithIdentifier:")]
		IntPtr Constructor(string identifier);

		// @property (copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; set; }
	}

	[Static]
	partial interface TileSourceConstants
	{
		// extern const MGLTileSourceOption _Nonnull MGLTileSourceOptionMinimumZoomLevel;
		[Field("MGLTileSourceOptionMinimumZoomLevel", "__Internal")]
		NSString MGLTileSourceOptionMinimumZoomLevel { get; }

		// extern const MGLTileSourceOption _Nonnull MGLTileSourceOptionMaximumZoomLevel;
		[Field("MGLTileSourceOptionMaximumZoomLevel", "__Internal")]
		NSString MGLTileSourceOptionMaximumZoomLevel { get; }

		// extern const MGLTileSourceOption _Nonnull MGLTileSourceOptionAttributionHTMLString;
		[Field("MGLTileSourceOptionAttributionHTMLString", "__Internal")]
		NSString MGLTileSourceOptionAttributionHTMLString { get; }

		// extern const MGLTileSourceOption _Nonnull MGLTileSourceOptionAttributionInfos;
		[Field("MGLTileSourceOptionAttributionInfos", "__Internal")]
		NSString MGLTileSourceOptionAttributionInfos { get; }

		// extern const MGLTileSourceOption _Nonnull MGLTileSourceOptionTileCoordinateSystem;
		[Field("MGLTileSourceOptionTileCoordinateSystem", "__Internal")]
		NSString MGLTileSourceOptionTileCoordinateSystem { get; }
	}

	// @interface MGLTileSource : MGLSource
	[BaseType(typeof(Source))]
	[DisableDefaultCtor]
	interface TileSource
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier configurationURL:(NSURL * _Nonnull)configurationURL;
		[Export("initWithIdentifier:configurationURL:")]
		IntPtr Constructor(string identifier, NSUrl configurationURL);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier tileURLTemplates:(NSArray<NSString *> * _Nonnull)tileURLTemplates options:(NSDictionary<MGLTileSourceOption,id> * _Nullable)options;
		[Export("initWithIdentifier:tileURLTemplates:options:")]
		IntPtr Constructor(string identifier, string[] tileURLTemplates, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// @property (readonly, copy, nonatomic) NSURL * _Nullable configurationURL;
		[NullAllowed, Export("configurationURL", ArgumentSemantic.Copy)]
		NSUrl ConfigurationURL { get; }

		// @property (readonly, copy, nonatomic) NSArray<MGLAttributionInfo *> * _Nonnull attributionInfos;
		[Export("attributionInfos", ArgumentSemantic.Copy)]
		AttributionInfo[] AttributionInfos { get; }
	}

	// @interface MGLVectorSource : MGLTileSource
	[BaseType(typeof(TileSource))]
	interface MGLVectorSource
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier configurationURL:(NSURL * _Nonnull)configurationURL __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:configurationURL:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, NSUrl configurationURL);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier tileURLTemplates:(NSArray<NSString *> * _Nonnull)tileURLTemplates options:(NSDictionary<MGLTileSourceOption,id> * _Nullable)options __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:tileURLTemplates:options:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, string[] tileURLTemplates, [NullAllowed] NSDictionary<NSString, NSObject> options);
	}

	[Static]
	partial interface ShapeSourceConstants
	{
		// extern const MGLShapeSourceOption _Nonnull MGLShapeSourceOptionClustered;
		[Field("MGLShapeSourceOptionClustered", "__Internal")]
		NSString MGLShapeSourceOptionClustered { get; }

		// extern const MGLShapeSourceOption _Nonnull MGLShapeSourceOptionClusterRadius;
		[Field("MGLShapeSourceOptionClusterRadius", "__Internal")]
		NSString MGLShapeSourceOptionClusterRadius { get; }

		// extern const MGLShapeSourceOption _Nonnull MGLShapeSourceOptionMaximumZoomLevelForClustering;
		[Field("MGLShapeSourceOptionMaximumZoomLevelForClustering", "__Internal")]
		NSString MGLShapeSourceOptionMaximumZoomLevelForClustering { get; }

		// extern const MGLShapeSourceOption _Nonnull MGLShapeSourceOptionMaximumZoomLevel;
		[Field("MGLShapeSourceOptionMaximumZoomLevel", "__Internal")]
		NSString MGLShapeSourceOptionMaximumZoomLevel { get; }

		// extern const MGLShapeSourceOption _Nonnull MGLShapeSourceOptionBuffer;
		[Field("MGLShapeSourceOptionBuffer", "__Internal")]
		NSString MGLShapeSourceOptionBuffer { get; }

		// extern const MGLShapeSourceOption _Nonnull MGLShapeSourceOptionSimplificationTolerance;
		[Field("MGLShapeSourceOptionSimplificationTolerance", "__Internal")]
		NSString MGLShapeSourceOptionSimplificationTolerance { get; }
	}

	// @interface MGLShapeSource : MGLSource
	[BaseType(typeof(Source))]
	interface ShapeSource
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier URL:(NSURL * _Nonnull)url options:(NSDictionary<MGLShapeSourceOption,id> * _Nullable)options __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:URL:options:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, NSUrl url, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier shape:(MGLShape * _Nullable)shape options:(NSDictionary<MGLShapeSourceOption,id> * _Nullable)options __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:shape:options:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, [NullAllowed] Shape shape, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier features:(NSArray<MGLShape<MGLFeature> *> * _Nonnull)features options:(NSDictionary<MGLShapeSourceOption,id> * _Nullable)options;
		[Export("initWithIdentifier:features:options:")]
		IntPtr Constructor(string identifier, Feature[] features, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier shapes:(NSArray<MGLShape *> * _Nonnull)shapes options:(NSDictionary<MGLShapeSourceOption,id> * _Nullable)options;
		[Export("initWithIdentifier:shapes:options:")]
		IntPtr Constructor(string identifier, Shape[] shapes, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// @property (copy, nonatomic) MGLShape * _Nullable shape;
		[NullAllowed, Export("shape", ArgumentSemantic.Copy)]
		Shape Shape { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable URL;
		[NullAllowed, Export("URL", ArgumentSemantic.Copy)]
		NSUrl URL { get; set; }
	}

	[Static]
	partial interface TileSourceOptionConstants
	{
		// extern const MGLTileSourceOption _Nonnull MGLTileSourceOptionTileSize;
		[Field("MGLTileSourceOptionTileSize", "__Internal")]
		NSString MGLTileSourceOptionTileSize { get; }
	}

	// @interface MGLRasterSource : MGLTileSource
	[BaseType(typeof(TileSource))]
	interface RasterSource
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier configurationURL:(NSURL * _Nonnull)configurationURL;
		[Export("initWithIdentifier:configurationURL:")]
		IntPtr Constructor(string identifier, NSUrl configurationURL);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier configurationURL:(NSURL * _Nonnull)configurationURL tileSize:(CGFloat)tileSize __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:configurationURL:tileSize:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, NSUrl configurationURL, nfloat tileSize);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier tileURLTemplates:(NSArray<NSString *> * _Nonnull)tileURLTemplates options:(NSDictionary<MGLTileSourceOption,id> * _Nullable)options __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:tileURLTemplates:options:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, string[] tileURLTemplates, [NullAllowed] NSDictionary<NSString, NSObject> options);
	}

	// @interface MGLTilePyramidOfflineRegion : NSObject <MGLOfflineRegion, NSSecureCoding, NSCopying>
	[BaseType(typeof(NSObject), Name = "MGLTilePyramidOfflineRegion")]
	[DisableDefaultCtor]
	interface TilePyramidOfflineRegion : OfflineRegion, INSSecureCoding, INSCopying
	{
		// @property (readonly, nonatomic) NSURL * _Nonnull styleURL;
		[Export("styleURL")]
		NSUrl StyleURL { get; }

		// @property (readonly, nonatomic) MGLCoordinateBounds bounds;
		[Export("bounds")]
		CoordinateBounds Bounds { get; }

		// @property (readonly, nonatomic) double minimumZoomLevel;
		[Export("minimumZoomLevel")]
		double MinimumZoomLevel { get; }

		// @property (readonly, nonatomic) double maximumZoomLevel;
		[Export("maximumZoomLevel")]
		double MaximumZoomLevel { get; }

		// -(instancetype _Nonnull)initWithStyleURL:(NSURL * _Nullable)styleURL bounds:(MGLCoordinateBounds)bounds fromZoomLevel:(double)minimumZoomLevel toZoomLevel:(double)maximumZoomLevel __attribute__((objc_designated_initializer));
		[Export("initWithStyleURL:bounds:fromZoomLevel:toZoomLevel:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] NSUrl styleURL, CoordinateBounds bounds, double minimumZoomLevel, double maximumZoomLevel);
	}

	// @interface MGLUserLocation : NSObject <MGLAnnotation, NSSecureCoding>
	[BaseType(typeof(NSObject))]
	interface UserLocation : IAnnotation, INSSecureCoding
	{
		// @property (readonly, nonatomic) CLLocation * _Nullable location;
		[NullAllowed, Export("location")]
		CLLocation Location { get; }

		// @property (readonly, getter = isUpdating, nonatomic) BOOL updating;
		[Export("updating")]
		bool Updating { [Bind("isUpdating")] get; }

		// @property (readonly, nonatomic) CLHeading * _Nullable heading;
		[NullAllowed, Export("heading")]
		CLHeading Heading { get; }

		// @property (copy, nonatomic) NSString * _Nonnull title;
		[Export("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable subtitle;
		[NullAllowed, Export("subtitle")]
		string Subtitle { get; set; }
	}

	// @interface MGLUserLocationAnnotationView : MGLAnnotationView
	[BaseType(typeof(AnnotationView))]
	interface UserLocationAnnotationView
	{
		// @property (readonly, nonatomic, weak) MGLMapView * _Nullable mapView;
		[NullAllowed, Export("mapView", ArgumentSemantic.Weak)]
		MapView MapView { get; }

		// @property (readonly, nonatomic, weak) MGLUserLocation * _Nullable userLocation;
		[NullAllowed, Export("userLocation", ArgumentSemantic.Weak)]
		UserLocation UserLocation { get; }

		// @property (readonly, nonatomic, weak) CALayer * _Nullable hitTestLayer;
		[NullAllowed, Export("hitTestLayer", ArgumentSemantic.Weak)]
		CALayer HitTestLayer { get; }

		// -(void)update;
		[Export("update")]
		void Update();
	}

	// @interface MGLAdditions (NSValue)
	[Category]
	[BaseType(typeof(NSValue))]
	interface NSValue_MGLAdditions
	{
		// +(instancetype _Nonnull)valueWithMGLCoordinate:(CLLocationCoordinate2D)coordinate;
		[Static]
		[Export("valueWithMGLCoordinate:")]
		NSValue ValueWithMGLCoordinate(CLLocationCoordinate2D coordinate);

		// @property (readonly) CLLocationCoordinate2D MGLCoordinateValue;
		[Static]
		[Export("MGLCoordinateValue")]
		CLLocationCoordinate2D MGLCoordinateValue { get; }

		// +(instancetype _Nonnull)valueWithMGLCoordinateSpan:(MGLCoordinateSpan)span;
		[Static]
		[Export("valueWithMGLCoordinateSpan:")]
		NSValue ValueWithMGLCoordinateSpan(CoordinateSpan span);

		// @property (readonly) MGLCoordinateSpan MGLCoordinateSpanValue;
		[Static]
		[Export("MGLCoordinateSpanValue")]
		CoordinateSpan CoordinateSpanValue { get; }

		// +(instancetype _Nonnull)valueWithMGLCoordinateBounds:(MGLCoordinateBounds)bounds;
		[Static]
		[Export("valueWithMGLCoordinateBounds:")]
		NSValue ValueWithMGLCoordinateBounds(CoordinateBounds bounds);

		// @property (readonly) MGLCoordinateBounds MGLCoordinateBoundsValue;
		[Static]
		[Export("MGLCoordinateBoundsValue")]
		CoordinateBounds CoordinateBoundsValue { get; }

		// +(NSValue * _Nonnull)valueWithMGLOfflinePackProgress:(MGLOfflinePackProgress)progress;
		[Static]
		[Export("valueWithMGLOfflinePackProgress:")]
		NSValue GetValue(OfflinePackProgress progress);

		// @property (readonly) MGLOfflinePackProgress MGLOfflinePackProgressValue;
		[Static]
		[Export("MGLOfflinePackProgressValue")]
		OfflinePackProgress OfflinePackProgressValue { get; }
	}

	// @interface MGLAttributionInfo : NSObject
	[BaseType(typeof(NSObject))]
	interface AttributionInfo
	{
		// -(instancetype _Nonnull)initWithTitle:(NSAttributedString * _Nonnull)title URL:(NSURL * _Nullable)URL;
		[Export("initWithTitle:URL:")]
		IntPtr Constructor(NSAttributedString title, [NullAllowed] NSUrl URL);

		// @property (nonatomic) NSAttributedString * _Nonnull title;
		[Export("title", ArgumentSemantic.Assign)]
		NSAttributedString Title { get; set; }

		// @property (nonatomic) NSURL * _Nullable URL;
		[NullAllowed, Export("URL", ArgumentSemantic.Assign)]
		NSUrl URL { get; set; }

		// @property (getter = isFeedbackLink, nonatomic) BOOL feedbackLink;
		[Export("feedbackLink")]
		bool FeedbackLink { [Bind("isFeedbackLink")] get; set; }

		// -(NSURL * _Nullable)feedbackURLAtCenterCoordinate:(CLLocationCoordinate2D)centerCoordinate zoomLevel:(double)zoomLevel;
		[Export("feedbackURLAtCenterCoordinate:zoomLevel:")]
		[return: NullAllowed]
		NSUrl FeedbackURLAtCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel);
	}
}
