using System;

namespace TangGame.View
{
	public class Skill
	{
		
		public const int BASE_ATTACK_ID = 0;
		public const int BASE_ATTACK_ACTION_ID = 1;
		public const string BASE_ATTACK_NAME = "base";
		
		public const int HZHX_ID = 11;
		public const int HDXBR_ID = 12;
		public const int HKGX_ID = 13;
		public const int HRPFY_ID = 14;
		public const int HTJHG_ID = 15;
		
		public const int KXLN_ID = 21;
		public const int KCDRQ_ID = 22;
		public const int KCFPL_ID = 23;
		public const int KYKPS_ID = 24;
		public const int KYZLZ_ID = 25;
		
		public const int SSXM_ID = 31;
		public const int SJRYD_ID = 32;
		public const int SJZLW_ID = 33;
		public const int SLYQF_ID = 34;
		public const int STDKJ_ID = 35;
		
		public const int HZHX_ACTION_ID = 1;
		public const int HDXBR_ACTION_ID = 2;
		public const int HKGX_ACTION_ID = 3;
		public const int HRPFY_ACTION_ID = 3;
		public const int HTJHG_ACTION_ID = 3;
		
		public const int KXLN_ACTION_ID = 1;
		public const int KCDRQ_ACTION_ID = 2;
		public const int KCFPL_ACTION_ID = 3;
		public const int KYKPS_ACTION_ID = 3;
		public const int KYZLZ_ACTION_ID = 3;
		
		public const int SSXM_ACTION_ID = 1;
		public const int SJRYD_ACTION_ID = 2;
		public const int SJZLW_ACTION_ID = 3;
		public const int SLYQF_ACTION_ID = 3;
		public const int STDKJ_ACTION_ID = 3;
		
		public const string HZHX_NAME = "hzhx";
		public const string HDXBR_NAME = "hdxbr";
		public const string HKGX_NAME = "hkgx";
		public const string HRPFY_NAME= "hrpfy";
		public const string HTJHG_NAME = "htjhg";
		
		public const string KXLN_NAME = "kxln";
		public const string KCDRQ_NAME = "kcdrq";
		public const string KCFPL_NAME = "kcfpl";
		public const string KYKPS_NAME = "kykps";
		public const string KYZLZ_NAME = "kyzlz";
		
		public const string SSXM_NAME = "ssxm";
		public const string SJRYD_NAME = "sjryd";
		public const string SJZLW_NAME = "sjzlw";
		public const string SLYQF_NAME = "slyqf";
		public const string STDKJ_NAME = "stdkj";
		
		public int Id {
			get;
			private set;
		}
		
		public string Name {
			get;
			private set;
		}
		
		public int ActionId {
			get;
			private set;
		}
		
		//public SkillEffect effect;
		
		public float EffectiveRadius = 80F;
		
		private Skill (int id)
		{
			this.Id = id;
		}
		
		private static Skill baseAttack = null;
		public static Skill BaseAttack {
			get{
				if(baseAttack == null){
					baseAttack = new Skill(Skill.BASE_ATTACK_ID);
					baseAttack.Name = BASE_ATTACK_NAME;
					baseAttack.ActionId = BASE_ATTACK_ACTION_ID;
					//baseAttack.effect = null;
				}
				return baseAttack;
			}
		}
		
		// ---- halberd ---- 
		private static Skill hzhx = null;
		public static Skill HZHX{
			get {
				if(hzhx == null){
					hzhx = new Skill(Skill.HZHX_ID);
					hzhx.Name = Skill.HZHX_NAME;
					hzhx.ActionId = Skill.HZHX_ACTION_ID;
					//hzhx.effect = SkillEffect.HZHX;
				}
				return hzhx;
			}
		}
		
		private static Skill hdxbr = null;
		public static Skill HDXBR{
			get {
				if(hdxbr == null){
					hdxbr = new Skill(Skill.HDXBR_ID);
					hdxbr.Name = Skill.HDXBR_NAME;
					hdxbr.ActionId = Skill.HDXBR_ACTION_ID;
					//hdxbr.effect = SkillEffect.HDXBR;
				}
				return hdxbr;
			}
		}
		
		private static Skill hkgx = null;
		public static Skill HKGX{
			get {
				if(hkgx == null){
					hkgx = new Skill(Skill.HKGX_ID);
					hkgx.Name = Skill.HKGX_NAME;
					hkgx.ActionId = Skill.HKGX_ACTION_ID;
					//hkgx.effect = SkillEffect.HKGX;
				}
				return hkgx;
			}
		}
		
		private static Skill hrpfy = null;
		public static Skill HRPFY{
			get{
				if(hrpfy == null){
					hrpfy = new Skill(Skill.HRPFY_ID);
					hrpfy.Name = Skill.HRPFY_NAME;
					hrpfy.ActionId = Skill.HRPFY_ACTION_ID;
					//hrpfy.effect = SkillEffect.HRPFY;
				}
				return hrpfy;
			}
		}
		
		private static Skill htjhg = null;
		public static Skill HTJHG {
			get{
				if(htjhg == null){
					htjhg = new Skill(Skill.HTJHG_ID);
					htjhg.Name = Skill.HTJHG_NAME;
					htjhg.ActionId = Skill.HTJHG_ACTION_ID;
					//htjhg.effect = SkillEffect.HTJHG;
				}
				return htjhg;
			}
		}
		
		
		// ---- knife ----
		
		private static Skill kxln = null;
		public static Skill KXLN {
			get {
				if(kxln == null){
					kxln = new Skill(Skill.KXLN_ID);
					kxln.Name = Skill.KXLN_NAME;
					kxln.ActionId = Skill.KXLN_ACTION_ID;
					//kxln.effect = SkillEffect.KXLN;
				}
				return kxln;
			}
		}
		
		private static Skill kcdrq = null;
		public static Skill KCDRQ {
			get {
				if(kcdrq == null){
					kcdrq = new Skill(Skill.KCDRQ_ID);
					kcdrq.Name = Skill.KCDRQ_NAME;
					kcdrq.ActionId = Skill.KCDRQ_ACTION_ID;
					//kcdrq.effect = SkillEffect.KCDRQ;
				}
				return kcdrq;
			}
		}
		
		private static Skill kcfpl = null;
		public static Skill KCFPL {
			get {
				if(kcfpl == null){
					kcfpl = new Skill(Skill.KCFPL_ID);
					kcfpl.Name = Skill.KCFPL_NAME;
					kcfpl.ActionId = Skill.KCFPL_ACTION_ID;
					//kcfpl.effect = SkillEffect.KCFPL;
				}
				return kcfpl;
			}
		}
		private static Skill kykps = null;
		public static Skill KYKPS {
			get {
				if(kykps == null){
					kykps = new Skill(Skill.KYKPS_ID);
					kykps.Name = Skill.KYKPS_NAME;
					kykps.ActionId = Skill.KYKPS_ACTION_ID;
					//kykps.effect = SkillEffect.KYKPS;
				}
				return kykps;
			}
		}
		private static Skill kyzlz = null;
		public static Skill KYZLZ {
			get {
				if(kyzlz == null){
					kyzlz = new Skill(Skill.KYZLZ_ID);
					kyzlz.Name = Skill.KYZLZ_NAME;
					kyzlz.ActionId = Skill.KYZLZ_ACTION_ID;
					//kyzlz.effect = SkillEffect.KYZLZ;
				}
				return kyzlz;
			}
		}
		
		// ---- sword ----
		
		private static Skill ssxm = null;
		public static Skill SSXM {
			get {
				if(ssxm == null){
					ssxm = new Skill(Skill.SSXM_ID);
					ssxm.Name = Skill.SSXM_NAME;
					ssxm.ActionId = Skill.SSXM_ACTION_ID;
					//ssxm.effect = SkillEffect.SSXM;
				}
				return ssxm;
			}
		}
		
		private static Skill sjryd = null;
		public static Skill SJRYD {
			get {
				if(sjryd == null){
					sjryd = new Skill(Skill.SJRYD_ID);
					sjryd.Name = Skill.SJRYD_NAME;
					sjryd.ActionId = Skill.SJRYD_ACTION_ID;
					//sjryd.effect = SkillEffect.SJRYD;
				}
				return sjryd;
			}
		}
		
		private static Skill sjzlw = null;
		public static Skill SJZLW {
			get{
				if(sjzlw == null){
					sjzlw = new Skill(Skill.SJZLW_ID);
					sjzlw.Name = Skill.SJZLW_NAME;
					sjzlw.ActionId = Skill.SJZLW_ACTION_ID;
					//sjzlw.effect = SkillEffect.SJZLW;
				}
				return sjzlw;
			}
		}
		private static Skill slyqf = null;
		public static Skill SLYQF {
			get {
				if(slyqf == null){
					slyqf = new Skill(Skill.SLYQF_ID);
					slyqf.Name = Skill.SLYQF_NAME;
					slyqf.ActionId = Skill.SLYQF_ACTION_ID;
					//slyqf.effect = SkillEffect.SLYQF;
				}
				return slyqf;
			}
		}
		
		private static Skill stdkj = null;
		public static Skill STDKJ {
			get {
				if(stdkj == null){
					stdkj = new Skill(Skill.STDKJ_ID);
					stdkj.Name = Skill.STDKJ_NAME;
					stdkj.ActionId = Skill.STDKJ_ACTION_ID;
					//stdkj.effect = SkillEffect.STDKJ;
				}
				return stdkj;
			}
		}
	}
}

