using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangGame.Xml
{
//	<value>
//		<id>30182</id>
//		<name>再次打击</name>
//		<type>302</type>
//		<next_task>30183</next_task>
//		<obtainCond>30181,301,0</obtainCond>
//		<accept_npc>9120</accept_npc>
//		<return_npc>1167</return_npc>
//		<note>刚才高仙芝传书给我，叫我让人快去告诉首领，我们的援军就快到了，你去的路上展现一下你的威风，消灭一些步兵吧。</note>
//		<complete_note>有了你们的帮助，我就放心了，你再去打击一下他们的士气。</complete_note>
//		<pre>1$在#T%坦驹岭#C%消灭</pre><!--未完成追踪-->
//		<condition>1,667,小勃律步兵,201,35,25#6045#2222</condition><!--未完成追踪-->
//		<award>0,104,390000;0,105,500;0,107,1400</award>
//		<u_g_desc>向#T%坦驹岭#C%的#9%9120#G%李怀忠#E%#F%11#G%#I%#E%询问他手下军队的情况吧。</u_g_desc><!--未接描述-->
//		<u_desc>消灭35个#A%25,6045,2222#G%小勃律步兵#E%#F%1#G%#I%#E%吧</u_desc><!--未完成描述-->
//		<c_desc>向#T%坦驹岭#C%的#9%1167#G%首领#E%#F%12#G%#I%#E%询问他手下军队的情况吧。</c_desc><!--完成描述-->
//		<g_track>前往#T%坦驹岭#C%寻找#9%9120#G%李怀忠#E% #F%11#G%#I%#E%<g_track><!--未接追踪-->
//		<c_track>前往#T%坦驹岭#C%寻找#9%1167#G%首领#E% #F%12#G%#I%#E%</c_track><!--已完成追踪-->
//		<scene>0</scene>
//		<continue_time>0</continue_time>
//		<finish_num>0</finish_num>
//		<cd_time>0</cd_time>
//		<reward>0</reward>
//		<accept_time>0</accept_time>
//		<return_time>0</return_time>
//		<limit_leve>38</limit_leve>
//		<version>1</version>
//		<starlevel>0</starlevel>
//		<refreshType>0</refreshType>
//		<levelStr>0</levelStr>
//		<starType>0</starType>
//		<mia_complete>0</mia_complete>
//		<other_coin>0</other_coin>
//		<fly>11,25,125,182;1,25,201,148;12,25,211,128</fly>
//	</value>

public class TaskOld
{
    public int id;
    public string name;
    public int type;
    public string next_task;
    public string obtainCond;
    public int accept_npc;
    public int return_npc;
    public string note;
    public string complete_note;
    public string pre;
    public string condition;
    public string award;//已接追踪
    public string s_award;
    public string need_good;
    public string fly;
    public string u_g_desc;//未接描述
    public string u_desc;//未完成描述
    public string c_desc;//完成描述
    public string g_track;//未接追踪
    public string c_track;//完成追踪
    public int scene;
    public int continue_time;
    public int finish_num;
    public int cd_time;
    public int reward;
    public int accept_time;
    public int return_time;
    public string taskTip;
    public int limit_leve;
    public int is_del;
    public int version;
    public string task_goods;
    public int starlevel;
    public int refreshType;
    public string levelStr;
    public int starType;
    public int mia_complete;
    public int starLevel;
    public string starLink;
    public int other_coin;
    public string other_reward;
}

[XmlRoot("root")]
public class TaskRootOld
{
    [XmlElement("value")]
    public List<TaskOld> items = new List<TaskOld>();
}
}

