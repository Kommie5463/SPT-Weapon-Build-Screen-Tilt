using System.Reflection;
using BepInEx;
using EFT.UI.WeaponModding;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace BuildScreenTilt
{
    [BepInPlugin("com.kommie.buildscreentilt", "Build Screen Tilt", "1.1.0")]
    public class BuildScreenTiltPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new WeaponPreviewRotatePatch().Enable();
        }
    }

    public class WeaponPreviewRotatePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(WeaponPreview), nameof(WeaponPreview.Rotate));
        }

        [PatchPrefix]
        private static void Prefix(ref float minTilt, ref float maxTilt)
        {
            minTilt = 0f;
            maxTilt = 0f;
        }
    }
}