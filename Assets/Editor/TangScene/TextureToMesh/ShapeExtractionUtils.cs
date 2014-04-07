#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace TangScene
{
  public static class ShapeExtractionUtils
  {

    // Texture2D to PaddedImage
    public static PaddedImage PadTexture(Texture2D texture2D, float alphaCutOff){

      if(texture2D == null)
	{
	  return null;
	}
      
      byte alphaCutOff32 = (byte) (alphaCutOff * 255.0f);

      Color32[] texturePixels = texture2D.GetPixels32();
      int pixelCount = texturePixels.Length;

      PaddedImage paddedImage = new PaddedImage( texture2D.width, texture2D.height, false );
      
      // Parse all pixels
      for( int pixelIndex = 0; pixelIndex < pixelCount; pixelIndex++ )
	{
	  Color32 f4Pixel = texturePixels[ pixelIndex ];
	  paddedImage.SetSpritePixel( pixelIndex, ( f4Pixel.a >= alphaCutOff32 ) );
	}

      // Fill 1px holes
      paddedImage.FillInsulatedHoles();

      return paddedImage;
      
    }
		
    // Double the width and height of a binarized image
    public static PaddedImage ResizeImage( PaddedImage paddedImage )
    {
      int resizedSpriteWidth = paddedImage.SpriteWidth * 2;
      int resizedSpriteHeight = paddedImage.SpriteHeight * 2;

      PaddedImage resizedPaddedImage = new PaddedImage( resizedSpriteWidth, resizedSpriteHeight, false);
      // Upsampling
      // Copy original pixels to resized sprite pixels array
      for( int resizedY = 0; resizedY < resizedSpriteHeight; resizedY++ )
	{
	  for( int resizedX = 0; resizedX < resizedSpriteWidth; resizedX++ )
	    {
	      resizedPaddedImage[ resizedPaddedImage.SpriteCoords2PixelIndex( resizedX, resizedY )]
		= paddedImage[ paddedImage.SpriteCoords2PixelIndex(resizedX/2, resizedY/2) ];
	    }
	}

      return resizedPaddedImage;
    }


  }
}
#endif

