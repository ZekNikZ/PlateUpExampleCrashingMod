using Kitchen;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using System.Linq;
using KitchenLib.Utils;
using KitchenData;
using KitchenLib.Customs;
using KitchenDemoMod.Items;
using KitchenLib.References;

// Namespace should have "Kitchen" in the beginning
namespace KitchenDemoMod
{
    public class Mod : BaseMod, IModSystem
    {
        // guid must be unique and is recommended to be in reverse domain name notation
        // mod name that is displayed to the player and listed in the mods menu
        // mod version must follow semver e.g. "1.2.3"
        public const string MOD_GUID = "demomod";
        public const string MOD_NAME = "Demo Mod";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "ZekNikZ";
        public const string MOD_GAMEVERSION = ">=1.1.1";
        public const bool DEBUG_MODE = true;
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.1" current and all future
        // e.g. ">=1.1.1 <=1.2.3" for all from/until

        internal static Item Apple => Find<Item>(ItemReferences.Apple);
        internal static Item Item1 => Find<Item, Item1>();
        internal static ItemGroup Item2 => Find<ItemGroup, Item2>();

        public static AssetBundle Bundle;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void Initialise()
        {
            base.Initialise();

            // For log file output so the official plateup support staff can identify if/which a mod is being used
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        protected void AddGameData()
        {
            LogInfo("Attempting to register game data...");

            // TODO: rearrange these lines to prevent the crash
            AddGameDataObject<Item2>();
            AddGameDataObject<Item1>();

            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
            
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            //LogInfo("Attempting to load asset bundle...");
            //Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            //LogInfo("Done loading asset bundle.");

            AddGameData();
        }
        private static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }

        private static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return (T)GDOUtils.GetCustomGameDataObject<C>()?.GameDataObject;
        }

        #region Logging
        // You can remove this, I just prefer a more standardized logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
