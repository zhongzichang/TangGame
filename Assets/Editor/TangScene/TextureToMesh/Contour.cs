#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TangScene {
	
	public class Contour : IComparable<Contour> {
	
		// Contour vertices
		private CircularLinkedList<Vector2> m_oContourVertices = new CircularLinkedList<Vector2>( );
	
		// Region the contour belongs to
		private int m_iRegion = 0;
	
		// Contour vertices list getter
		public CircularLinkedList<Vector2> Vertices
		{
			get
			{
				return m_oContourVertices;
			}
		}
		
		// Region getter
		public int Region
		{
			get
			{
				return m_iRegion;
			}
		}
	
		// Contour vertex getter
		public Vector2 this[ int a_iIndex ]
		{
			get
			{
				return m_oContourVertices[ a_iIndex ].Value;
			}
		}
	
		public int Count
		{
			get
			{
				return m_oContourVertices.Count;
			}
		}
	
		// Constructor
		public Contour( int a_iRegion )
		{
			m_iRegion = a_iRegion;
		}
	
		public void AddFirst( Vector2 a_f2ContourVertex )
		{
			m_oContourVertices.AddFirst( a_f2ContourVertex );
		}
	
		// Add a contour vertex to the list
		public void AddLast( Vector2 a_f2ContourVertex )
		{
			m_oContourVertices.AddLast( a_f2ContourVertex );
		}
	
		public void AddLast( IEnumerable<Vector2> a_rContourVertices )
		{
			foreach( Vector2 f2ContourPartVertex in a_rContourVertices )
			{
				m_oContourVertices.AddLast( f2ContourPartVertex );
			}
		}
	
		public int CompareTo( Contour a_rAnotherContour )
		{
			if( m_iRegion < a_rAnotherContour.m_iRegion )
			{
				return -1;
			}
			else if( m_iRegion > a_rAnotherContour.m_iRegion )
			{
				return 1;
			}
			else // ==
			{
				float fThisContourMaxX = float.NegativeInfinity;
				float fAnotherContourMaxX = float.NegativeInfinity;
	
				foreach( Vector2 f2ContourVertex in a_rAnotherContour.m_oContourVertices )
				{
					fAnotherContourMaxX = Mathf.Max( f2ContourVertex.x, fAnotherContourMaxX );
				}
	
				foreach( Vector2 f2ContourVertex in m_oContourVertices )
				{
					fThisContourMaxX = Mathf.Max( f2ContourVertex.x, fThisContourMaxX );
					if( fThisContourMaxX > fAnotherContourMaxX )
					{
						return -1;
					}
				}
	
				if( fThisContourMaxX < fAnotherContourMaxX )
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}
	}
}
#endif