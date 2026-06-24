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
            public const string MOD_VERSION = "0.5";
        }

        private void Start()
        {
            //LoadConfig();
            //new Harmony(this.GetType().Name).PatchAll();
            //LogRecipes("log");
            //LogRecipes("rock");
            //LogRecipes("brick");
            //LogRecipes("fragment");
            SetRecipes("log", new[] { "*" }, new[] { "workbench" }, new[] { "log_small", "log_small", "s649_binding" });
            SetRecipes("rock", new[] { "*" }, new[] { "workbench" }, new[] { "rock_small", "rock_small", "s649_binding" });
            SetRecipes("clay", new[] { "*" }, new[] { "workbench" }, new[] { "clay_small", "clay_small", "s649_binding" });
            SetRecipes("fragment", new[] { "*" }, new[] { "workbench" }, new[] { "fragment_small", "fragment_small", "s649_binding" });
            ChangeComponents("plank", new[] { "log_small" });
            ChangeComponents("cutstone", new[] { "rock_small" });
            ChangeComponents("brick", new[] { "clay_small" });
            ChangeComponents("glass", new[] { "fragment_small" });
            //ShowCompo("figure");
            //ShowCompo("figure2");
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
        private void LogRecipes(string idThing)
        {
            string[] texts;// = string.Join(", ", comThings);
            texts = new[]
            {
                string.Join(", ", EClass.sources.things.map[idThing].recipeKey),
                string.Join(", ", EClass.sources.things.map[idThing].factory),
                string.Join(", ", EClass.sources.things.map[idThing].components),
            };
            Debug.Log($"SR:info:{idThing}:{string.Join("/", texts)}");
        }
        private void SetRecipes(string idThing, string[] recipeKey = null, string[] factory = null, string[] compo = null)
        {
            if (recipeKey != null) EClass.sources.things.map[idThing].recipeKey = recipeKey;
            if (factory != null) EClass.sources.things.map[idThing].factory = factory;
            if (compo != null) EClass.sources.things.map[idThing].components = compo;
            LogRecipes(idThing);
        }
        /*
        private void LoadConfig() 
        {
        
        }
        */

    }
}
