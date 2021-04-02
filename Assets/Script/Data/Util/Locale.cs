using Assets.Script.Enumerator;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Locale : MonoBehaviour
{
    public static IniData Translate { get; private set; }
    private const string LOCALE_PATH = @".\Assets\Resources\Locale\";

    public static void LoadLocate(Language language)
    {
        try
        {
            string path;
            switch (language)
            {
                case Language.BR:
                    path = @"pt-BR";
                    break;

                case Language.EN:
                    path = @"en-US";
                    break;

                default:
                    path = @"pt-BR";
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
        return parser.ReadFile($"{LOCALE_PATH}{path}.ini");
    }
}