using UnityEngine;
using System;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
public class HeroGoods
{

    public long heroId;

    public long id;

    public int goodsId;

    public int bindingHeroId;

    public short sum;

    public short durable;

    public short intensifyNum;

    public long destroyTime;

    public short index;

    public short hole;

    public int score;

    public long addExp;

  public long stoneUpExp;

    public List<Gem> gemList = new List<Gem>();

    public List<Effect> randomEffect = new List<Effect>();

    public List<Effect> addStoneEffect = new List<Effect>();

    public List<Effect> intensifyEffect = new List<Effect>();

    public List<Effect> additiveEffect = new List<Effect>();

    public short createOrDelType;

    public long time;

    public short useNum;

    public Goods goods;

    public bool isLock;

    public int luck;

    public long luckTime;

    //======
    public string horseName;
    public short horseLv;
    public short horseStage;
    public long horseUpExp;

    public static HeroGoods Parse(MsgData data)
    {
        //Debug.Log("===========================HeroGoods==================================");
        //Debug.Log("DataSize:"+data.Size);
        int index = 0;
        HeroGoods goods = new HeroGoods();
        goods.goodsId = data.GetInt(index++);
        goods.id = (long)data.GetDouble(index++);
        goods.bindingHeroId = (int)data.GetDouble(index++);
        goods.sum = data.GetShort(index++);
        goods.durable = data.GetShort(index++);
        goods.intensifyNum = data.GetShort(index++);
        goods.hole = data.GetShort(index++);
        //goods.gemList

        //Debug.Log("0");
        string gemListInfo = data.GetString(index++);
        goods.ParseGem(gemListInfo);

        string intensifyInfo = data.GetString(index++);
        goods.ParseEffect(intensifyInfo, goods.intensifyEffect);

        string otherAttributeInfo = data.GetString(index++);
        goods.ParseEffect(otherAttributeInfo, goods.additiveEffect);

        goods.index = data.GetShort(index++);
        //Debug.Log("1");
        string randomEffectListInfo = data.GetString(index++);
        goods.ParseEffect(randomEffectListInfo, goods.randomEffect);

        string addStoneEffectInfo = data.GetString(index++);
        goods.ParseEffect(addStoneEffectInfo, goods.addStoneEffect);

        goods.addExp = (long) data.GetDouble(index++);
        goods.stoneUpExp = (long) data.GetInt(index++);
	
        goods.score = data.GetInt(index++);
        goods.destroyTime = (long) data.GetDouble(index++);
        goods.luck = data.GetInt(index++);
        goods.luckTime = (long)data.GetDouble(index++);
        //Debug.Log("2");
        if(index < data.Size)
        {

            goods.horseName = data.GetString(index++);
            goods.horseLv = data.GetShort(index++);
            goods.horseStage = data.GetShort(index++);
            goods.horseUpExp = (long)data.GetDouble(index++);

        }
        return goods;
    }

    /// 解析属性值
    private void ParseEffect(string effectStr, List<Effect> list)
    {
        if(string.IsNullOrEmpty(effectStr))
        {
            return;
        }
        string[] effectArr = effectStr.Split(';');

        foreach(string str in effectArr)
        {
            if(string.IsNullOrEmpty(str))
            {
                continue;
            }
            string[] strArr = str.Split(',');
            Effect effect = new Effect();
            effect.type = (short)int.Parse(strArr[0]);
            effect.attribute1 = int.Parse(strArr[1]);
            if(strArr.Length > 2)
            {
                effect.attribute4 = int.Parse(strArr[2]);
            }
            list.Add(effect);
        }
    }

    /// 解析宝石
    private void ParseGem(string str)
    {
        if(string.IsNullOrEmpty(str))
        {
            return;
        }
        string[] strArr = str.Split(';');
        foreach(string gemStr in strArr)
        {
            if(string.IsNullOrEmpty(gemStr))
            {
                continue;
            }
            string[] gemStrArr = gemStr.Split(',');
            Gem gem = new Gem();
            int index = 0;
            gem.goods = int.Parse(gemStrArr[index++]);
            gem.name = gemStrArr[index++];
            int count = (int)((gemStrArr.Length - 2) / 2);
            for(int i = 0; i < count; i++)
            {
                int key = int.Parse(gemStrArr[index++]);
                int value = int.Parse(gemStrArr[index++]);
                gem.effectMap.Add(key, value);
            }
            this.gemList.Add(gem);
        }
    }
}
}

