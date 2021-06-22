using Harion.ModsManagers;
using Harion.ModsManagers.Configuration;
using Harion.ModsManagers.Mods;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NewColor {
    public class ModManager : ModRegistry, IModManager, IModManagerLink {

        public string DisplayName => "New Color";

        public string Version => typeof(NewColor).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        public string SmallDescription => "Add skin and hat";

        public string Description => "This mod uses Harion and adds various new colors and hats to the game.";

        public string Credit => "Evan & Hardel";

        public Dictionary<string, Sprite> ModsLinks => new Dictionary<string, Sprite>() {
            { "https://github.com/Evan91380/NewColor", ModsSocial.GithubSprite }
        };

    }
}
