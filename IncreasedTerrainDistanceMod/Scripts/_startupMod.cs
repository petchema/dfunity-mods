﻿using UnityEngine;
using System.Collections;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.Utility.ModSupport;   //required for modding features
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings; //required for mod settings

using IncreasedTerrainDistanceMod;

namespace IncreasedTerrainDistanceMod
{
    public class _startupMod : MonoBehaviour
    {
        public static Mod mod;
        private static GameObject gameobjectIncreasedTerrainDistanceMod = null;
        private static IncreasedTerrainDistance componentIncreasedTerrainDistance = null;

        // Settings


        [Invoke(StateManager.StateTypes.Start)]
        public static void InitStart(InitParams initParams)
        {
            // Get this mod
            mod = initParams.Mod;

            // Load settings. Pass this mod as paramater
            //ModSettings settings = new ModSettings(mod);

            // settings

            initMod();

            //after finishing, set the mod's IsReady flag to true.
            ModManager.Instance.GetMod(initParams.ModTitle).IsReady = true;
        }

        /*  
        *   used for debugging
        *   howto debug:
        *       -) add a dummy GameObject to DaggerfallUnityGame scene
        *       -) attach this script (_startupMod) as component
        *       -) deactivate mod in mod list (since dummy gameobject will start up mod)
        *       -) attach debugger and set breakpoint to one of the mod's cs files and debug
        */
        void Awake()
        {
            initMod();
        }

        public static void initMod()
        {
            Debug.Log("init of IncreasedTerrainDistanceMod standalone");
            gameobjectIncreasedTerrainDistanceMod = new GameObject("IncreasedTerrainDistanceMod");
            componentIncreasedTerrainDistance = gameobjectIncreasedTerrainDistanceMod.AddComponent<IncreasedTerrainDistance>();
        }
    }
}