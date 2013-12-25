/**
 * Battle drop push
 *
 * Date: 2013/12/5
 * Author: zzc
 */

using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{

  /// <summary>
  ///   掉落条目
  /// </summary>
  public class DropItem
  {
    public int id;
    public int count;

    public static DropItem Parse(MsgData data)
    {
      DropItem item = new DropItem();
      item.id = data.GetInt(0);
      item.count = data.GetInt(1);
      return item;
    }
  }


  /// <summary>
  ///   掉落记录
  /// </summary>
  public class DropRecord
  {
    public short x;
    public short y;
    public List<DropItem> items;

    public static DropRecord Parse(MsgData data)
    {
      DropRecord record = new DropRecord();
      record.x = data.GetShort(0);
      record.y = data.GetShort(1);
      
      MsgData msgData = data.GetMsgData(2);
      List<DropItem> items = new List<DropItem>();
      for(int i=0; i<msgData.Size; i++ )
	{
	  items.Add( DropItem.Parse(msgData.GetMsgData(i)) );
	}

      return record;

    }


  }
  
  /// <summary>
  ///   战斗掉落推送
  /// </summary>
  [Response(NAME)]
  public class BattleDropPush : Response
  {
    
    public const string NAME = "battleDrop_PUSH";

    public byte tokenCode;

    public List<DropRecord> records;

    public BattleDropPush() : base(NAME)
    {
      
    }

    public static BattleDropPush Parse(MsgData data)
    {

      
      BattleDropPush push = new BattleDropPush();

      /*
      push.tokenCode = data.GetByte(0);


      List<DropRecord> records = new List<DropRecord>();

      MsgData msgData = data.GetMsgData(1);

      for( int i = 0; i < msgData.Size; i++ )
	{
	  records.Add( DropRecord.Parse(msgData.GetMsgData(i)) );
	}
      
      push.records = records;
      */

      return push;
    }

  }
  
}