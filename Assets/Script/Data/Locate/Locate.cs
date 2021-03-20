using Assets.Script.Enumerator;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Locate : MonoBehaviour
{
    public static IniData Translate { get; private set; }
    private const string LOCATE_PATH = @".\Assets\Script\Data\Locate\";

    public static void LoadLocate(Language language)
    {
        try
        {
            string path;
            switch (language)
            {
                case Language.BR:
                    path = @"pt\pt-br";
                    break;

                case Language.EN:
                    path = @"en\en-us";
                    break;

                default:
                    path = @"pt\pt-br";
                    break;
            }

            Translate = ReadIni(path);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            throw;
        }
    }

    private static IniData ReadIni(string path)
    {
        var parser = new FileIniDataParser();
        return parser.ReadFile($"{LOCATE_PATH}{path}.ini");
    }
}