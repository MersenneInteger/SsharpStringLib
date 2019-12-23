using System;
using System.Text;
using Crestron.SimplSharp;// For Basic SIMPL# Classes

namespace SsharpStringLib
{
    public class StringLib
    {
        public delegate void CallbackHandler(SimplSharpString str, ushort index);
        public CallbackHandler CallbackEvent { set; get; }

        /// <summary>
        /// SIMPL+ can only execute the default constructor. If you have variables that require initialization, please
        /// use an Initialize method
        /// </summary>
        public StringLib()
        {

        }
        /// <summary>
        /// compare strings, return 0 if strings have same position 
        /// in the sort order, return 1 if str1 is less than str2, 
        /// return -1 if str1 is greater than str2
        /// </summary>
        /// <param name="str1">string</param>
        /// <param name="str2">string</param>
        /// <returns>short</returns>
        public short Compare(string str1, string str2)
        {
            return (short)str1.CompareTo(str2);
        }

        /// <summary>
        /// return 1 if str contains subStr as a substring, return 0 if not
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="subStr">string</param>
        /// <returns>ushort</returns>
        public ushort Contains(string str, string subStr)
        {
            return (ushort)(str.Contains(subStr) ? 1 : 0);
        }

        /// <summary>
        /// return 1 if strings are equal (case-sensitive) or 0 if not
        /// </summary>
        /// <param name="str1">string</param>
        /// <param name="str2">string</param>
        /// <returns>ushort</returns>
        public ushort Equals(string str1, string str2)
        {
            return (ushort)(str1.Equals(str2) ? 1 : 0);
        }

        /// <summary>
        /// return index of ch within str
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public ushort IndexOf(string str, string ch)
        {
            return (ushort)str.IndexOf(ch);
        }

        /// <summary>
        /// insert ch in str starting at pos
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="ch">string</param>
        /// <param name="pos">ushort</param>
        /// <returns>string</returns>
        public string InsertString(string str, string ch, ushort pos)
        {
            if (pos >= str.Length)
            {
                ErrorLog.Error("Invalid index given in InsertString");
                return str;
            }
            return str.Insert(pos, ch);
        }

        /// <summary>
        /// remove char or string starting at index up to count
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="index">ushort</param>
        /// <param name="count">ushort</param>
        /// <returns>string</returns>
        public string RemoveString(string str, ushort index, ushort count)
        {
            if ((count + index) >= str.Length)
            {
                ErrorLog.Error("Invalid index given in RemoveString");
                return str;
            }
            return str.Remove(index, count);
        }

        /// <summary>
        /// replace oldStr with newStr in str
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="oldStr">string</param>
        /// <param name="newStr">string</param>
        /// <returns>string</returns>
        public string ReplaceString(string str, string oldStr, string newStr)
        {
            if (str.Contains(oldStr))
                return str.Replace(oldStr, newStr);
            else
            {
                ErrorLog.Error("Error in ReplaceString. {0} not found in {1}.", oldStr, str);
                return str;
            }
        }

        /// <summary>
        /// return substring given start and length
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="start">ushort</param>
        /// <param name="length">ushort</param>
        /// <returns>string</returns>
        public string SubString(string str, ushort start, ushort length)
        {
            if ((start + length) < str.Length)
                return str.Substring(start, length);
            else
            {
                ErrorLog.Error("Error in SubString. Invalid starting or length value");
                return str;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="delim"></param>
        /// <returns>string</returns>
        public void SplitString(string str, string delim)
        {
            var strings = str.Split(delim.ToCharArray());
            SimplSharpString[] splitStrs = new SimplSharpString[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                splitStrs[i] = (SimplSharpString)strings[i];
                CallbackEvent(splitStrs[i], (ushort)i);
            }
        }

        /// <summary>
        /// Trim whitspace from beginning and end of string
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public string TrimString(string str)
        {
            return str.Trim();
        }
    }
}
