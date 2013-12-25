using System;
using UnityEngine;
using TangGame;
/// <summary>
/// 技能显示面板
/// create by huxiaobo
/// 2013.11.14
/// </summary>
public class SkillItemPanel : MonoBehaviour
{
	public UISprite skillIcon;
	public UILabel levelLabel;
	public UILabel skillNameLabel;
	public UILabel upLevelLabel;
	public UISprite selectBorder;

	#region
  private int skillSort;
  public int SkillSort {
    get { return skillSort; }
    set { skillSort = value; }
  }
	//技能ID
	private int skillIndex;
	public int SkillIndex {
		get { return skillIndex; }
		set { skillIndex = value; }
	}
	//技能状态
	private int skillState;
	public int SkillState
	{
		get { return skillState; }
		set { skillState = value; }
	}
	#endregion

	void Start()
	{
		NGUITools.AddWidgetCollider(this.gameObject);
		this.SetSelected(false);
	}
	public void UpdateShow(string icon, string name, int level, string state, int sort)
	{

		GameObject prefab  = PrefabCache.getIconPrefabs(GameConsts.SKILL_ATLAS, GameConsts.SKILL_PATH);
		UIAtlas atlas = prefab.GetComponent<UIAtlas>();
		skillIcon.atlas = atlas;
		skillIcon.spriteName = icon.ToString();
		skillIcon.enabled = true;
		skillNameLabel.GetComponent<UILabel>().text = name;
		skillNameLabel.enabled = true;
		levelLabel.GetComponent<UILabel>().text = "Lv" + level;
		levelLabel.enabled = true;
		upLevelLabel.GetComponent<UILabel>().text = state;
		upLevelLabel.enabled = true;
		SkillSort = sort;
		skillIcon.enabled = true;
	}
	public void ClearData()
	{
		skillIcon.enabled = false;
		levelLabel.enabled = false;
		skillNameLabel.enabled = false;
		upLevelLabel.enabled = false;
		SkillIndex = 0;
	}
	public void SetSelected(bool bo)
	{
			selectBorder.GetComponent<UISprite>().enabled = bo;
	}
}