using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
using System.Globalization;

namespace s649_SmallResource
{
    [BepInPlugin(PluginDatas.GUID, PluginDatas.MOD_TITLE, PluginDatas.MOD_VERSION)]
    public class MainPlugin : BaseUnityPlugin
    {
        public static class PluginDatas
        {
            public const string GUID = "s649_SmallResource";
            public const string MOD_TITLE = "Small Resource";
            public const string MOD_VERSION = "0.0.0";
        }

        private void Start()
        {
            //LoadConfig();
            //new Harmony(this.GetType().Name).PatchAll();
            ChangeComponents("plank", new[] { "logSmall" });
            ChangeComponents("cutstone", new[] { "rockSmall" });
            ChangeComponents("brick", new[] { "claySmall" });
            ChangeComponents("glass", new[] { "fragmentSmall" });
        }
        private void ChangeComponents(string idThing, string[] comThings)
        {
            Debug.Log($"SR:Components:plank:{EClass.sources.things.map[idThing].components}");
            EClass.sources.things.map[idThing].components = comThings;
            Debug.Log($"SR:ChangeComponents:plank:{EClass.sources.things.map[idThing].components}");
        }
        /*
        private void LoadConfig() 
        {
        
        }
        */

    }
}
