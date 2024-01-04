using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ScriptParser : MonoBehaviour
{
    private static string NUM_PARSE = @"{[\d]*}";

    public static string Parse(string desc, int[] data)
    {
        string str = desc;
        MatchCollection mc = Regex.Matches(str, NUM_PARSE);

        foreach (Match m in mc)
        {
            string value = m.Value;
            //{1}
            int index = int.Parse(value.Trim('{').TrimEnd('}'));
            if (0 <= index && index < data.Length)
            {
                str = Regex.Replace(str, string.Concat("\\", value), data[index].ToString());
            }
        }
        return str;
    }
}

