using System;
using System.Collections;
using TangGame.View;
using System.IO;
using TangGame.Xml;

namespace TangGame
{
    /// 玩家名称
    public class NameCache
    {
        public static string[] familyName;
        public static string[] man;
        public static string[] woman;
        private const int SEX_MALE = 1;

        ///根据性别获取完成名称
        public static string GetName(int sex)
        {
            if (familyName == null)
            {
                return "";
            }
            string result = "";
            Random random = new Random();
            result = familyName[random.Next(familyName.Length)];
            if (IsMale(sex))
            { //男性
                result += man[random.Next(man.Length)];
            }
            else
            {
                result += woman[random.Next(woman.Length)];
            }
            result = result.Replace("\r", "");
            return result;
        }

        private static bool IsMale(int sex)
        {
            return sex == SEX_MALE;
        }
    }
}