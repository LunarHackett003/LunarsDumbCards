using BepInEx;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
namespace LunarsCards
{
    [BepInDependency("com.willis.rounds.unbound")]
    [BepInDependency("pykess.rounds.plugins.moddingutils")]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch")]
    [BepInPlugin("lunar.rounds.dumbcards", "Lunars Dumb Cards", "0.0.1")]
    [BepInProcess("Rounds.exe")]

    public class LunarsDumbCards : BaseUnityPlugin
    {
        internal static string modInitials = "LDC";
        internal static AssetBundle assets;
        void Awake()
        {
            UnityEngine.Debug.Log("Wake the fuck up, Unity!");
            assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("lunarscards", typeof(LunarsDumbCards).Assembly);
            UnityEngine.Debug.Log("Woah, we loaded this thing");
            assets.LoadAsset<GameObject>("ModCards").GetComponent<CardHolder>().RegisterCards();
        }
        void Start()
        {
            UnityEngine.Debug.Log("Wake the fuck up, Unity!");
        }
    }
}