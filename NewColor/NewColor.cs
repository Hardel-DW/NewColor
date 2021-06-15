using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using UnhollowerBaseLib;
using static HardelAPI.Utility.HatsCreator;
using HardelAPI.Utility.Helper;
using HardelAPI.Utility;
using HardelAPI.Utility.Utils;
using HardelAPI.Reactor;
using static HardelAPI.Utility.Helper.ColorHelper;

namespace NewColor
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(HardelAPI.HardelApiPlugin.Id)]

    public class NewColor : BasePlugin
    {
        public const string Id = "fr.evan.newcolor";
        public static ManualLogSource Logger;

        public Harmony Harmony { get; } = new Harmony(Id);


        public override void Load(){
            
            Logger = Log;
            Harmony.PatchAll();
            AddColor();
            AddHat();
        }


        private void AddColor()
        {
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Dark Red",
                shortname = "Dark Red",
                color = new Color32(156, 25, 25, byte.MaxValue),
                shadow = new Color32(80, 0, 0, byte.MaxValue),
                isLighterColor = false
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Yellow",
                shortname = "Yellow",
                color = new Color32(255, 221, 18, byte.MaxValue),
                shadow = new Color32(179, 145, 0, byte.MaxValue),
                isLighterColor = true
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Light Blue",
                shortname = "Light Blue",
                color = new Color32(0, 172, 237, byte.MaxValue),
                shadow = new Color32(0, 92, 161, byte.MaxValue),
                isLighterColor = true
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Light Rose",
                shortname = "Light Rose",
                color = new Color32(242, 198, 209, byte.MaxValue),
                shadow = ColorHelper.Shadow(new Color32(242, 198, 209, byte.MaxValue)),
                isLighterColor = true
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Turquoise",
                shortname = "Turquoise",
                color = new Color32(22, 132, 176, byte.MaxValue),
                shadow = new Color32(15, 89, 117, byte.MaxValue),
                isLighterColor = false
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Gray",
                shortname = "Gray",
                color = new Color32(175, 175, 175, byte.MaxValue),
                shadow = ColorHelper.Shadow(new Color32(175, 175, 175, byte.MaxValue)),
                isLighterColor = true
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Black",
                shortname = "Black",
                color = new Color32(30, 30, 30, byte.MaxValue),
                shadow = new Color32(10, 10, 10, byte.MaxValue),
                isLighterColor = false
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "White",
                shortname = "White",
                color = new Color32(240, 240, 240, byte.MaxValue),
                shadow = ColorHelper.Shadow(new Color32(240, 240, 240, byte.MaxValue)),
                isLighterColor = true
            });
            ColorHelper.AddColor(new CustomColor
            {
                longname = "Dark Green",
                shortname = "Dark Green",
                color = new Color32(15, 89, 7, byte.MaxValue),
                shadow = new Color32(5, 30, 0, byte.MaxValue),
                isLighterColor = true
            });
        }

        private void AddHat()
        {
            Assembly _assembly;
            _assembly = Assembly.GetExecutingAssembly();
            List<string> filenames = new List<string>();
            filenames = _assembly.GetManifestResourceNames().ToList<string>();
            List<string> HatFiles = new List<string>();
            for (int i = 0; i < filenames.Count(); i++)
            {
                string[] items = filenames.ToArray();
                if (items[i].ToString().EndsWith(".png"))
                {
                    HatFiles.Add(items[i].ToString());
                }
            }
            foreach (var hat in HatFiles)
            {
                CreateHats(new HatData { sprite = CreateSprite(hat), bounce = false, highUp = false, offset = new Vector2(0f, 0.1f), author = "JeffLeBg", name = hat });

            }
        }

        public static Sprite CreateSprite(string name, bool hat = true)
        {
            var pixelsPerUnit = hat ? 225f : 100f;
            var pivot = hat ? new Vector2(0.5f, 0.8f) : new Vector2(0.5f, 0.5f);

            var assembly = Assembly.GetExecutingAssembly();
            var tex = UIUtils.CreateEmptyTexture();
            var imageStream = assembly.GetManifestResourceStream(name);
            var img = imageStream.ReadFully();
            LoadImage(tex, img, true);
            tex.DontDestroy();
            var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, (float)tex.width, (float)tex.height), pivot, pixelsPerUnit);
            sprite.DontDestroy();
            return sprite;
        }

        private static void LoadImage(Texture2D tex, byte[] data, bool markNonReadable)
        {
            _iCallLoadImage ??= IL2CPP.ResolveICall<DLoadImage>("UnityEngine.ImageConversion::LoadImage");
            var il2CPPArray = (Il2CppStructArray<byte>)data;
            _iCallLoadImage.Invoke(tex.Pointer, il2CPPArray.Pointer, markNonReadable);
        }

        private delegate bool DLoadImage(IntPtr tex, IntPtr data, bool markNonReadable);

        private static DLoadImage _iCallLoadImage;

    }

    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionShowerPatch
    {
        public static void Postfix(VersionShower __instance)
        {
            HardelAPI.HarionVersionShower.Text.text += "\n<color=#9c1919FF>New</color> <color=#FFDD12FF>Col</color><color=#00ACEDFF>or</color>";
        }
    }
}


