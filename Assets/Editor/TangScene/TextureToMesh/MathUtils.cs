using UnityEngine;
using System.Collections;

namespace TangScene {

	public static class MathUtils
	{
		// Computes camera Horizontal Field of View (in radians)
		public static float HorizontalFOV( Camera a_rCamera )
		{
			float fHalfVerticalFOV = a_rCamera.fieldOfView * 0.5f;
			float fTanVerticalFOV = Mathf.Tan( fHalfVerticalFOV * Mathf.Deg2Rad );
			
			return 2.0f * Mathf.Atan( a_rCamera.aspect * fTanVerticalFOV );
		}
	
		// Computes camera Horizontal Field of View (in degrees)
		public static float HorizontalFOVDeg( Camera a_rCamera )
		{
			return Mathf.Rad2Deg * HorizontalFOV( a_rCamera );
		}
	
		// Computes main camera Horizontal Field of view (in radians)
		public static float MainCameraHorizontalFOV( )
		{
			return HorizontalFOV( Camera.main );
		}
	
		// Computes main camera Horizontal Field of View (in degrees)
		public static float MainCameraHorizontalFOVDeg( )
		{
			return HorizontalFOVDeg( Camera.main );
		}
	
		// Computes the camera frustum width at a given distance
		public static float CameraFrustumWidthAtDistance( Camera a_rCamera, float a_fDistanceFromCamera )
		{
			// Computes size from D = length / tan( FOV / 2 ) formula
			// => length = D * tan( FOV / 2 )
			float fHorizontalFOV = 0.5f * HorizontalFOV( a_rCamera );
			float fTanHorizontalFOV = Mathf.Tan( fHorizontalFOV );
	
			// In this case, because we got length from pivot point, it's only the half-length of the mesh
			// So, we need to multiply by 2 to get the "full" length
			return 2.0f * fTanHorizontalFOV * a_fDistanceFromCamera;
		}
	
		// Computes the camera frustum height at a given distance
		public static float CameraFrustumHeightAtDistance( Camera a_rCamera, float a_fDistanceFromCamera )
		{
			// Computes size from D = length / tan( FOV / 2 ) formula
			// => length = D * tan( FOV / 2 )
			float fVerticalFOV = a_rCamera.fieldOfView * 0.5f;
			float fTanVerticalFOV = Mathf.Tan( Mathf.Deg2Rad * fVerticalFOV );
	
			// In this case, because we got length from pivot point, it's only the half-length of the mesh
			// So, we need to multiply by 2 to get the "full" length
			return 2.0f * fTanVerticalFOV * a_fDistanceFromCamera;	
		}
	
		// Computes the *main* camera frustrum height at a given distance
		public static float MainCameraFrustumHeightAtDistance( float a_fDistanceFromMainCamera )
		{
			return CameraFrustumHeightAtDistance( Camera.main, a_fDistanceFromMainCamera );	
		}
	
		// Computes the *main* camera frustum width at a given distance
		public static float MainCameraFrustumWidthAtDistance( float a_fDistanceFromMainCamera )
		{
			return CameraFrustumWidthAtDistance( Camera.main, a_fDistanceFromMainCamera );
		}
	
		// Computes the distance to camera from a frustum width
		public static float DistanceToCameraFromFrustumWidth( Camera a_rCamera, float a_fFrustumWidth )
		{
			float fHorizontalFOV = HorizontalFOV( a_rCamera ) * 0.5f;
			float fTanHorizontalFOV = Mathf.Tan( fHorizontalFOV );
			return a_fFrustumWidth / fTanHorizontalFOV;
		}
	
		// Computes the distance to camera from a frustum height
		public static float DistanceToCameraFromFrustumHeight( Camera a_rCamera, float a_fFrustumHeight )
		{
			float fVerticalFOV = a_rCamera.fieldOfView * 0.5f;
			float fTanVerticalFOV = Mathf.Tan( Mathf.Deg2Rad * fVerticalFOV );
			return a_fFrustumHeight / fTanVerticalFOV;
		}
	
		// Computes the distance to the *main* camera from a frustum width
		public static float DistanceToMainCameraFromFrustumWidth( float a_fFrustumWidth )
		{
			return DistanceToCameraFromFrustumWidth( Camera.main, a_fFrustumWidth );
		}
	
		// Computes the distance to the *main* camera from a frustum height
		public static float DistanceToMainCameraFromFrustumHeight( float a_fFrustumHeight )
		{
			return DistanceToCameraFromFrustumHeight( Camera.main, a_fFrustumHeight );
		}
	
		// Rounds the value a_fValue to the closest multiple of a_fSnap
		// a_fSnap *MUST* be positive.
		// Working version of Handles.SnapValue...
		public static float SnapValue( float a_fValue, float a_fSnap )
		{
			return a_fSnap * Mathf.Round( a_fValue / a_fSnap );
		}
	
		// Returns true if a_f3Point is inside the triangle ABC (in 2D). Vertices A, B & C must be ordered CCW
		// http://blogs.msdn.com/b/rezanour/archive/2011/08/07/barycentric-coordinates-and-point-in-triangle-tests.aspx
		public static bool IsPointInsideTriangle( Vector3 a_f3TriangleVertexA, Vector3 a_f3TriangleVertexB, Vector3 a_f3TriangleVertexC, Vector3 a_f3Point )
		{
			Vector3 f3U = a_f3TriangleVertexB - a_f3TriangleVertexA;
			Vector3 f3V = a_f3TriangleVertexC - a_f3TriangleVertexA;
			Vector3 f3W = a_f3Point - a_f3TriangleVertexA;
	
			Vector3 f3CrossVW = Vector3.Cross( f3V, f3W );
			Vector3 f3CrossVU = Vector3.Cross( f3V, f3U );
	
			if( Vector3.Dot( f3CrossVW, f3CrossVU ) < 0.0f )
			{
				return false;
			}
	
			Vector3 f3CrossUW = Vector3.Cross( f3U, f3W );
			Vector3 f3CrossUV = Vector3.Cross( f3U, f3V );
	
			if( Vector3.Dot( f3CrossUW, f3CrossUV ) < 0.0f )
			{
				return false;
			}
	
			float fInvDenom = 1.0f / f3CrossUV.magnitude;
			float fR = f3CrossVW.magnitude * fInvDenom;
			float fT = f3CrossUW.magnitude * fInvDenom;
	
			return ( fR <= 1.0f && fT <= 1.0f && fR + fT <= 1.0f );
		}
	
		// Returns true if a 2D ray intersects a 2D segment defined by a_f2SegmentStart and a_f2SegmentEnd
		// The T factor is returned into a_fRayHitT var
		public static bool Raycast2DSegment( Ray a_rRay, Vector2 a_f2SegmentStart, Vector2 a_f2SegmentEnd, out float a_fRayHitDistance )
		{
			// Vector orthogonal to ray direction vector
			Vector2 f2PerpRay = PerpVector2( a_rRay.direction );
	
			// Vector orthogonal to segment vector
			Vector2 f2PerpSegment = PerpVector2( a_f2SegmentEnd - a_f2SegmentStart );
	
			// Dot product between the 2 previously created vector
			float fDotPerpSegmentRayDirection = Vector2.Dot( f2PerpSegment, a_rRay.direction );
	
			// Ray( T ) default value...
			a_fRayHitDistance = 0.0f;
	
			// Vector3->Vector2
			Vector2 f2RayOrigin = new Vector2( a_rRay.origin.x, a_rRay.origin.y );
	
			// If not parallel...
			if( Mathf.Approximately( fDotPerpSegmentRayDirection, 0.0f ) == false )
			{
				float fS = Vector2.Dot( f2PerpSegment, a_f2SegmentStart - f2RayOrigin ) / fDotPerpSegmentRayDirection;
				float fT = Vector2.Dot( f2PerpRay, a_f2SegmentStart - f2RayOrigin ) / fDotPerpSegmentRayDirection;
	
				// If belongs to segment ( 0 <= T <= 1 ) and in ray forward direction ( 0 <= S )
				if( 0.0f <= fT && fT <= 1.0f && 0.0f <= fS )
				{
					a_fRayHitDistance = fS;
					return true;
				}
				return false;
			}
			return false;
		}
	
		// Returns an orthogonal Vector2 to the specified Vector2
		public static Vector2 PerpVector2( Vector2 a_f2Vector )
		{
			return new Vector2( a_f2Vector.y, - a_f2Vector.x );
		}
	
		// Returns an orthogonal Vector2 to the specified Vector3 (z-value dismissed)
		public static Vector2 PerpVector2( Vector3 a_f3Vector )
		{
			return new Vector2( a_f3Vector.y, - a_f3Vector.x );
		}
	
		// Returns the distance between a point and a line segment (described by a beginning and an ending)
		public static float DistancePointToLineSegment( Vector3 a_f3Point, Vector3 a_f3SegmentBeginning, Vector3 a_f3SegmentEnding )
		{
			Vector3 f3SegmentDirection = Vector3.Normalize( a_f3SegmentEnding - a_f3SegmentBeginning );
			Vector3 f3BeginningToPoint = a_f3Point - a_f3SegmentBeginning;
			Vector3 f3EndingToPoint    = a_f3Point - a_f3SegmentEnding;
	
			float fBeginningDot = Vector3.Dot( f3BeginningToPoint, f3SegmentDirection );
			float fEndingDot    = Vector3.Dot( f3EndingToPoint, f3SegmentDirection );
	
			// Between end and start => distance to segment
			if( 0.0f <= fBeginningDot && fEndingDot <= 0.0f )
			{
				return ( f3BeginningToPoint - fBeginningDot * f3SegmentDirection ).magnitude;
			}
			else if( 0.0f > fBeginningDot )	// Distance to segment beginning
			{
				return Vector3.Distance( a_f3Point, a_f3SegmentBeginning );
			}
			else // Distance to segment ending
			{
				return Vector3.Distance( a_f3Point, a_f3SegmentEnding );
			}
		}
	
	}
}