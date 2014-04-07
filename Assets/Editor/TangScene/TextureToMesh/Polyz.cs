using System;
using System.Collections.Generic;
using UnityEngine;

namespace TangScene
{
  public class Polyz
  {
    
    public static Mesh Texture2Grid (Texture2D texture2D,
				     float alphaCutOff,
				     float scaleFactor,
				     Vector3 pivotCoords, 
				     int horizontalSubDivs,
				     int verticalSubDivs)
    {
			
      // Step 1
      // Distinguish completely transparent pixels from significant pixel by "binarizing" the texture.
      PaddedImage paddedImage = ShapeExtractionUtils.PadTexture (texture2D, alphaCutOff);
			
      // Step 2
      // Triangulate the grid straight from binarized image
      Mesh mesh = PolygonTriangulationUtils.PolygonizeGrid (paddedImage,
							    scaleFactor,
							    pivotCoords,
							    horizontalSubDivs,
							    verticalSubDivs);
			
      // Wrap up the mesh before delivering ;^)
      mesh.name = "mesh_grid_" + texture2D.name;
      mesh.RecalculateBounds ();
      mesh.RecalculateNormals ();
      mesh.Optimize ();
			
      return mesh;
    }
		
    public static Mesh Texture2Contour (Texture2D texture2D,
					float alphaCutOff,
					float accuracy,
					bool polygonizeHoles,
					float scaleFactor,
					Vector3 pivotCoords)
    {
			
      // Step 1
      // Distinguish completely transparent pixels from significant pixel by "binarizing" the texture.
      //BinarizedImage binarizedImage = Uni2DEditorShapeExtractionUtils.BinarizeTexture (texture2D, alphaCutOff);
      PaddedImage paddedImage = ShapeExtractionUtils.PadTexture (texture2D, alphaCutOff);
			
			
      // Step 2
      // Build binarized outer/inner contours and label image regions
      List<Contour> outerContours;
      List<Contour> innerContours;
			
      ContourExtractionUtils.CombinedContourLabeling (paddedImage,
						      polygonizeHoles, 
						      out outerContours, 
						      out innerContours);
			
      // Step 3: vectorization (determine dominant points)
      if (polygonizeHoles) {
	// Step 3a: if hole support asked by user, merge inner contours into outer contours first
	outerContours = ContourPolygonizationUtils.MergeInnerAndOuterContours(outerContours, 
									      innerContours);
      }
		
      // Simplify contours
      List<Contour> dominantContoursList = ContourPolygonizationUtils.SimplifyContours (outerContours, 
											accuracy);
			
      // Step 4: triangulation
      Mesh mesh = PolygonTriangulationUtils.PolygonizeContours (dominantContoursList,
								scaleFactor,
								pivotCoords,
								texture2D.width,
								texture2D.height);
					
			
      // Wrap up the mesh before delivering ;^)
      mesh.name = "mesh_contour_" + texture2D.name;
      mesh.RecalculateBounds ();
      mesh.RecalculateNormals ();
      mesh.Optimize ();
			
      return mesh;
    }
  }
}

