using HarmonyLib;
using UnityEngine;

namespace PropSnap.Patches
{
    [HarmonyPatch(assembly, "BeginFrame")]
    internal sealed class PropPlaceBoardToolAssetHolderPatch
    {
        private const string assembly = "PropPlaceBoardTool+AssetHolder,Bouncyrock.TaleSpire.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";

        public static void Postfix(ref Transform ____holderTransform, ref PropPreviewBoardAsset ____asset)
        {
            if (PropGridSnappingPlugin.GridSnapEnabled)
                ____holderTransform.position = new Vector3(Round(____holderTransform.position.x), (____holderTransform.position.y), Round(____holderTransform.position.z));
        }

        private static float Round(float f) => Mathf.Round(f / PropGridSnappingPlugin.SnapIncrement) * PropGridSnappingPlugin.SnapIncrement;

    }
}
