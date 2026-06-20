using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using HarmonyLib;
using UnityEngine;
using BepInEx;
//using BepInEx.Configuration;
//using System.Globalization;

namespace s649_SmallResource
{
    [BepInPlugin(PluginDatas.GUID, PluginDatas.MOD_TITLE, PluginDatas.MOD_VERSION)]
    public class MainPlugin : BaseUnityPlugin
    {
        public static class PluginDatas
        {
            public const string GUID = "s649_SmallResource";
            public const string MOD_TITLE = "Small Resource";
            public const string MOD_VERSION = "0.2";
        }

        private void Start()
        {
            //LoadConfig();
            //new Harmony(this.GetType().Name).PatchAll();
            ChangeComponents("plank", new[] { "log_small" });
            ChangeComponents("cutstone", new[] { "rock_small" });
            ChangeComponents("brick", new[] { "clay_small" });
            ChangeComponents("glass", new[] { "fragment_small" });
            ShowCompo("figure");
            ShowCompo("figure2");
            ChangeComponents("figure", new[] { "log_small" });
            ChangeComponents("figure2", new[] { "log_small" });
            //ShowCompo("potion_empty");
            //ChangeComponents("potion_empty", new[] { "glass/1", "log@carbone/1|logSmall" });
        }
        private void ChangeComponents(string idThing, string[] comThings)
        {
            //ShowCompo(idThing);
            EClass.sources.things.map[idThing].components = comThings;
            ShowCompo(idThing);
        }
        private void ShowCompo(string idThing) 
        {
            string text;// = string.Join(", ", comThings);
            text = string.Join(", ", EClass.sources.things.map[idThing].components);
            Debug.Log($"SR:Components:{idThing}:{text}");
        }
        /*
        private void LoadConfig() 
        {
        
        }
        */

    }
}
