using UnityEngine;
using System.Collections;
using TangGame.Xml;

namespace TangGame
{
  public class LoginPanelCache
  {
    private static long heroId = 0; 

    public static long HeroId {
      get { return heroId; }
      set { heroId = value; }
    }

    private static short heroSex = HERO_MALE;

    public static short HeroSex {
      get { return heroSex; }
      set { heroSex = value; }
    }

    private static string errorMessage = "";

    public static string ErrorMessage {
      get { return errorMessage; }
      set { errorMessage = value; }
    }

    private static string username = "";

    public static string Username {
      get { return username; }
      set { username = value; }
    }

    private static string password = "";

    public static string Password {
      get { return password; }
      set { password = value; }
    }

    private const int HERO_MALE = 1; // 男
    private const int HERO_FEMALE = 2;  // 女
    // config/HeroInitialize.xml
    private const int HERO_ID_1 = 100001; // 狂战
    private const int HERO_ID_2 = 100002; // 飞羽
    private const int HERO_ID_3 = 100003; // 舞天
    private const int HERO_ID_4 = 100004; // 冰凝

    private static int heroType = HERO_ID_1;
    
    public static int HeroType {
      get { return heroType; }
      set { heroType = value; }
    }
    
    public static int HeroTypeId{
      get { return heroType - 100000;}
    }

    public static void UpdateHeroType (string name)
    {
      if (name == "Box1") {
        HeroType = HERO_ID_1; 		
      } else if (name == "Box2") {
        HeroType = HERO_ID_2; 	
      } else if (name == "Box3") {
        HeroType = HERO_ID_3; 	
      } else if (name == "Box4") {
        HeroType = HERO_ID_4; 	
      }
    }

    public static void UpdateHeroSex (string name)
    {
      if (name == "Male") {
        HeroSex = HERO_MALE;
      } else {
        HeroSex = HERO_FEMALE; 	
      }
    }

    public static HeroInitialize GetHeroInfo ()
    {
      return Config.heroInitializeTable [HeroTypeId.ToString()];
    }

    public static string GetHeroImageName ()
    {
      if (HeroSex == HERO_MALE) {
        if (HeroType == HERO_ID_1) {
          return "role_lyg_m";
        } else if (HeroType == HERO_ID_2) {
          return "role_qjl_m";
        } else {
          return "role_xlk_m";
        }
      } else {
        if (HeroType == HERO_ID_1) {
          return "role_lyg_f";
        } else if (HeroType == HERO_ID_2) {
          return "role_qjl_f";
        } else {
          return "role_xlk_f";
        }
      }
    }
  }
}
