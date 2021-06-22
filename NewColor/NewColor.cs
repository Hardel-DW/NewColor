using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Harion;
using Harion.Utility.Helper;
using Harion.ColorDesigner;
using Harion.HatDesigner;

namespace NewColor {

    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(HarionPlugin.Id)]
    public class NewColor : BasePlugin {
        public const string Id = "fr.evan.newcolor";
        public static ManualLogSource Logger;

        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load() {
            Logger = Log;
            Harmony.PatchAll();
            AddColor();
            AddHat();
        }

        private void AddColor() {
            ColorCreator.AddColor(new CustomColor {
                name = "Dark Red",
                color = new Color32(156, 25, 25, byte.MaxValue),
                shadow = new Color32(80, 0, 0, byte.MaxValue),
                isLighterColor = false
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Yellow",
                color = new Color32(255, 221, 18, byte.MaxValue),
                shadow = new Color32(179, 145, 0, byte.MaxValue),
                isLighterColor = true
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Light Blue",
                color = new Color32(0, 172, 237, byte.MaxValue),
                shadow = new Color32(0, 92, 161, byte.MaxValue),
                isLighterColor = true
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Light Rose",
                color = new Color32(242, 198, 209, byte.MaxValue),
                shadow = new Color32(172, 128, 139, byte.MaxValue),
                isLighterColor = true
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Turquoise",
                color = new Color32(22, 132, 176, byte.MaxValue),
                shadow = new Color32(15, 89, 117, byte.MaxValue),
                isLighterColor = false
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Gray",
                color = new Color32(175, 175, 175, byte.MaxValue),
                shadow = new Color32(105, 105, 105, byte.MaxValue),
                isLighterColor = true
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Black",
                color = new Color32(30, 30, 30, byte.MaxValue),
                shadow = new Color32(10, 10, 10, byte.MaxValue),
                isLighterColor = false
            });
            ColorCreator.AddColor(new CustomColor {
                name = "White",
                color = new Color32(240, 240, 240, byte.MaxValue),
                shadow = new Color32(170, 170, 170, byte.MaxValue),
                isLighterColor = true
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Dark Green",
                color = new Color32(15, 89, 7, byte.MaxValue),
                shadow = new Color32(5, 30, 0, byte.MaxValue),
                isLighterColor = true
            });
            ColorCreator.AddColor(new CustomColor {
                name = "Turquoise",
                color = new Color32(61, 255, 181, byte.MaxValue),
                shadow = new Color32(31, 128, 91, byte.MaxValue),
                isLighterColor = true
            });
        }

        private void AddHat() {
            List<string> fiesNames = Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList();
            List<string> HatFiles = fiesNames.Where(item => item.EndsWith(".png")).ToList();

            foreach (string hat in HatFiles) {
                HatCreator.CreateHats(new CustomHat {
                    sprite = SpriteHelper.LoadHatSprite(hat),
                    bounce = false,
                    highUp = false,
                    offset = new Vector2(0f, 0.1f),
                    author = "JeffLeBg",
                    name = hat
                });
            }
        }
    }
}