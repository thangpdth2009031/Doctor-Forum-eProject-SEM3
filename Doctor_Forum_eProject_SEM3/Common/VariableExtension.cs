using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Common
{
    public class VariableExtension
    {
    }
    public class SelectListModel
    {
        public object Key { get; set; }
        public string Value { get; set; }
    }
    public static class GenderKey
    {
      /*  public const int Male = 1;
        public const int FeMale = 0;*/

        public static List<SelectListModel> GetDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key=1,Value="Male" },
                new SelectListModel{Key=0,Value="Female" }
            };
        }

        public static string GetEmployeeType(int type)
        {
            switch (type)
            {
                case 0:
                    return "Female";

                case 1:
                    return "Male";

                default:
                    return "Unknown";
            }
        }
    }

    public static class TypePost
    {
     /*   public const int News = 0;
        public const int Question = 1;        
        public const int Posts = 2;
        public const int Knowledge = 3;
*/

        public static List<SelectListModel> ListTypePost()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key=0,Value="News" },
                new SelectListModel{Key=1,Value="Question" },                
                new SelectListModel{Key=2,Value="Posts" },
                new SelectListModel{Key=3,Value="Knowledge" }
            };
        }

        public static string GetTypePost(int type)
        {
            switch (type)
            {
                case 0:
                    return "News";
                case 1:
                    return "Question";
                case 2:
                    return "Posts";
                case 3:
                    return "Knowledge";
                default:
                    return "Posts";
            }
        }
    }
}