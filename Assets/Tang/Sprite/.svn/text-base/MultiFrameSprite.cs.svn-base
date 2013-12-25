using UnityEngine;
using System.Collections;


namespace Tang {
	
  [ExecuteInEditMode]
  public class MultiFrameSprite : TTSprite
  {

#region Public Fields
    public Frame[] m_frames;
#endregion
		
#region Public Properties
    public Frame[] frames
    {
      get
	{
	  return m_frames;
	}
      set
	{
	  m_frames = value;
	  maxIndex = m_frames.Length - 1;
	  currentIndex = 0;
	}
    }

    public override int currentIndex
    {
      get 
        {
          return m_currentIndex;
        }
      set
        {
          if( value != m_currentIndex ) 
	    {
            if( value > m_maxIndex )
	      {
              if( m_currentIndex != m_maxIndex ) 
		{
                  m_currentIndex = m_maxIndex;
                  CurrentFrame = frames[currentIndex];
                }
              }
	    else if( value < 0 )
	      {
                if( m_currentIndex != 0 )
		  {
                    m_currentIndex = 0;
                    CurrentFrame = frames[m_currentIndex];
                  }
              }
	    else
             {
               m_currentIndex = value;
               CurrentFrame = frames[m_currentIndex];
						
             }
           }
         }
     }
#endregion
		
#region Mono Methods
		
    // Use this for initialization
    void Awake ()
    {
			
      if( frames != null && frames.Length > 0 )
	{
				
          // init ---
          base.Init();
          m_maxIndex = frames.Length - 1;
          if( m_currentIndex > m_maxIndex )
            {
              m_currentIndex = m_maxIndex;
            } 
          else if(m_currentIndex < 0)
            {
              m_currentIndex = 0;
            }
          CurrentFrame = frames[m_currentIndex];
         // ---
        }
    }
#endregion
  }
}