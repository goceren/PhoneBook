using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Core.Enum
{
    public static class EnumExtensions
    {
        public static int GetEnumInteger(this System.Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length <= 0)
                return Convert.ToInt16(en);
            var attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);

            return attrs.Length > 0
                ? Convert.ToInt16(((Description)attrs[0]).Value)
                : Convert.ToInt16(en);
        }
    }



    public class Description : Attribute
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public Description(string text)
        {
            Text = text;
        }
        public Description(string text, int value)
        {
            Text = text;
            Value = value;
        }
    }
}
