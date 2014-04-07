using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEditor;
using Tang;
using TangUtils;


namespace TangScene
{
  public class Exporters
  {
    [MenuItem ("TangScene/Export Scene XML File ... ")]
    public static void ExportScene(){

      // scene
      Scene scene = new Scene();
      List<TsObject> objList = new List<TsObject>();

      // meta
      Meta meta = new Meta();
      meta.dateTime = DateTime.Now;
      scene.meta = meta;

      // scene name
      SceneBhvr sceneBhvr = GameObject.FindObjectOfType(typeof(SceneBhvr)) as SceneBhvr;
      if(sceneBhvr != null)
	{
	  scene.id = sceneBhvr.sceneId;
	  scene.name = sceneBhvr.sceneName;
	  scene.type = sceneBhvr.sceneType;
	}
      else
	{
	  Debug.LogWarning("SceneBhvr not found.");
	}

      // scene bounds
      SceneBoundsBhvr sceneBoundsBhvr = GameObject.FindObjectOfType(typeof(SceneBoundsBhvr)) as SceneBoundsBhvr;
      if(sceneBoundsBhvr != null)
	{
	  scene.width = (int)sceneBoundsBhvr.bounds.width;
	  scene.height = (int)sceneBoundsBhvr.bounds.height;
	}
      else
	{
	  Debug.LogWarning("SceneBoundsBhvr not found.");
	}
      

      // stages
      StageBhvr[] stageBhvrs = GameObject.FindObjectsOfType(typeof(StageBhvr)) as StageBhvr[];
      if( stageBhvrs != null )
	{
	  Stage[] stages = new Stage[stageBhvrs.Length];
	  for(int i=0; i<stages.Length; i++)
	    {
	      stages[i] = new Stage();
	      stages[i].localPosition = stageBhvrs[i].transform.localPosition;
	      stages[i].materialName = stageBhvrs[i].renderer.sharedMaterial.name;
	      stages[i].width = stageBhvrs[i].width;
	      stages[i].height = stageBhvrs[i].height;
	      stages[i].x = stageBhvrs[i].x;
	      stages[i].y = stageBhvrs[i].y;
	    }
	  objList.AddRange( stages );
	}
      else
	{
	  Debug.LogWarning("StageBhvr[] not found.");
	}


      // actors( npc )
      /*
      ActorBhvr[] actorBhvrs = GameObject.FindObjectsOfType( typeof(ActorBhvr) ) as ActorBhvr[];
      if( actorBhvrs != null )
	{

	  for(int i=0; i< actorBhvrs.Length; i++)
	    {
	      if( actorBhvrs[i].actorType == ActorType.npc )
		{
		  Actor actor = new Actor();
		  actor.id = actorBhvrs[i].baseId;
		  actor.baseId = actorBhvrs[i].baseId;
		  actor.nickName = actorBhvrs[i].nickName;
		  actor.actorType = actorBhvrs[i].actorType;
		  actor.localPosition = actorBhvrs[i].transform.localPosition;
		  actor.name = actorBhvrs[i].name;

		  SpriteAnimate spriteAnimate = actorBhvrs[i].GetComponent<SpriteAnimate>();
		  TsAnimation animation = null;

		  if( spriteAnimate != null )
		    animation = FromSpriteAnimation(spriteAnimate.spriteAnimationPrefab);

		  if( animation != null )
		    actor.animation = animation;
		  else
		    Debug.LogWarning("Actor " + actor.id  + " Animation not found.");

		  CharacterStatusBhvr statusBhvr = actorBhvrs[i].GetComponent<CharacterStatusBhvr>();
		  if( statusBhvr != null )
		    actor.status = statusBhvr.Status;

		  Directional directional = actorBhvrs[i].GetComponent<Directional>();
		  if( directional != null )
		    actor.direction = directional.Direction;

		  objList.Add( actor );

		}
	      
	    }
	}*/


      // sceneries
      SceneryBhvr[] sceneryBhvrs = GameObject.FindObjectsOfType( typeof(SceneryBhvr) ) as SceneryBhvr[];
      
      if( sceneryBhvrs != null )
	{
	  Scenery[] sceneries = new Scenery[sceneryBhvrs.Length];
	  for(int i=0; i<sceneryBhvrs.Length; i++)
	    {
	      sceneries[i] = new Scenery();
	      sceneries[i].localPosition = sceneryBhvrs[i].transform.localPosition;

	      SpriteAnimate spriteAnimate = sceneryBhvrs[i].GetComponent<SpriteAnimate>();
	      TsAnimation animation = null;

	      if( spriteAnimate != null )
		{
		  animation = FromSpriteAnimation(spriteAnimate.spriteAnimationPrefab);
		  sceneries[i].spriteSetName = spriteAnimate.spriteSetName;
		}
	      if( animation != null )
		{
		  sceneries[i].animation = animation;
		}
	      else
		Debug.LogWarning("Scenery " + sceneries[i].localPosition + " animation not found.");

	      HeightOffsetBhvr heightOffsetBhvr = sceneryBhvrs[i].GetComponent<HeightOffsetBhvr>();
	      if( heightOffsetBhvr != null )
		sceneries[i].heightOffset = true;
	      else
		sceneries[i].heightOffset = false;

	    }
	  objList.AddRange( sceneries );
	}

      // portals
      PortalBhvr[] portalBhvrs = GameObject.FindObjectsOfType( typeof(PortalBhvr) ) as PortalBhvr[];
      if( portalBhvrs != null )
	{
	  Portal[] portals = new Portal[portalBhvrs.Length];
	  for(int i=0; i< portalBhvrs.Length; i++)
	    {
	      portals[i] = new Portal();
	      portals[i].baseId = portalBhvrs[i].baseId;
	      portals[i].name = portalBhvrs[i].name;
	      portals[i].destination = portalBhvrs[i].destination;
	      portals[i].localPosition = portalBhvrs[i].transform.localPosition;

	      SpriteAnimate spriteAnimate = portalBhvrs[i].GetComponent<SpriteAnimate>();
	      TsAnimation animation = null;

	      if( spriteAnimate != null )
		{
		  animation = FromSpriteAnimation(spriteAnimate.spriteAnimationPrefab);
		}
	      if( animation != null )
		portals[i].animation = animation;
	      else
		Debug.LogWarning("Portal " + portals[i].localPosition + " animation not found.");
	      
	    }
	  objList.AddRange( portals );
	}

      // cameras
      Camera[] cameras = GameObject.FindObjectsOfType( typeof(Camera) ) as Camera[];
      if( cameras != null )
	{
	  TsCamera[] tscameras = new TsCamera[cameras.Length];
	  for(int i=0; i<cameras.Length; i++)
	    {
	      TsCamera tc = new TsCamera();
	      tc.name = cameras[i].name;
	      tc.localPosition = cameras[i].transform.localPosition;
	      tc.localRotation = cameras[i].transform.localRotation;
	      tc.localScale = cameras[i].transform.localScale;
	      
	      tc.clearFlags = cameras[i].clearFlags;
	      tc.cullingMask = cameras[i].cullingMask;
	      tc.orthographic = cameras[i].orthographic;
	      tc.orthographicSize = cameras[i].orthographicSize;
	      tc.nearClipPlane = cameras[i].nearClipPlane;
	      tc.farClipPlane = cameras[i].farClipPlane;
	      tc.rect = cameras[i].rect;
	      tc.depth = cameras[i].depth;
	      
	      GUILayer guiLayer = cameras[i].GetComponent<GUILayer>();
	      tc.guiLayer = guiLayer == null ? false : true;
		
	      
	      AudioListener audioListener = cameras[i].GetComponent<AudioListener>();
	      tc.audioListener = audioListener == null ? false : true;

	      CameraScrolling scrolling = cameras[i].GetComponent<CameraScrolling>();
	      if( scrolling != null )
		{
		  tc.scroll = true;
		  tc.scrollDistance = scrolling.distance;
		  tc.scrollSpringiness = scrolling.springiness;
		  tc.scrollCacheX = scrolling.cacheX;
		  tc.scrollCacheZ = scrolling.cacheZ;
		  tc.scrollTransition = scrolling.transition;
		}
	      
	      tscameras[i] = tc;

	      objList.AddRange(tscameras);
	      
	    }
	}

      if( objList.Count > 0 )
	{
	  scene.objs = objList.ToArray();
	}


      if( sceneBhvr != null )
	{
	  
	  string filepath = EditorUtility.SaveFilePanel("Save scene as XML",
							"",
							"scene_" + sceneBhvr.sceneId + ".xml",
							"xml");
	  if( !String.IsNullOrEmpty(filepath) ) {
	    XmlSerializer serializer = new XmlSerializer( typeof(Scene) );
	    TextWriter writer = new StreamWriter(filepath);
	    serializer.Serialize(writer, scene);

	  }
	}

    }
		
    [MenuItem ("TangScene/Export DTH Scene XML File ... ")]
    public static void ExportDTHScene() {

      // scene
      dth.Map map = new dth.Map();

      // meta
      Meta meta = new Meta();
      meta.dateTime = DateTime.Now;
      map.meta = meta;

      // scene name
      SceneBhvr sceneBhvr = GameObject.FindObjectOfType(typeof(SceneBhvr)) as SceneBhvr;
      if(sceneBhvr != null)
	{
	  map.id = sceneBhvr.sceneId;
	  map.name = sceneBhvr.sceneName;
	}

      // scene bounds
      SceneBoundsBhvr sceneBoundsBhvr = GameObject.FindObjectOfType(typeof(SceneBoundsBhvr)) as SceneBoundsBhvr;
      if(sceneBoundsBhvr != null)
	{
	  map.mapW = (int)sceneBoundsBhvr.bounds.width;
	  map.mapH = (int)sceneBoundsBhvr.bounds.height;
	}

      // stage
      StageBhvr stageBhvr = GameObject.FindObjectOfType(typeof(StageBhvr)) as StageBhvr;
      if( stageBhvr != null )
	{
	  map.resName = stageBhvr.materialName;
	}

      // walkable
      GameObject walkableGobj = GameObject.Find("walkable-grids");
      if( walkableGobj != null )
	{

	  MeshFilter mf = walkableGobj.GetComponent<MeshFilter>();
	  if(mf != null)
	    {
	      
	      int[] points = null;
	      Mesh mesh = mf.sharedMesh;
	      if(mesh != null) 
		{
		  points = MeshToArray.TranslateByXZ(mesh);
		  int columns = map.mapW / Grid.WIDTH;
		  int rows = map.mapH / Grid.HEIGHT;
		  int[,] pointMap = new int[rows, columns];
		  for(int i=0; i<pointMap.GetLength(0); i++)
		    {
		      for(int j=0; j<pointMap.GetLength(1); j++)
			{
			  pointMap[i,j] = 1;
			}
		    }
		  for(int i=0; i<points.Length; i+=2 )
		    {
		      pointMap[points[i+1],points[i]] = 0;
		    }

		  string[] roadRows = new string[pointMap.GetLength(0)];
		  for(int i=0; i<pointMap.GetLength(0); i++)
		    {
		      StringBuilder pointMapSb = new StringBuilder();
		      for(int j=0; j<pointMap.GetLength(1); j++)
			{
			  pointMapSb.Append(pointMap[i,j] + ",");
			}
		      roadRows[i] = pointMapSb.Remove(pointMapSb.Length-1,1).ToString();
		    }
		  
		  //dth.Road road = new dth.Road();
		  //road.rows = roadRows;
		  map.road = roadRows;

		}
	    }
	}


      // actors
      ActorBhvr[] actorBhvrs = GameObject.FindObjectsOfType( typeof(ActorBhvr) ) as ActorBhvr[];
      if( actorBhvrs != null )
	{
	  List<dth.Npc> npcs = new List<dth.Npc>();
	  List<dth.Monster> monsters = new List<dth.Monster>();
	  foreach( ActorBhvr actorBhvr in actorBhvrs )
	    {
	      if( actorBhvr.actorType == ActorType.npc )
		{
		  dth.Npc npc = new dth.Npc();
		  npc.uid = actorBhvr.baseId;
		  npc.posx = (int) actorBhvr.transform.localPosition.x;
		  npc.posy = -(int) actorBhvr.transform.localPosition.z;

		  SpriteAnimate spriteAnimate = actorBhvr.GetComponent<SpriteAnimate>();
		  if( spriteAnimate != null )
		    {
		      npc.resName = spriteAnimate.spriteAnimationPrefab.name;
		    }

		  npcs.Add( npc );
		  
		}
	      else if( actorBhvr.actorType == ActorType.monster )
		{

		  dth.Monster monster = new dth.Monster();
		  monster.monsterId = actorBhvr.baseId;

		  monster.posx = (int) actorBhvr.transform.localPosition.x;
		  monster.posy = -(int) actorBhvr.transform.localPosition.z;

		  SpriteAnimate spriteAnimate = actorBhvr.GetComponent<SpriteAnimate>();
		  if( spriteAnimate != null )
		    {
		      monster.resName = spriteAnimate.spriteAnimationPrefab.name;
		    } 
		  
		  monsters.Add( monster );
		  
		}
	    }

	  if( npcs.Count > 0 )
	    map.npc = npcs.ToArray();

	  if( monsters.Count > 0 )
	    map.monster = monsters.ToArray();
	}


      // door
      PortalBhvr[] portalBhvrs = GameObject.FindObjectsOfType( typeof(PortalBhvr) ) as PortalBhvr[];
      if( portalBhvrs != null )
	{
	  dth.Door[] doors = new dth.Door[portalBhvrs.Length];
	  for(int i=0; i< portalBhvrs.Length; i++)
	    {
	      doors[i] = new dth.Door();
	      Point grid = Grid.FromPosition(portalBhvrs[i].transform.localPosition);
	      doors[i].posx = grid.x;
	      doors[i].posy = grid.y;
	      doors[i].toMapId = portalBhvrs[i].destination.sceneId;
	      doors[i].toX = portalBhvrs[i].destination.grid.x;
	      doors[i].toY = portalBhvrs[i].destination.grid.y;
	      doors[i].uid = portalBhvrs[i].baseId;
	    }
	  map.door = doors;
	}

      string filepath = EditorUtility.SaveFilePanel("Save scene as XML",
						    "",
						    "map_" + sceneBhvr.sceneId + ".xml",
						    "xml");
      if( !String.IsNullOrEmpty(filepath) ) {
	XmlSerializer serializer = new XmlSerializer( typeof(dth.Map) );
	TextWriter writer = new StreamWriter(filepath);
	serializer.Serialize(writer, map);

      }

    }

    [ MenuItem( "TangScene/Build Android Scene ..." ) ]
    public static void BuildAndroidScene()
    {

      int count = 0 ;
      if( Selection.objects != null && Selection.objects.Length > 0)
	{
	  
	  count = Selection.objects.Length;
	  string[] levels = new string[count];

	  for(int i=0; i<count; i++)
	    {
	      levels[i] = AssetDatabase.GetAssetPath(Selection.objects[i]);
	    }

	  string filepath = EditorUtility.SaveFilePanel("Save scene",
							"",
							Selection.objects[0] + ".ab",
							"ab");
	  if( !String.IsNullOrEmpty( filepath ) ) 
	    {
	      BuildPipeline.BuildStreamedSceneAssetBundle( levels, filepath, BuildTarget.Android );
	    }
	}

    }


    [ MenuItem( "TangScene/Build Standalone Windows Scene ..." ) ]
    public static void BuildStandaloneWindowsScene()
    {

      int count = 0 ;
      if( Selection.objects != null && Selection.objects.Length > 0)
	{
	  
	  count = Selection.objects.Length;
	  string[] levels = new string[count];

	  for(int i=0; i<count; i++)
	    {
	      levels[i] = AssetDatabase.GetAssetPath(Selection.objects[i]);
	    }

	  string filepath = EditorUtility.SaveFilePanel("Save scene",
							"",
							Selection.objects[0] + ".ab",
							"ab");
	  if( !String.IsNullOrEmpty( filepath ) ) 
	    {
	      BuildPipeline.BuildStreamedSceneAssetBundle( levels, filepath, BuildTarget.StandaloneWindows );
	    }
	}

    }

    [ MenuItem( "TangScene/Build iPhone Scene ..." ) ]
    public static void BuildIPhoneScene()
    {

      int count = 0 ;
      if( Selection.objects != null && Selection.objects.Length > 0)
	{
	  
	  count = Selection.objects.Length;
	  string[] levels = new string[count];

	  for(int i=0; i<count; i++)
	    {
	      levels[i] = AssetDatabase.GetAssetPath(Selection.objects[i]);
	    }

	  string filepath = EditorUtility.SaveFilePanel("Save scene",
							"",
							Selection.objects[0] + ".ab",
							"ab");
	  if( !String.IsNullOrEmpty( filepath ) ) 
	    {
	      BuildPipeline.BuildStreamedSceneAssetBundle( levels, filepath, BuildTarget.iPhone );
	    }
	}

    }


    private static TsAnimation FromSpriteAnimation(SpriteAnimation spriteAnimation)
    {

      List<TsLayer> tsLayers = new List<TsLayer>();
      foreach(SpriteLayer spriteLayer in spriteAnimation.layers)
	{

	  string layerName = spriteLayer.name;
	  TASprite spritePrefab = null;
	  string spriteName = null;
	  if( spriteLayer.spritePrefab != null)
	    {
	      spritePrefab = spriteLayer.spritePrefab;
	      spriteName = spritePrefab.name;
	    }
	  if( !String.IsNullOrEmpty(layerName) && ! String.IsNullOrEmpty(spriteName) )
	    {

	      // layer
	      TsLayer tsLayer = new TsLayer();
	      tsLayer.name = layerName;

	      // sprite
	      TsSprite tsSprite = new TsSprite();
	      tsSprite.name = spriteName;
	      tsLayer.sprite = tsSprite;
	      
	      tsLayers.Add(tsLayer);
	    }
	}
      if( tsLayers.Count > 0 )
	{
	  TsAnimation animation = new TsAnimation();
	  animation.layers = tsLayers.ToArray();
	  animation.name = spriteAnimation.name;
	  return animation;
	} 
      else
	{
	  return null;	  
	}
    }
  }
}

