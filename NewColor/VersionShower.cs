using HardelAPI;
using HarmonyLib;
namespace NewColor {
    
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionShowerPatch {
        public static void Postfix() {
            HarionVersionShower.Text.text += "\n<color=#9c1919FF>New</color> <color=#FFDD12FF>Col</color><color=#00ACEDFF>or</color>";
        }
    }
}
