#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace TangScene {
	
	public static class ContourPolygonizationUtils
	{
		public static List<Contour> MergeInnerAndOuterContours( List<Contour> outerContours, List<Contour> innerContours )
		{
			// Step 0: Sort the contours by region and their max x-value
			outerContours.Sort( );
			innerContours.Sort( );
	
			// Step 1: Insert every inner contours to corresponding outer contours
			List<Contour> mergedContoursList = new List<Contour>( outerContours.Count );
			foreach( Contour rOuterContour in outerContours )
			{
				Contour rMergedContour = rOuterContour;
	
				// Loop over inner contours
				foreach( Contour rInnerContour in innerContours )
				{
					if( rInnerContour.Region == rMergedContour.Region )
					{
						// Insert inner contour into outer contour
						rMergedContour = PolygonTriangulationUtils.InsertInnerContourIntoOuterContour( rMergedContour, rInnerContour );
					}
					else if( rInnerContour.Region > rMergedContour.Region )	// inner contours are sorted by region...
					{
						break;	// ... so stop if inner contour region greater than outer contour region
					}
				}
	
				if( rMergedContour.Count > 2 )
				{
					mergedContoursList.Add( rMergedContour );
				}
			}
			return mergedContoursList;
		}
	
		public static List<Contour> SimplifyContours( List<Contour> outerContours, float a_fAccuracy )
		{
			List<Contour> oSimplifiedContoursList = new List<Contour>( outerContours.Count );
	
			foreach( Contour rOuterContour in outerContours )
			{
				// Simplify the new outer contour
				List<Vector2> oOuterContourVertices = new List<Vector2>( rOuterContour.Vertices );
	
				List<Vector2> oSimplifiedOuterContourVertices = RamerDouglasPeuker( oOuterContourVertices, 0, oOuterContourVertices.Count - 1, a_fAccuracy );
	
				if( oSimplifiedOuterContourVertices.Count > 2 )
				{	
					// Create the contour
					Contour oSimplifiedOuterContour = new Contour( rOuterContour.Region );
					oSimplifiedOuterContour.AddLast( oSimplifiedOuterContourVertices );
		
					// Add the contour to the list
					oSimplifiedContoursList.Add( oSimplifiedOuterContour );
				}
			}
	
			return oSimplifiedContoursList;
		}
	
		// The Douglas–Peucker algorithm is an algorithm for reducing the number of points in a curve that is approximated by a series of points.
		// The purpose of the algorithm is, given a curve composed of line segments, to find a similar curve with fewer points.
		// The algorithm defines 'dissimilar' based on the maximum distance between the original curve and the simplified curve.
		// The simplified curve consists of a subset of the points that defined the original curve.
		public static List<Vector2> RamerDouglasPeuker( List<Vector2> a_rContour, int a_iStartingPixelIndex, int a_iEndingPixelIndex, float a_fAccuracy )
		{
			// List of dominant vertices that define the original curve
			List<Vector2> oDominantContour = new List<Vector2>( );
	
			// Create a line from the first vertex to the last index
			Vector2 f2StartLineCoords = a_rContour[ a_iStartingPixelIndex ];
			Vector2 f2EndLineCoords   = a_rContour[ a_iEndingPixelIndex ];
	
			float fDistanceMax = 0.0f;
			int iDominantPixelIndex = -1;
	
			// Looking for a dominant point which is further than the threshold distance (epsilon)
			for( int iIndex = a_iStartingPixelIndex + 1; iIndex < a_iEndingPixelIndex; ++iIndex )
			{
				Vector2 f2ContourPointCoords = a_rContour[ iIndex ];
	
				float fDistance = HandleUtility.DistancePointToLine( f2ContourPointCoords, f2StartLineCoords, f2EndLineCoords );
	
				// New max distance to line
				if( fDistance > fDistanceMax )
				{
					fDistanceMax = fDistance;
					iDominantPixelIndex = iIndex;
				}
			}
	
			// Dominant point found?
			if( fDistanceMax > a_fAccuracy )
			{
				// Break the line in two at the dominant vertex and apply the algorithm recursively to these 2 segments.
				List<Vector2> rDominantContourLeft  = RamerDouglasPeuker( a_rContour, a_iStartingPixelIndex, iDominantPixelIndex, a_fAccuracy );
				List<Vector2> rDominantContourRight = RamerDouglasPeuker( a_rContour, iDominantPixelIndex, a_iEndingPixelIndex, a_fAccuracy );
	
				// Add the results
				oDominantContour.AddRange( rDominantContourLeft );
				oDominantContour.RemoveAt( oDominantContour.Count - 1 ); // Avoid duplication of end/start shared bound ( [1..iDominantIndex] U [iDominantIndex..End] )
				oDominantContour.AddRange( rDominantContourRight );
			}
			else
			{
				// No dominant point found -> only the two vertices of the line are really needed
				// to define this part of the curve.
				oDominantContour.Add( f2StartLineCoords );
				oDominantContour.Add( f2EndLineCoords );
			}
	
			return oDominantContour;
		}
	}
}
#endif