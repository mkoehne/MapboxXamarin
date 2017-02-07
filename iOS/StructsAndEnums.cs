using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace Mapbox
{
	[Native]
	public enum AnnotationViewDragState : ulong
	{
		None = 0,
		Starting,
		Dragging,
		Canceling,
		Ending
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CoordinateSpan
	{
		public double latitudeDelta;

		public double longitudeDelta;
	}
	/*
	static class CFunctions
	{
		// CoordinateSpan CoordinateSpanMake (CLLocationDegrees latitudeDelta, CLLocationDegrees longitudeDelta) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern CoordinateSpan CoordinateSpanMake (double latitudeDelta, double longitudeDelta);

		// BOOL CoordinateSpanEqualToCoordinateSpan (CoordinateSpan span1, CoordinateSpan span2) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool CoordinateSpanEqualToCoordinateSpan (CoordinateSpan span1, CoordinateSpan span2);

		// CoordinateBounds CoordinateBoundsMake (CLLocationCoordinate2D sw, CLLocationCoordinate2D ne) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern CoordinateBounds CoordinateBoundsMake (CLLocationCoordinate2D sw, CLLocationCoordinate2D ne);

		// BOOL CoordinateBoundsEqualToCoordinateBounds (CoordinateBounds bounds1, CoordinateBounds bounds2) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool CoordinateBoundsEqualToCoordinateBounds (CoordinateBounds bounds1, CoordinateBounds bounds2);

		// BOOL CoordinateBoundsIntersectsCoordinateBounds (CoordinateBounds bounds1, CoordinateBounds bounds2) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool CoordinateBoundsIntersectsCoordinateBounds (CoordinateBounds bounds1, CoordinateBounds bounds2);

		// BOOL CoordinateInCoordinateBounds (CLLocationCoordinate2D coordinate, CoordinateBounds bounds) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool CoordinateInCoordinateBounds (CLLocationCoordinate2D coordinate, CoordinateBounds bounds);

		// CoordinateSpan CoordinateBoundsGetCoordinateSpan (CoordinateBounds bounds) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern CoordinateSpan CoordinateBoundsGetCoordinateSpan (CoordinateBounds bounds);

		// CoordinateBounds CoordinateBoundsOffset (CoordinateBounds bounds, CoordinateSpan offset) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern CoordinateBounds CoordinateBoundsOffset (CoordinateBounds bounds, CoordinateSpan offset);

		// BOOL CoordinateBoundsIsEmpty (CoordinateBounds bounds) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool CoordinateBoundsIsEmpty (CoordinateBounds bounds);

		// NSString * _Nonnull StringFromCoordinateBounds (CoordinateBounds bounds) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern NSString StringFromCoordinateBounds (CoordinateBounds bounds);

		// CGFloat RadiansFromDegrees (CLLocationDegrees degrees) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern nfloat RadiansFromDegrees (double degrees);

		// CLLocationDegrees DegreesFromRadians (CGFloat radians) __attribute__((always_inline));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern double DegreesFromRadians (nfloat radians);
	}
	*/

	[StructLayout (LayoutKind.Sequential)]
    public struct CoordinateBounds
    {
        public CLLocationCoordinate2D SouthWest;
        public CLLocationCoordinate2D NorthEast;
    }

	[Native]
	public enum ErrorCode : long
	{
		Unknown = -1,
		NotFound = 1,
		BadServerResponse = 2,
		ConnectionFailed = 3
	}

	[Native]
	public enum UserTrackingMode : ulong
	{
		None = 0,
		Follow,
		FollowWithHeading,
		FollowWithCourse
	}

	[Native]
	public enum MapDebugMaskOptions : ulong
	{
		TileBoundariesMask = 1 << 1,
		TileInfoMask = 1 << 2,
		TimestampsMask = 1 << 3,
		CollisionBoxesMask = 1 << 4,
		OverdrawVisualizationMask = 1 << 5
	}

	[Native]
	public enum AnnotationVerticalAlignment : ulong
	{
		Center = 0,
		Top,
		Bottom
	}

	[Native]
	public enum OfflinePackState : long
	{
		Unknown = 0,
		Inactive = 1,
		Active = 2,
		Complete = 3,
		Invalid = 4
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct OfflinePackProgress
	{
		public ulong countOfResourcesCompleted;

		public ulong countOfBytesCompleted;

		public ulong countOfTilesCompleted;

		public ulong countOfTileBytesCompleted;

		public ulong countOfResourcesExpected;

		public ulong maximumResourcesExpected;
	}

	[Native]
	public enum FillTranslationAnchor : ulong
	{
		Map,
		Viewport
	}

	[Native]
	public enum LineCap : ulong
	{
		Butt,
		Round,
		Square
	}

	[Native]
	public enum LineJoin : ulong
	{
		Bevel,
		Round,
		Miter
	}

	[Native]
	public enum LineTranslationAnchor : ulong
	{
		Map,
		Viewport
	}

	[Native]
	public enum IconRotationAlignment : ulong
	{
		Map,
		Viewport,
		Auto
	}

	[Native]
	public enum IconTextFit : ulong
	{
		None,
		Width,
		Height,
		Both
	}

	[Native]
	public enum SymbolPlacement : ulong
	{
		Point,
		Line
	}

	[Native]
	public enum TextAnchor : ulong
	{
		Center,
		Left,
		Right,
		Top,
		Bottom,
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight
	}

	[Native]
	public enum TextJustification : ulong
	{
		Left,
		Center,
		Right
	}

	[Native]
	public enum TextPitchAlignment : ulong
	{
		Map,
		Viewport,
		Auto
	}

	[Native]
	public enum TextRotationAlignment : ulong
	{
		Map,
		Viewport,
		Auto
	}

	[Native]
	public enum TextTransform : ulong
	{
		None,
		Uppercase,
		Lowercase
	}

	[Native]
	public enum IconTranslationAnchor : ulong
	{
		Map,
		Viewport
	}

	[Native]
	public enum TextTranslationAnchor : ulong
	{
		Map,
		Viewport
	}

	[Native]
	public enum CircleScaleAlignment : ulong
	{
		Map,
		Viewport
	}

	[Native]
	public enum CircleTranslationAnchor : ulong
	{
		Map,
		Viewport
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct StyleLayerDrawingContext
	{
		public CGSize size;

		public CLLocationCoordinate2D centerCoordinate;

		public double zoomLevel;

		public double direction;

		public nfloat pitch;
	}

	[Native]
	public enum TileCoordinateSystem : ulong
	{
		Xyz = 0,
		Tms
	}
}
