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

namespace Grab{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Wol : BaseUnityPlugin
    {
        bool inRoom;
        GameObject hand;
        GameObject cube;
        Rigidbody Body;
        bool Up;
        public float gravity;
        private readonly XRNode lNode = XRNode.LeftHand;
        Vector2 joystick;
        void OnGameInitialized(object sender, EventArgs e)
        {
            Body = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;
        }
        
        void FixedUpdate()
        {
            Body.AddForce(Vector3.down * gravity * Body.mass);
        }
        void Update()
        {
            InputDevices.GetDeviceAtXRNode(lNode).TryGetFeatureValue(CommonUsages.secondary2DAxis, out joystick);
            if(joystick.y == 1f)
            {
                Up = true;
            }
            if (Up)
            {
                

            }
        }
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }
        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode){
            inRoom = true;
        }
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode){
            inRoom = false;
        }
    }
}