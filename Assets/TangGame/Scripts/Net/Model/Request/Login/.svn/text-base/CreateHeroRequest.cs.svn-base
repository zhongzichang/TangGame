using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  public class CreateHeroRequest : Request
  {
    private string name;
    private short heroSex;
    private int heroTypeId;

    public CreateHeroRequest(string name, short heroSex, int heroTypeId)
    {
      this.name = name;
      this.heroSex = heroSex;
      this.heroTypeId = heroTypeId;
    }

    public NetData NetData {
      get {
        NetData data = new NetData(LoginProxy.S_CREATE_HERO);
        data.PutShort(heroSex); 
        data.PutString(name); 
        data.PutInt(heroTypeId); 
        return data;
      }
    }
  }
}
