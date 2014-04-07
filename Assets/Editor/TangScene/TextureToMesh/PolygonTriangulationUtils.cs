#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TangScene
{
  public static class PolygonTriangulationUtils
  {
    // Returns a flat 3D polygonized mesh from 2D outer/inner contours
    public static Mesh PolygonizeContours( List<Contour> a_rDominantContoursList, float a_fScale, Vector3 a_f3PivotPoint, float a_fWidth, float a_fHeight )
    {
      // The mesh to build
      Mesh oCombinedMesh = new Mesh( );

      int iContourCount = a_rDominantContoursList.Count; //a_rDominantContoursList.Count;

      // Step 2: Ear clip outer contour
      CombineInstance[ ] oCombineMeshInstance = new CombineInstance[ iContourCount ];

      for( int iContourIndex = 0; iContourIndex < iContourCount; ++iContourIndex )
	{
	  Vector3[ ] oVerticesArray;
	  int[ ] oTrianglesArray;
	  Vector2[ ] oUVs;
	  Mesh oSubMesh = new Mesh( );

	  EarClipping( a_rDominantContoursList[ iContourIndex ], a_fScale, a_f3PivotPoint, a_fWidth, a_fHeight, out oVerticesArray, out oTrianglesArray, out oUVs );
				
	  Vector3[] vertices = new Vector3[oVerticesArray.Length];
	  for( int index = 0; index < vertices.Length; index++ ){
	    Vector3 ov3 = oVerticesArray[index];
	    vertices[index] = new Vector3(ov3.x, 0F, ov3.y);
	  }
			
	  // oSubMesh.vertices  = oVerticesArray;
	  oSubMesh.vertices  = vertices;
	  oSubMesh.uv        = oUVs;
	  oSubMesh.triangles = oTrianglesArray;
	
	  oCombineMeshInstance[ iContourIndex ].mesh = oSubMesh;
	}

      // Step 3: Combine every sub meshes (merge, no transform)
      oCombinedMesh.CombineMeshes( oCombineMeshInstance, true, false );

      // Return!
      return oCombinedMesh;		
    }
		
    public static Mesh PolygonizeGrid ( PaddedImage paddedImage, float scale, 
					Vector3 pivotCoords, int horizontalSubDivs, int verticalSubDivs )
    {

      // Texture dimensions
      int textureWidth  = paddedImage.SpriteWidth;
      int textureHeight = paddedImage.SpriteHeight;

      int gridSubDivPerRow    = horizontalSubDivs;
      int gridSubDivPerColumn = verticalSubDivs;
      int gridSubDivCount     = gridSubDivPerRow * gridSubDivPerColumn;

      int gridVertexCount = ( horizontalSubDivs + 1 ) * ( verticalSubDivs + 1 );
		
      // Grid div dimensions
      float gridSubDivPixelWidth  = ( (float) textureWidth  ) / (float) gridSubDivPerRow;
      float gridSubDivPixelHeight = ( (float) textureHeight ) / (float) gridSubDivPerColumn;

      // Also store these values as ints
      int intGridSubDivPixelWidth  = Mathf.FloorToInt( gridSubDivPixelWidth );
      int intGridSubDivPixelHeight = Mathf.FloorToInt( gridSubDivPixelHeight );

      // Vertex pos -> index dictionary: stores the index associated to a given vertex
      int currentVertexIndex = 0;
      Dictionary<Vector3,int> vertexPosIndexDict = new Dictionary<Vector3, int>( gridVertexCount );

      // Mesh data
      List<int> gridPlaneTriangleList = new List<int>( 6 * gridVertexCount );	// quad = 2 tris, 1 tri = 3 vertices => 2 * 3

      // Iterate grid divs
      for( int gridSubDivIndex = 0; gridSubDivIndex < gridSubDivCount; gridSubDivIndex++ )
	{
	  // ( X, Y ) grid div pos from grid div index (in grid div space)
	  int gridSubDivX = gridSubDivIndex % gridSubDivPerRow;
	  int gridSubDivY = gridSubDivIndex / gridSubDivPerRow;

	  // Set grid sub div as empty while no significant pixel found
	  bool emptyGridSubDiv = true;
	  for( int y = 0, yLimit = intGridSubDivPixelHeight; emptyGridSubDiv && y < yLimit; y++ )
	    {
	      for( int x = 0, xLimit = intGridSubDivPixelWidth; emptyGridSubDiv && x < xLimit; x++ )
		{
		  int pixelIndex = paddedImage.SpriteCoords2PixelIndex( 
								       x + Mathf.FloorToInt( gridSubDivX * gridSubDivPixelWidth ), 
								       y + Mathf.FloorToInt( gridSubDivY * gridSubDivPixelHeight ) );

		  // At least one pixel is significant => need to create the whole grid div
		  if( paddedImage[ pixelIndex ] )
		    {
		      /*
		       * Grid div
		       * 
		       *	       ...       ...
		       *	        |         |
		       *	... --- TL ------- TR --- ...
		       *	        |   T2  / |
		       *	        |     /   |
		       *	        |   /     |
		       *	        | /   T1  |
		       *	... --- BL ------- BR --- ...
		       * 	        |         |
		       * 	       ...       ...
		       */
		      Vector3 bottomLeftVertex  = new Vector3(         gridSubDivX * gridSubDivPixelWidth,         gridSubDivY * gridSubDivPixelHeight, 0.0f );	// BL
		      Vector3 bottomRightVertex = new Vector3( ( gridSubDivX + 1 ) * gridSubDivPixelWidth,         gridSubDivY * gridSubDivPixelHeight, 0.0f );	// BR
		      Vector3 topRightVertex    = new Vector3( ( gridSubDivX + 1 ) * gridSubDivPixelWidth, ( gridSubDivY + 1 ) * gridSubDivPixelHeight, 0.0f );	// TR
		      Vector3 topLeftVertex     = new Vector3(         gridSubDivX * gridSubDivPixelWidth, ( gridSubDivY + 1 ) * gridSubDivPixelHeight, 0.0f );	// TL
						
		      int bottomLeftVertexIndex;
		      int bottomRightVertexIndex;
		      int topRightVertexIndex;
		      int topLeftVertexIndex;
						
		      // For each grid div vertex, query its index if already created (the vertex might be shared with other grid divs).
		      // If not, create it.
		      if( vertexPosIndexDict.TryGetValue( bottomLeftVertex, out bottomLeftVertexIndex ) == false )
			{
			  bottomLeftVertexIndex = currentVertexIndex++;
			  vertexPosIndexDict.Add( bottomLeftVertex, bottomLeftVertexIndex );
			}
						
		      if( vertexPosIndexDict.TryGetValue( bottomRightVertex, out bottomRightVertexIndex ) == false )
			{
			  bottomRightVertexIndex = currentVertexIndex++;
			  vertexPosIndexDict.Add( bottomRightVertex, bottomRightVertexIndex );
			}
						
		      if( vertexPosIndexDict.TryGetValue( topRightVertex, out topRightVertexIndex ) == false )
			{
			  topRightVertexIndex = currentVertexIndex++;
			  vertexPosIndexDict.Add( topRightVertex, topRightVertexIndex );
			}
						
		      if( vertexPosIndexDict.TryGetValue( topLeftVertex, out topLeftVertexIndex ) == false )
			{
			  topLeftVertexIndex = currentVertexIndex++;
			  vertexPosIndexDict.Add( topLeftVertex, topLeftVertexIndex );
			}
						
		      // Create grid div triangles
		      // First triangle (T1)
		      gridPlaneTriangleList.Add( bottomRightVertexIndex );	// BR
		      gridPlaneTriangleList.Add( bottomLeftVertexIndex );	// BL
		      gridPlaneTriangleList.Add( topRightVertexIndex );		// TR
						
		      // Second triangle (T2)
		      gridPlaneTriangleList.Add( bottomLeftVertexIndex );	// BL
		      gridPlaneTriangleList.Add( topLeftVertexIndex );		// TL
		      gridPlaneTriangleList.Add( topRightVertexIndex );		// TR

		      // Set grid sub div as not empty
		      emptyGridSubDiv = false;
		    }
		}
	    }
	}

      // Apply pivot + compute UVs
      int vertexCount = vertexPosIndexDict.Count;
      Vector2[ ] gridPlaneUVs      = new Vector2[ vertexCount ];
      Vector3[ ] gridPlaneVertices = new Vector3[ vertexCount ];
      Vector2 dimensions          = new Vector2( 1.0f / (float) textureWidth, 1.0f / (float) textureHeight );

      foreach( KeyValuePair<Vector3,int> vertexPosIndexPair in vertexPosIndexDict )
	{
	  Vector3 vertexPos = vertexPosIndexPair.Key;
	  int index = vertexPosIndexPair.Value;

	  gridPlaneUVs[ index ]      = new Vector2( vertexPos.x * dimensions.x, vertexPos.y * dimensions.y );
	  gridPlaneVertices[ index ] = ( vertexPos - pivotCoords ) * scale;
	}
			
			
      Mesh mesh = new Mesh( );
		
      Vector3[] vertices = new Vector3[gridPlaneVertices.Length];
      for( int index = 0; index < vertices.Length; index++ ){
	Vector3 ov3 = gridPlaneVertices[index];
	vertices[index] = new Vector3(ov3.x, 0F, ov3.y);
      }
      mesh.vertices  = vertices;
			
      //mesh.vertices  = gridPlaneVertices;	
      mesh.uv        = gridPlaneUVs;
      mesh.triangles = gridPlaneTriangleList.ToArray( );	// LINQ

      return mesh;

      
    }
		
		
    // Finds a pair of inner contour vertex / outer contour vertex that are mutually visible
    public static Contour InsertInnerContourIntoOuterContour( Contour a_rOuterContour, Contour a_rInnerContour )
    {
      // Look for the inner vertex of maximum x-value
      Vector2 f2InnerContourVertexMax = Vector2.one * int.MinValue;
      CircularLinkedListNode<Vector2> rMutualVisibleInnerContourVertexNode = null;

      CircularLinkedList<Vector2> rInnerContourVertexList = a_rInnerContour.Vertices;
      CircularLinkedListNode<Vector2> rInnerContourVertexNode = rInnerContourVertexList.First;
		
      do
	{
	  // x-value
	  Vector2 f2InnerContourVertex = rInnerContourVertexNode.Value;

	  // New max x found
	  if( f2InnerContourVertexMax.x < f2InnerContourVertex.x )
	    {
	      f2InnerContourVertexMax = f2InnerContourVertex;
	      rMutualVisibleInnerContourVertexNode = rInnerContourVertexNode;
	    }

	  // Go to next vertex
	  rInnerContourVertexNode = rInnerContourVertexNode.Next;
	}
      while( rInnerContourVertexNode != rInnerContourVertexList.First );

      // Visibility ray
      Ray oInnerVertexVisibilityRay = new Ray( f2InnerContourVertexMax, Vector3.right );
      float fClosestDistance = int.MaxValue;
      Vector2 f2ClosestOuterEdgeStart = Vector2.zero;
      Vector2 f2ClosestOuterEdgeEnd = Vector2.zero;

      Contour rOuterCutContour = new Contour( a_rOuterContour.Region );
      rOuterCutContour.AddLast( a_rOuterContour.Vertices );

      CircularLinkedList<Vector2> rOuterCutContourVertexList = rOuterCutContour.Vertices;
      CircularLinkedListNode<Vector2> rOuterContourVertexEdgeStart = null;

      // Raycast from the inner contour vertex to every edge
      CircularLinkedListNode<Vector2> rOuterContourVertexNode = rOuterCutContourVertexList.First;
      do
	{
	  // Construct outer edge from current and next outer contour vertices
	  Vector2 f2OuterEdgeStart = rOuterContourVertexNode.Value;
	  Vector2 f2OuterEdgeEnd = rOuterContourVertexNode.Next.Value;
	  Vector2 f2OuterEdge = f2OuterEdgeEnd - f2OuterEdgeStart;

	  // Orthogonal vector to edge (pointing to polygon interior)
	  Vector2 f2OuterEdgeNormal = MathUtils.PerpVector2( f2OuterEdge );

	  // Vector from edge start to inner vertex
	  Vector2 f2OuterEdgeStartToInnerVertex = f2InnerContourVertexMax - f2OuterEdgeStart;

	  // If the inner vertex is on the left of the edge (interior),
	  // test if there's any intersection
	  if( Vector2.Dot( f2OuterEdgeStartToInnerVertex, f2OuterEdgeNormal ) >= 0.0f )
	    {
	      float fDistanceT;

	      // If visibility intersects outer edge... 
	      if( MathUtils.Raycast2DSegment( oInnerVertexVisibilityRay, f2OuterEdgeStart, f2OuterEdgeEnd, out fDistanceT ) == true )
		{
		  // Is it the closest intersection we found?
		  if( fClosestDistance > fDistanceT )
		    {
		      fClosestDistance = fDistanceT;
		      rOuterContourVertexEdgeStart = rOuterContourVertexNode;

		      f2ClosestOuterEdgeStart = f2OuterEdgeStart;
		      f2ClosestOuterEdgeEnd = f2OuterEdgeEnd;
		    }
		}
	    }

	  // Go to next edge
	  rOuterContourVertexNode = rOuterContourVertexNode.Next;
	}
      while( rOuterContourVertexNode != rOuterCutContourVertexList.First );

      // Take the vertex of maximum x-value from the closest intersected edge
      Vector2 f2ClosestVisibleOuterContourVertex;
      CircularLinkedListNode<Vector2> rMutualVisibleOuterContourVertexNode;
      if( f2ClosestOuterEdgeStart.x < f2ClosestOuterEdgeEnd.x )
	{
	  f2ClosestVisibleOuterContourVertex = f2ClosestOuterEdgeEnd;
	  rMutualVisibleOuterContourVertexNode = rOuterContourVertexEdgeStart.Next;
	}
      else
	{
	  f2ClosestVisibleOuterContourVertex = f2ClosestOuterEdgeStart;
	  rMutualVisibleOuterContourVertexNode = rOuterContourVertexEdgeStart;
	}

      // Looking for points inside the triangle defined by inner vertex, intersection point an closest outer vertex
      // If a point is inside this triangle, at least one is a reflex vertex
      // The closest reflex vertex which minimises the angle this-vertex/inner vertex/intersection vertex
      // would be choosen as the mutual visible vertex
      Vector3 f3IntersectionPoint = oInnerVertexVisibilityRay.GetPoint( fClosestDistance );
      Vector2 f2InnerContourVertexToIntersectionPoint = new Vector2( f3IntersectionPoint.x, f3IntersectionPoint.y ) - f2InnerContourVertexMax;
      Vector2 f2NormalizedInnerContourVertexToIntersectionPoint = f2InnerContourVertexToIntersectionPoint.normalized;

      float fMaxDotAngle = float.MinValue;
      float fMinDistance = float.MaxValue;
      rOuterContourVertexNode = rOuterCutContourVertexList.First;
      do
	{
	  Vector2 f2OuterContourVertex = rOuterContourVertexNode.Value;

	  // if vertex not part of triangle
	  if( f2OuterContourVertex != f2ClosestVisibleOuterContourVertex )
	    {
	      // if vertex is inside triangle...
	      if( MathUtils.IsPointInsideTriangle( f2InnerContourVertexMax, f3IntersectionPoint, f2ClosestVisibleOuterContourVertex, f2OuterContourVertex ) == true )
		{
		  // if vertex is reflex
		  Vector2 f2PreviousOuterContourVertex = rOuterContourVertexNode.Previous.Value;
		  Vector2 f2NextOuterContourVertex = rOuterContourVertexNode.Next.Value;
	
		  if( IsReflexVertex( f2OuterContourVertex, f2PreviousOuterContourVertex, f2NextOuterContourVertex ) == true )
		    {
		      // Use dot product as distance
		      Vector2 f2InnerContourVertexToReflexVertex = f2OuterContourVertex - f2InnerContourVertexMax;

		      // INFO: f2NormalizedInnerContourVertexToIntersectionPoint == Vector3.right (if everything is right)
		      float fDistance = Vector2.Dot( f2NormalizedInnerContourVertexToIntersectionPoint, f2InnerContourVertexToReflexVertex );
		      float fDotAngle = Vector2.Dot( f2NormalizedInnerContourVertexToIntersectionPoint, f2InnerContourVertexToReflexVertex.normalized );

		      // New mutual visible vertex if angle smaller (e.g. dot angle larger) than min or equal and closer
		      if( fDotAngle > fMaxDotAngle || ( fDotAngle == fMaxDotAngle && fDistance < fMinDistance ) )
			{
			  fMaxDotAngle = fDotAngle;
			  fMinDistance = fDistance;
			  rMutualVisibleOuterContourVertexNode = rOuterContourVertexNode;
			}
		    }
		}
	    }

	  // Go to next vertex
	  rOuterContourVertexNode = rOuterContourVertexNode.Next;
	}
      while( rOuterContourVertexNode != rOuterCutContourVertexList.First );

      // Insert now the cut into the polygon
      // The cut starts from the outer contour mutual visible vertex to the inner vertex
      CircularLinkedListNode<Vector2> rOuterContourVertexNodeToInsertBefore = rMutualVisibleOuterContourVertexNode.Next;

      // Loop over the inner contour starting from the inner contour vertex...
      rInnerContourVertexNode = rMutualVisibleInnerContourVertexNode;
      do
	{
	  // ... add the inner contour vertex before the outer contour vertex after the cut
	  rOuterCutContourVertexList.AddBefore( rOuterContourVertexNodeToInsertBefore, rInnerContourVertexNode.Value );
	  rInnerContourVertexNode = rInnerContourVertexNode.Next;
	}
      while( rInnerContourVertexNode != rMutualVisibleInnerContourVertexNode );

      // Close the cut by doubling the inner and outer contour vertices
      rOuterCutContourVertexList.AddBefore( rOuterContourVertexNodeToInsertBefore, rMutualVisibleInnerContourVertexNode.Value );
      rOuterCutContourVertexList.AddBefore( rOuterContourVertexNodeToInsertBefore, rMutualVisibleOuterContourVertexNode.Value );

      return rOuterCutContour;
    }
		
		
    // Returns true if the vertex I is a reflex vertex, i.e. the angle JÎH is >= 180°
    private static bool IsReflexVertex( Vector3 a_f3VertexI, Vector3 a_f3VertexJ, Vector3 a_f3VertexH )
    {
      Vector3 f3SegmentJI = a_f3VertexI - a_f3VertexJ;
      Vector3 f3SegmentIH = a_f3VertexH - a_f3VertexI;
      Vector3 f3JINormal  = new Vector3( f3SegmentJI.y, - f3SegmentJI.x, 0 );

      return Vector3.Dot( f3SegmentIH, f3JINormal ) < 0.0f;
    }
		
		
    // Returns a polygonized mesh from a 2D outer contour
    private static void EarClipping( Contour a_rDominantOuterContour, float a_fScale, Vector3 a_f3PivotPoint, float a_fWidth, float a_fHeight, out Vector3[ ] a_rVerticesArray, out int[ ] a_rTrianglesArray, out Vector2[ ] a_rUVs )
    {
      // Sum of all contours count
      int iVerticesCount = a_rDominantOuterContour.Count;

      // Mesh vertices array
      a_rVerticesArray = new Vector3[ iVerticesCount ];

      // Mesh UVs array
      a_rUVs           = new Vector2[ iVerticesCount ];

      // Vertex indexes lists array (used by ear clipping algorithm)
      CircularLinkedList<int> oVertexIndexesList = new CircularLinkedList<int>( );

      // Build contour vertex index circular list
      // Store every Vector3 into mesh vertices array
      // Store corresponding index into the circular list
      int iVertexIndex = 0;
      foreach( Vector2 f2OuterContourVertex in a_rDominantOuterContour.Vertices )
	{
	  a_rVerticesArray[ iVertexIndex ] = f2OuterContourVertex;
	  oVertexIndexesList.AddLast( iVertexIndex );

	  ++iVertexIndex;
	}

      // Build reflex/convex vertices lists
      LinkedList<int> rReflexVertexIndexesList;
      LinkedList<int> rConvexVertexIndexesList;
      BuildReflexConvexVertexIndexesLists( a_rVerticesArray, oVertexIndexesList, out rReflexVertexIndexesList, out rConvexVertexIndexesList );

      // Triangles for this contour
      List<int> oTrianglesList = new List<int>( 3 * iVerticesCount );

      // Build ear tips list
      CircularLinkedList<int> rEarTipVertexIndexesList = BuildEarTipVerticesList( a_rVerticesArray, oVertexIndexesList, rReflexVertexIndexesList, rConvexVertexIndexesList );

      // Remove the ear tips one by one!
      while( rEarTipVertexIndexesList.Count > 0 && oVertexIndexesList.Count > 2 )
	{

	  CircularLinkedListNode<int> rEarTipNode = rEarTipVertexIndexesList.First;

	  // Ear tip index
	  int iEarTipVertexIndex = rEarTipNode.Value;

	  // Ear vertex indexes
	  CircularLinkedListNode<int> rContourVertexNode                 = oVertexIndexesList.Find( iEarTipVertexIndex );
	  CircularLinkedListNode<int> rPreviousAdjacentContourVertexNode = rContourVertexNode.Previous;
	  CircularLinkedListNode<int> rNextAdjacentContourVertexNode     = rContourVertexNode.Next;

	  int iPreviousAjdacentContourVertexIndex = rPreviousAdjacentContourVertexNode.Value;
	  int iNextAdjacentContourVertexIndex     = rNextAdjacentContourVertexNode.Value;
		
	  // Add the ear triangle to our triangles list
	  oTrianglesList.Add( iPreviousAjdacentContourVertexIndex );
	  oTrianglesList.Add( iEarTipVertexIndex );
	  oTrianglesList.Add( iNextAdjacentContourVertexIndex );

	  // Remove the ear tip from vertices / convex / ear lists
	  oVertexIndexesList.Remove( iEarTipVertexIndex );
	  rConvexVertexIndexesList.Remove( iEarTipVertexIndex );

	  // Adjacent n-1 vertex
	  // if was convex => remain convex, can possibly an ear
	  // if was an ear => can possibly not remain an ear
	  // if was reflex => can possibly convex and possibly an ear
	  if( rReflexVertexIndexesList.Contains( iPreviousAjdacentContourVertexIndex ) )
	    {
	      CircularLinkedListNode<int> rPreviousPreviousAdjacentContourVertexNode = rPreviousAdjacentContourVertexNode.Previous;

	      Vector3 f3AdjacentContourVertex         = a_rVerticesArray[ rPreviousAdjacentContourVertexNode.Value ];
	      Vector3 f3PreviousAdjacentContourVertex = a_rVerticesArray[ rPreviousPreviousAdjacentContourVertexNode.Value ];
	      Vector3 f3NextAdjacentContourVertex     = a_rVerticesArray[ rPreviousAdjacentContourVertexNode.Next.Value ];

	      if( IsReflexVertex( f3AdjacentContourVertex, f3PreviousAdjacentContourVertex, f3NextAdjacentContourVertex ) == false )
		{
		  rReflexVertexIndexesList.Remove( iPreviousAjdacentContourVertexIndex );
		  rConvexVertexIndexesList.AddFirst( iPreviousAjdacentContourVertexIndex );
		}
	    }

	  // Adjacent n+1 vertex
	  // if was convex => remain convex, can possibly an ear
	  // if was an ear => can possibly not remain an ear
	  // if was reflex => can possibly convex and possibly an ear
	  if( rReflexVertexIndexesList.Contains( iNextAdjacentContourVertexIndex ) )
	    {
	      CircularLinkedListNode<int> rNextNextAdjacentContourVertexNode = rNextAdjacentContourVertexNode.Next;

	      Vector3 f3AdjacentContourVertex         = a_rVerticesArray[ rNextAdjacentContourVertexNode.Value ];
	      Vector3 f3PreviousAdjacentContourVertex = a_rVerticesArray[ rNextAdjacentContourVertexNode.Previous.Value ];
	      Vector3 f3NextAdjacentContourVertex     = a_rVerticesArray[ rNextNextAdjacentContourVertexNode.Value ];

	      if( IsReflexVertex( f3AdjacentContourVertex, f3PreviousAdjacentContourVertex, f3NextAdjacentContourVertex ) == false )
		{
		  rReflexVertexIndexesList.Remove( iNextAdjacentContourVertexIndex );
		  rConvexVertexIndexesList.AddFirst( iNextAdjacentContourVertexIndex );
		}
	    }

	  if( rConvexVertexIndexesList.Contains( iPreviousAjdacentContourVertexIndex ) )
	    {
	      if( IsEarTip( a_rVerticesArray, iPreviousAjdacentContourVertexIndex, oVertexIndexesList, rReflexVertexIndexesList ) )
		{
		  if( rEarTipVertexIndexesList.Contains( iPreviousAjdacentContourVertexIndex ) == false )
		    {
		      rEarTipVertexIndexesList.AddLast( iPreviousAjdacentContourVertexIndex );
		    }
		}
	      else
		{
		  rEarTipVertexIndexesList.Remove( iPreviousAjdacentContourVertexIndex );
		}
	    }

	  if( rConvexVertexIndexesList.Contains( iNextAdjacentContourVertexIndex ) )
	    {
	      if( IsEarTip( a_rVerticesArray, iNextAdjacentContourVertexIndex, oVertexIndexesList, rReflexVertexIndexesList ) )
		{
		  if( rEarTipVertexIndexesList.Contains( iNextAdjacentContourVertexIndex ) == false )
		    {
		      rEarTipVertexIndexesList.AddFirst( iNextAdjacentContourVertexIndex );
		    }
		}
	      else
		{
		  rEarTipVertexIndexesList.Remove( iNextAdjacentContourVertexIndex );
		}
	    }

	  rEarTipVertexIndexesList.Remove( iEarTipVertexIndex );
	}

      // Create UVs, rescale vertices, apply pivot
      Vector2 f2Dimensions = new Vector2( 1.0f / a_fWidth, 1.0f / a_fHeight );
      for( iVertexIndex = 0; iVertexIndex < iVerticesCount; ++iVertexIndex )
	{
	  Vector3 f3VertexPos = a_rVerticesArray[ iVertexIndex ];

	  //a_rUVs[ iVertexIndex ] = Vector2.Scale( f3VertexPos, f2Dimensions );
	  a_rUVs[ iVertexIndex ]           = new Vector2( f3VertexPos.x * f2Dimensions.x, f3VertexPos.y * f2Dimensions.y );
	  a_rVerticesArray[ iVertexIndex ] = ( f3VertexPos - a_f3PivotPoint ) * a_fScale;
	}

      a_rTrianglesArray = oTrianglesList.ToArray( );
    }
		
    // Builds indexes lists of reflex and convex vertex
    private static void BuildReflexConvexVertexIndexesLists( Vector3[ ] a_rContourVerticesArray, CircularLinkedList<int> a_rContourVertexIndexesList, out LinkedList<int> a_rReflexVertexIndexesList, out LinkedList<int> a_rConvexVertexIndexesList )
    {
      LinkedList<int> oReflexVertexIndexesList = new LinkedList<int>( );
      LinkedList<int> oConvexVertexIndexesList = new LinkedList<int>( );

      // Iterate contour vertices
      CircularLinkedListNode<int> rContourNode = a_rContourVertexIndexesList.First;
      do
	{
	  int iContourVertexIndex         = rContourNode.Value;
	  Vector3 f3ContourVertex         = a_rContourVerticesArray[ iContourVertexIndex ];
	  Vector3 f3PreviousContourVertex = a_rContourVerticesArray[ rContourNode.Previous.Value ];
	  Vector3 f3NextContourVertex     = a_rContourVerticesArray[ rContourNode.Next.Value ];

	  // Sorting reflex / convex vertices
	  // Reflex vertex forms a triangle with an angle >= 180°
	  if( IsReflexVertex( f3ContourVertex, f3PreviousContourVertex, f3NextContourVertex ) == true )
	    {
	      oReflexVertexIndexesList.AddLast( iContourVertexIndex );
	    }
	  else // angle < 180° => Convex vertex
	    {
	      oConvexVertexIndexesList.AddLast( iContourVertexIndex );
	    }

	  rContourNode = rContourNode.Next;
	}
      while( rContourNode != a_rContourVertexIndexesList.First );

      // Transmit results
      a_rReflexVertexIndexesList = oReflexVertexIndexesList;
      a_rConvexVertexIndexesList = oConvexVertexIndexesList;
    }
		
    // Builds and return a list of vertex indexes that are ear tips.
    private static CircularLinkedList<int> BuildEarTipVerticesList( Vector3[ ] a_rMeshVertices, CircularLinkedList<int> a_rOuterContourVertexIndexesList, LinkedList<int> a_rReflexVertexIndexesList, LinkedList<int> a_rConvexVertexIndexesList )
    {
      CircularLinkedList<int> oEarTipVertexIndexesList = new CircularLinkedList<int>( );

      // Iterate convex vertices
      for( LinkedListNode<int> rConvexIndexNode = a_rConvexVertexIndexesList.First; rConvexIndexNode != null; rConvexIndexNode = rConvexIndexNode.Next )
	{
	  // The convex vertex index
	  int iConvexContourVertexIndex = rConvexIndexNode.Value;

	  // Is the convex vertex is an ear tip?
	  if( IsEarTip( a_rMeshVertices, iConvexContourVertexIndex, a_rOuterContourVertexIndexesList, a_rReflexVertexIndexesList ) == true )
	    {
	      // Yes: adds it to the list
	      oEarTipVertexIndexesList.AddLast( iConvexContourVertexIndex );
	    }
	}

      // Return the ear tip list
      return oEarTipVertexIndexesList;
    }
		
    // Returns true if the specified convex vertex is an ear tip
    private static bool IsEarTip( Vector3[ ] a_rMeshVertices, int a_iEarTipConvexVertexIndex, CircularLinkedList<int> a_rContourVertexIndexesList, LinkedList<int> a_rReflexVertexIndexesList )
    {
      CircularLinkedListNode<int> rContourVertexNode = a_rContourVertexIndexesList.Find( a_iEarTipConvexVertexIndex );

      int iPreviousContourVertexIndex = rContourVertexNode.Previous.Value;
      int iNextContourVertexIndex = rContourVertexNode.Next.Value;

      // Retrieve previous (i-1) / current (i) / next (i+1) vertices to form the triangle < Vi-1, Vi, Vi+1 >
      Vector3 f3ConvexContourVertex   = a_rMeshVertices[ a_iEarTipConvexVertexIndex ];
      Vector3 f3PreviousContourVertex = a_rMeshVertices[ iPreviousContourVertexIndex ];
      Vector3 f3NextContourVertex     = a_rMeshVertices[ iNextContourVertexIndex ];

      // Look for an inner point into the triangle formed by the 3 vertices
      // Only need to look over the reflex vertices.
      for( LinkedListNode<int> rReflexIndexNode = a_rReflexVertexIndexesList.First; rReflexIndexNode != null; rReflexIndexNode = rReflexIndexNode.Next )
	{
	  // Retrieve the reflex vertex
	  int iReflexContourVertexIndex = rReflexIndexNode.Value;

	  // Is the point inside the triangle?
	  // (Exclude the triangle points themselves)
	  Vector3 f3ReflexContourVertex = a_rMeshVertices[ iReflexContourVertexIndex ];
	  if( f3ReflexContourVertex != f3PreviousContourVertex && f3ReflexContourVertex != f3ConvexContourVertex && f3ReflexContourVertex != f3NextContourVertex )
	    {
	      if( MathUtils.IsPointInsideTriangle( f3PreviousContourVertex, f3ConvexContourVertex, f3NextContourVertex, f3ReflexContourVertex ) == true )
		{
		  // Point is inside triangle: not an ear tip
		  return false;
		}
	    }
	}

      // No point inside the triangle: ear tip found!
      return true;
    }
  }
}
#endif