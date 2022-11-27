using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using PluginUtilities;

namespace PropSnap
{

    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(SetInjectionFlag.Guid)]
    public sealed class PropGridSnappingPlugin : BaseUnityPlugin
    {
        // constants
        private const string Name = "Prop Snap To Grid";
        private const string Guid = "org.hollofox.plugins.PropGridSnappingPlugin";
        private const string Version = "0.0.0.0";

        // Config
        private static ConfigEntry<bool> _GridSnapEnabled;
        private static ConfigEntry<float> _SnapIncrement;

        internal static bool GridSnapEnabled => _GridSnapEnabled.Value;
        internal static float SnapIncrement => _SnapIncrement.Value;

        /// <summary>
        /// Awake plugin
        /// </summary>
        void Awake()
        {
            Logger.LogInfo("In Awake for Prop Snap");
            _GridSnapEnabled = Config.Bind("Grid Snapping","Enabled",true);
            _SnapIncrement = Config.Bind("Grid Snapping", "Increment",0.5f);
            var harmony = new Harmony(Guid);
            harmony.PatchAll();

            ModdingTales.ModdingUtils.Initialize(this, Logger, "Hollofoxes'");
        }
    }
}
