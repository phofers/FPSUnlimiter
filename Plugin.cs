using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace FPSUnlimiter;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        // I think (???) Debug.Log prints to unity player.log file but really am unsure. Whatever, it doesn't matter much, it's still logging in the bepinex log.
        Debug.Log("This game is MODDED! FPSUnlimiter is loaded.");
        Harmony harmony = new Harmony("phofers");
        harmony.PatchAll();
    }

    [HarmonyPatch(typeof(FPSLimiter), "Awake")]
    public class FPSPatch
    {
        static bool Prefix()
        {


            Application.targetFrameRate = -1;
            QualitySettings.vSyncCount = 0;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} FPSLimiter patch applied!");
            return false;
            
        }
        
    }
    



}
