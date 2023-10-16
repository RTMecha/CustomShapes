using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using BepInEx;
using HarmonyLib;

using UnityEngine;
using UnityEngine.UI;

using LSFunctions;
using TMPro;

using RTFunctions.Functions;
using RTFunctions.Functions.IO;
using RTFunctions.Functions.Managers;
using RTFunctions.Functions.Managers.Networking;
using RTFunctions.Functions.Optimization;
using RTFunctions.Functions.Optimization.Objects;
using RTFunctions.Functions.Optimization.Objects.Visual;

using BeatmapObject = DataManager.GameData.BeatmapObject;

namespace CustomShapes
{
    [BepInPlugin("com.mecha.customshapes", "Custom Shapes", " 1.3.0")]
    public class ShapesPlugin : BaseUnityPlugin
    {
        public static string VersionNumber => PluginInfo.PLUGIN_VERSION;

        public static ShapesPlugin inst;
        public static string className = "[<color=#FFD800>CustomShapes</color>]\n";
        readonly Harmony harmony = new Harmony("Shapes");

        public static Sprite diamondSprite;
        public static Sprite diamondHollowSprite;
        public static Sprite diamondHollowThinSprite;
        public static Sprite chevronSprite;
        public static Sprite pentagonSprite;
        public static Sprite pentagonHollowSprite;
        public static Sprite pentagonHollowThinSprite;
        public static Sprite pentagonHalfSprite;
        public static Sprite pentagonHalfHollowSprite;
        public static Sprite pentagonHalfHollowThinSprite;
        public static Sprite paLogoTopSprite;
        public static Sprite paLogoBottomSprite;
        public static Sprite paLogoSprite;
        public static Sprite starSprite;
        
        void Awake()
        {
            inst = this;

            Logger.LogInfo($"Plugin Custom Shapes is loaded!");
            harmony.PatchAll(typeof(ShapesPlugin));
            harmony.PatchAll(typeof(ObjectShapePatch));
        }

        static IEnumerator SetObjectSprite(BeatmapObject beatmapObject, SpriteRenderer sprite, Transform transform, string path)
        {
            var ogPos = transform.localPosition;
            var ogSca = transform.localScale;

            if (RTFile.FileExists(path))
                yield return inst.StartCoroutine(AlephNetworkManager.DownloadImageTexture("file://" + path, delegate (Texture2D x)
                {
                    sprite.sprite = RTSpriteManager.CreateSprite(x);
                }));
            else sprite.sprite = ArcadeManager.inst.defaultImage;

            //yield return inst.StartCoroutine(SpriteManager.GetSprite(path, new SpriteManager.SpriteLimits(), delegate (Sprite cover)
            //{
            //    sprite.sprite = cover;
            //}, delegate (string errorFile)
            //{
            //    sprite.sprite = ArcadeManager.inst.defaultImage;
            //}, TextureFormat.ARGB32));

            transform.localPosition = ogPos;
            transform.localScale = ogSca;

            yield break;
        }

        //[HarmonyPatch(typeof(ObjectManager), "Update")]
        //[HarmonyPostfix]
        static void ISUpdateSVG()
        {
            if (GameManager.inst != null && DataManager.inst.gameData.beatmapObjects.Count > 0)
            {
                if (GameManager.inst.gameState != GameManager.State.Loading)
                {
                    foreach (var beatmapObject in DataManager.inst.gameData.beatmapObjects)
                    {
                        if (beatmapObject.shape == 6 && beatmapObject.TimeWithinLifespan() && Updater.TryGetObject(beatmapObject, out LevelObject levelObject) && levelObject.visualObject.Renderer && levelObject.visualObject.Renderer.GetType() == typeof(SpriteRenderer))
                        {
                            var sprite = (SpriteRenderer)levelObject.visualObject.Renderer;

                            var regex = new System.Text.RegularExpressions.Regex(@"img\((.*?)\)");
                            var match = regex.Match(beatmapObject.text);

                            if (match.Success)
                            {
                                string jpgFileLocation = RTFile.ApplicationDirectory + RTFile.basePath + match.Groups[1].ToString();

                                if (sprite.sprite == null)
                                {
                                    inst.StartCoroutine(SetObjectSprite(beatmapObject, sprite, levelObject.visualObject.GameObject.transform, jpgFileLocation));
                                }
                            }
                            else if (RTFile.FileExists(RTFile.ApplicationDirectory + RTFile.basePath + beatmapObject.text))
                            {
                                string jpgFileLocation = RTFile.ApplicationDirectory + RTFile.basePath + beatmapObject.text;

                                if (sprite.sprite == null)
                                {
                                    inst.StartCoroutine(SetObjectSprite(beatmapObject, sprite, levelObject.visualObject.GameObject.transform, jpgFileLocation));
                                }
                            }
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(ObjEditor), "Start")]
        [HarmonyPostfix]
        static void ISCustomShapeOption()
        {
            GameObject.Find("Editor Systems/Editor GUI/sizer/main/EditorDialogs/GameObjectDialog/data/left/Scroll View/Viewport/Content/shape/7").SetActive(true);

            string imageObjLocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_image_obj.png";

            //{
            //    Image sprite = GameObject.Find("Editor Systems/Editor GUI/sizer/main/EditorDialogs/GameObjectDialog/data/left/Scroll View/Viewport/Content/shape/7/Image").GetComponent<Image>();

            //    inst.StartCoroutine(AlephNetworkManager.DownloadImageTexture("https://media.discordapp.net/attachments/1151231196022452255/1151550105682448395/editor_gui_image_obj.png", delegate (Texture2D x)
            //    {
            //        sprite.sprite = RTSpriteManager.CreateSprite(x);
            //    }));
            //}

            if (RTFile.FileExists(imageObjLocation))
            {
                Image sprite = GameObject.Find("Editor Systems/Editor GUI/sizer/main/EditorDialogs/GameObjectDialog/data/left/Scroll View/Viewport/Content/shape/7/Image").GetComponent<Image>();

                SpriteManager.GetSprite(imageObjLocation, sprite, TextureFormat.Alpha8);
            }
            else
            {
                EditorManager.inst.DisplayNotification("Failed to load image shape sprite!", 2f, EditorManager.NotificationType.Error, false);
            }

            ObjEditor.inst.ObjectView.transform.Find("shape").GetComponent<GridLayoutGroup>().spacing = new Vector2(7.6f, 0f);

            //Pentagon
            {
                GameObject shape8 = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shape/6").gameObject);
                shape8.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shape"));
                shape8.name = "8";
                shape8.transform.localScale = Vector3.one;

                GameObject shapeSettings8 = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/6").gameObject);
                shapeSettings8.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings"));
                shapeSettings8.name = "8";
                shapeSettings8.transform.localScale = Vector3.one;

                string pentagonGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pentagon.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pentagon.png"))
                {
                    Image sprite = shape8.transform.Find("Image").GetComponent<Image>();
                    Image spriteSettings = shapeSettings8.transform.GetChild(0).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(pentagonGUILocation, sprite, TextureFormat.Alpha8);
                    SpriteManager.GetSprite(pentagonGUILocation, spriteSettings, TextureFormat.Alpha8);
                }

                string pentagonHollowGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pentagon_outline.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pentagon_outline.png"))
                {
                    Image sprite = shapeSettings8.transform.GetChild(1).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(pentagonHollowGUILocation, sprite, TextureFormat.Alpha8);
                }

                string pentagonHollowThinGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pentagon_outline_thin.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pentagon_outline_thin.png"))
                {
                    Image sprite = shapeSettings8.transform.GetChild(2).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(pentagonHollowThinGUILocation, sprite, TextureFormat.Alpha8);
                }

                string pentagonHalfGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pentagon_half.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pentagon_half.png"))
                {
                    Image sprite = shapeSettings8.transform.GetChild(3).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(pentagonHalfGUILocation, sprite, TextureFormat.Alpha8);
                }

                string pentagonHalfHollowGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pentagon_half_outline.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pentagon_half_outline.png"))
                {
                    Image sprite = shapeSettings8.transform.GetChild(4).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(pentagonHalfHollowGUILocation, sprite, TextureFormat.Alpha8);
                }

                string pentagonHalfHollowThinGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pentagon_half_outline_thin.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pentagon_half_outline_thin.png"))
                {
                    Image sprite = shapeSettings8.transform.GetChild(5).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(pentagonHalfHollowThinGUILocation, sprite, TextureFormat.Alpha8);
                }
            }

            //Misc
            {
                GameObject shape9 = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shape/6").gameObject);
                shape9.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shape"));
                shape9.name = "9";
                shape9.transform.localScale = Vector3.one;

                string dotsGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_dots.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_dots.png"))
                {
                    Image sprite = shape9.transform.Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(dotsGUILocation, sprite, TextureFormat.Alpha8);
                }

                GameObject shapeSettings9 = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/2").gameObject);
                shapeSettings9.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings"));
                shapeSettings9.name = "9";
                shapeSettings9.transform.localScale = Vector3.one;

                string paLogoTopGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pa_logo_top.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pa_logo_top.png"))
                {
                    Image sprite = shapeSettings9.transform.GetChild(0).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(paLogoTopGUILocation, sprite, TextureFormat.Alpha8);
                }

                string paLogoBottomGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pa_logo_bottom.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pa_logo_bottom.png"))
                {
                    Image sprite = shapeSettings9.transform.GetChild(1).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(paLogoBottomGUILocation, sprite, TextureFormat.Alpha8);
                }

                string paLogoGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_pa_logo.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_pa_logo.png"))
                {
                    Image sprite = shapeSettings9.transform.GetChild(2).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(paLogoGUILocation, sprite, TextureFormat.Alpha8);
                }

                string starGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_star.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_star.png"))
                {
                    Image sprite = shapeSettings9.transform.GetChild(3).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(starGUILocation, sprite, TextureFormat.Alpha8);
                }

                string moonGUILocation = "BepInEx/plugins/Assets/editor_gui_moon.png";

                if (RTFile.FileExists(moonGUILocation))
                {
                    Image sprite = shapeSettings9.transform.GetChild(4).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(RTFile.ApplicationDirectory + moonGUILocation, sprite, TextureFormat.Alpha8);
                }

                string moonThinGUILocation = "BepInEx/plugins/Assets/editor_gui_moon.png";

                if (RTFile.FileExists(moonThinGUILocation))
                {
                    Image sprite = shapeSettings9.transform.GetChild(5).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(RTFile.ApplicationDirectory + moonThinGUILocation, sprite, TextureFormat.Alpha8);
                }

                string moonHalfGUILocation = "BepInEx/plugins/Assets/editor_gui_moon_half.png";

                if (RTFile.FileExists(moonHalfGUILocation))
                {
                    Image sprite = shapeSettings9.transform.GetChild(6).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(RTFile.ApplicationDirectory + moonHalfGUILocation, sprite, TextureFormat.Alpha8);
                }

                string moonHalfThinGUILocation = "BepInEx/plugins/Assets/editor_gui_moon_half_thin.png";

                if (RTFile.FileExists(moonHalfThinGUILocation))
                {
                    Image sprite = shapeSettings9.transform.GetChild(7).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(RTFile.ApplicationDirectory + moonHalfThinGUILocation, sprite, TextureFormat.Alpha8);
                }

                string moonQuarterGUILocation = "BepInEx/plugins/Assets/editor_gui_moon_quarter.png";

                if (RTFile.FileExists(moonQuarterGUILocation))
                {
                    Image sprite = shapeSettings9.transform.GetChild(8).Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(RTFile.ApplicationDirectory + moonQuarterGUILocation, sprite, TextureFormat.Alpha8);
                }
            }

            //Diamond
            {
                GameObject shapeSettings1Diamond = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/1/rectangle").gameObject);
                shapeSettings1Diamond.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings/1"));
                shapeSettings1Diamond.transform.SetSiblingIndex(3);
                shapeSettings1Diamond.name = "diamond";
                shapeSettings1Diamond.transform.localScale = Vector3.one;

                string diamondGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_diamond.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_diamond.png"))
                {
                    Image sprite = shapeSettings1Diamond.transform.Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(diamondGUILocation, sprite, TextureFormat.Alpha8);
                }

                GameObject shapeSettings1DiamondHollow = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/1/rectangle").gameObject);
                shapeSettings1DiamondHollow.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings/1"));
                shapeSettings1DiamondHollow.transform.SetSiblingIndex(4);
                shapeSettings1DiamondHollow.name = "diamond_outline";
                shapeSettings1DiamondHollow.transform.localScale = Vector3.one;

                string diamondHollowGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_diamond_outline.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_diamond_outline.png"))
                {
                    Image sprite = shapeSettings1DiamondHollow.transform.Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(diamondHollowGUILocation, sprite, TextureFormat.Alpha8);
                }

                GameObject shapeSettings1DiamondHollowThin = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/1/rectangle").gameObject);
                shapeSettings1DiamondHollowThin.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings/1"));
                shapeSettings1DiamondHollowThin.transform.SetSiblingIndex(5);
                shapeSettings1DiamondHollowThin.name = "diamond_outline_thin";
                shapeSettings1DiamondHollowThin.transform.localScale = Vector3.one;

                string diamondHollowThinGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_diamond_outline_thin.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_diamond_outline_thin.png"))
                {
                    Image sprite = shapeSettings1DiamondHollowThin.transform.Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(diamondHollowThinGUILocation, sprite, TextureFormat.Alpha8);
                }
            }

            //Arrow
            {
                GameObject shapeSettings4Chevron = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/4/top_arrow").gameObject);
                shapeSettings4Chevron.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings/4"));
                shapeSettings4Chevron.transform.SetSiblingIndex(2);
                shapeSettings4Chevron.name = "chevron_arrow";
                shapeSettings4Chevron.transform.localScale = Vector3.one;

                string chevronArrowGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_chevron_arrow.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_chevron_arrow.png"))
                {
                    Image sprite = shapeSettings4Chevron.transform.Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(chevronArrowGUILocation, sprite, TextureFormat.Alpha8);
                }
            }

            //Triangle
            {
                GameObject shapeSettings3TriangleOutlineThin = Instantiate(ObjEditor.inst.ObjectView.transform.Find("shapesettings/3/right_triangle_outline").gameObject);
                shapeSettings3TriangleOutlineThin.transform.SetParent(ObjEditor.inst.ObjectView.transform.Find("shapesettings/3"));
                shapeSettings3TriangleOutlineThin.transform.SetSiblingIndex(4);
                shapeSettings3TriangleOutlineThin.name = "triangle_outline_thin";
                shapeSettings3TriangleOutlineThin.transform.localScale = Vector3.one;

                string triangleOutlineThinGUILocation = RTFile.ApplicationDirectory + "BepInEx/plugins/Assets/editor_gui_triangle_outline_thin.png";

                if (RTFile.FileExists("BepInEx/plugins/Assets/editor_gui_triangle_outline_thin.png"))
                {
                    Image sprite = shapeSettings3TriangleOutlineThin.transform.Find("Image").GetComponent<Image>();

                    SpriteManager.GetSprite(triangleOutlineThinGUILocation, sprite, TextureFormat.Alpha8);
                }
            }

            //Circles
            {
                var shapeSettings2 = ObjEditor.inst.ObjectView.transform.Find("shapesettings/2").gameObject;
                var rect = shapeSettings2.GetComponent<RectTransform>();
                var scroll = shapeSettings2.AddComponent<ScrollRect>();
                shapeSettings2.AddComponent<Mask>();
                var image = shapeSettings2.AddComponent<Image>();

                scroll.horizontal = true;
                scroll.vertical = false;
                scroll.content = rect;
                scroll.viewport = rect;
                image.color = new Color(1f, 1f, 1f, 0.01f);

                var circle = shapeSettings2.transform.Find("circle").gameObject;
                var g1 = Instantiate(circle);
                g1.transform.SetParent(shapeSettings2.transform);
                g1.transform.localScale = Vector3.one;
                g1.transform.SetSiblingIndex(9);

                var g2 = Instantiate(circle);
                g2.transform.SetParent(shapeSettings2.transform);
                g2.transform.localScale = Vector3.one;
                g2.transform.SetSiblingIndex(10);

                var g3 = Instantiate(circle);
                g3.transform.SetParent(shapeSettings2.transform);
                g3.transform.localScale = Vector3.one;
                g3.transform.SetSiblingIndex(11);

                var g4 = Instantiate(circle);
                g4.transform.SetParent(shapeSettings2.transform);
                g4.transform.localScale = Vector3.one;
                g4.transform.SetSiblingIndex(12);

                var g5 = Instantiate(circle);
                g5.transform.SetParent(shapeSettings2.transform);
                g5.transform.localScale = Vector3.one;
                g5.transform.SetSiblingIndex(13);

                var g6 = Instantiate(circle);
                g6.transform.SetParent(shapeSettings2.transform);
                g6.transform.localScale = Vector3.one;
                g6.transform.SetSiblingIndex(14);

                var g7 = Instantiate(circle);
                g7.transform.SetParent(shapeSettings2.transform);
                g7.transform.localScale = Vector3.one;
                g7.transform.SetSiblingIndex(15);
            }

            //Misc again
            {
                var shapeSettings9 = ObjEditor.inst.ObjectView.transform.Find("shapesettings/9").gameObject;
                var rect = shapeSettings9.GetComponent<RectTransform>();
                var scroll = shapeSettings9.AddComponent<ScrollRect>();
                shapeSettings9.AddComponent<Mask>();
                var image = shapeSettings9.AddComponent<Image>();

                scroll.horizontal = true;
                scroll.vertical = false;
                scroll.content = rect;
                scroll.viewport = rect;
                image.color = new Color(1f, 1f, 1f, 0.01f);

                var circle = shapeSettings9.transform.Find("circle").gameObject;
                for (int i = 9; i < 23; i++)
                {
                    var g1 = Instantiate(circle);
                    g1.transform.SetParent(shapeSettings9.transform);
                    g1.transform.localScale = Vector3.one;
                    g1.transform.SetSiblingIndex(i);
                }

                //var g1 = Instantiate(circle);
                //g1.transform.SetParent(shapeSettings9.transform);
                //g1.transform.localScale = Vector3.one;
                //g1.transform.SetSiblingIndex(9);

                //var g2 = Instantiate(circle);
                //g2.transform.SetParent(shapeSettings9.transform);
                //g2.transform.localScale = Vector3.one;
                //g2.transform.SetSiblingIndex(10);

                //var g3 = Instantiate(circle);
                //g3.transform.SetParent(shapeSettings9.transform);
                //g3.transform.localScale = Vector3.one;
                //g3.transform.SetSiblingIndex(11);

                //var g4 = Instantiate(circle);
                //g4.transform.SetParent(shapeSettings9.transform);
                //g4.transform.localScale = Vector3.one;
                //g4.transform.SetSiblingIndex(12);

                //var g5 = Instantiate(circle);
                //g5.transform.SetParent(shapeSettings9.transform);
                //g5.transform.localScale = Vector3.one;
                //g5.transform.SetSiblingIndex(13);

                //var g6 = Instantiate(circle);
                //g6.transform.SetParent(shapeSettings9.transform);
                //g6.transform.localScale = Vector3.one;
                //g6.transform.SetSiblingIndex(14);

                //var g7 = Instantiate(circle);
                //g7.transform.SetParent(shapeSettings9.transform);
                //g7.transform.localScale = Vector3.one;
                //g7.transform.SetSiblingIndex(15);

                //var g8 = Instantiate(circle);
                //g8.transform.SetParent(shapeSettings9.transform);
                //g8.transform.localScale = Vector3.one;
                //g8.transform.SetSiblingIndex(16);

                //var g9 = Instantiate(circle);
                //g9.transform.SetParent(shapeSettings9.transform);
                //g9.transform.localScale = Vector3.one;
                //g9.transform.SetSiblingIndex(17);

                //var g10 = Instantiate(circle);
                //g10.transform.SetParent(shapeSettings9.transform);
                //g10.transform.localScale = Vector3.one;
                //g10.transform.SetSiblingIndex(18);

                //var g11 = Instantiate(circle);
                //g11.transform.SetParent(shapeSettings9.transform);
                //g11.transform.localScale = Vector3.one;
                //g11.transform.SetSiblingIndex(19);

                //var g12 = Instantiate(circle);
                //g12.transform.SetParent(shapeSettings9.transform);
                //g12.transform.localScale = Vector3.one;
                //g12.transform.SetSiblingIndex(20);

                //var g13 = Instantiate(circle);
                //g13.transform.SetParent(shapeSettings9.transform);
                //g13.transform.localScale = Vector3.one;
                //g13.transform.SetSiblingIndex(21);

                //var g14 = Instantiate(circle);
                //g14.transform.SetParent(shapeSettings9.transform);
                //g14.transform.localScale = Vector3.one;
                //g14.transform.SetSiblingIndex(22);
            }
        }

        [HarmonyPatch(typeof(GameManager), "Awake")]
        [HarmonyPostfix]
        static void ISSVGManager()
        {
            GameObject spriteManager = new GameObject("SpriteManager");
            spriteManager.transform.SetParent(GameObject.Find("Game Systems").transform);
            spriteManager.AddComponent<SpriteManager>();
        }

        [HarmonyPatch(typeof(ObjEditor), "RefreshKeyframeGUI")]
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return new CodeMatcher(instructions)
              .MatchForward(false,
                new CodeMatch(OpCodes.Ldstr, "shapesettings/7/text"))
              .Advance(-3)
              .RemoveInstructions(19)
              .Advance(-183)
              .ThrowIfNotMatch("Is not ldc.i4.7", new CodeMatch(OpCodes.Ldc_I4_7))
              .InsertAndAdvance(new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(ObjectManager), "inst")))
              .InsertAndAdvance(new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(ObjectManager), "objectPrefabs")))
              .SetInstruction(new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<ObjectManager.ObjectPrefabHolder>), "get_Count")))
              .InstructionEnumeration();
        }
    }
}
