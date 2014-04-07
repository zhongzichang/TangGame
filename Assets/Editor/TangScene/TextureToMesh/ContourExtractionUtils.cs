#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TangScene {

	public static class ContourExtractionUtils
	{
		public static void CombinedContourLabeling( PaddedImage paddedImage, bool polygonizeHoles, 
			out List<Contour> outerContours, out List<Contour> innerContours )
		{
			outerContours = new List<Contour>( );
			innerContours = new List<Contour>( );
	
			int[ ] labelMap = new int[ paddedImage.PixelCount ];	// init as 0
			int regionCounter = 0;
	
			for( int y = 0; y < paddedImage.SpriteHeight; y++ )
			{
				int label = 0;
	
				for( int x = 0; x < paddedImage.SpriteWidth; ++x )
				{
					int pixelIndex = paddedImage.SpriteCoords2PixelIndex( x, y );
	
					if( paddedImage[ pixelIndex ] == true )	// Foreground
					{
						if( label != 0 )	// Continue inside region
						{
							labelMap[ pixelIndex ] = label;
						}
						else
						{
							label = labelMap[ pixelIndex ];
							if( label == 0 )	// New outer contour
							{
								regionCounter++;
								label = regionCounter;
								Contour outerContour = TraceContour( pixelIndex, NeighborDirection.DirectionRight, 
									label, paddedImage, labelMap );
								outerContours.Add( outerContour );
								labelMap[ pixelIndex ] = label;
							}
						}
					}
					else // Background
					{
						if( label != 0 )
						{
							if( polygonizeHoles == true )
							{
								if( labelMap[ pixelIndex ] == 0 )	// New inner contour
								{
									pixelIndex = paddedImage.SpriteCoords2PixelIndex( x - 1, y );
									Contour innerContour = TraceContour( pixelIndex, NeighborDirection.DirectionUpRight, 
										label, paddedImage, labelMap );
									innerContours.Add( innerContour );
								}
								label = 0;
							}
							else if( labelMap[ pixelIndex ] != -1 )
							{
								labelMap[ pixelIndex ] = label;
							}
							else
							{
								label = 0;
							}
						}
					}
				}
			}
		}
	
		public static Contour TraceContour( int startingPixelIndex, NeighborDirection startingDirection, 
			int contourLabel, PaddedImage paddedImage, int[ ] labelMap )
		{
			
			int pixelIndexTrace;
			NeighborDirection directionNext = startingDirection;
			FindNextPoint( startingPixelIndex, startingDirection, paddedImage, labelMap, out pixelIndexTrace, out directionNext );
			Contour contour = new Contour( contourLabel );
			contour.AddFirst( paddedImage.PixelIndex2SpriteCoords( pixelIndexTrace ) );
			int previousPixelIndex = startingPixelIndex;
			int currentPixelIndex = pixelIndexTrace;
			bool done = ( startingPixelIndex == pixelIndexTrace );
	
			// Choose a bias factor
			// The bias factor points to exterior if tracing an outer contour
			// The bias factor points to interior if tracing an inner contour
			float orthoBiasFactor;
			if( startingDirection == NeighborDirection.DirectionUpRight )	// inner contour
			{
				orthoBiasFactor = -0.2f;
			}
			else // outer contour
			{
				orthoBiasFactor = 0.2f;
			}
			
			while( done == false )
			{
				labelMap[ currentPixelIndex ] = contourLabel;
				NeighborDirection directionSearch = (NeighborDirection) ( ( (int) directionNext + 6 ) % 8 );
				int nextPixelIndex;
				FindNextPoint( currentPixelIndex, directionSearch, paddedImage, labelMap, out nextPixelIndex, out directionNext );
	
				previousPixelIndex = currentPixelIndex;
				currentPixelIndex = nextPixelIndex;
				done = ( previousPixelIndex == startingPixelIndex && currentPixelIndex == pixelIndexTrace );
	
				if( done == false )
				{
					// Apply some bias to inner and outer contours to avoid them overlap
					// Use the orthogonal vector to direction
					// == direction - 2 % 8 but easier to compute (always positive)
					NeighborDirection orthoBiasDirection = (NeighborDirection) ( ( (int) directionNext + 6 ) % 8 ); 
					Vector2 f2Bias = orthoBiasFactor * PaddedImage.GetDirectionVector( orthoBiasDirection );
	
					// Add bias to pixel pos
					Vector2 f2BiasedPos = f2Bias + paddedImage.PixelIndex2SpriteCoords( nextPixelIndex );
	
					// Add biased pos to contour
					contour.AddFirst( f2BiasedPos );
				}
			}
	
			return contour;	
		}
	
		public static void FindNextPoint( int startingPixelIndex, NeighborDirection startingDirection, 
			PaddedImage paddedImage, int[ ] labelMap, 
			out int nextPixelIndex, out NeighborDirection nextDirection )
		{
			nextDirection = startingDirection;
	
			// Search in all directions except initial direction (=> 7)
			for( int searchIteration = 0; searchIteration < 7; searchIteration++ )
			{
				nextPixelIndex = paddedImage.GetNeighborPixelIndex( startingPixelIndex, nextDirection );
	
				if( paddedImage[ nextPixelIndex ] == false )	// Background pixel, mark it as visited
				{
					labelMap[ nextPixelIndex ] = -1;	// mark as visited
					nextDirection = (NeighborDirection) ( ( (int) nextDirection + 1 ) % 8 );	// Next direction...
				}
				else // Non background pixel
				{
					return;
				}
			}
			nextPixelIndex = startingPixelIndex;	// return starting index
		}
	}
	
}
#endif