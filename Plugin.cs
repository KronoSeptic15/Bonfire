using BepInEx;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;
using System;
using UnityEngine.XR;

namespace Bonfire{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Wol : BaseUnityPlugin
    {
        GameObject fire;
        Vector3 fireScale;
        void OnGameInitialized(object sender, EventArgs e)
        {
            fire = GameObject.Find("Level/forest/campfire");
            fireScale = fire.transform.localScale;
            fire.transform.localScale += new Vector3(5f, 5f, 5f);
            fire.transform.localPosition = new Vector3(12.098f, -1.492f, -0.5f);
        }
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }
        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            fire.transform.localScale = fireScale;
        }
    }
}