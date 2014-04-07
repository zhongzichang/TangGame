#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TangScene
{
  public class PaddedImage
  {
    private BitArray pixelsBitArray;
	
    private int spriteWidth;
    private int spriteHeight;
		
    // [direction, x|y]
    private static int[,] directionDeltas = { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } };
	
    public PaddedImage( int spriteWidth, int spriteHeight, bool defaultValue )
    {
      this.spriteWidth = spriteWidth;
      this.spriteHeight = spriteHeight;
      pixelsBitArray = new BitArray( this.PixelCount, defaultValue );
    }
	
    public bool this[ int index ]
    {
      get
	{
	  return pixelsBitArray[ index ];
	}
      set
	{
	  pixelsBitArray[ index ] = value;
	}
    }
	
    public int SpriteHeight
    {
      get
	{
	  return spriteHeight;
	}
    }
	
    public int SpriteWidth
    {
      get
	{
	  return spriteWidth;
	}
    }
	
    public int Width
    {
      get
	{
	  return spriteWidth + 2;
	}
    }
	
    public int Height
    {
      get
	{
	  return spriteHeight + 2;
	}
    }
	
    public int PixelCount
    {
      get
	{
	  return ( this.Width ) * ( this.Height );
	}
    }
	
    //  coords(unpadded) => pixelIndex(padded)
    public int SpriteCoords2PixelIndex( int x, int y )
    {
      return x + 1 + ( y + 1 ) * ( this.Width );
    }
	
    public int SpriteCoords2PixelIndex( Vector2 coords )
    {
      return ((int) coords.x) + 1 + ( ((int) coords.y) + 1 ) * ( this.Width );
    }
	
    // pixelIndex(padded) => corrds(unpadded)
    public Vector2 PixelIndex2SpriteCoords( int pixelIndex )
    {
      return new Vector2( ( pixelIndex % ( this.Width ) ) - 1, ( pixelIndex / ( this.Width ) ) - 1 );
    }
		
    // pixelIndex(unpadded) => pixelIndex(padded)
    private int SpriteIndex2Index( int spriteIndex )
    {
      return ( ( spriteIndex / spriteWidth ) + 1 ) * ( this.Width ) + ( ( spriteIndex % spriteWidth ) + 1 );
    }
	
    // Transform a pixel index used internally by the bit array into pixel index via accessors
    /*private int Index2SpriteIndex( int pixelIndex )
      {
      return ( ( pixelIndex / Width ) - 1 ) * spriteWidth + ( ( pixelIndex % Width ) - 1 );
      }*/
	
    // Return true if the pixel is wedged i.e. its 4-neighbors of the pixel are all significants
		
    public bool IsPixelWedged( int pixelIndex )
    {
      return pixelsBitArray[ pixelIndex + 1            ] == true
	&& pixelsBitArray[ pixelIndex - 1            ] == true
	&& pixelsBitArray[ pixelIndex - this.Width ] == true
	&& pixelsBitArray[ pixelIndex + this.Width ] == true;
    }
    public static Vector2 GetDirectionVector( NeighborDirection direction )
    {
      int directionValue = (int) direction;
      return new Vector2( directionDeltas[ directionValue, 0 ], directionDeltas[ directionValue, 1 ] );
    }
		
    public int GetNeighborPixelIndex( int pixelIndex, NeighborDirection direction )
    {
      int directionValue = (int) direction;
      return pixelIndex + directionDeltas[ directionValue, 0 ] + directionDeltas[ directionValue, 1 ] * ( this.Width );
    }
	
    public void SetSpritePixel( int spriteIndex, bool pixelValue )
    {
      int pixelIndex = this.SpriteIndex2Index( spriteIndex );
      pixelsBitArray[ pixelIndex ] = pixelValue;
    }
	
    // Fill wedged white 1px holes
    public void FillInsulatedHoles( )
    {
      for( int y = 0; y < spriteHeight; ++y )
	{
	  for( int x = 0; x < spriteWidth; ++x )
	    {
	      int pixelIndex = SpriteCoords2PixelIndex( x, y );
	      if( pixelsBitArray[ pixelIndex ] == false && this.IsPixelWedged( pixelIndex ) == true )
		{
		  pixelsBitArray[ pixelIndex ] = true;
		}
	    }
	}
    }
  }
}

#endif