/*
 * Created by emacs
 * Date: 2013/9/13
 * Author: zzc
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using Tang;

namespace TangScene
{
  public class GameObjectFactory
  {
    private delegate void InitGobj(GameObject gobj, TsObject tsobj);
    private static Dictionary<Type, InitGobj> methodTable = new Dictionary<Type, InitGobj>();

    private static volatile GameObjectFactory m_instance = null;
    private static readonly object m_staticSyncRoot = new object();
   
    public static GameObjectFactory Instance
    {
      get
	{
	  if( m_instance == null )
	    {
	      lock( m_staticSyncRoot )
		{
		  if( m_instance == null )
		    m_instance = NewInstance();
		}
	    }
	  return m_instance;
	}
    }


    public GameObject NewGobj(TsObject tsobj)
    {
      Type type = tsobj.GetType();

      GameObject gobj = new GameObject();
      gobj.name = tsobj.name;

      gobj.transform.localPosition = tsobj.localPosition;
	  
      // animation
      if( tsobj.animation != null )
	{
	  SpriteAnimate spriteAnimate = gobj.AddComponent<SpriteAnimate>();
	  spriteAnimate.spriteSetName = tsobj.spriteSetName;
	  AddSpriteAnimation(tsobj.animation, spriteAnimate);

	}


      // special components
      if( methodTable.ContainsKey( type ) )
	{
	  methodTable[type](gobj, tsobj);
	}


      // add component with script name
      if( tsobj.scripts != null && tsobj.scripts.Length > 0 )
	{
	  foreach( string script in tsobj.scripts )
	    {
	      gobj.AddComponent(script);
	    }
	}

      return gobj;
    }


    private static GameObjectFactory NewInstance()
    {
      GameObjectFactory factory = new GameObjectFactory();
      methodTable.Add(typeof(Actor), factory.InitActorGobj );
      methodTable.Add(typeof(Scenery), factory.InitSceneryGobj );
      methodTable.Add(typeof(Portal), factory.InitPortalGobj );
      methodTable.Add(typeof(Stage), factory.InitStageGobj );
      methodTable.Add(typeof(TsCamera), factory.InitSceneCamera );
      return factory;
    }
    
    private GameObjectFactory()
    {
      // prohibit construct outside
      // do nothing
    }

    private void InitActorGobj(GameObject gobj, TsObject tsobj)
    {
      Actor actor = tsobj as Actor;
      switch( actor.actorType )
	{
	case ActorType.hero:
	  InitHeroGobj(gobj, actor);
	  break;
	case ActorType.npc:
	  InitNpcGobj(gobj, actor);
	  break;
	case ActorType.monster:
	  InitMonsterGobj(gobj, actor);
	  break;
	case ActorType.pet:
	  InitPetGobj(gobj, actor);
	  break;
	default:
	  Debug.Log("illegal actor type");
	  break;
	}
      
    }


    /// <summary>
    ///   Create Hero
    /// </summary>
    private void InitHeroGobj(GameObject gobj, Actor actor)
    {

      AddActorBhvr(gobj, actor);
      AddNavigable(gobj, actor);
      AddCharacterController(gobj);

    }


    /// <summary>
    ///   Create NPC
    /// </summary>
    private void InitNpcGobj(GameObject gobj, Actor actor)
    {

      AddActorBhvr(gobj, actor);

    }


    /// <summary>
    ///   Create Monster
    /// </summary>
    private void InitMonsterGobj(GameObject gobj, Actor actor)
    {

      AddActorBhvr(gobj, actor);
      AddNavigable(gobj, actor);
      AddCharacterController(gobj);

    }

    private void InitPetGobj(GameObject gobj, Actor actor)
    {

      AddActorBhvr(gobj, actor);
      AddNavigable(gobj, actor);
      AddCharacterController(gobj);
      
    }


    /// <summary>
    ///   Create Portal
    /// </summary>
    private void InitPortalGobj(GameObject gobj, TsObject tsobj)
    {

      Portal portal =  tsobj as Portal;

      PortalBhvr portalBhvr = gobj.AddComponent<PortalBhvr>();
      portalBhvr.baseId = portal.baseId;
      portalBhvr.destination = portal.destination;

      SphereCollider sc = gobj.AddComponent<SphereCollider>();
      sc.center = Vector3.zero;
      sc.isTrigger = true;
      sc.radius = 50F;

      gobj.AddComponent<Locational>();

    }


    /// <summary>
    ///   Create Stage
    /// </summary>
    private void InitStageGobj(GameObject gobj, TsObject tsobj)
    {

      Stage stage = tsobj as Stage;

      Mesh mesh = MeshHelper.CreateRectBaseXz((int)stage.x, 
					      -(int)stage.y,
					      stage.width, stage.height);
      MeshFilter mf = gobj.AddComponent<MeshFilter>();
      mf.mesh = mesh;
      LoadableMaterialBhvr loadableMaterialBhvr = gobj.AddComponent<LoadableMaterialBhvr>();
      loadableMaterialBhvr.MatName = stage.materialName;
      gobj.name = stage.materialName;


      MeshCollider mc = gobj.AddComponent<MeshCollider>();
      mc.sharedMesh = mesh;
      
      StageBhvr stageBhvr = gobj.AddComponent<StageBhvr>();
      stageBhvr.x = stage.x;
      stageBhvr.y = stage.y;
      stageBhvr.width = stage.width;
      stageBhvr.height = stage.height;
      stageBhvr.materialName = stage.materialName;

      if( gobj.GetComponent<Locational>() == null )
	      gobj.AddComponent<Locational>();


    }



    /// <summary>
    ///   Create Scenery
    /// </summary>
    private void InitSceneryGobj(GameObject gobj, TsObject tsobj)
    {

      Scenery scenery = tsobj as Scenery;

      if( scenery.heightOffset )
	gobj.AddComponent<HeightOffsetBhvr>();

      if( gobj.GetComponent<Locational>() == null )
	gobj.AddComponent<Locational>();


    }


    private void InitSceneCamera(GameObject gobj, TsObject tsobj )
    {
    	gobj.transform.localRotation = tsobj.localRotation;
      gobj.transform.localScale = tsobj.localScale;

      TsCamera tscamera = tsobj as TsCamera;

      gobj.tag  = Texts.MAIN_CAMERA;

      Camera camera = gobj.AddComponent<Camera>();
      camera.clearFlags = tscamera.clearFlags;
      camera.cullingMask = tscamera.cullingMask;
      camera.orthographic = tscamera.orthographic;
      camera.orthographicSize = tscamera.orthographicSize;
      //camera.orthographicSize = Screen.height/2;
      camera.nearClipPlane = tscamera.nearClipPlane;
      camera.farClipPlane = tscamera.farClipPlane;
      camera.rect = tscamera.rect;
      camera.depth = tscamera.depth;

      if( tscamera.guiLayer )
	gobj.AddComponent<GUILayer>();
      if( tscamera.audioListener )
	gobj.AddComponent<AudioListener>();

      if( tscamera.scroll )
	{
	  
	  CameraScrolling cameraScrolling = gobj.AddComponent<CameraScrolling>();
	  cameraScrolling.distance = tscamera.scrollDistance;
	  cameraScrolling.springiness = tscamera.scrollSpringiness;
	  cameraScrolling.cacheX = tscamera.scrollCacheX;
	  cameraScrolling.cacheZ = tscamera.scrollCacheZ;
	  cameraScrolling.transition = tscamera.scrollTransition;
	  
	}
      
    }

    private GameObject CreateSceneCamera()
    {
      GameObject gobj = new GameObject();
      gobj.name = Texts.CAMERA;
      gobj.tag  = Texts.MAIN_CAMERA;

      gobj.transform.localPosition = new Vector3(0,0,0);
      gobj.transform.Rotate(new Vector3(90,0,0));
      gobj.transform.localScale = new Vector3(1,1,1);

      Camera camera = gobj.AddComponent<Camera>();
      camera.clearFlags = CameraClearFlags.Skybox;
      camera.cullingMask = 1;
      camera.orthographic = true;
      //camera.orthographicSize = Screen.height/2;
      camera.orthographicSize = 300;
      camera.nearClipPlane = 1;
      camera.farClipPlane = 10000;
      camera.rect = new Rect(0,0,1,1);
      camera.depth = -1;

      gobj.AddComponent<GUILayer>();
      gobj.AddComponent<AudioListener>();

      CameraScrolling cameraScrolling = gobj.AddComponent<CameraScrolling>();
      cameraScrolling.distance = 6000F;
      cameraScrolling.springiness = 1F;
      cameraScrolling.cacheX = 150F;
      cameraScrolling.cacheZ = 70F;
      cameraScrolling.transition = false;
      
      return gobj;
    }



    /// <summary>
    ///   Create Scene
    /// </summary>
    public void BuildScene(Scene scene)
    {
      
      GameObject sceneGobj = new GameObject();
      sceneGobj.name = scene.name;

      Rect sceneBounds = new Rect( 0, 0, scene.width, scene.height );
      SceneBoundsBhvr sceneBoundsBhvr = sceneGobj.AddComponent<SceneBoundsBhvr>();
      sceneBoundsBhvr.bounds = sceneBounds;
      
      SceneBhvr sceneBhvr = sceneGobj.AddComponent<SceneBhvr>();
      sceneBhvr.sceneId = scene.id;
      sceneBhvr.sceneName = scene.name;
      sceneBhvr.sceneType = scene.type;

      sceneGobj.AddComponent<SceneFacadeBhvr>();
      sceneGobj.AddComponent<FpsBhvr>();

      // tsobjs
      int total = scene.objs.Length;
      for(int i=0; i<total; i++){
        NewGobj( scene.objs[i] );
        PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NtftNames.TG_LOADING_PROGRESS, (float)(i+1)/total);
      }

      // transparent layer
      CheckHalfTransparent();

      // camera
      if( Camera.main != null )
	{
	  CameraScrolling cs = Camera.main.GetComponent<CameraScrolling>();
	  if( cs != null )
	    cs.sceneBounds = sceneBounds;
	}

      
    }

    private void CheckHalfTransparent()
    {
      GameObject transparent = GameObject.Find("transparent");

      if( transparent != null )
	{
	  HalfTransparentBhvr halfTransparentBhvr = transparent.GetComponent<HalfTransparentBhvr>();
	  if( halfTransparentBhvr == null )
	    transparent.AddComponent<HalfTransparentBhvr>();

	  Locational locational = transparent.GetComponent<Locational>();
	  if( locational == null )
	    transparent.AddComponent<Locational>();

	}
      
    }

    /// <summary>
    ///   New Sprite Animation
    /// </summary>
    private SpriteAnimation AddSpriteAnimation(TsAnimation tsanimation, SpriteAnimate spriteAnimate)
    {

      GameObject gobj = new GameObject();
      gobj.name = tsanimation.name;
      SpriteAnimation animation = gobj.AddComponent<SpriteAnimation>();
      animation.playOnStart = tsanimation.playOnStart;
      animation.loop = tsanimation.loop;
      animation.fps = tsanimation.fps;
      
      spriteAnimate.spriteAnimation = animation;

      foreach( TsLayer tslayer in tsanimation.layers )
	  animation.PutLayer( tslayer );

      return animation;

    }

    private Navigable AddNavigable(GameObject gobj, Actor actor)
    {
      // navigable
      NavMeshHit closestHit;
      if( NavMesh.SamplePosition( gobj.transform.localPosition , out closestHit, 500, 1 ) ){
	gobj.transform.position = closestHit.position;
	Navigable navigable = gobj.AddComponent<Navigable>();
	navigable.Speed = actor.speed;
      }

      return null;

    }

    private CharacterController AddCharacterController(GameObject gobj)
    {
      // character controller
      CharacterController cc = gobj.AddComponent<CharacterController>();
      cc.slopeLimit = 0;
      cc.stepOffset = 0.3F;
      cc.center = new Vector3(0,3,0);
      cc.radius = 0.5F;
      cc.height = 2F;
      return cc;
    }

    private ActorBhvr AddActorBhvr(GameObject gobj, Actor actor)
    {

      // actor bhvr
      ActorBhvr actorBhvr = gobj.AddComponent<ActorBhvr>();
      actorBhvr.id = actor.id;
      actorBhvr.baseId = actor.baseId;
      actorBhvr.nickName = actor.nickName;
      actorBhvr.actorType = actor.actorType;

      // character status bhvr
      CharacterStatusBhvr characterStatusBhvr = gobj.AddComponent<CharacterStatusBhvr>();
      characterStatusBhvr.Status = actor.status;

      // directional
      Directional directional = gobj.AddComponent<Directional>();
      directional.Direction = actor.direction;

      gobj.AddComponent<Selectable>();

      return actorBhvr;
    }

  }
}