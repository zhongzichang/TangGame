using UnityEngine;
using System.Collections.Generic;

namespace Tang
{
  [ExecuteInEditMode]
  public class MultiSetSprite : MultiFrameSprite
  {
  
#region Public Fields

    public FrameSet[] frameSets;
    public string m_currentSetName = null;

#endregion
    
#region Private Fields

    private Dictionary<string, FrameSet> frameSetTable = new Dictionary<string, FrameSet> ();

#endregion
    
#region Public Properties

    public string currentSetName {
      get {
        return m_currentSetName;
      }
      set {
        if (frameSetTable.ContainsKey (value) && m_currentSetName != value) {
          m_currentSetName = value;
          frames = frameSetTable [m_currentSetName].frames;
          //if (currentIndex >= frames.Length)
            CurrentFrame = frames [0];
        }
      }
    }

#endregion
    
#region Mono Method

    // Use this for initialization
    void Awake ()
    {
      
      if (frameSets != null && frameSets.Length > 0) {
        
        // init ---
        base.Init ();
        
        foreach (FrameSet frameSet in frameSets) {
          frameSetTable.Add (frameSet.name, frameSet);
        }
        
        if (m_currentSetName == null || !frameSetTable.ContainsKey (m_currentSetName)) {
          m_currentSetName = frameSets [0].name;
        }
        
        frames = frameSetTable [m_currentSetName].frames;
        
        m_maxIndex = frames.Length - 1;

        if (m_currentIndex > m_maxIndex) {
          m_currentIndex = m_maxIndex;          
        } else if (m_currentIndex < 0) {
          m_currentIndex = 0;
        }
        
        CurrentFrame = frames [m_currentIndex];
        
        // ---
      }
    }

#endregion
    
  }

}
