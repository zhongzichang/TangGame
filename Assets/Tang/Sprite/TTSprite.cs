using UnityEngine;
using System.Collections;

namespace Tang
{
  [ExecuteInEditMode]
  public class TTSprite : MonoBehaviour
  {

    public delegate void MaxIndexChange(int maxIndex);

    public MaxIndexChange maxIndexChangeHandler;

    public delegate void BecameVisible();

    public BecameVisible becameVisibleHandler;

    public delegate void BecameInvisible();

    public BecameInvisible becameInvisibleHandler;

#region Public Fields

    public bool m_flipHorizontal = false;
    public bool m_flipVertical = false;
    public int m_currentIndex = 0;

#endregion
    
#region Protected Fields

    protected int m_maxIndex = 0;

#endregion
    
#region Private Fields

    private MeshFilter mf = null;
    private MeshRenderer mr = null;
    private bool frameUpdated = false;
    private Frame m_currentFrame = null;
    private string realMaterialKey = null;
    private string halfTransparentMaterialKey = null;
    private bool isReal = true;

#endregion
    
#region Public Properties 

    public int maxIndex {
      get { return m_maxIndex;}
      set {
        m_maxIndex = value;
        if (maxIndexChangeHandler != null)
          maxIndexChangeHandler(m_maxIndex);

      }
    }

    public virtual int currentIndex {
      get { return m_currentIndex; }
      set { m_currentIndex = value; }
    }

    public Frame CurrentFrame {
      get {
        return m_currentFrame;
      }
      set {
        if (value != null) {
          m_currentFrame = value;
          frameUpdated = true;
        }
      }
    }

    public bool flipHorizontal {
      get { return m_flipHorizontal; }
      set {
        if (m_flipHorizontal != value) {
          m_flipHorizontal = value;
          frameUpdated = true;
        }
      }
    }

    public bool flipVertical {
      get { return m_flipVertical; }
      set {
        if (m_flipVertical != value) {
          m_flipVertical = value;
          frameUpdated = true;
        }
      }
    }

#endregion
        
#region Protected Methods

    protected void Init()
    {
      InitComponents();
    }
    
    protected void InitComponents()
    {
      
      mf = GetComponent<MeshFilter>();
      if (mf == null)
        mf = gameObject.AddComponent<MeshFilter>();
      Mesh mesh = MeshOne.NewMesh();
      mf.mesh = mesh;

      mr = GetComponent<MeshRenderer>();
      
#if UNITY_EDITOR
      realMaterialKey = mr.renderer.sharedMaterial.name;
#else
      realMaterialKey = mr.renderer.material.name;
#endif
      halfTransparentMaterialKey = realMaterialKey + "_ht";

    }
    
    protected void UpdateMesh(Frame fr)
    {
      
      Vector2[] uv = fr.uv;     
      
      if (flipHorizontal) {
        uv = new Vector2[fr.uv.Length];
        for (int i=0; i<uv.Length; i++) {
          uv[0] = fr.uv[1];
          uv[1] = fr.uv[0];
          uv[2] = fr.uv[3];
          uv[3] = fr.uv[2];
        }
        transform.localPosition = new Vector3(-fr.offset.x, 0, fr.offset.y);
      }
      
      if (flipVertical) {
        uv = new Vector2[fr.uv.Length];
        for (int i=0; i<uv.Length; i++) {
          uv[0] = fr.uv[3];
          uv[3] = fr.uv[0];
          uv[1] = fr.uv[2];
          uv[2] = fr.uv[1];
        }
        transform.localPosition = new Vector3(fr.offset.x, 0, -fr.offset.y);
      }
      
#if UNITY_EDITOR
      mf.sharedMesh.uv = uv;
#else
      mf.mesh.uv = uv;
#endif
      
      if (!flipHorizontal && !flipVertical) {
        transform.localPosition = new Vector3(fr.offset.x, 0, fr.offset.y);
      }
      transform.localScale = new Vector3(fr.size.x, 1, fr.size.y);
      
    }

#endregion
    
#region Mono Methods

    void Update()
    {

      if (frameUpdated) {
        frameUpdated = false;
        UpdateMesh(m_currentFrame);
      }
    }

    void OnDestroy()
    {
      
      if (mf != null) {
#if UNITY_EDITOR
  DestroyImmediate(mf.sharedMesh);
#else
        Destroy(mf.mesh);
#endif
      }
    }

    void OnBecameVisible()
    {
      if (becameVisibleHandler != null) {
        becameVisibleHandler();
      }
    }

    void OnBecameInvisible()
    {
      if (becameInvisibleHandler != null) {
        becameInvisibleHandler();
      }
    }

    void OnTouch(TouchHit touchHit)
    {
      if (transform.parent != null && transform.parent.parent != null
        && transform.parent.parent.parent != null) {
        transform.parent.parent.parent.SendMessage("OnTouch", touchHit);
      }
    }

#endregion

    public void OnBecameHalfTransparent()
    {
      mr.renderer.material = HalfTransparentMaterial;
      isReal = false;
    }

    public void OnBecameReal()
    {
      mr.renderer.material = RealMaterial;
      isReal = true;
    }

    /// <summary>
    ///   调整高光级别，必须 >1
    /// </summary>
    public void ChangeSpecularLevel(int level)
    {
      string key = realMaterialKey + level;
      Material material = null;
      if (!AssetCache.materialTable.ContainsKey(key)) {
        material = new Material(RealMaterial);
        material.shader = Shader.Find("Mobile/Tang/Transparent/UV_RGBA_Scale");
        material.SetColor("_tangRGBA", new Vector4(level, level, level, 1));
        AssetCache.materialTable.Add(key, material);
      } else
        material = AssetCache.materialTable[key];

      mr.renderer.material = material;

    }

    public void RevertSpecular()
    {
      if (isReal)
        mr.renderer.material = RealMaterial;
      else
        mr.renderer.material = HalfTransparentMaterial;
    }

    private Material RealMaterial {
      get {
        if (!AssetCache.materialTable.ContainsKey(realMaterialKey)) {
          Material realMaterial = mr.renderer.material;
          AssetCache.materialTable.Add(realMaterialKey, realMaterial);
          return realMaterial;
        } else
          return AssetCache.materialTable[realMaterialKey];
      }

    }

    private Material HalfTransparentMaterial {
      get {
        if (!AssetCache.materialTable.ContainsKey(halfTransparentMaterialKey)) {
          Material halfTransparentMaterial = new Material(RealMaterial);
          halfTransparentMaterial.shader = Shader.Find("Mobile/Tang/Transparent/UV_RGBA_Scale");
          halfTransparentMaterial.SetColor("_tangRGBA", new Vector4(1, 1, 1, 0.5F));
          AssetCache.materialTable.Add(halfTransparentMaterialKey, halfTransparentMaterial);
          return halfTransparentMaterial;
        } else
          return AssetCache.materialTable[halfTransparentMaterialKey];
      }
    }

  }
}
