using System;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

using HarmonyLib;
using BepInEx;

namespace CustomShapes
{
    [HarmonyPatch(typeof(ObjectManager))]
    public class ObjectShapePatch : MonoBehaviour
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void CreateShapes()
        {
            NewShapes.CreateMeshes();
        }
    }
}
