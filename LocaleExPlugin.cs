using BepInEx;
using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace CDT.Valheim.LocaleEx
{
    [BepInPlugin(GUID: PLUGIN_GUID, Name: PLUGIN_NAME, Version: PLUGIN_VERSION)]
    public class LocaleExPlugin : BaseUnityPlugin
    {
        const string PLUGIN_GUID = "CDT.Valheim.LocaleEx";
        const string PLUGIN_NAME = "CDT.Valheim.LocaleEx";
        const string PLUGIN_VERSION = "1.0.0";

        internal static LocaleExPlugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            PatchLocalization();

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");
        }

        Localization LocalizationInstance => Localization.instance;

        Dictionary<string, string> LocalizationInstance__m_translations => typeof(Localization)
            .GetField("m_translations", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.GetValue(LocalizationInstance) as Dictionary<string, string>;

        LocalizationSettings LocalizationClass__m_localizationSettings => typeof(Localization)
            .GetField("m_localizationSettings", BindingFlags.Static | BindingFlags.NonPublic)
            ?.GetValue(null) as LocalizationSettings;

        private void PatchLocalization()
        {
            if (!Directory.Exists("locales")) Directory.CreateDirectory("locales");

            var playerSettingLanguage = PlayerPrefs.GetString("language", "");
            PlayerPrefs.DeleteKey("language");

            var gameLanguages = LocalizationInstance.GetLanguages();

            DumpRawCsvLangFiles();

            DumpDefauldLanguageDictionary();

            LoadCustomLocale("English");

            LoadCustomLanguages(gameLanguages);

            ApplyPatch();

            if (playerSettingLanguage != "")
            {
                PlayerPrefs.SetString("language", playerSettingLanguage);
                LocalizationInstance.SetupLanguage(playerSettingLanguage);
            }
        }

        private void DumpRawCsvLangFiles()
        {
            if (LocalizationClass__m_localizationSettings is LocalizationSettings m_localizationSettings)
            {
                if (!Directory.Exists("locales/raw")) Directory.CreateDirectory("locales/raw");

                foreach(var textAsset in m_localizationSettings.Localizations)
                {
                    File.WriteAllText($"locales/raw/{textAsset.name}.csv", textAsset.text);
                }
            }
        }

        private void DumpDefauldLanguageDictionary()
        {
            if (LocalizationInstance__m_translations is Dictionary<string, string> m_translations)
            {
                File.WriteAllText($"locales/default.json", JsonConvert.SerializeObject(m_translations, Formatting.Indented));
            }
        }

        // template: locale\\lang_Vietnamese.json
        Regex LocaleExMatcher = new Regex("^locales\\\\lang_(.*).json$");

        private void LoadCustomLanguages(List<string> gameLanguages)
        {
            foreach (var langFilename in Directory.GetFiles("locales"))
            {

                if (LocaleExMatcher.Match(langFilename) is Match match && match.Groups.Count == 2 && match.Groups[1]?.Value is string langName)
                {
                    gameLanguages.Add(langName);
                }
            }
        }
        private void ApplyPatch()
        {
            new Harmony(PLUGIN_GUID).Patch(
                AccessTools.Method(typeof(Localization), nameof(Localization.SetupLanguage))
                , postfix: new HarmonyMethod(typeof(LocaleExPlugin), nameof(SetupLanguage_postfix))
            );
        }

        private static void SetupLanguage_postfix(string language)
        {
            LoadCustomLocale(language);
        }

        private static void LoadCustomLocale (string language)
        {
            if (Instance.LocalizationInstance__m_translations is Dictionary<string, string> m_translations)
            {
                if (File.Exists("locales/common.json"))
                {
                    try
                    {
                        if (JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("locales/common.json")) is Dictionary<string, string> dict)
                        {
                            foreach (var kv in dict)
                            {
                                m_translations[kv.Key] = kv.Value;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Instance.Logger.LogError(ex);
                    }
                }

                if (File.Exists($"locales/lang_{language}.json"))
                {
                    try
                    {
                        if (JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText($"locales/lang_{language}.json")) is Dictionary<string, string> dict)
                        {
                            foreach (var kv in dict)
                            {
                                m_translations[kv.Key] = kv.Value;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Instance.Logger.LogError(ex);
                    }
                }

                Instance.Logger.LogInfo($"Patch custom locale for ({language})");

            }
        }
    }
}
