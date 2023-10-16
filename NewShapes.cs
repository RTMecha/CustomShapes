using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using HarmonyLib;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

using RTFunctions.Functions;
using RTFunctions.Functions.IO;
using RTFunctions.Functions.Managers;

namespace CustomShapes
{
    public class NewShapes : MonoBehaviour
    {
        public static Mesh paLogoTopMesh = new Mesh();
		public static Mesh paLogoBottomMesh = new Mesh();
		public static Mesh paLogoMesh = new Mesh();

		public static Mesh starMesh = new Mesh();
		public static Mesh moonMesh = new Mesh();
		public static Mesh moonThinMesh = new Mesh();
		public static Mesh moonHalfMesh = new Mesh();
		public static Mesh moonHalfThinMesh = new Mesh();
		public static Mesh moonQuarterMesh = new Mesh();
		public static Mesh moonQuarterThinMesh = new Mesh();

		public static Mesh systemErrorWingMesh = new Mesh();

		public static Mesh heartMesh = new Mesh();
		public static Mesh heartHollowMesh = new Mesh();
		public static Mesh heartHollowThinMesh = new Mesh();
		public static Mesh heartHalfMesh = new Mesh();
		public static Mesh heartHalfHollowMesh = new Mesh();
		public static Mesh heartHalfHollowThinMesh = new Mesh();

		public static Mesh circleMoonMesh = new Mesh();
		public static Mesh circleMoonThinMesh = new Mesh();
		public static Mesh circleMoonThinnerMesh = new Mesh();
		public static Mesh circleHalfMoonMesh = new Mesh();
		public static Mesh circleHalfMoonThinMesh = new Mesh();
		public static Mesh circleHalfMoonThinnerMesh = new Mesh();
		public static Mesh circleQuarterMoonMesh = new Mesh();
		public static Mesh circleQuarterMoonThinMesh = new Mesh();
		public static Mesh circleQuarterMoonThinnerMesh = new Mesh();

		public static Mesh pentagonMesh = new Mesh();
		public static Mesh pentagonHollowMesh = new Mesh();
		public static Mesh pentagonHollowThinMesh = new Mesh();
		public static Mesh pentagonHalfMesh = new Mesh();
		public static Mesh pentagonHalfHollowMesh = new Mesh();
		public static Mesh pentagonHalfHollowThinMesh = new Mesh();

		public static Mesh chevronArrowMesh = new Mesh();

		public static Mesh triangleHollowThinMesh = new Mesh();

		public static Mesh circleHollowThinnerMesh = new Mesh();
		public static Mesh circleHalfHollowThinMesh = new Mesh();
		public static Mesh circleHalfHollowThinnerMesh = new Mesh();
		public static Mesh circleQuarterHollowThinMesh = new Mesh();
		public static Mesh circleQuarterHollowThinnerMesh = new Mesh();
		public static Mesh circleEighthHollowThinMesh = new Mesh();
		public static Mesh circleEighthHollowThinnerMesh = new Mesh();

		public static Mesh diamondMesh;
		public static Mesh diamondHollowMesh;
		public static Mesh diamondHollowThinMesh;

		public static void CreateMeshes()
		{
			if (!GameObject.Find("CustomShapes Mesh Stopper"))
			{
				GameObject gameObjectStopper = new GameObject("CustomShapes Mesh Stopper");

				if (EditorManager.inst == null)
                {
					if (ObjectManager.inst.objectPrefabs.Count != 7)
                    {
						GameObject imageMesh = new GameObject("mesh");
						imageMesh.layer = 8;
						GameObject imageObject = new GameObject("object");
						imageObject.layer = 8;
						imageObject.transform.SetParent(imageMesh.transform);

						imageObject.AddComponent<SpriteRenderer>();
						Rigidbody2D imageRB = imageObject.AddComponent<Rigidbody2D>();

						imageRB.angularDrag = 0f;
						imageRB.bodyType = RigidbodyType2D.Kinematic;
						imageRB.gravityScale = 0f;
						imageRB.inertia = 0f;

						ObjectManager.ObjectPrefabHolder imageShapePrefab = new ObjectManager.ObjectPrefabHolder();
						imageShapePrefab.options.Add(imageMesh);

						ObjectManager.inst.objectPrefabs.Add(imageShapePrefab);
					}
                }

				//Object Prefab Holders
				ObjectManager.ObjectPrefabHolder miscShapePrefabs = new ObjectManager.ObjectPrefabHolder();
				ObjectManager.ObjectPrefabHolder pentagonShapePrefabs = new ObjectManager.ObjectPrefabHolder();

				//PA Logo Top
				{
					GameObject paLogoTopGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					paLogoTopGameObject.name = "pa_logo_top";
					paLogoTopGameObject.layer = 8;

					Vector3[] paLogoTopVerts = new Vector3[]
					{
						new Vector3(0.031000f, 0.281000f, 0.000000f),
						new Vector3(0.250000f, 0.500000f, 0.000000f),
						new Vector3(0.500000f, 0.250000f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.406200f, -0.093800f, 0.000000f),
					};

					int[] paLogoTopTris = new int[]
					{
						0,
						1,
						2,
						2,
						3,
						0,
						0,
						3,
						4,
					};

					//5 = 0
					//6 = 1
					//7 = 2
					//8 = 3
					//9 = 4

					paLogoTopMesh.vertices = paLogoTopVerts;
					paLogoTopMesh.triangles = paLogoTopTris;

					paLogoTopMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					paLogoTopMesh.subMeshCount = 1;
					Bounds paLogoTopMeshBounds = paLogoTopMesh.bounds;
					paLogoTopMeshBounds.center = Vector3.zero;
					paLogoTopMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					paLogoTopMesh.bounds = paLogoTopMeshBounds;

					paLogoTopMesh.name = "pa_logo_top";

					paLogoTopGameObject.GetComponentInChildren<MeshFilter>().mesh = paLogoTopMesh;

					Vector2[] paLogoTopPoints = new Vector2[]
					{
						new Vector2(0.031000f, 0.281000f),
						new Vector2(0.250000f, 0.500000f),
						new Vector2(0.500000f, 0.250000f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(0.406200f, -0.093800f),
					};

					paLogoTopGameObject.GetComponentInChildren<PolygonCollider2D>().points = paLogoTopPoints;

					miscShapePrefabs.options.Add(paLogoTopGameObject);
				}

				//PA Logo Bottom
				{
					GameObject paLogoBottomGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					paLogoBottomGameObject.name = "pa_logo_bottom";
					paLogoBottomGameObject.layer = 8;

					Vector3[] paLogoBottomVerts = new Vector3[]
					{
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.374600f, -0.125400f, 0.000000f),
						new Vector3(0.000000f, -0.500000f, 0.000000f),
						new Vector3(-0.500000f, 0.250000f, 0.000000f),
						new Vector3(-0.250000f, 0.500000f, 0.000000f),
					};

					int[] paLogoBottomTris = new int[]
					{
						0,
						1,
						2,
						3,
						1,
						0,
						4,
						1,
						3,
					};

					paLogoBottomMesh.vertices = paLogoBottomVerts;
					paLogoBottomMesh.triangles = paLogoBottomTris;

					paLogoBottomMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					paLogoBottomMesh.subMeshCount = 1;
					Bounds paLogoBottomMeshBounds = paLogoBottomMesh.bounds;
					paLogoBottomMeshBounds.center = Vector3.zero;
					paLogoBottomMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					paLogoBottomMesh.bounds = paLogoBottomMeshBounds;

					paLogoBottomMesh.name = "pa_logo_bottom";

					paLogoBottomGameObject.GetComponentInChildren<MeshFilter>().mesh = paLogoBottomMesh;

					Vector2[] paLogoBottomPoints = new Vector2[]
					{
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(0.374600f, -0.125400f),
						new Vector2(0.000000f, -0.500000f),
						new Vector2(-0.500000f, 0.250000f),
						new Vector2(-0.250000f, 0.500000f),
					};

					paLogoBottomGameObject.GetComponentInChildren<PolygonCollider2D>().points = paLogoBottomPoints;

					miscShapePrefabs.options.Add(paLogoBottomGameObject);
				}

				//PA Logo Whole
				{
					GameObject paLogoGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					paLogoGameObject.name = "pa_logo";
					paLogoGameObject.layer = 8;

					Vector3[] paLogoVerts = new Vector3[]
					{
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.374600f, -0.125400f, 0.000000f),
						new Vector3(0.000000f, -0.500000f, 0.000000f),
						new Vector3(-0.500000f, 0.250000f, 0.000000f),
						new Vector3(-0.250000f, 0.500000f, 0.000000f),
						new Vector3(0.031000f, 0.281000f, 0.000000f),
						new Vector3(0.250000f, 0.500000f, 0.000000f),
						new Vector3(0.500000f, 0.250000f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.406200f, -0.093800f, 0.000000f),
					};

					int[] paLogoTris = new int[]
					{
						0,
						1,
						2,
						3,
						1,
						0,
						4,
						1,
						3,
						5,
						6,
						7,
						7,
						8,
						5,
						5,
						8,
						9,
					};

					//5 = 0
					//6 = 1
					//7 = 2
					//8 = 3
					//9 = 4

					paLogoMesh.vertices = paLogoVerts;
					paLogoMesh.triangles = paLogoTris;

					paLogoMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					paLogoMesh.subMeshCount = 1;
					Bounds paLogoMeshBounds = paLogoMesh.bounds;
					paLogoMeshBounds.center = Vector3.zero;
					paLogoMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					paLogoMesh.bounds = paLogoMeshBounds;

					paLogoMesh.name = "pa_logo";

					paLogoGameObject.GetComponentInChildren<MeshFilter>().mesh = paLogoMesh;

					Vector2[] paLogoPoints = new Vector2[]
					{
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(0.374600f, -0.125400f),
						new Vector2(0.000000f, -0.500000f),
						new Vector2(-0.500000f, 0.250000f),
						new Vector2(-0.250000f, 0.500000f),
						new Vector2(0.031000f, 0.281000f),
						new Vector2(0.250000f, 0.500000f),
						new Vector2(0.500000f, 0.250000f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(0.406200f, -0.093800f),
					};

					paLogoGameObject.GetComponentInChildren<PolygonCollider2D>().points = paLogoPoints;

					miscShapePrefabs.options.Add(paLogoGameObject);
				}

				//Pentagon
				{
					GameObject pentagonGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					pentagonGameObject.name = "pentagon";
					pentagonGameObject.layer = 8;

					Vector3[] pentagonVerts = new Vector3[]
					{
						new Vector3(0, 0.5f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(-0.293893f, -0.404508f, 0f),
						new Vector3(-0.475528f, 0.154509f, 0f)
					};

					int[] pentagonTris = new int[]
					{
						0,
						1,
						2,
						2,
						3,
						0,
						0,
						3,
						4
					};

					pentagonMesh.vertices = pentagonVerts;
					pentagonMesh.triangles = pentagonTris;

					pentagonMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					pentagonMesh.subMeshCount = 1;
					Bounds pentagonMeshBounds = pentagonMesh.bounds;
					pentagonMeshBounds.center = Vector3.zero;
					pentagonMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					pentagonMesh.bounds = pentagonMeshBounds;

					pentagonMesh.name = "pentagon";

					pentagonGameObject.GetComponentInChildren<MeshFilter>().mesh = pentagonMesh;

					Vector2[] pentagonPoints = new Vector2[]
					{
						new Vector2(0, 0.5f),
						new Vector2(0.475528f, 0.154509f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(-0.293893f, -0.404508f),
						new Vector2(-0.475528f, 0.154509f)
					};

					pentagonGameObject.GetComponentInChildren<PolygonCollider2D>().points = pentagonPoints;

					pentagonShapePrefabs.options.Add(pentagonGameObject);
				}

				//Pentagon Hollow
				{
					GameObject pentagonHollowGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					pentagonHollowGameObject.name = "pentagon_outline";
					pentagonHollowGameObject.layer = 8;

					Vector3[] pentagonHollowVerts = new Vector3[]
					{
						new Vector3(0f, 0.5f, 0f),
						new Vector3(-0.475528f, 0.154509f, 0f),
						new Vector3(-0.293893f, -0.404508f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f),

						new Vector3(0f, 0.375f, 0f),
						new Vector3(-0.356646f, 0.115881f, 0f),
						new Vector3(-0.220419f, -0.303381f, 0f),
						new Vector3(0.220419f, -0.303381f, 0f),
						new Vector3(0.356646f, 0.115881f, 0f)
					};

					int[] pentagonHollowTris = new int[]
					{
						//Tri 1
						0,
						6,
						1,
						//Tri 2
						1,
						7,
						2,
						//Tri 3
						2,
						8,
						3,
						//Tri 4
						3,
						9,
						4,
						//Tri 5
						4,
						5,
						0,

						//Tri 6
						0,
						5,
						6,
						//Tri 7
						1,
						6,
						7,
						//Tri 8
						2,
						7,
						8,
						//Tri 9
						3,
						8,
						9,
						//Tri 10
						4,
						9,
						5
					};

					pentagonHollowMesh.vertices = pentagonHollowVerts;
					pentagonHollowMesh.triangles = pentagonHollowTris;

					pentagonHollowMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					pentagonHollowMesh.subMeshCount = 1;
					Bounds pentagonHollowMeshBounds = pentagonHollowMesh.bounds;
					pentagonHollowMeshBounds.center = Vector3.zero;
					pentagonHollowMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					pentagonHollowMesh.bounds = pentagonHollowMeshBounds;

					pentagonHollowMesh.name = "pentagon_outline";

					pentagonHollowGameObject.GetComponentInChildren<MeshFilter>().mesh = pentagonHollowMesh;

					Vector2[] pentagonHollowPoints = new Vector2[]
					{
						new Vector2(0f, 0.5f),
						new Vector2(-0.475528f, 0.154509f),
						new Vector2(-0.293893f, -0.404508f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(0.475528f, 0.154509f),

						new Vector2(0f, 0.375f),
						new Vector2(-0.356646f, 0.115881f),
						new Vector2(-0.220419f, -0.303381f),
						new Vector2(0.220419f, -0.303381f),
						new Vector2(0.356646f, 0.115881f)
					};

					pentagonHollowGameObject.GetComponentInChildren<PolygonCollider2D>().points = pentagonHollowPoints;

					pentagonShapePrefabs.options.Add(pentagonHollowGameObject);
				}

				//Pentagon Hollow Thin
				{
					GameObject pentagonHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					pentagonHollowThinGameObject.name = "pentagon_outline_thin";
					pentagonHollowThinGameObject.layer = 8;

					Vector3[] pentagonHollowThinVerts = new Vector3[]
					{
						new Vector3(0f, 0.5f, 0f),
						new Vector3(-0.475528f, 0.154509f, 0f),
						new Vector3(-0.293893f, -0.404508f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f),

						new Vector3(0f, 0.45f, 0f),
						new Vector3(-0.427975f, 0.139058f, 0f),
						new Vector3(-0.264503f, -0.364058f, 0f),
						new Vector3(0.264503f, -0.364058f, 0f),
						new Vector3(0.427975f, 0.139058f, 0f)
					};

					int[] pentagonHollowThinTris = new int[]
					{
						//Tri 1
						0,
						6,
						1,
						//Tri 2
						1,
						7,
						2,
						//Tri 3
						2,
						8,
						3,
						//Tri 4
						3,
						9,
						4,
						//Tri 5
						4,
						5,
						0,

						//Tri 6
						0,
						5,
						6,
						//Tri 7
						1,
						6,
						7,
						//Tri 8
						2,
						7,
						8,
						//Tri 9
						3,
						8,
						9,
						//Tri 10
						4,
						9,
						5
					};

					pentagonHollowThinMesh.vertices = pentagonHollowThinVerts;
					pentagonHollowThinMesh.triangles = pentagonHollowThinTris;

					pentagonHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					pentagonHollowThinMesh.subMeshCount = 1;
					Bounds pentagonHollowThinMeshBounds = pentagonHollowThinMesh.bounds;
					pentagonHollowThinMeshBounds.center = Vector3.zero;
					pentagonHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					pentagonHollowThinMesh.bounds = pentagonHollowThinMeshBounds;

					pentagonHollowThinMesh.name = "pentagon_outline_thin";

					pentagonHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = pentagonHollowThinMesh;

					Vector2[] pentagonHollowThinPoints = new Vector2[]
					{
						new Vector2(0f, 0.5f),
						new Vector2(-0.475528f, 0.154509f),
						new Vector2(-0.293893f, -0.404508f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(0.475528f, 0.154509f),

						new Vector2(0f, 0.45f),
						new Vector2(-0.427975f, 0.139058f),
						new Vector2(-0.264503f, -0.364058f),
						new Vector2(0.264503f, -0.364058f),
						new Vector2(0.427975f, 0.139058f)
					};

					pentagonHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = pentagonHollowThinPoints;

					pentagonShapePrefabs.options.Add(pentagonHollowThinGameObject);
				}

				//Pentagon Half
				{
					GameObject pentagonHalfGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					pentagonHalfGameObject.name = "pentagon_half";
					pentagonHalfGameObject.layer = 8;

					Vector3[] pentagonHalfVerts = new Vector3[]
					{
						new Vector3(0, 0.5f, 0f),
						new Vector3(0f, -0.404509f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f)
					};

					int[] pentagonHalfTris = new int[]
					{
						0,
						2,
						1,
						0,
						3,
						2
					};

					pentagonHalfMesh.vertices = pentagonHalfVerts;
					pentagonHalfMesh.triangles = pentagonHalfTris;

					pentagonHalfMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					pentagonHalfMesh.subMeshCount = 1;
					Bounds pentagonHalfMeshBounds = pentagonHalfMesh.bounds;
					pentagonHalfMeshBounds.center = Vector3.zero;
					pentagonHalfMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					pentagonHalfMesh.bounds = pentagonHalfMeshBounds;

					pentagonHalfMesh.name = "pentagon_half";

					pentagonHalfGameObject.GetComponentInChildren<MeshFilter>().mesh = pentagonHalfMesh;

					Vector2[] pentagonHalfPoints = new Vector2[]
					{
						new Vector2(0, 0.5f),
						new Vector2(0f, -0.404509f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(0.475528f, 0.154509f)
					};

					pentagonHalfGameObject.GetComponentInChildren<PolygonCollider2D>().points = pentagonHalfPoints;

					pentagonShapePrefabs.options.Add(pentagonHalfGameObject);
				}

				//Pentagon Half Hollow
				{
					GameObject pentagonHalfHollowGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					pentagonHalfHollowGameObject.name = "pentagon_half_outline";
					pentagonHalfHollowGameObject.layer = 8;

					Vector3[] pentagonHalfHollowVerts = new Vector3[]
					{
						new Vector3(0, 0.5f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(0f, -0.404508f, 0f),
						new Vector3(0f, -0.303381f, 0f),
						new Vector3(0.22042f, -0.303381f, 0f),
						new Vector3(0.356646f, 0.115881f, 0f),
						new Vector3(0f, 0.375f, 0f)
					};

					int[] pentagonHalfHollowTris = new int[]
					{
						0,
						6,
						7,
						6,
						1,
						5,
						5,
						2,
						4,
						4,
						2,
						3,
						2,
						5,
						1,
						1,
						6,
						0
					};

					pentagonHalfHollowMesh.vertices = pentagonHalfHollowVerts;
					pentagonHalfHollowMesh.triangles = pentagonHalfHollowTris;

					pentagonHalfHollowMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					pentagonHalfHollowMesh.subMeshCount = 1;
					Bounds pentagonHalfHollowMeshBounds = pentagonHalfHollowMesh.bounds;
					pentagonHalfHollowMeshBounds.center = Vector3.zero;
					pentagonHalfHollowMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					pentagonHalfHollowMesh.bounds = pentagonHalfHollowMeshBounds;

					pentagonHalfHollowMesh.name = "pentagon_half_outline";

					pentagonHalfHollowGameObject.GetComponentInChildren<MeshFilter>().mesh = pentagonHalfHollowMesh;

					Vector2[] pentagonHalfHollowPoints = new Vector2[]
					{
						new Vector2(0, 0.5f),
						new Vector2(0.475528f, 0.154509f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(0f, -0.404508f),
						new Vector2(0f, -0.303381f),
						new Vector2(0.22042f, -0.303381f),
						new Vector2(0.356646f, 0.115881f),
						new Vector2(0f, 0.375f)
					};

					pentagonHalfHollowGameObject.GetComponentInChildren<PolygonCollider2D>().points = pentagonHalfHollowPoints;

					pentagonShapePrefabs.options.Add(pentagonHalfHollowGameObject);
				}

				//Pentagon Half Hollow Thin
				{
					GameObject pentagonHalfHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					pentagonHalfHollowThinGameObject.name = "pentagon_half_outline_thin";
					pentagonHalfHollowThinGameObject.layer = 8;

					Vector3[] pentagonHalfHollowThinVerts = new Vector3[]
					{
						new Vector3(0, 0.5f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(0f, -0.404508f, 0f),
						new Vector3(0f, -0.364058f, 0f),
						new Vector3(0.264503f, -0.364058f, 0f),
						new Vector3(0.427975f, 0.139058f, 0f),
						new Vector3(0f, 0.45f, 0f)
					};

					int[] pentagonHalfHollowThinTris = new int[]
					{
						0,
						6,
						7,
						6,
						1,
						5,
						5,
						2,
						4,
						4,
						2,
						3,
						2,
						5,
						1,
						1,
						6,
						0
					};

					pentagonHalfHollowThinMesh.vertices = pentagonHalfHollowThinVerts;
					pentagonHalfHollowThinMesh.triangles = pentagonHalfHollowThinTris;

					pentagonHalfHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					pentagonHalfHollowThinMesh.subMeshCount = 1;
					Bounds pentagonHalfHollowThinMeshBounds = pentagonHalfHollowThinMesh.bounds;
					pentagonHalfHollowThinMeshBounds.center = Vector3.zero;
					pentagonHalfHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					pentagonHalfHollowThinMesh.bounds = pentagonHalfHollowThinMeshBounds;

					pentagonHalfHollowThinMesh.name = "pentagon_half_outline_thin";

					pentagonHalfHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = pentagonHalfHollowThinMesh;

					Vector2[] pentagonHalfHollowThinPoints = new Vector2[]
					{
						new Vector2(0, 0.5f),
						new Vector2(0.475528f, 0.154509f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(0f, -0.404508f),
						new Vector2(0f, -0.364058f),
						new Vector2(0.264503f, -0.364058f),
						new Vector2(0.427975f, 0.139058f),
						new Vector2(0f, 0.45f)
					};

					pentagonHalfHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = pentagonHalfHollowThinPoints;

					pentagonShapePrefabs.options.Add(pentagonHalfHollowThinGameObject);
				}

				//Chevron Arrow
				{
					GameObject chevronArrowGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					chevronArrowGameObject.name = "chevron_arrow";
					chevronArrowGameObject.layer = 8;

					Vector3[] chevronArrowVerts = new Vector3[]
					{
						new Vector3(0.5f, 0f, 0f),
						new Vector3(0f, -0.5f, 0f),
						new Vector3(-0.5f, -0.5f, 0f),
						new Vector3(0f, 0f, 0f),
						new Vector3(-0.5f, 0.5f, 0f),
						new Vector3(0f, 0.5f, 0f)
					};

					int[] chevronArrowTris = new int[]
					{
						0,
						1,
						2,
						2,
						3,
						0,
						0,
						3,
						4,
						4,
						5,
						0
					};

					chevronArrowMesh.vertices = chevronArrowVerts;
					chevronArrowMesh.triangles = chevronArrowTris;

					chevronArrowMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					chevronArrowMesh.subMeshCount = 1;
					Bounds chevronArrowMeshBounds = chevronArrowMesh.bounds;
					chevronArrowMeshBounds.center = Vector3.zero;
					chevronArrowMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					chevronArrowMesh.bounds = chevronArrowMeshBounds;

					chevronArrowMesh.name = "chevron_arrow";

					chevronArrowGameObject.GetComponentInChildren<MeshFilter>().mesh = chevronArrowMesh;

					Vector2[] chevronArrowPoints = new Vector2[]
					{
						new Vector2(0.5f, 0f),
						new Vector2(0f, -0.5f),
						new Vector2(-0.5f, -0.5f),
						new Vector2(0f, 0f),
						new Vector2(-0.5f, 0.5f),
						new Vector2(0f, 0.5f)
					};

					chevronArrowGameObject.GetComponentInChildren<PolygonCollider2D>().points = chevronArrowPoints;

					ObjectManager.inst.objectPrefabs[3].options.Add(chevronArrowGameObject);
				}

				//Triangle Hollow Thin
				{
					GameObject triangleHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					triangleHollowThinGameObject.name = "triangle_outline_thin";
					triangleHollowThinGameObject.layer = 8;

					Vector3[] triangleHollowThinVerts = new Vector3[]
					{
						new Vector3(0.000000f, 0.575000f, 0.000000f),
						new Vector3(0.498000f, -0.287500f, 0.000000f),
						new Vector3(0.448200f, -0.258750f, 0.000000f),
						new Vector3(0.000000f, 0.517500f, 0.000000f),
						new Vector3(-0.448200f, -0.258750f, 0.000000f),
						new Vector3(-0.498000f, -0.287500f, 0.000000f),
					};

					int[] triangleHollowThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						1,
						4,
						2,
						5,
						0,
						3,
						1,
						5,
						4,
						5,
						3,
						4,
					};

					triangleHollowThinMesh.vertices = triangleHollowThinVerts;
					triangleHollowThinMesh.triangles = triangleHollowThinTris;

					triangleHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					triangleHollowThinMesh.subMeshCount = 1;
					Bounds triangleHollowThinMeshBounds = triangleHollowThinMesh.bounds;
					triangleHollowThinMeshBounds.center = Vector3.zero;
					triangleHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					triangleHollowThinMesh.bounds = triangleHollowThinMeshBounds;

					triangleHollowThinMesh.name = "triangle_outline_thin";

					triangleHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = triangleHollowThinMesh;

					Vector2[] triangleHollowThinPoints = new Vector2[]
					{
						new Vector2(0.000000f, 0.575000f),
						new Vector2(0.498000f, -0.287500f),
						new Vector2(0.448200f, -0.258750f),
						new Vector2(0.000000f, 0.517500f),
						new Vector2(-0.448200f, -0.258750f),
						new Vector2(-0.498000f, -0.287500f),
					};

					triangleHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = triangleHollowThinPoints;

					ObjectManager.inst.objectPrefabs[2].options.Add(triangleHollowThinGameObject);
				}

				//Circle Hollow Thinner
				{
					GameObject circleHollowThinnerGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleHollowThinnerGameObject.name = "circle_outline_thinner";
					circleHollowThinnerGameObject.layer = 8;

					Vector3[] circleHollowThinnerVerts = new Vector3[]
					{
						new Vector3(0.097545f, 0.490392f, 0.000000f),
						new Vector3(0.000000f, 0.479254f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.093498f, 0.470045f, 0.000000f),
						new Vector3(-0.093497f, 0.470045f, 0.000000f),
						new Vector3(0.191342f, 0.461940f, 0.000000f),
						new Vector3(-0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.183402f, 0.442773f, 0.000000f),
						new Vector3(-0.183402f, 0.442773f, 0.000000f),
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(-0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.266259f, 0.398485f, 0.000000f),
						new Vector3(-0.266259f, 0.398485f, 0.000000f),
						new Vector3(0.353553f, 0.353553f, 0.000000f),
						new Vector3(-0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.338884f, 0.338883f, 0.000000f),
						new Vector3(-0.338883f, 0.338884f, 0.000000f),
						new Vector3(0.415735f, 0.277785f, 0.000000f),
						new Vector3(-0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.398485f, 0.266259f, 0.000000f),
						new Vector3(-0.398485f, 0.266259f, 0.000000f),
						new Vector3(0.461940f, 0.191342f, 0.000000f),
						new Vector3(-0.415734f, 0.277785f, 0.000000f),
						new Vector3(0.442773f, 0.183402f, 0.000000f),
						new Vector3(-0.442772f, 0.183403f, 0.000000f),
						new Vector3(0.490393f, 0.097545f, 0.000000f),
						new Vector3(-0.461940f, 0.191342f, 0.000000f),
						new Vector3(0.470045f, 0.093498f, 0.000000f),
						new Vector3(-0.470045f, 0.093498f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(-0.490393f, 0.097546f, 0.000000f),
						new Vector3(0.479254f, 0.000000f, 0.000000f),
						new Vector3(-0.479254f, 0.000000f, 0.000000f),
						new Vector3(0.490393f, -0.097545f, 0.000000f),
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.470045f, -0.093498f, 0.000000f),
						new Vector3(-0.470045f, -0.093497f, 0.000000f),
						new Vector3(0.461940f, -0.191342f, 0.000000f),
						new Vector3(-0.490393f, -0.097545f, 0.000000f),
						new Vector3(0.442773f, -0.183402f, 0.000000f),
						new Vector3(-0.442773f, -0.183402f, 0.000000f),
						new Vector3(0.415735f, -0.277785f, 0.000000f),
						new Vector3(-0.461940f, -0.191341f, 0.000000f),
						new Vector3(0.398485f, -0.266259f, 0.000000f),
						new Vector3(-0.398485f, -0.266259f, 0.000000f),
						new Vector3(0.353553f, -0.353553f, 0.000000f),
						new Vector3(-0.415735f, -0.277785f, 0.000000f),
						new Vector3(0.338884f, -0.338884f, 0.000000f),
						new Vector3(-0.338884f, -0.338883f, 0.000000f),
						new Vector3(0.277785f, -0.415735f, 0.000000f),
						new Vector3(-0.353554f, -0.353553f, 0.000000f),
						new Vector3(0.266259f, -0.398485f, 0.000000f),
						new Vector3(-0.266259f, -0.398485f, 0.000000f),
						new Vector3(0.191342f, -0.461940f, 0.000000f),
						new Vector3(-0.277785f, -0.415735f, 0.000000f),
						new Vector3(0.183402f, -0.442773f, 0.000000f),
						new Vector3(-0.183403f, -0.442773f, 0.000000f),
						new Vector3(0.097545f, -0.490393f, 0.000000f),
						new Vector3(-0.191342f, -0.461940f, 0.000000f),
						new Vector3(0.093498f, -0.470045f, 0.000000f),
						new Vector3(-0.093498f, -0.470045f, 0.000000f),
						new Vector3(0.000000f, -0.500000f, 0.000000f),
						new Vector3(-0.097545f, -0.490393f, 0.000000f),
						new Vector3(0.000000f, -0.479254f, 0.000000f),
					};

					int[] circleHollowThinnerTris = new int[]
					{
						0,
						1,
						2,
						0,
						3,
						1,
						2,
						1,
						4,
						5,
						3,
						0,
						2,
						4,
						6,
						5,
						7,
						3,
						6,
						4,
						8,
						9,
						7,
						5,
						6,
						8,
						10,
						9,
						11,
						7,
						10,
						8,
						12,
						13,
						11,
						9,
						10,
						12,
						14,
						13,
						15,
						11,
						14,
						12,
						16,
						17,
						15,
						13,
						14,
						16,
						18,
						17,
						19,
						15,
						18,
						16,
						20,
						21,
						19,
						17,
						18,
						20,
						22,
						21,
						23,
						19,
						22,
						20,
						24,
						25,
						23,
						21,
						22,
						24,
						26,
						25,
						27,
						23,
						26,
						24,
						28,
						29,
						27,
						25,
						26,
						28,
						30,
						29,
						31,
						27,
						30,
						28,
						32,
						33,
						31,
						29,
						30,
						32,
						34,
						33,
						35,
						31,
						34,
						32,
						36,
						37,
						35,
						33,
						34,
						36,
						38,
						37,
						39,
						35,
						38,
						36,
						40,
						41,
						39,
						37,
						38,
						40,
						42,
						41,
						43,
						39,
						42,
						40,
						44,
						45,
						43,
						41,
						42,
						44,
						46,
						45,
						47,
						43,
						46,
						44,
						48,
						49,
						47,
						45,
						46,
						48,
						50,
						49,
						51,
						47,
						50,
						48,
						52,
						53,
						51,
						49,
						50,
						52,
						54,
						53,
						55,
						51,
						54,
						52,
						56,
						57,
						55,
						53,
						54,
						56,
						58,
						57,
						59,
						55,
						58,
						56,
						60,
						61,
						59,
						57,
						58,
						60,
						62,
						61,
						63,
						59,
						62,
						60,
						63,
						62,
						63,
						61,
					};

					circleHollowThinnerMesh.vertices = circleHollowThinnerVerts;
					circleHollowThinnerMesh.triangles = circleHollowThinnerTris;

					circleHollowThinnerMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleHollowThinnerMesh.subMeshCount = 1;
					Bounds circleHollowThinnerMeshBounds = circleHollowThinnerMesh.bounds;
					circleHollowThinnerMeshBounds.center = Vector3.zero;
					circleHollowThinnerMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleHollowThinnerMesh.bounds = circleHollowThinnerMeshBounds;

					circleHollowThinnerMesh.name = "circle_outline_thinner";

					circleHollowThinnerGameObject.GetComponentInChildren<MeshFilter>().mesh = circleHollowThinnerMesh;

					Vector2[] circleHollowThinnerPoints = new Vector2[]
					{
						new Vector2(0.097545f, 0.490392f),
						new Vector2(0.000000f, 0.479254f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.093498f, 0.470045f),
						new Vector2(-0.093497f, 0.470045f),
						new Vector2(0.191342f, 0.461940f),
						new Vector2(-0.097544f, 0.490393f),
						new Vector2(0.183402f, 0.442773f),
						new Vector2(-0.183402f, 0.442773f),
						new Vector2(0.277785f, 0.415735f),
						new Vector2(-0.191341f, 0.461940f),
						new Vector2(0.266259f, 0.398485f),
						new Vector2(-0.266259f, 0.398485f),
						new Vector2(0.353553f, 0.353553f),
						new Vector2(-0.277785f, 0.415735f),
						new Vector2(0.338884f, 0.338883f),
						new Vector2(-0.338883f, 0.338884f),
						new Vector2(0.415735f, 0.277785f),
						new Vector2(-0.353553f, 0.353554f),
						new Vector2(0.398485f, 0.266259f),
						new Vector2(-0.398485f, 0.266259f),
						new Vector2(0.461940f, 0.191342f),
						new Vector2(-0.415734f, 0.277785f),
						new Vector2(0.442773f, 0.183402f),
						new Vector2(-0.442772f, 0.183403f),
						new Vector2(0.490393f, 0.097545f),
						new Vector2(-0.461940f, 0.191342f),
						new Vector2(0.470045f, 0.093498f),
						new Vector2(-0.470045f, 0.093498f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(-0.490393f, 0.097546f),
						new Vector2(0.479254f, 0.000000f),
						new Vector2(-0.479254f, 0.000000f),
						new Vector2(0.490393f, -0.097545f),
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(0.470045f, -0.093498f),
						new Vector2(-0.470045f, -0.093497f),
						new Vector2(0.461940f, -0.191342f),
						new Vector2(-0.490393f, -0.097545f),
						new Vector2(0.442773f, -0.183402f),
						new Vector2(-0.442773f, -0.183402f),
						new Vector2(0.415735f, -0.277785f),
						new Vector2(-0.461940f, -0.191341f),
						new Vector2(0.398485f, -0.266259f),
						new Vector2(-0.398485f, -0.266259f),
						new Vector2(0.353553f, -0.353553f),
						new Vector2(-0.415735f, -0.277785f),
						new Vector2(0.338884f, -0.338884f),
						new Vector2(-0.338884f, -0.338883f),
						new Vector2(0.277785f, -0.415735f),
						new Vector2(-0.353554f, -0.353553f),
						new Vector2(0.266259f, -0.398485f),
						new Vector2(-0.266259f, -0.398485f),
						new Vector2(0.191342f, -0.461940f),
						new Vector2(-0.277785f, -0.415735f),
						new Vector2(0.183402f, -0.442773f),
						new Vector2(-0.183403f, -0.442773f),
						new Vector2(0.097545f, -0.490393f),
						new Vector2(-0.191342f, -0.461940f),
						new Vector2(0.093498f, -0.470045f),
						new Vector2(-0.093498f, -0.470045f),
						new Vector2(0.000000f, -0.500000f),
						new Vector2(-0.097545f, -0.490393f),
						new Vector2(0.000000f, -0.479254f),
					};

					circleHollowThinnerGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleHollowThinnerPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleHollowThinnerGameObject);
				}

				//Circle Half Outline Thin
				{
					GameObject circleHalfHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleHalfHollowThinGameObject.name = "circle_half_outline_thin";
					circleHalfHollowThinGameObject.layer = 8;

					Vector3[] circleHalfHollowThinVerts = new Vector3[]
					{
						new Vector3(0.097545f, -0.490393f, 0.000000f),
						new Vector3(0.000000f, -0.500000f, 0.000000f),
						new Vector3(0.000000f, -0.451377f, 0.000000f),
						new Vector3(0.088059f, -0.442704f, 0.000000f),
						new Vector3(0.191342f, -0.461940f, 0.000000f),
						new Vector3(0.172735f, -0.417018f, 0.000000f),
						new Vector3(0.277785f, -0.415735f, 0.000000f),
						new Vector3(0.250772f, -0.375306f, 0.000000f),
						new Vector3(0.353554f, -0.353553f, 0.000000f),
						new Vector3(0.319172f, -0.319172f, 0.000000f),
						new Vector3(0.415735f, -0.277785f, 0.000000f),
						new Vector3(0.375306f, -0.250771f, 0.000000f),
						new Vector3(0.461940f, -0.191341f, 0.000000f),
						new Vector3(0.417018f, -0.172734f, 0.000000f),
						new Vector3(0.490393f, -0.097545f, 0.000000f),
						new Vector3(0.442704f, -0.088059f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.451377f, 0.000000f, 0.000000f),
						new Vector3(0.490392f, 0.097546f, 0.000000f),
						new Vector3(0.442704f, 0.088060f, 0.000000f),
						new Vector3(0.461939f, 0.191342f, 0.000000f),
						new Vector3(0.417018f, 0.172735f, 0.000000f),
						new Vector3(0.415734f, 0.277786f, 0.000000f),
						new Vector3(0.375306f, 0.250772f, 0.000000f),
						new Vector3(0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.319171f, 0.319172f, 0.000000f),
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.250771f, 0.375307f, 0.000000f),
						new Vector3(0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.172734f, 0.417018f, 0.000000f),
						new Vector3(0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.088059f, 0.442704f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.000000f, 0.451377f, 0.000000f),
					};

					int[] circleHalfHollowThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
						16,
						15,
						17,
						18,
						16,
						17,
						18,
						17,
						19,
						20,
						18,
						19,
						20,
						19,
						21,
						22,
						20,
						21,
						22,
						21,
						23,
						24,
						22,
						23,
						24,
						23,
						25,
						26,
						24,
						25,
						26,
						25,
						27,
						28,
						26,
						27,
						28,
						27,
						29,
						30,
						28,
						29,
						30,
						29,
						31,
						32,
						30,
						31,
						32,
						31,
						33,
					};

					circleHalfHollowThinMesh.vertices = circleHalfHollowThinVerts;
					circleHalfHollowThinMesh.triangles = circleHalfHollowThinTris;

					circleHalfHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleHalfHollowThinMesh.subMeshCount = 1;
					Bounds circleHalfHollowThinMeshBounds = circleHalfHollowThinMesh.bounds;
					circleHalfHollowThinMeshBounds.center = Vector3.zero;
					circleHalfHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleHalfHollowThinMesh.bounds = circleHalfHollowThinMeshBounds;

					circleHalfHollowThinMesh.name = "circle_half_outline_thin";

					circleHalfHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = circleHalfHollowThinMesh;

					Vector2[] circleHalfHollowThinPoints = new Vector2[]
					{
						new Vector2(0.097545f, -0.490393f),
						new Vector2(0.000000f, -0.500000f),
						new Vector2(0.000000f, -0.451377f),
						new Vector2(0.088059f, -0.442704f),
						new Vector2(0.191342f, -0.461940f),
						new Vector2(0.172735f, -0.417018f),
						new Vector2(0.277785f, -0.415735f),
						new Vector2(0.250772f, -0.375306f),
						new Vector2(0.353554f, -0.353553f),
						new Vector2(0.319172f, -0.319172f),
						new Vector2(0.415735f, -0.277785f),
						new Vector2(0.375306f, -0.250771f),
						new Vector2(0.461940f, -0.191341f),
						new Vector2(0.417018f, -0.172734f),
						new Vector2(0.490393f, -0.097545f),
						new Vector2(0.442704f, -0.088059f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(0.451377f, 0.000000f),
						new Vector2(0.490392f, 0.097546f),
						new Vector2(0.442704f, 0.088060f),
						new Vector2(0.461939f, 0.191342f),
						new Vector2(0.417018f, 0.172735f),
						new Vector2(0.415734f, 0.277786f),
						new Vector2(0.375306f, 0.250772f),
						new Vector2(0.353553f, 0.353554f),
						new Vector2(0.319171f, 0.319172f),
						new Vector2(0.277785f, 0.415735f),
						new Vector2(0.250771f, 0.375307f),
						new Vector2(0.191341f, 0.461940f),
						new Vector2(0.172734f, 0.417018f),
						new Vector2(0.097544f, 0.490393f),
						new Vector2(0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.000000f, 0.451377f),
					};

					circleHalfHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleHalfHollowThinPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleHalfHollowThinGameObject);
				}

				//Circle Half Hollow Thinner
				{
					GameObject circleHalfHollowThinnerGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleHalfHollowThinnerGameObject.name = "circle_half_outline_thinner";
					circleHalfHollowThinnerGameObject.layer = 8;

					Vector3[] circleHalfHollowThinnerVerts = new Vector3[]
					{
						new Vector3(0.097545f, -0.490393f, 0.000000f),
						new Vector3(0.000000f, -0.500000f, 0.000000f),
						new Vector3(0.000000f, -0.479254f, 0.000000f),
						new Vector3(0.093498f, -0.470045f, 0.000000f),
						new Vector3(0.191342f, -0.461940f, 0.000000f),
						new Vector3(0.183403f, -0.442773f, 0.000000f),
						new Vector3(0.277785f, -0.415735f, 0.000000f),
						new Vector3(0.266259f, -0.398485f, 0.000000f),
						new Vector3(0.353554f, -0.353553f, 0.000000f),
						new Vector3(0.338884f, -0.338883f, 0.000000f),
						new Vector3(0.415735f, -0.277785f, 0.000000f),
						new Vector3(0.398485f, -0.266259f, 0.000000f),
						new Vector3(0.461940f, -0.191341f, 0.000000f),
						new Vector3(0.442773f, -0.183402f, 0.000000f),
						new Vector3(0.490393f, -0.097545f, 0.000000f),
						new Vector3(0.470045f, -0.093497f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.479254f, 0.000000f, 0.000000f),
						new Vector3(0.490393f, 0.097546f, 0.000000f),
						new Vector3(0.470045f, 0.093498f, 0.000000f),
						new Vector3(0.461940f, 0.191342f, 0.000000f),
						new Vector3(0.442772f, 0.183403f, 0.000000f),
						new Vector3(0.415734f, 0.277785f, 0.000000f),
						new Vector3(0.398485f, 0.266259f, 0.000000f),
						new Vector3(0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.338883f, 0.338884f, 0.000000f),
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.266259f, 0.398485f, 0.000000f),
						new Vector3(0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.183402f, 0.442773f, 0.000000f),
						new Vector3(0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.093497f, 0.470045f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.000000f, 0.479254f, 0.000000f),

					};

					int[] circleHalfHollowThinnerTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
						16,
						15,
						17,
						18,
						16,
						17,
						18,
						17,
						19,
						20,
						18,
						19,
						20,
						19,
						21,
						22,
						20,
						21,
						22,
						21,
						23,
						24,
						22,
						23,
						24,
						23,
						25,
						26,
						24,
						25,
						26,
						25,
						27,
						28,
						26,
						27,
						28,
						27,
						29,
						30,
						28,
						29,
						30,
						29,
						31,
						32,
						30,
						31,
						32,
						31,
						33,

					};

					circleHalfHollowThinnerMesh.vertices = circleHalfHollowThinnerVerts;
					circleHalfHollowThinnerMesh.triangles = circleHalfHollowThinnerTris;

					circleHalfHollowThinnerMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleHalfHollowThinnerMesh.subMeshCount = 1;
					Bounds circleHalfHollowThinnerMeshBounds = circleHalfHollowThinnerMesh.bounds;
					circleHalfHollowThinnerMeshBounds.center = Vector3.zero;
					circleHalfHollowThinnerMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleHalfHollowThinnerMesh.bounds = circleHalfHollowThinnerMeshBounds;

					circleHalfHollowThinnerMesh.name = "circle_half_outline_thinner";

					circleHalfHollowThinnerGameObject.GetComponentInChildren<MeshFilter>().mesh = circleHalfHollowThinnerMesh;

					Vector2[] circleHalfHollowThinnerPoints = new Vector2[]
					{
						new Vector2(0.097545f, -0.490393f),
						new Vector2(0.000000f, -0.500000f),
						new Vector2(0.000000f, -0.479254f),
						new Vector2(0.093498f, -0.470045f),
						new Vector2(0.191342f, -0.461940f),
						new Vector2(0.183403f, -0.442773f),
						new Vector2(0.277785f, -0.415735f),
						new Vector2(0.266259f, -0.398485f),
						new Vector2(0.353554f, -0.353553f),
						new Vector2(0.338884f, -0.338883f),
						new Vector2(0.415735f, -0.277785f),
						new Vector2(0.398485f, -0.266259f),
						new Vector2(0.461940f, -0.191341f),
						new Vector2(0.442773f, -0.183402f),
						new Vector2(0.490393f, -0.097545f),
						new Vector2(0.470045f, -0.093497f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(0.479254f, 0.000000f),
						new Vector2(0.490393f, 0.097546f),
						new Vector2(0.470045f, 0.093498f),
						new Vector2(0.461940f, 0.191342f),
						new Vector2(0.442772f, 0.183403f),
						new Vector2(0.415734f, 0.277785f),
						new Vector2(0.398485f, 0.266259f),
						new Vector2(0.353553f, 0.353554f),
						new Vector2(0.338883f, 0.338884f),
						new Vector2(0.277785f, 0.415735f),
						new Vector2(0.266259f, 0.398485f),
						new Vector2(0.191341f, 0.461940f),
						new Vector2(0.183402f, 0.442773f),
						new Vector2(0.097544f, 0.490393f),
						new Vector2(0.093497f, 0.470045f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.000000f, 0.479254f),

					};

					circleHalfHollowThinnerGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleHalfHollowThinnerPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleHalfHollowThinnerGameObject);
				}

				//Circle Quarter Hollow Thin
				{
					GameObject circleQuarterHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleQuarterHollowThinGameObject.name = "circle_quarter_outline_thin";
					circleQuarterHollowThinGameObject.layer = 8;

					Vector3[] circleQuarterHollowThinVerts = new Vector3[]
					{
						new Vector3(0.490392f, 0.097546f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.451377f, 0.000000f, 0.000000f),
						new Vector3(0.442704f, 0.088060f, 0.000000f),
						new Vector3(0.461939f, 0.191342f, 0.000000f),
						new Vector3(0.417018f, 0.172735f, 0.000000f),
						new Vector3(0.415734f, 0.277786f, 0.000000f),
						new Vector3(0.375306f, 0.250772f, 0.000000f),
						new Vector3(0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.319171f, 0.319172f, 0.000000f),
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.250771f, 0.375307f, 0.000000f),
						new Vector3(0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.172734f, 0.417018f, 0.000000f),
						new Vector3(0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.088059f, 0.442704f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.000000f, 0.451377f, 0.000000f),
					};

					int[] circleQuarterHollowThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
						16,
						15,
						17,

					};

					circleQuarterHollowThinMesh.vertices = circleQuarterHollowThinVerts;
					circleQuarterHollowThinMesh.triangles = circleQuarterHollowThinTris;

					circleQuarterHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleQuarterHollowThinMesh.subMeshCount = 1;
					Bounds circleQuarterHollowThinMeshBounds = circleQuarterHollowThinMesh.bounds;
					circleQuarterHollowThinMeshBounds.center = Vector3.zero;
					circleQuarterHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleQuarterHollowThinMesh.bounds = circleQuarterHollowThinMeshBounds;

					circleQuarterHollowThinMesh.name = "circle_quarter_outline_thin";

					circleQuarterHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = circleQuarterHollowThinMesh;

					Vector2[] circleQuarterHollowThinPoints = new Vector2[]
					{
						new Vector2(0.490392f, 0.097546f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(0.451377f, 0.000000f),
						new Vector2(0.442704f, 0.088060f),
						new Vector2(0.461939f, 0.191342f),
						new Vector2(0.417018f, 0.172735f),
						new Vector2(0.415734f, 0.277786f),
						new Vector2(0.375306f, 0.250772f),
						new Vector2(0.353553f, 0.353554f),
						new Vector2(0.319171f, 0.319172f),
						new Vector2(0.277785f, 0.415735f),
						new Vector2(0.250771f, 0.375307f),
						new Vector2(0.191341f, 0.461940f),
						new Vector2(0.172734f, 0.417018f),
						new Vector2(0.097544f, 0.490393f),
						new Vector2(0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.000000f, 0.451377f),

					};

					circleQuarterHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleQuarterHollowThinPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleQuarterHollowThinGameObject);
				}

				//Circle Quarter Hollow Thinner
				{
					GameObject circleQuarterHollowThinnerGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleQuarterHollowThinnerGameObject.name = "circle_quarter_outline_thinner";
					circleQuarterHollowThinnerGameObject.layer = 8;

					Vector3[] circleQuarterHollowThinnerVerts = new Vector3[]
					{
						new Vector3(0.490393f, 0.097546f, 0.000000f),
						new Vector3(0.500000f, 0.000000f, 0.000000f),
						new Vector3(0.479254f, 0.000000f, 0.000000f),
						new Vector3(0.470045f, 0.093498f, 0.000000f),
						new Vector3(0.461940f, 0.191342f, 0.000000f),
						new Vector3(0.442772f, 0.183403f, 0.000000f),
						new Vector3(0.415734f, 0.277786f, 0.000000f),
						new Vector3(0.398485f, 0.266259f, 0.000000f),
						new Vector3(0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.338883f, 0.338884f, 0.000000f),
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.266259f, 0.398485f, 0.000000f),
						new Vector3(0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.183402f, 0.442773f, 0.000000f),
						new Vector3(0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.093497f, 0.470045f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.000000f, 0.479254f, 0.000000f),

					};

					int[] circleQuarterHollowThinnerTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
						16,
						15,
						17,

					};

					circleQuarterHollowThinnerMesh.vertices = circleQuarterHollowThinnerVerts;
					circleQuarterHollowThinnerMesh.triangles = circleQuarterHollowThinnerTris;

					circleQuarterHollowThinnerMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleQuarterHollowThinnerMesh.subMeshCount = 1;
					Bounds circleQuarterHollowThinnerMeshBounds = circleQuarterHollowThinnerMesh.bounds;
					circleQuarterHollowThinnerMeshBounds.center = Vector3.zero;
					circleQuarterHollowThinnerMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleQuarterHollowThinnerMesh.bounds = circleQuarterHollowThinnerMeshBounds;

					circleQuarterHollowThinnerMesh.name = "circle_quarter_outline_thinner";

					circleQuarterHollowThinnerGameObject.GetComponentInChildren<MeshFilter>().mesh = circleQuarterHollowThinnerMesh;

					Vector2[] circleQuarterHollowThinnerPoints = new Vector2[]
					{
						new Vector2(0.490393f, 0.097546f),
						new Vector2(0.500000f, 0.000000f),
						new Vector2(0.479254f, 0.000000f),
						new Vector2(0.470045f, 0.093498f),
						new Vector2(0.461940f, 0.191342f),
						new Vector2(0.442772f, 0.183403f),
						new Vector2(0.415734f, 0.277786f),
						new Vector2(0.398485f, 0.266259f),
						new Vector2(0.353553f, 0.353554f),
						new Vector2(0.338883f, 0.338884f),
						new Vector2(0.277785f, 0.415735f),
						new Vector2(0.266259f, 0.398485f),
						new Vector2(0.191341f, 0.461940f),
						new Vector2(0.183402f, 0.442773f),
						new Vector2(0.097544f, 0.490393f),
						new Vector2(0.093497f, 0.470045f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.000000f, 0.479254f),

					};

					circleQuarterHollowThinnerGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleQuarterHollowThinnerPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleQuarterHollowThinnerGameObject);
				}

				//Circle Eighth Hollow Thin
				{
					GameObject circleEighthHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleEighthHollowThinGameObject.name = "circle_eighth_outline_thin";
					circleEighthHollowThinGameObject.layer = 8;

					Vector3[] circleEighthHollowThinVerts = new Vector3[]
					{
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.319171f, 0.319172f, 0.000000f),
						new Vector3(0.250771f, 0.375307f, 0.000000f),
						new Vector3(0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.172734f, 0.417018f, 0.000000f),
						new Vector3(0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.088059f, 0.442704f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.000000f, 0.451377f, 0.000000f),

					};

					int[] circleEighthHollowThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,

					};

					circleEighthHollowThinMesh.vertices = circleEighthHollowThinVerts;
					circleEighthHollowThinMesh.triangles = circleEighthHollowThinTris;

					circleEighthHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleEighthHollowThinMesh.subMeshCount = 1;
					Bounds circleEighthHollowThinMeshBounds = circleEighthHollowThinMesh.bounds;
					circleEighthHollowThinMeshBounds.center = Vector3.zero;
					circleEighthHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleEighthHollowThinMesh.bounds = circleEighthHollowThinMeshBounds;

					circleEighthHollowThinMesh.name = "circle_eighth_outline_thin";

					circleEighthHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = circleEighthHollowThinMesh;

					Vector2[] circleEighthHollowThinPoints = new Vector2[]
					{
						new Vector2(0.277785f, 0.415735f),
						new Vector2(0.353553f, 0.353554f),
						new Vector2(0.319171f, 0.319172f),
						new Vector2(0.250771f, 0.375307f),
						new Vector2(0.191341f, 0.461940f),
						new Vector2(0.172734f, 0.417018f),
						new Vector2(0.097544f, 0.490393f),
						new Vector2(0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.000000f, 0.451377f),

					};

					circleEighthHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleEighthHollowThinPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleEighthHollowThinGameObject);
				}

				//Circle Eighth Hollow Thinner
				{
					GameObject circleEighthHollowThinnerGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					circleEighthHollowThinnerGameObject.name = "circle_eighth_outline_thinner";
					circleEighthHollowThinnerGameObject.layer = 8;

					Vector3[] circleEighthHollowThinnerVerts = new Vector3[]
					{
						new Vector3(0.277785f, 0.415735f, 0.000000f),
						new Vector3(0.353553f, 0.353554f, 0.000000f),
						new Vector3(0.338883f, 0.338884f, 0.000000f),
						new Vector3(0.266259f, 0.398485f, 0.000000f),
						new Vector3(0.191341f, 0.461940f, 0.000000f),
						new Vector3(0.183402f, 0.442773f, 0.000000f),
						new Vector3(0.097544f, 0.490393f, 0.000000f),
						new Vector3(0.093497f, 0.470045f, 0.000000f),
						new Vector3(0.000000f, 0.500000f, 0.000000f),
						new Vector3(0.000000f, 0.479254f, 0.000000f),

					};

					int[] circleEighthHollowThinnerTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,

					};

					circleEighthHollowThinnerMesh.vertices = circleEighthHollowThinnerVerts;
					circleEighthHollowThinnerMesh.triangles = circleEighthHollowThinnerTris;

					circleEighthHollowThinnerMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleEighthHollowThinnerMesh.subMeshCount = 1;
					Bounds circleEighthHollowThinnerMeshBounds = circleEighthHollowThinnerMesh.bounds;
					circleEighthHollowThinnerMeshBounds.center = Vector3.zero;
					circleEighthHollowThinnerMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleEighthHollowThinnerMesh.bounds = circleEighthHollowThinnerMeshBounds;

					circleEighthHollowThinnerMesh.name = "circle_eighth_outline_thinner";

					circleEighthHollowThinnerGameObject.GetComponentInChildren<MeshFilter>().mesh = circleEighthHollowThinnerMesh;

					Vector2[] circleEighthHollowThinnerPoints = new Vector2[]
					{
						new Vector2(0.277785f, 0.415735f),
						new Vector2(0.353553f, 0.353554f),
						new Vector2(0.338883f, 0.338884f),
						new Vector2(0.266259f, 0.398485f),
						new Vector2(0.191341f, 0.461940f),
						new Vector2(0.183402f, 0.442773f),
						new Vector2(0.097544f, 0.490393f),
						new Vector2(0.093497f, 0.470045f),
						new Vector2(0.000000f, 0.500000f),
						new Vector2(0.000000f, 0.479254f),

					};

					circleEighthHollowThinnerGameObject.GetComponentInChildren<PolygonCollider2D>().points = circleEighthHollowThinnerPoints;

					ObjectManager.inst.objectPrefabs[1].options.Add(circleEighthHollowThinnerGameObject);
				}

				//Diamond
				{
					GameObject diamond = Instantiate(ObjectManager.inst.objectPrefabs[0].options[0]);
					diamond.name = "diamond";
					diamond.layer = 8;

					Vector3[] diamondVerts = diamond.GetComponentInChildren<MeshFilter>().mesh.vertices;

					diamondVerts[0] = Rotate(diamondVerts[0], 45f);
					diamondVerts[1] = Rotate(diamondVerts[1], 45f);
					diamondVerts[2] = Rotate(diamondVerts[2], 45f);
					diamondVerts[3] = Rotate(diamondVerts[3], 45f);

					diamond.GetComponentInChildren<MeshFilter>().mesh.vertices = diamondVerts;
					diamondMesh = diamond.GetComponentInChildren<MeshFilter>().mesh;

					GameObject diamondBase = diamond.GetComponentInChildren<MeshFilter>().gameObject;
					if (diamondBase.GetComponent<BoxCollider2D>())
					{
						Destroy(diamondBase.GetComponent<BoxCollider2D>());
						var poly = diamondBase.AddComponent<PolygonCollider2D>();
						poly.isTrigger = true;
						poly.CreateCollider(diamond.GetComponentInChildren<MeshFilter>());
					}
					diamond.GetComponentInChildren<MeshRenderer>().enabled = true;

					ObjectManager.inst.objectPrefabs[0].options.Add(diamond);
				}

				//Diamond Hollow
				{
					GameObject diamondHollow = Instantiate(ObjectManager.inst.objectPrefabs[0].options[1]);
					diamondHollow.name = "diamond_outline";
					diamondHollow.layer = 8;

					Vector3[] diamondHollowVerts = diamondHollow.GetComponentInChildren<MeshFilter>().mesh.vertices;

					diamondHollowVerts[0] = Rotate(diamondHollowVerts[0], 45f);
					diamondHollowVerts[1] = Rotate(diamondHollowVerts[1], 45f);
					diamondHollowVerts[2] = Rotate(diamondHollowVerts[2], 45f);
					diamondHollowVerts[3] = Rotate(diamondHollowVerts[3], 45f);
					diamondHollowVerts[4] = Rotate(diamondHollowVerts[4], 45f);
					diamondHollowVerts[5] = Rotate(diamondHollowVerts[5], 45f);
					diamondHollowVerts[6] = Rotate(diamondHollowVerts[6], 45f);
					diamondHollowVerts[7] = Rotate(diamondHollowVerts[7], 45f);

					diamondHollow.GetComponentInChildren<MeshFilter>().mesh.vertices = diamondHollowVerts;
					diamondHollowMesh = diamondHollow.GetComponentInChildren<MeshFilter>().mesh;

					GameObject diamondHollowBase = diamondHollow.GetComponentInChildren<MeshFilter>().gameObject;
					if (diamondHollowBase.GetComponent<BoxCollider2D>())
					{
						Destroy(diamondHollowBase.GetComponent<BoxCollider2D>());
						var poly = diamondHollowBase.AddComponent<PolygonCollider2D>();
						poly.isTrigger = true;
						poly.CreateCollider(diamondHollow.GetComponentInChildren<MeshFilter>());
					}

					ObjectManager.inst.objectPrefabs[0].options.Add(diamondHollow);
				}

				//Diamond Hollow Thin
				{
					GameObject diamondHollowThin = Instantiate(ObjectManager.inst.objectPrefabs[0].options[2]);
					diamondHollowThin.name = "diamond_outline_thin";
					diamondHollowThin.layer = 8;

					Vector3[] diamondHollowThinVerts = diamondHollowThin.GetComponentInChildren<MeshFilter>().mesh.vertices;

					diamondHollowThinVerts[0] = Rotate(diamondHollowThinVerts[0], 45f);
					diamondHollowThinVerts[1] = Rotate(diamondHollowThinVerts[1], 45f);
					diamondHollowThinVerts[2] = Rotate(diamondHollowThinVerts[2], 45f);
					diamondHollowThinVerts[3] = Rotate(diamondHollowThinVerts[3], 45f);
					diamondHollowThinVerts[4] = Rotate(diamondHollowThinVerts[4], 45f);
					diamondHollowThinVerts[5] = Rotate(diamondHollowThinVerts[5], 45f);
					diamondHollowThinVerts[6] = Rotate(diamondHollowThinVerts[6], 45f);
					diamondHollowThinVerts[7] = Rotate(diamondHollowThinVerts[7], 45f);

					diamondHollowThin.GetComponentInChildren<MeshFilter>().mesh.vertices = diamondHollowThinVerts;
					diamondHollowThinMesh = diamondHollowThin.GetComponentInChildren<MeshFilter>().mesh;

					GameObject diamondHollowThinBase = diamondHollowThin.GetComponentInChildren<MeshFilter>().gameObject;
					if (diamondHollowThinBase.GetComponent<BoxCollider2D>())
					{
						Destroy(diamondHollowThinBase.GetComponent<BoxCollider2D>());
						var poly = diamondHollowThinBase.AddComponent<PolygonCollider2D>();
						poly.isTrigger = true;
						poly.CreateCollider(diamondHollowThin.GetComponentInChildren<MeshFilter>());
					}

					ObjectManager.inst.objectPrefabs[0].options.Add(diamondHollowThin);
				}

				//Star
				{
					GameObject starGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					starGameObject.name = "star";
					starGameObject.layer = 8;

					Vector3[] starVerts = new Vector3[]
					{
						new Vector3(0f, 0.5f, 0f),
						new Vector3(0.111967f, 0.154109f, 0f),
						new Vector3(0.475528f, 0.154509f, 0f),
						new Vector3(0.181166f, -0.058864f, 0f),
						new Vector3(0.293893f, -0.404508f, 0f),
						new Vector3(0f, -0.190489f, 0f),
						new Vector3(-0.293893f, -0.404508f, 0f),
						new Vector3(-0.181166f, -0.058864f, 0f),
						new Vector3(-0.475528f, 0.154509f, 0f),
						new Vector3(-0.111967f, 0.154109f, 0f)
					};

					int[] starTris = new int[]
					{
						//Point 1
						0,
						1,
						9,
						//Point 2
						1,
						2,
						3,
						//Point 3
						3,
						4,
						5,
						//Point 4
						5,
						6,
						7,
						//Point 5
						7,
						8,
						9,
						//Middle 1
						1,
						5,
						9,
						//Middle 2
						1,
						3,
						5,
						//Middle 3
						9,
						5,
						7
					};

					starMesh.vertices = starVerts;
					starMesh.triangles = starTris;

					starMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					starMesh.subMeshCount = 1;
					Bounds starMeshBounds = starMesh.bounds;
					starMeshBounds.center = Vector3.zero;
					starMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					starMesh.bounds = starMeshBounds;

					starMesh.name = "star";

					starGameObject.GetComponentInChildren<MeshFilter>().mesh = starMesh;

					Vector2[] starPoints = new Vector2[]
					{
						new Vector2(0f, 0.5f),
						new Vector2(0.111967f, 0.154109f),
						new Vector2(0.475528f, 0.154509f),
						new Vector2(0.181166f, -0.058864f),
						new Vector2(0.293893f, -0.404508f),
						new Vector2(0f, -0.190489f),
						new Vector2(-0.293893f, -0.404508f),
						new Vector2(-0.181166f, -0.058864f),
						new Vector2(-0.475528f, 0.154509f),
						new Vector2(-0.111967f, 0.154109f)
					};

					starGameObject.GetComponentInChildren<PolygonCollider2D>().points = starPoints;

					miscShapePrefabs.options.Add(starGameObject);
				}

				//Moon
				{
					GameObject moonGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					moonGameObject.name = "moon";
					moonGameObject.layer = 8;

					Vector3[] moonVerts = new Vector3[]
					{
						//new Vector3(0f, 0.374848f, 0f), 0
						//new Vector3(0.097544f, 0.392314f, 0f), 1
						//new Vector3(0.191341f, 0.378791f, 0f), 2
						//new Vector3(0.277785f, 0.349218f, 0f), 3
						//new Vector3(0.353553f, 0.304056f, 0f), 4
						//new Vector3(0.415734f, 0.244451f, 0f), 5
						//new Vector3(0.461939f, 0.172208f, 0f), 6

						new Vector3(-0.097544f, 0.392314f, 0.000000f),
						new Vector3(0.000000f, 0.374848f, 0.000000f),
						new Vector3(-0.073129f, 0.367646f, 0.000000f),
						new Vector3(-0.191341f, 0.378791f, 0.000000f),
						new Vector3(-0.143448f, 0.346315f, 0.000000f),
						new Vector3(-0.277785f, 0.349218f, 0.000000f),
						new Vector3(-0.208254f, 0.311675f, 0.000000f),
						new Vector3(-0.353553f, 0.304056f, 0.000000f),
						new Vector3(-0.265057f, 0.265058f, 0.000000f),
						new Vector3(-0.415734f, 0.244451f, 0.000000f),
						new Vector3(-0.311675f, 0.208255f, 0.000000f),
						new Vector3(-0.461940f, 0.172208f, 0.000000f),
						new Vector3(-0.346314f, 0.143449f, 0.000000f),
						new Vector3(-0.490393f, 0.089742f, 0.000000f),
						new Vector3(-0.367645f, 0.073130f, 0.000000f),
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(-0.374848f, 0.000000f, 0.000000f),
						new Vector3(-0.490393f, -0.089741f, 0.000000f),
						new Vector3(-0.367646f, -0.073129f, 0.000000f),
						new Vector3(-0.461940f, -0.172207f, 0.000000f),
						new Vector3(-0.346315f, -0.143448f, 0.000000f),
						new Vector3(-0.415735f, -0.244451f, 0.000000f),
						new Vector3(-0.311675f, -0.208254f, 0.000000f),
						new Vector3(-0.353554f, -0.304056f, 0.000000f),
						new Vector3(-0.265058f, -0.265058f, 0.000000f),
						new Vector3(-0.277785f, -0.349217f, 0.000000f),
						new Vector3(-0.208255f, -0.311675f, 0.000000f),
						new Vector3(-0.191342f, -0.378790f, 0.000000f),
						new Vector3(-0.143448f, -0.346314f, 0.000000f),
						new Vector3(-0.097545f, -0.392314f, 0.000000f),
						new Vector3(-0.073129f, -0.367645f, 0.000000f),
						new Vector3(0.000000f, -0.374848f, 0.000000f),

					};

					int[] moonTris = new int[]
					{
						//Point 1
						//0,
						//1,
						//2,

						0,
						1,
						2,
						0,
						2,
						3,
						2,
						4,
						3,
						3,
						4,
						5,
						4,
						6,
						5,
						5,
						6,
						7,
						6,
						8,
						7,
						7,
						8,
						9,
						8,
						10,
						9,
						9,
						10,
						11,
						10,
						12,
						11,
						11,
						12,
						13,
						12,
						14,
						13,
						13,
						14,
						15,
						14,
						16,
						15,
						15,
						16,
						17,
						16,
						18,
						17,
						17,
						18,
						19,
						18,
						20,
						19,
						19,
						20,
						21,
						20,
						22,
						21,
						21,
						22,
						23,
						22,
						24,
						23,
						23,
						24,
						25,
						24,
						26,
						25,
						25,
						26,
						27,
						26,
						28,
						27,
						27,
						28,
						29,
						28,
						30,
						29,
						29,
						30,
						31,

					};

					moonMesh.vertices = moonVerts;
					moonMesh.triangles = moonTris;

					moonMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					moonMesh.subMeshCount = 1;
					Bounds moonMeshBounds = moonMesh.bounds;
					moonMeshBounds.center = Vector3.zero;
					moonMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					moonMesh.bounds = moonMeshBounds;

					moonMesh.name = "moon";

					moonGameObject.GetComponentInChildren<MeshFilter>().mesh = moonMesh;

					Vector2[] moonPoints = new Vector2[]
					{
						new Vector2(-0.097545f, -0.451161f),
						new Vector2(-0.088059f, -0.442704f),
						new Vector2(0.000000f, -0.451377f),
						new Vector2(-0.172735f, -0.417018f),
						new Vector2(-0.191342f, -0.434223f),
						new Vector2(-0.250772f, -0.375306f),
						new Vector2(-0.277785f, -0.399105f),
						new Vector2(-0.319172f, -0.319172f),
						new Vector2(-0.353554f, -0.346482f),
						new Vector2(-0.375306f, -0.250771f),
						new Vector2(-0.415735f, -0.277785f),
						new Vector2(-0.417018f, -0.172734f),
						new Vector2(-0.461940f, -0.191341f),
						new Vector2(-0.490393f, -0.097545f),
						new Vector2(-0.442704f, -0.088059f),
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(-0.451377f, 0.000000f),
						new Vector2(-0.490393f, 0.097546f),
						new Vector2(-0.442704f, 0.088060f),
						new Vector2(-0.461940f, 0.191342f),
						new Vector2(-0.417018f, 0.172735f),
						new Vector2(-0.375306f, 0.250772f),
						new Vector2(-0.415734f, 0.277786f),
						new Vector2(-0.353553f, 0.346483f),
						new Vector2(-0.319171f, 0.319172f),
						new Vector2(-0.277785f, 0.399106f),
						new Vector2(-0.250771f, 0.375307f),
						new Vector2(-0.191341f, 0.434224f),
						new Vector2(-0.172734f, 0.417018f),
						new Vector2(-0.097544f, 0.451161f),
						new Vector2(-0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.451377f),
					};

					moonGameObject.GetComponentInChildren<PolygonCollider2D>().points = moonPoints;

					miscShapePrefabs.options.Add(moonGameObject);
				}

				//Moon Thin
				{
					GameObject moonThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					moonThinGameObject.name = "moon_thin";
					moonThinGameObject.layer = 8;

					Vector3[] moonThinVerts = new Vector3[]
					{
						new Vector3(-0.097545f, -0.451161f, 0.000000f),
						new Vector3(-0.088059f, -0.442704f, 0.000000f),
						new Vector3(0.000000f, -0.451377f, 0.000000f),
						new Vector3(-0.172735f, -0.417018f, 0.000000f),
						new Vector3(-0.191342f, -0.434223f, 0.000000f),
						new Vector3(-0.250772f, -0.375306f, 0.000000f),
						new Vector3(-0.277785f, -0.399105f, 0.000000f),
						new Vector3(-0.319172f, -0.319172f, 0.000000f),
						new Vector3(-0.353554f, -0.346482f, 0.000000f),
						new Vector3(-0.375306f, -0.250771f, 0.000000f),
						new Vector3(-0.415735f, -0.277785f, 0.000000f),
						new Vector3(-0.417018f, -0.172734f, 0.000000f),
						new Vector3(-0.461940f, -0.191341f, 0.000000f),
						new Vector3(-0.490393f, -0.097545f, 0.000000f),
						new Vector3(-0.442704f, -0.088059f, 0.000000f),
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(-0.451377f, 0.000000f, 0.000000f),
						new Vector3(-0.490393f, 0.097546f, 0.000000f),
						new Vector3(-0.442704f, 0.088060f, 0.000000f),
						new Vector3(-0.461940f, 0.191342f, 0.000000f),
						new Vector3(-0.417018f, 0.172735f, 0.000000f),
						new Vector3(-0.375306f, 0.250772f, 0.000000f),
						new Vector3(-0.415734f, 0.277786f, 0.000000f),
						new Vector3(-0.353553f, 0.346483f, 0.000000f),
						new Vector3(-0.319171f, 0.319172f, 0.000000f),
						new Vector3(-0.277785f, 0.399106f, 0.000000f),
						new Vector3(-0.250771f, 0.375307f, 0.000000f),
						new Vector3(-0.191341f, 0.434224f, 0.000000f),
						new Vector3(-0.172734f, 0.417018f, 0.000000f),
						new Vector3(-0.097544f, 0.451161f, 0.000000f),
						new Vector3(-0.088059f, 0.442704f, 0.000000f),
						new Vector3(0.000000f, 0.451377f, 0.000000f),
					};

					int[] moonThinTris = new int[]
					{
						//Point 1
						//0,
						//1,
						//2,

						0,
						1,
						2,
						0,
						3,
						1,
						0,
						4,
						3,
						4,
						5,
						3,
						4,
						6,
						5,
						6,
						7,
						5,
						6,
						8,
						7,
						8,
						9,
						7,
						8,
						10,
						9,
						10,
						11,
						9,
						10,
						12,
						11,
						13,
						11,
						12,
						13,
						14,
						11,
						15,
						14,
						13,
						15,
						16,
						14,
						17,
						16,
						15,
						17,
						18,
						16,
						19,
						18,
						17,
						19,
						20,
						18,
						19,
						21,
						20,
						19,
						22,
						21,
						23,
						21,
						22,
						23,
						24,
						21,
						25,
						24,
						23,
						25,
						26,
						24,
						27,
						26,
						25,
						27,
						28,
						26,
						29,
						28,
						27,
						29,
						30,
						28,
						31,
						30,
						29,
					};

					moonThinMesh.vertices = moonThinVerts;
					moonThinMesh.triangles = moonThinTris;

					moonThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					moonThinMesh.subMeshCount = 1;
					Bounds moonThinMeshBounds = moonThinMesh.bounds;
					moonThinMeshBounds.center = Vector3.zero;
					moonThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					moonThinMesh.bounds = moonThinMeshBounds;

					moonThinMesh.name = "moon_thin";

					moonThinGameObject.GetComponentInChildren<MeshFilter>().mesh = moonThinMesh;

					Vector2[] moonThinPoints = new Vector2[]
					{
						new Vector2(-0.097545f, -0.451161f),
						new Vector2(-0.088059f, -0.442704f),
						new Vector2(0.000000f, -0.451377f),
						new Vector2(-0.172735f, -0.417018f),
						new Vector2(-0.191342f, -0.434223f),
						new Vector2(-0.250772f, -0.375306f),
						new Vector2(-0.277785f, -0.399105f),
						new Vector2(-0.319172f, -0.319172f),
						new Vector2(-0.353554f, -0.346482f),
						new Vector2(-0.375306f, -0.250771f),
						new Vector2(-0.415735f, -0.277785f),
						new Vector2(-0.417018f, -0.172734f),
						new Vector2(-0.461940f, -0.191341f),
						new Vector2(-0.490393f, -0.097545f),
						new Vector2(-0.442704f, -0.088059f),
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(-0.451377f, 0.000000f),
						new Vector2(-0.490393f, 0.097546f),
						new Vector2(-0.442704f, 0.088060f),
						new Vector2(-0.461940f, 0.191342f),
						new Vector2(-0.417018f, 0.172735f),
						new Vector2(-0.375306f, 0.250772f),
						new Vector2(-0.415734f, 0.277786f),
						new Vector2(-0.353553f, 0.346483f),
						new Vector2(-0.319171f, 0.319172f),
						new Vector2(-0.277785f, 0.399106f),
						new Vector2(-0.250771f, 0.375307f),
						new Vector2(-0.191341f, 0.434224f),
						new Vector2(-0.172734f, 0.417018f),
						new Vector2(-0.097544f, 0.451161f),
						new Vector2(-0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.451377f),

					};

					moonThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = moonThinPoints;

					miscShapePrefabs.options.Add(moonThinGameObject);
				}

				//Moon Half
				{
					GameObject moonHalfGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					moonHalfGameObject.name = "moon_half";
					moonHalfGameObject.layer = 8;

					Vector3[] moonHalfVerts = new Vector3[]
					{
						new Vector3(-0.490392f, 0.089742f, 0.000000f),
						new Vector3(-0.374848f, 0.000000f, 0.000000f),
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(-0.367645f, 0.073130f, 0.000000f),
						new Vector3(-0.461939f, 0.172208f, 0.000000f),
						new Vector3(-0.346314f, 0.143449f, 0.000000f),
						new Vector3(-0.415734f, 0.244451f, 0.000000f),
						new Vector3(-0.311675f, 0.208255f, 0.000000f),
						new Vector3(-0.353553f, 0.304056f, 0.000000f),
						new Vector3(-0.265057f, 0.265058f, 0.000000f),
						new Vector3(-0.277785f, 0.349218f, 0.000000f),
						new Vector3(-0.208254f, 0.311675f, 0.000000f),
						new Vector3(-0.191341f, 0.378791f, 0.000000f),
						new Vector3(-0.143448f, 0.346315f, 0.000000f),
						new Vector3(-0.097544f, 0.392314f, 0.000000f),
						new Vector3(-0.073129f, 0.367646f, 0.000000f),
						new Vector3(0.000000f, 0.374848f, 0.000000f),
					};

					int[] moonHalfTris = new int[]
					{
						//Point 1
						//0,
						//1,
						//2,

						0,
						1,
						2,
						0,
						3,
						1,
						4,
						3,
						0,
						4,
						5,
						3,
						6,
						5,
						4,
						6,
						7,
						5,
						8,
						7,
						6,
						8,
						9,
						7,
						10,
						9,
						8,
						10,
						11,
						9,
						12,
						11,
						10,
						12,
						13,
						11,
						14,
						13,
						12,
						14,
						15,
						13,
						16,
						15,
						14,
					};

					moonHalfMesh.vertices = moonHalfVerts;
					moonHalfMesh.triangles = moonHalfTris;

					moonHalfMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					moonHalfMesh.subMeshCount = 1;
					Bounds moonHalfMeshBounds = moonHalfMesh.bounds;
					moonHalfMeshBounds.center = Vector3.zero;
					moonHalfMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					moonHalfMesh.bounds = moonHalfMeshBounds;

					moonHalfMesh.name = "moon_half";

					moonHalfGameObject.GetComponentInChildren<MeshFilter>().mesh = moonHalfMesh;

					Vector2[] moonHalfPoints = new Vector2[]
					{
						new Vector2(-0.490392f, 0.089742f),
						new Vector2(-0.374848f, 0.000000f),
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(-0.367645f, 0.073130f),
						new Vector2(-0.461939f, 0.172208f),
						new Vector2(-0.346314f, 0.143449f),
						new Vector2(-0.415734f, 0.244451f),
						new Vector2(-0.311675f, 0.208255f),
						new Vector2(-0.353553f, 0.304056f),
						new Vector2(-0.265057f, 0.265058f),
						new Vector2(-0.277785f, 0.349218f),
						new Vector2(-0.208254f, 0.311675f),
						new Vector2(-0.191341f, 0.378791f),
						new Vector2(-0.143448f, 0.346315f),
						new Vector2(-0.097544f, 0.392314f),
						new Vector2(-0.073129f, 0.367646f),
						new Vector2(0.000000f, 0.374848f),

					};

					moonHalfGameObject.GetComponentInChildren<PolygonCollider2D>().points = moonHalfPoints;

					miscShapePrefabs.options.Add(moonHalfGameObject);
				}

				//Moon Half Thin
				{
					GameObject moonHalfThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					moonHalfThinGameObject.name = "moon_half_thin";
					moonHalfThinGameObject.layer = 8;

					Vector3[] moonHalfThinVerts = new Vector3[]
					{
						new Vector3(-0.490392f, 0.097546f, 0.000000f),
						new Vector3(-0.451377f, 0.000000f, 0.000000f),
						new Vector3(-0.500000f, 0.000000f, 0.000000f),
						new Vector3(-0.442704f, 0.088060f, 0.000000f),
						new Vector3(-0.461939f, 0.191342f, 0.000000f),
						new Vector3(-0.417018f, 0.172735f, 0.000000f),
						new Vector3(-0.415734f, 0.277786f, 0.000000f),
						new Vector3(-0.375306f, 0.250772f, 0.000000f),
						new Vector3(-0.353553f, 0.346483f, 0.000000f),
						new Vector3(-0.319171f, 0.319172f, 0.000000f),
						new Vector3(-0.277785f, 0.399106f, 0.000000f),
						new Vector3(-0.250771f, 0.375307f, 0.000000f),
						new Vector3(-0.191341f, 0.434224f, 0.000000f),
						new Vector3(-0.172734f, 0.417018f, 0.000000f),
						new Vector3(-0.097544f, 0.451161f, 0.000000f),
						new Vector3(-0.088059f, 0.442704f, 0.000000f),
						new Vector3(0.000000f, 0.451377f, 0.000000f),
					};

					int[] moonHalfThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						3,
						1,
						4,
						3,
						0,
						4,
						5,
						3,
						6,
						5,
						4,
						6,
						7,
						5,
						8,
						7,
						6,
						8,
						9,
						7,
						10,
						9,
						8,
						10,
						11,
						9,
						12,
						11,
						10,
						12,
						13,
						11,
						14,
						13,
						12,
						14,
						15,
						13,
						16,
						15,
						14,
					};

					moonHalfThinMesh.vertices = moonHalfThinVerts;
					moonHalfThinMesh.triangles = moonHalfThinTris;

					moonHalfThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					moonHalfThinMesh.subMeshCount = 1;
					Bounds moonHalfThinMeshBounds = moonHalfThinMesh.bounds;
					moonHalfThinMeshBounds.center = Vector3.zero;
					moonHalfThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					moonHalfThinMesh.bounds = moonHalfThinMeshBounds;

					moonHalfThinMesh.name = "moon_half_thin";

					moonHalfThinGameObject.GetComponentInChildren<MeshFilter>().mesh = moonHalfThinMesh;

					Vector2[] moonHalfThinPoints = new Vector2[]
					{
						new Vector2(-0.490392f, 0.097546f),
						new Vector2(-0.451377f, 0.000000f),
						new Vector2(-0.500000f, 0.000000f),
						new Vector2(-0.442704f, 0.088060f),
						new Vector2(-0.461939f, 0.191342f),
						new Vector2(-0.417018f, 0.172735f),
						new Vector2(-0.415734f, 0.277786f),
						new Vector2(-0.375306f, 0.250772f),
						new Vector2(-0.353553f, 0.346483f),
						new Vector2(-0.319171f, 0.319172f),
						new Vector2(-0.277785f, 0.399106f),
						new Vector2(-0.250771f, 0.375307f),
						new Vector2(-0.191341f, 0.434224f),
						new Vector2(-0.172734f, 0.417018f),
						new Vector2(-0.097544f, 0.451161f),
						new Vector2(-0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.451377f),
					};

					moonHalfThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = moonHalfThinPoints;

					miscShapePrefabs.options.Add(moonHalfThinGameObject);
				}

				//Moon Quarter
				{
					GameObject moonQuarterGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					moonQuarterGameObject.name = "moon_quarter";
					moonQuarterGameObject.layer = 8;

					Vector3[] moonQuarterVerts = new Vector3[]
					{
						new Vector3(-0.277785f, 0.349218f, 0.000000f),
						new Vector3(-0.265057f, 0.265058f, 0.000000f),
						new Vector3(-0.353553f, 0.304056f, 0.000000f),
						new Vector3(-0.208254f, 0.311675f, 0.000000f),
						new Vector3(-0.191341f, 0.378791f, 0.000000f),
						new Vector3(-0.143448f, 0.346315f, 0.000000f),
						new Vector3(-0.097544f, 0.392314f, 0.000000f),
						new Vector3(-0.073129f, 0.367646f, 0.000000f),
						new Vector3(0.000000f, 0.374848f, 0.000000f),
					};

					int[] moonQuarterTris = new int[]
					{
						//Point 1
						//0,
						//1,
						//2,

						0,
						1,
						2,
						0,
						3,
						1,
						4,
						3,
						0,
						4,
						5,
						3,
						6,
						5,
						4,
						6,
						7,
						5,
						8,
						7,
						6,
					};

					moonQuarterMesh.vertices = moonQuarterVerts;
					moonQuarterMesh.triangles = moonQuarterTris;

					moonQuarterMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					moonQuarterMesh.subMeshCount = 1;
					Bounds moonQuarterMeshBounds = moonQuarterMesh.bounds;
					moonQuarterMeshBounds.center = Vector3.zero;
					moonQuarterMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					moonQuarterMesh.bounds = moonQuarterMeshBounds;

					moonQuarterMesh.name = "moon_quarter";

					moonQuarterGameObject.GetComponentInChildren<MeshFilter>().mesh = moonQuarterMesh;

					Vector2[] moonQuarterPoints = new Vector2[]
					{
						new Vector2(-0.277785f, 0.349218f),
						new Vector2(-0.265057f, 0.265058f),
						new Vector2(-0.353553f, 0.304056f),
						new Vector2(-0.208254f, 0.311675f),
						new Vector2(-0.191341f, 0.378791f),
						new Vector2(-0.143448f, 0.346315f),
						new Vector2(-0.097544f, 0.392314f),
						new Vector2(-0.073129f, 0.367646f),
						new Vector2(0.000000f, 0.374848f),
					};

					moonQuarterGameObject.GetComponentInChildren<PolygonCollider2D>().points = moonQuarterPoints;

					miscShapePrefabs.options.Add(moonQuarterGameObject);
				}

				//Moon Quarter Thin
				{
					GameObject moonQuarterThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					moonQuarterThinGameObject.name = "moon_quarter_thin";
					moonQuarterThinGameObject.layer = 8;

					Vector3[] moonQuarterThinVerts = new Vector3[]
					{
						new Vector3(-0.277785f, 0.399106f, 0.000000f),
						new Vector3(-0.319171f, 0.319172f, 0.000000f),
						new Vector3(-0.353553f, 0.346483f, 0.000000f),
						new Vector3(-0.250771f, 0.375307f, 0.000000f),
						new Vector3(-0.191341f, 0.434224f, 0.000000f),
						new Vector3(-0.172734f, 0.417018f, 0.000000f),
						new Vector3(-0.097544f, 0.451161f, 0.000000f),
						new Vector3(-0.088059f, 0.442704f, 0.000000f),
						new Vector3(0.000000f, 0.451377f, 0.000000f),
					};

					int[] moonQuarterThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						3,
						1,
						4,
						3,
						0,
						4,
						5,
						3,
						6,
						5,
						4,
						6,
						7,
						5,
						8,
						7,
						6,
					};

					moonQuarterThinMesh.vertices = moonQuarterThinVerts;
					moonQuarterThinMesh.triangles = moonQuarterThinTris;

					moonQuarterThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					moonQuarterThinMesh.subMeshCount = 1;
					Bounds moonQuarterThinMeshBounds = moonQuarterThinMesh.bounds;
					moonQuarterThinMeshBounds.center = Vector3.zero;
					moonQuarterThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					moonQuarterThinMesh.bounds = moonQuarterThinMeshBounds;

					moonQuarterThinMesh.name = "moon_quarter_thin";

					moonQuarterThinGameObject.GetComponentInChildren<MeshFilter>().mesh = moonQuarterThinMesh;

					Vector2[] moonQuarterThinPoints = new Vector2[]
					{
						new Vector2(-0.277785f, 0.399106f),
						new Vector2(-0.319171f, 0.319172f),
						new Vector2(-0.353553f, 0.346483f),
						new Vector2(-0.250771f, 0.375307f),
						new Vector2(-0.191341f, 0.434224f),
						new Vector2(-0.172734f, 0.417018f),
						new Vector2(-0.097544f, 0.451161f),
						new Vector2(-0.088059f, 0.442704f),
						new Vector2(0.000000f, 0.451377f),
					};

					moonQuarterThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = moonQuarterThinPoints;

					miscShapePrefabs.options.Add(moonQuarterThinGameObject);
				}

				//System Error Wing
				{
					GameObject systemErrorWingGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					systemErrorWingGameObject.name = "system_error_wing";
					systemErrorWingGameObject.layer = 8;

					Vector3[] systemErrorWingVerts = new Vector3[]
					{
						new Vector3(0.242568f, 0.586492f, 0.000000f),
						new Vector3(0.309467f, 0.642088f, 0.000000f),
						new Vector3(0.304052f, 0.611258f, 0.000000f),
						new Vector3(0.369126f, 0.628910f, 0.000000f),
						new Vector3(0.412872f, 0.704368f, 0.000000f),
						new Vector3(0.424029f, 0.631875f, 0.000000f),
						new Vector3(0.519154f, 0.747827f, 0.000000f),
						new Vector3(0.458669f, 0.604527f, 0.000000f),
						new Vector3(0.599752f, 0.766443f, 0.000000f),
						new Vector3(0.473525f, 0.549422f, 0.000000f),
						new Vector3(0.672724f, 0.778688f, 0.000000f),
						new Vector3(0.483291f, 0.500238f, 0.000000f),
						new Vector3(0.756641f, 0.762448f, 0.000000f),
						new Vector3(0.812796f, 0.731813f, 0.000000f),
						new Vector3(0.477506f, 0.469922f, 0.000000f),
						new Vector3(0.844169f, 0.685041f, 0.000000f),
						new Vector3(0.781127f, 0.584500f, 0.000000f),
						new Vector3(0.853649f, 0.630913f, 0.000000f),
						new Vector3(0.824124f, 0.564972f, 0.000000f),
						new Vector3(0.474341f, 0.440986f, 0.000000f),
						new Vector3(0.461107f, 0.408114f, 0.000000f),
						new Vector3(0.767945f, 0.539902f, 0.000000f),
						new Vector3(0.434770f, 0.368345f, 0.000000f),
						new Vector3(0.736651f, 0.484730f, 0.000000f),
						new Vector3(0.407130f, 0.329408f, 0.000000f),
						new Vector3(0.698583f, 0.428551f, 0.000000f),
						new Vector3(0.359455f, 0.275758f, 0.000000f),
						new Vector3(0.639086f, 0.363176f, 0.000000f),
						new Vector3(0.289022f, 0.203943f, 0.000000f),
						new Vector3(0.486939f, 0.256849f, 0.000000f),
						new Vector3(0.522272f, 0.262495f, 0.000000f),
						new Vector3(0.173876f, 0.121093f, 0.000000f),
						new Vector3(0.398359f, 0.166413f, 0.000000f),
						new Vector3(0.334792f, 0.150522f, 0.000000f),
						new Vector3(0.000838f, -0.001090f, 0.000000f),
						new Vector3(0.279919f, 0.086408f, 0.000000f),
					};

					int[] systemErrorWingTris = new int[]
					{
						0,
						1,
						2,
						3,
						2,
						1,
						3,
						1,
						4,
						5,
						3,
						4,
						5,
						4,
						6,
						7,
						5,
						6,
						7,
						6,
						8,
						9,
						7,
						8,
						9,
						8,
						10,
						11,
						9,
						10,
						11,
						10,
						12,
						11,
						12,
						13,
						13,
						14,
						11,
						13,
						15,
						14,
						16,
						14,
						15,
						17,
						16,
						15,
						17,
						18,
						16,
						16,
						19,
						14,
						20,
						19,
						16,
						20,
						16,
						21,
						22,
						20,
						21,
						22,
						21,
						23,
						24,
						22,
						23,
						24,
						23,
						25,
						26,
						24,
						25,
						26,
						25,
						27,
						28,
						26,
						27,
						28,
						27,
						29,
						29,
						27,
						30,
						31,
						28,
						29,
						32,
						29,
						30,
						31,
						29,
						33,
						32,
						33,
						29,
						31,
						33,
						34,
						35,
						33,
						32,
					};

					systemErrorWingMesh.vertices = systemErrorWingVerts;
					systemErrorWingMesh.triangles = systemErrorWingTris;

					systemErrorWingMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					systemErrorWingMesh.subMeshCount = 1;
					Bounds systemErrorWingMeshBounds = systemErrorWingMesh.bounds;
					systemErrorWingMeshBounds.center = Vector3.zero;
					systemErrorWingMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					systemErrorWingMesh.bounds = systemErrorWingMeshBounds;

					systemErrorWingMesh.name = "system_error_wing";

					systemErrorWingGameObject.GetComponentInChildren<MeshFilter>().mesh = systemErrorWingMesh;

					Vector2[] systemErrorWingPoints = new Vector2[]
					{
						new Vector2(0.242568f, 0.586492f),
						new Vector2(0.309467f, 0.642088f),
						new Vector2(0.304052f, 0.611258f),
						new Vector2(0.369126f, 0.628910f),
						new Vector2(0.412872f, 0.704368f),
						new Vector2(0.424029f, 0.631875f),
						new Vector2(0.519154f, 0.747827f),
						new Vector2(0.458669f, 0.604527f),
						new Vector2(0.599752f, 0.766443f),
						new Vector2(0.473525f, 0.549422f),
						new Vector2(0.672724f, 0.778688f),
						new Vector2(0.483291f, 0.500238f),
						new Vector2(0.756641f, 0.762448f),
						new Vector2(0.812796f, 0.731813f),
						new Vector2(0.477506f, 0.469922f),
						new Vector2(0.844169f, 0.685041f),
						new Vector2(0.781127f, 0.584500f),
						new Vector2(0.853649f, 0.630913f),
						new Vector2(0.824124f, 0.564972f),
						new Vector2(0.474341f, 0.440986f),
						new Vector2(0.461107f, 0.408114f),
						new Vector2(0.767945f, 0.539902f),
						new Vector2(0.434770f, 0.368345f),
						new Vector2(0.736651f, 0.484730f),
						new Vector2(0.407130f, 0.329408f),
						new Vector2(0.698583f, 0.428551f),
						new Vector2(0.359455f, 0.275758f),
						new Vector2(0.639086f, 0.363176f),
						new Vector2(0.289022f, 0.203943f),
						new Vector2(0.486939f, 0.256849f),
						new Vector2(0.522272f, 0.262495f),
						new Vector2(0.173876f, 0.121093f),
						new Vector2(0.398359f, 0.166413f),
						new Vector2(0.334792f, 0.150522f),
						new Vector2(0.000838f, -0.001090f),
						new Vector2(0.279919f, 0.086408f),
					};

					systemErrorWingGameObject.GetComponentInChildren<PolygonCollider2D>().points = systemErrorWingPoints;

					miscShapePrefabs.options.Add(systemErrorWingGameObject);
				}

				//Heart
				{
					GameObject heartGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					heartGameObject.name = "heart";
					heartGameObject.layer = 8;

					Vector3[] heartVerts = new Vector3[]
					{
						new Vector3(-0.073223f, 0.323437f, 0.000000f),
						new Vector3(0.000000f, 0.250856f, 0.000000f),
						new Vector3(-0.142202f, 0.375604f, 0.000000f),
						new Vector3(-0.202023f, 0.391481f, 0.000000f),
						new Vector3(-0.286794f, 0.364263f, 0.000000f),
						new Vector3(-0.343018f, 0.305291f, 0.000000f),
						new Vector3(-0.379794f, 0.231199f, 0.000000f),
						new Vector3(-0.380166f, 0.124218f, 0.000000f),
						new Vector3(-0.340172f, 0.023475f, 0.000000f),
						new Vector3(-0.248312f, -0.106149f, 0.000000f),
						new Vector3(-0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.000000f, -0.379687f, 0.000000f),
						new Vector3(0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.248312f, -0.106149f, 0.000000f),
						new Vector3(0.340172f, 0.023475f, 0.000000f),
						new Vector3(0.380166f, 0.124218f, 0.000000f),
						new Vector3(0.379794f, 0.231199f, 0.000000f),
						new Vector3(0.343018f, 0.305291f, 0.000000f),
						new Vector3(0.286794f, 0.364263f, 0.000000f),
						new Vector3(0.202023f, 0.391481f, 0.000000f),
						new Vector3(0.142202f, 0.375604f, 0.000000f),
						new Vector3(0.073223f, 0.323437f, 0.000000f),
					};

					int[] heartTris = new int[]
					{
						0,
						1,
						2,
						3,
						2,
						1,
						4,
						3,
						1,
						5,
						4,
						1,
						6,
						5,
						1,
						7,
						6,
						1,
						8,
						7,
						1,
						9,
						8,
						1,
						10,
						9,
						1,
						11,
						10,
						1,
						11,
						1,
						12,
						12,
						1,
						13,
						13,
						1,
						14,
						14,
						1,
						15,
						15,
						1,
						16,
						16,
						1,
						17,
						17,
						1,
						18,
						18,
						1,
						19,
						19,
						1,
						20,
						21,
						20,
						1,
					};

					heartMesh.vertices = heartVerts;
					heartMesh.triangles = heartTris;

					heartMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					heartMesh.subMeshCount = 1;
					Bounds heartMeshBounds = heartMesh.bounds;
					heartMeshBounds.center = Vector3.zero;
					heartMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					heartMesh.bounds = heartMeshBounds;

					heartMesh.name = "heart";

					heartGameObject.GetComponentInChildren<MeshFilter>().mesh = heartMesh;

					Vector2[] heartPoints = new Vector2[]
					{
						new Vector2(-0.073223f, 0.323437f),
						new Vector2(0.000000f, 0.250856f),
						new Vector2(-0.142202f, 0.375604f),
						new Vector2(-0.202023f, 0.391481f),
						new Vector2(-0.286794f, 0.364263f),
						new Vector2(-0.343018f, 0.305291f),
						new Vector2(-0.379794f, 0.231199f),
						new Vector2(-0.380166f, 0.124218f),
						new Vector2(-0.340172f, 0.023475f),
						new Vector2(-0.248312f, -0.106149f),
						new Vector2(-0.101337f, -0.277620f),
						new Vector2(0.000000f, -0.379687f),
						new Vector2(0.101337f, -0.277620f),
						new Vector2(0.248312f, -0.106149f),
						new Vector2(0.340172f, 0.023475f),
						new Vector2(0.380166f, 0.124218f),
						new Vector2(0.379794f, 0.231199f),
						new Vector2(0.343018f, 0.305291f),
						new Vector2(0.286794f, 0.364263f),
						new Vector2(0.202023f, 0.391481f),
						new Vector2(0.142202f, 0.375604f),
						new Vector2(0.073223f, 0.323437f),
					};

					heartGameObject.GetComponentInChildren<PolygonCollider2D>().points = heartPoints;

					miscShapePrefabs.options.Add(heartGameObject);
				}

				//Heart Hollow
				{
					GameObject heartHollowGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					heartHollowGameObject.name = "heart_outline";
					heartHollowGameObject.layer = 8;

					Vector3[] heartHollowVerts = new Vector3[]
					{
						new Vector3(0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.000000f, -0.379687f, 0.000000f),
						new Vector3(0.000000f, -0.313050f, 0.000000f),
						new Vector3(-0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.086136f, -0.226294f, 0.000000f),
						new Vector3(-0.086136f, -0.226294f, 0.000000f),
						new Vector3(0.248312f, -0.106149f, 0.000000f),
						new Vector3(-0.248312f, -0.106149f, 0.000000f),
						new Vector3(0.211065f, -0.080543f, 0.000000f),
						new Vector3(-0.211065f, -0.080543f, 0.000000f),
						new Vector3(0.340172f, 0.023475f, 0.000000f),
						new Vector3(-0.340172f, 0.023475f, 0.000000f),
						new Vector3(0.289146f, 0.029637f, 0.000000f),
						new Vector3(-0.289146f, 0.029637f, 0.000000f),
						new Vector3(0.380166f, 0.124218f, 0.000000f),
						new Vector3(0.323142f, 0.115269f, 0.000000f),
						new Vector3(0.322825f, 0.189451f, 0.000000f),
						new Vector3(0.379794f, 0.231199f, 0.000000f),
						new Vector3(0.291565f, 0.252430f, 0.000000f),
						new Vector3(0.343018f, 0.305291f, 0.000000f),
						new Vector3(0.243775f, 0.302556f, 0.000000f),
						new Vector3(0.286794f, 0.364263f, 0.000000f),
						new Vector3(-0.380166f, 0.124218f, 0.000000f),
						new Vector3(-0.323142f, 0.115269f, 0.000000f),
						new Vector3(-0.322825f, 0.189451f, 0.000000f),
						new Vector3(-0.379794f, 0.231199f, 0.000000f),
						new Vector3(-0.291565f, 0.252430f, 0.000000f),
						new Vector3(-0.343018f, 0.305291f, 0.000000f),
						new Vector3(-0.243775f, 0.302556f, 0.000000f),
						new Vector3(-0.286794f, 0.364263f, 0.000000f),
						new Vector3(0.171720f, 0.325691f, 0.000000f),
						new Vector3(0.202023f, 0.391481f, 0.000000f),
						new Vector3(-0.171720f, 0.325691f, 0.000000f),
						new Vector3(-0.202023f, 0.391481f, 0.000000f),
						new Vector3(0.142202f, 0.375604f, 0.000000f),
						new Vector3(0.120872f, 0.312195f, 0.000000f),
						new Vector3(0.062239f, 0.267853f, 0.000000f),
						new Vector3(0.073223f, 0.323437f, 0.000000f),
						new Vector3(-0.142202f, 0.375604f, 0.000000f),
						new Vector3(-0.120872f, 0.312195f, 0.000000f),
						new Vector3(-0.062239f, 0.267853f, 0.000000f),
						new Vector3(-0.073223f, 0.323437f, 0.000000f),
						new Vector3(0.000000f, 0.206160f, 0.000000f),
						new Vector3(0.000000f, 0.250856f, 0.000000f),
					};

					int[] heartHollowTris = new int[]
					{
						0,
						1,
						2,
						3,
						2,
						1,
						0,
						2,
						4,
						3,
						5,
						2,
						6,
						0,
						4,
						7,
						5,
						3,
						6,
						4,
						8,
						7,
						9,
						5,
						10,
						6,
						8,
						11,
						9,
						7,
						10,
						8,
						12,
						11,
						13,
						9,
						14,
						10,
						12,
						14,
						12,
						15,
						14,
						15,
						16,
						14,
						16,
						17,
						17,
						16,
						18,
						17,
						18,
						19,
						19,
						18,
						20,
						19,
						20,
						21,
						22,
						13,
						11,
						22,
						23,
						13,
						22,
						24,
						23,
						22,
						25,
						24,
						25,
						26,
						24,
						25,
						27,
						26,
						27,
						28,
						26,
						27,
						29,
						28,
						21,
						20,
						30,
						21,
						30,
						31,
						29,
						32,
						28,
						29,
						33,
						32,
						34,
						31,
						30,
						34,
						30,
						35,
						34,
						35,
						36,
						34,
						36,
						37,
						38,
						32,
						33,
						38,
						39,
						32,
						38,
						40,
						39,
						38,
						41,
						40,
						37,
						36,
						42,
						41,
						42,
						40,
						37,
						42,
						43,
						41,
						43,
						42,
					};

					heartHollowMesh.vertices = heartHollowVerts;
					heartHollowMesh.triangles = heartHollowTris;

					heartHollowMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					heartHollowMesh.subMeshCount = 1;
					Bounds heartHollowMeshBounds = heartHollowMesh.bounds;
					heartHollowMeshBounds.center = Vector3.zero;
					heartHollowMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					heartHollowMesh.bounds = heartHollowMeshBounds;

					heartHollowMesh.name = "heart_outline";

					heartHollowGameObject.GetComponentInChildren<MeshFilter>().mesh = heartHollowMesh;

					Vector2[] heartHollowPoints = new Vector2[]
					{
						new Vector2(0.101337f, -0.277620f),
						new Vector2(0.000000f, -0.379687f),
						new Vector2(0.000000f, -0.313050f),
						new Vector2(-0.101337f, -0.277620f),
						new Vector2(0.086136f, -0.226294f),
						new Vector2(-0.086136f, -0.226294f),
						new Vector2(0.248312f, -0.106149f),
						new Vector2(-0.248312f, -0.106149f),
						new Vector2(0.211065f, -0.080543f),
						new Vector2(-0.211065f, -0.080543f),
						new Vector2(0.340172f, 0.023475f),
						new Vector2(-0.340172f, 0.023475f),
						new Vector2(0.289146f, 0.029637f),
						new Vector2(-0.289146f, 0.029637f),
						new Vector2(0.380166f, 0.124218f),
						new Vector2(0.323142f, 0.115269f),
						new Vector2(0.322825f, 0.189451f),
						new Vector2(0.379794f, 0.231199f),
						new Vector2(0.291565f, 0.252430f),
						new Vector2(0.343018f, 0.305291f),
						new Vector2(0.243775f, 0.302556f),
						new Vector2(0.286794f, 0.364263f),
						new Vector2(-0.380166f, 0.124218f),
						new Vector2(-0.323142f, 0.115269f),
						new Vector2(-0.322825f, 0.189451f),
						new Vector2(-0.379794f, 0.231199f),
						new Vector2(-0.291565f, 0.252430f),
						new Vector2(-0.343018f, 0.305291f),
						new Vector2(-0.243775f, 0.302556f),
						new Vector2(-0.286794f, 0.364263f),
						new Vector2(0.171720f, 0.325691f),
						new Vector2(0.202023f, 0.391481f),
						new Vector2(-0.171720f, 0.325691f),
						new Vector2(-0.202023f, 0.391481f),
						new Vector2(0.142202f, 0.375604f),
						new Vector2(0.120872f, 0.312195f),
						new Vector2(0.062239f, 0.267853f),
						new Vector2(0.073223f, 0.323437f),
						new Vector2(-0.142202f, 0.375604f),
						new Vector2(-0.120872f, 0.312195f),
						new Vector2(-0.062239f, 0.267853f),
						new Vector2(-0.073223f, 0.323437f),
						new Vector2(0.000000f, 0.206160f),
						new Vector2(0.000000f, 0.250856f),
					};

					heartHollowGameObject.GetComponentInChildren<PolygonCollider2D>().points = heartHollowPoints;

					miscShapePrefabs.options.Add(heartHollowGameObject);
				}

				//Heart Hollow Thin
				{
					GameObject heartHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					heartHollowThinGameObject.name = "heart_outline_thin";
					heartHollowThinGameObject.layer = 8;

					Vector3[] heartHollowThinVerts = new Vector3[]
					{
						new Vector3(0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.000000f, -0.379687f, 0.000000f),
						new Vector3(0.000000f, -0.344456f, 0.000000f),
						new Vector3(-0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.095388f, -0.249260f, 0.000000f),
						new Vector3(-0.095388f, -0.249260f, 0.000000f),
						new Vector3(0.248312f, -0.106149f, 0.000000f),
						new Vector3(-0.248312f, -0.106149f, 0.000000f),
						new Vector3(0.233737f, -0.089331f, 0.000000f),
						new Vector3(-0.233737f, -0.089331f, 0.000000f),
						new Vector3(0.340172f, 0.038051f, 0.000000f),
						new Vector3(-0.340172f, 0.038051f, 0.000000f),
						new Vector3(0.320204f, 0.041087f, 0.000000f),
						new Vector3(-0.320204f, 0.041087f, 0.000000f),
						new Vector3(0.380166f, 0.124218f, 0.000000f),
						new Vector3(0.357851f, 0.125530f, 0.000000f),
						new Vector3(0.357500f, 0.210734f, 0.000000f),
						new Vector3(0.379794f, 0.231199f, 0.000000f),
						new Vector3(0.322883f, 0.279839f, 0.000000f),
						new Vector3(0.343018f, 0.305291f, 0.000000f),
						new Vector3(0.269960f, 0.334841f, 0.000000f),
						new Vector3(0.286794f, 0.364263f, 0.000000f),
						new Vector3(-0.380166f, 0.124218f, 0.000000f),
						new Vector3(-0.357851f, 0.125530f, 0.000000f),
						new Vector3(-0.357500f, 0.210734f, 0.000000f),
						new Vector3(-0.379794f, 0.231199f, 0.000000f),
						new Vector3(-0.322883f, 0.279839f, 0.000000f),
						new Vector3(-0.343018f, 0.305291f, 0.000000f),
						new Vector3(-0.269960f, 0.334841f, 0.000000f),
						new Vector3(-0.286794f, 0.364263f, 0.000000f),
						new Vector3(0.190165f, 0.360226f, 0.000000f),
						new Vector3(0.202023f, 0.391481f, 0.000000f),
						new Vector3(-0.190165f, 0.360226f, 0.000000f),
						new Vector3(-0.202023f, 0.391481f, 0.000000f),
						new Vector3(0.142202f, 0.375604f, 0.000000f),
						new Vector3(0.133855f, 0.345418f, 0.000000f),
						new Vector3(0.068925f, 0.296763f, 0.000000f),
						new Vector3(0.073223f, 0.323437f, 0.000000f),
						new Vector3(-0.142202f, 0.375604f, 0.000000f),
						new Vector3(-0.133855f, 0.345418f, 0.000000f),
						new Vector3(-0.068925f, 0.296763f, 0.000000f),
						new Vector3(-0.073223f, 0.323437f, 0.000000f),
						new Vector3(0.000000f, 0.229068f, 0.000000f),
						new Vector3(0.000000f, 0.250856f, 0.000000f),
					};

					int[] heartHollowThinTris = new int[]
					{
						0,
						1,
						2,
						3,
						2,
						1,
						0,
						2,
						4,
						3,
						5,
						2,
						6,
						0,
						4,
						7,
						5,
						3,
						6,
						4,
						8,
						7,
						9,
						5,
						10,
						6,
						8,
						11,
						9,
						7,
						10,
						8,
						12,
						11,
						13,
						9,
						14,
						10,
						12,
						14,
						12,
						15,
						14,
						15,
						16,
						14,
						16,
						17,
						17,
						16,
						18,
						17,
						18,
						19,
						19,
						18,
						20,
						19,
						20,
						21,
						22,
						13,
						11,
						22,
						23,
						13,
						22,
						24,
						23,
						22,
						25,
						24,
						25,
						26,
						24,
						25,
						27,
						26,
						27,
						28,
						26,
						27,
						29,
						28,
						21,
						20,
						30,
						21,
						30,
						31,
						29,
						32,
						28,
						29,
						33,
						32,
						34,
						31,
						30,
						34,
						30,
						35,
						34,
						35,
						36,
						34,
						36,
						37,
						38,
						32,
						33,
						38,
						39,
						32,
						38,
						40,
						39,
						38,
						41,
						40,
						37,
						36,
						42,
						41,
						42,
						40,
						37,
						42,
						43,
						41,
						43,
						42,
					};

					heartHollowThinMesh.vertices = heartHollowThinVerts;
					heartHollowThinMesh.triangles = heartHollowThinTris;

					heartHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					heartHollowThinMesh.subMeshCount = 1;
					Bounds heartHollowThinMeshBounds = heartHollowThinMesh.bounds;
					heartHollowThinMeshBounds.center = Vector3.zero;
					heartHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					heartHollowThinMesh.bounds = heartHollowThinMeshBounds;

					heartHollowThinMesh.name = "heart_outline_thin";

					heartHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = heartHollowThinMesh;

					Vector2[] heartHollowThinPoints = new Vector2[]
					{
						new Vector2(0.101337f, -0.277620f),
						new Vector2(0.000000f, -0.379687f),
						new Vector2(0.000000f, -0.344456f),
						new Vector2(-0.101337f, -0.277620f),
						new Vector2(0.095388f, -0.249260f),
						new Vector2(-0.095388f, -0.249260f),
						new Vector2(0.248312f, -0.106149f),
						new Vector2(-0.248312f, -0.106149f),
						new Vector2(0.233737f, -0.089331f),
						new Vector2(-0.233737f, -0.089331f),
						new Vector2(0.340172f, 0.038051f),
						new Vector2(-0.340172f, 0.038051f),
						new Vector2(0.320204f, 0.041087f),
						new Vector2(-0.320204f, 0.041087f),
						new Vector2(0.380166f, 0.124218f),
						new Vector2(0.357851f, 0.125530f),
						new Vector2(0.357500f, 0.210734f),
						new Vector2(0.379794f, 0.231199f),
						new Vector2(0.322883f, 0.279839f),
						new Vector2(0.343018f, 0.305291f),
						new Vector2(0.269960f, 0.334841f),
						new Vector2(0.286794f, 0.364263f),
						new Vector2(-0.380166f, 0.124218f),
						new Vector2(-0.357851f, 0.125530f),
						new Vector2(-0.357500f, 0.210734f),
						new Vector2(-0.379794f, 0.231199f),
						new Vector2(-0.322883f, 0.279839f),
						new Vector2(-0.343018f, 0.305291f),
						new Vector2(-0.269960f, 0.334841f),
						new Vector2(-0.286794f, 0.364263f),
						new Vector2(0.190165f, 0.360226f),
						new Vector2(0.202023f, 0.391481f),
						new Vector2(-0.190165f, 0.360226f),
						new Vector2(-0.202023f, 0.391481f),
						new Vector2(0.142202f, 0.375604f),
						new Vector2(0.133855f, 0.345418f),
						new Vector2(0.068925f, 0.296763f),
						new Vector2(0.073223f, 0.323437f),
						new Vector2(-0.142202f, 0.375604f),
						new Vector2(-0.133855f, 0.345418f),
						new Vector2(-0.068925f, 0.296763f),
						new Vector2(-0.073223f, 0.323437f),
						new Vector2(0.000000f, 0.229068f),
						new Vector2(0.000000f, 0.250856f),
					};

					heartHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = heartHollowThinPoints;

					miscShapePrefabs.options.Add(heartHollowThinGameObject);
				}

				//Heart Half
				{
					GameObject heartHalfGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					heartHalfGameObject.name = "heart_half";
					heartHalfGameObject.layer = 8;

					Vector3[] heartHalfVerts = new Vector3[]
					{
						new Vector3(0.000000f, -0.379687f, 0.000000f),
						new Vector3(-0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.000000f, 0.250856f, 0.000000f),
						new Vector3(-0.248312f, -0.106149f, 0.000000f),
						new Vector3(-0.340172f, 0.023475f, 0.000000f),
						new Vector3(-0.380166f, 0.124218f, 0.000000f),
						new Vector3(-0.379794f, 0.231199f, 0.000000f),
						new Vector3(-0.343018f, 0.305291f, 0.000000f),
						new Vector3(-0.286794f, 0.364263f, 0.000000f),
						new Vector3(-0.202023f, 0.391481f, 0.000000f),
						new Vector3(-0.142202f, 0.375604f, 0.000000f),
						new Vector3(-0.073223f, 0.323437f, 0.000000f),
					};

					int[] heartHalfTris = new int[]
					{
						0,
						1,
						2,
						1,
						3,
						2,
						3,
						4,
						2,
						4,
						5,
						2,
						5,
						6,
						2,
						6,
						7,
						2,
						7,
						8,
						2,
						8,
						9,
						2,
						9,
						10,
						2,
						11,
						2,
						10,
					};

					heartHalfMesh.vertices = heartHalfVerts;
					heartHalfMesh.triangles = heartHalfTris;

					heartHalfMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					heartHalfMesh.subMeshCount = 1;
					Bounds heartHalfMeshBounds = heartHalfMesh.bounds;
					heartHalfMeshBounds.center = Vector3.zero;
					heartHalfMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					heartHalfMesh.bounds = heartHalfMeshBounds;

					heartHalfMesh.name = "heart_half";

					heartHalfGameObject.GetComponentInChildren<MeshFilter>().mesh = heartHalfMesh;

					Vector2[] heartHalfPoints = new Vector2[]
					{
						new Vector2(0.000000f, -0.379687f),
						new Vector2(-0.101337f, -0.277620f),
						new Vector2(0.000000f, 0.250856f),
						new Vector2(-0.248312f, -0.106149f),
						new Vector2(-0.340172f, 0.023475f),
						new Vector2(-0.380166f, 0.124218f),
						new Vector2(-0.379794f, 0.231199f),
						new Vector2(-0.343018f, 0.305291f),
						new Vector2(-0.286794f, 0.364263f),
						new Vector2(-0.202023f, 0.391481f),
						new Vector2(-0.142202f, 0.375604f),
						new Vector2(-0.073223f, 0.323437f),
					};

					heartHalfGameObject.GetComponentInChildren<PolygonCollider2D>().points = heartHalfPoints;

					miscShapePrefabs.options.Add(heartHalfGameObject);
				}

				//Heart Half Hollow
				{
					GameObject heartHalfHollowGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					heartHalfHollowGameObject.name = "heart_half_outline";
					heartHalfHollowGameObject.layer = 8;

					Vector3[] heartHalfHollowVerts = new Vector3[]
					{
						new Vector3(-0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.000000f, -0.313050f, 0.000000f),
						new Vector3(0.000000f, -0.379687f, 0.000000f),
						new Vector3(-0.086136f, -0.226294f, 0.000000f),
						new Vector3(-0.248312f, -0.106149f, 0.000000f),
						new Vector3(-0.211065f, -0.080543f, 0.000000f),
						new Vector3(-0.340172f, 0.023475f, 0.000000f),
						new Vector3(-0.289146f, 0.029637f, 0.000000f),
						new Vector3(-0.380166f, 0.124218f, 0.000000f),
						new Vector3(-0.323142f, 0.115269f, 0.000000f),
						new Vector3(-0.322825f, 0.189451f, 0.000000f),
						new Vector3(-0.379794f, 0.231199f, 0.000000f),
						new Vector3(-0.291565f, 0.252430f, 0.000000f),
						new Vector3(-0.343018f, 0.305291f, 0.000000f),
						new Vector3(-0.243775f, 0.302556f, 0.000000f),
						new Vector3(-0.286794f, 0.364263f, 0.000000f),
						new Vector3(-0.171720f, 0.325691f, 0.000000f),
						new Vector3(-0.202023f, 0.391481f, 0.000000f),
						new Vector3(-0.142202f, 0.375604f, 0.000000f),
						new Vector3(-0.120872f, 0.312195f, 0.000000f),
						new Vector3(-0.062239f, 0.267853f, 0.000000f),
						new Vector3(-0.073223f, 0.323437f, 0.000000f),
						new Vector3(0.000000f, 0.206160f, 0.000000f),
						new Vector3(0.000000f, 0.250856f, 0.000000f),
					};

					int[] heartHalfHollowTris = new int[]
					{
						0,
						1,
						2,
						0,
						3,
						1,
						4,
						3,
						0,
						4,
						5,
						3,
						6,
						5,
						4,
						6,
						7,
						5,
						8,
						7,
						6,
						8,
						9,
						7,
						8,
						10,
						9,
						8,
						11,
						10,
						11,
						12,
						10,
						11,
						13,
						12,
						13,
						14,
						12,
						13,
						15,
						14,
						15,
						16,
						14,
						15,
						17,
						16,
						18,
						16,
						17,
						18,
						19,
						16,
						18,
						20,
						19,
						18,
						21,
						20,
						21,
						22,
						20,
						21,
						23,
						22,
					};

					heartHalfHollowMesh.vertices = heartHalfHollowVerts;
					heartHalfHollowMesh.triangles = heartHalfHollowTris;

					heartHalfHollowMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					heartHalfHollowMesh.subMeshCount = 1;
					Bounds heartHalfHollowMeshBounds = heartHalfHollowMesh.bounds;
					heartHalfHollowMeshBounds.center = Vector3.zero;
					heartHalfHollowMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					heartHalfHollowMesh.bounds = heartHalfHollowMeshBounds;

					heartHalfHollowMesh.name = "heart_half_outline";

					heartHalfHollowGameObject.GetComponentInChildren<MeshFilter>().mesh = heartHalfHollowMesh;

					Vector2[] heartHalfHollowPoints = new Vector2[]
					{
						new Vector2(-0.101337f, -0.277620f),
						new Vector2(0.000000f, -0.313050f),
						new Vector2(0.000000f, -0.379687f),
						new Vector2(-0.086136f, -0.226294f),
						new Vector2(-0.248312f, -0.106149f),
						new Vector2(-0.211065f, -0.080543f),
						new Vector2(-0.340172f, 0.023475f),
						new Vector2(-0.289146f, 0.029637f),
						new Vector2(-0.380166f, 0.124218f),
						new Vector2(-0.323142f, 0.115269f),
						new Vector2(-0.322825f, 0.189451f),
						new Vector2(-0.379794f, 0.231199f),
						new Vector2(-0.291565f, 0.252430f),
						new Vector2(-0.343018f, 0.305291f),
						new Vector2(-0.243775f, 0.302556f),
						new Vector2(-0.286794f, 0.364263f),
						new Vector2(-0.171720f, 0.325691f),
						new Vector2(-0.202023f, 0.391481f),
						new Vector2(-0.142202f, 0.375604f),
						new Vector2(-0.120872f, 0.312195f),
						new Vector2(-0.062239f, 0.267853f),
						new Vector2(-0.073223f, 0.323437f),
						new Vector2(0.000000f, 0.206160f),
						new Vector2(0.000000f, 0.250856f),
					};

					heartHalfHollowGameObject.GetComponentInChildren<PolygonCollider2D>().points = heartHalfHollowPoints;

					miscShapePrefabs.options.Add(heartHalfHollowGameObject);
				}

				//Heart Half Hollow Thin
				{
					GameObject heartHalfHollowThinGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					heartHalfHollowThinGameObject.name = "heart_half_outline_thin";
					heartHalfHollowThinGameObject.layer = 8;

					Vector3[] heartHalfHollowThinVerts = new Vector3[]
					{
						new Vector3(-0.101337f, -0.277620f, 0.000000f),
						new Vector3(0.000000f, -0.344456f, 0.000000f),
						new Vector3(0.000000f, -0.379687f, 0.000000f),
						new Vector3(-0.095388f, -0.249260f, 0.000000f),
						new Vector3(-0.248312f, -0.106149f, 0.000000f),
						new Vector3(-0.233737f, -0.089331f, 0.000000f),
						new Vector3(-0.340172f, 0.038051f, 0.000000f),
						new Vector3(-0.320204f, 0.041087f, 0.000000f),
						new Vector3(-0.380166f, 0.124218f, 0.000000f),
						new Vector3(-0.357851f, 0.125530f, 0.000000f),
						new Vector3(-0.357500f, 0.210734f, 0.000000f),
						new Vector3(-0.379794f, 0.231199f, 0.000000f),
						new Vector3(-0.322883f, 0.279839f, 0.000000f),
						new Vector3(-0.343018f, 0.305291f, 0.000000f),
						new Vector3(-0.269960f, 0.334841f, 0.000000f),
						new Vector3(-0.286794f, 0.364263f, 0.000000f),
						new Vector3(-0.190165f, 0.360226f, 0.000000f),
						new Vector3(-0.202023f, 0.391481f, 0.000000f),
						new Vector3(-0.142202f, 0.375604f, 0.000000f),
						new Vector3(-0.133855f, 0.345418f, 0.000000f),
						new Vector3(-0.068925f, 0.296763f, 0.000000f),
						new Vector3(-0.073223f, 0.323437f, 0.000000f),
						new Vector3(0.000000f, 0.229068f, 0.000000f),
						new Vector3(0.000000f, 0.250856f, 0.000000f),
					};

					int[] heartHalfHollowThinTris = new int[]
					{
						0,
						1,
						2,
						0,
						3,
						1,
						4,
						3,
						0,
						4,
						5,
						3,
						6,
						5,
						4,
						6,
						7,
						5,
						8,
						7,
						6,
						8,
						9,
						7,
						8,
						10,
						9,
						8,
						11,
						10,
						11,
						12,
						10,
						11,
						13,
						12,
						13,
						14,
						12,
						13,
						15,
						14,
						15,
						16,
						14,
						15,
						17,
						16,
						18,
						16,
						17,
						18,
						19,
						16,
						18,
						20,
						19,
						18,
						21,
						20,
						21,
						22,
						20,
						21,
						23,
						22,
					};

					heartHalfHollowThinMesh.vertices = heartHalfHollowThinVerts;
					heartHalfHollowThinMesh.triangles = heartHalfHollowThinTris;

					heartHalfHollowThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					heartHalfHollowThinMesh.subMeshCount = 1;
					Bounds heartHalfHollowThinMeshBounds = heartHalfHollowThinMesh.bounds;
					heartHalfHollowThinMeshBounds.center = Vector3.zero;
					heartHalfHollowThinMeshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					heartHalfHollowThinMesh.bounds = heartHalfHollowThinMeshBounds;

					heartHalfHollowThinMesh.name = "heart_half_outline_thin";

					heartHalfHollowThinGameObject.GetComponentInChildren<MeshFilter>().mesh = heartHalfHollowThinMesh;

					Vector2[] heartHalfHollowThinPoints = new Vector2[]
					{
						new Vector2(-0.101337f, -0.277620f),
						new Vector2(0.000000f, -0.344456f),
						new Vector2(0.000000f, -0.379687f),
						new Vector2(-0.095388f, -0.249260f),
						new Vector2(-0.248312f, -0.106149f),
						new Vector2(-0.233737f, -0.089331f),
						new Vector2(-0.340172f, 0.038051f),
						new Vector2(-0.320204f, 0.041087f),
						new Vector2(-0.380166f, 0.124218f),
						new Vector2(-0.357851f, 0.125530f),
						new Vector2(-0.357500f, 0.210734f),
						new Vector2(-0.379794f, 0.231199f),
						new Vector2(-0.322883f, 0.279839f),
						new Vector2(-0.343018f, 0.305291f),
						new Vector2(-0.269960f, 0.334841f),
						new Vector2(-0.286794f, 0.364263f),
						new Vector2(-0.190165f, 0.360226f),
						new Vector2(-0.202023f, 0.391481f),
						new Vector2(-0.142202f, 0.375604f),
						new Vector2(-0.133855f, 0.345418f),
						new Vector2(-0.068925f, 0.296763f),
						new Vector2(-0.073223f, 0.323437f),
						new Vector2(0.000000f, 0.229068f),
						new Vector2(0.000000f, 0.250856f),
					};

					heartHalfHollowThinGameObject.GetComponentInChildren<PolygonCollider2D>().points = heartHalfHollowThinPoints;

					miscShapePrefabs.options.Add(heartHalfHollowThinGameObject);
				}

				//Circle Moon
				{
					GameObject meshGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					meshGameObject.name = "circle_moon";
					meshGameObject.layer = 8;

					Vector3[] meshVerts = new Vector3[]
					{
 						new Vector3(0.09754536f, -0.4903926f, 0f),
						new Vector3(1.629207E-07f, -0.4999999f, 0f),
						new Vector3(0.07312947f, -0.4639708f, 0f),
						new Vector3(0.1913419f, -0.4619396f, 0f),
						new Vector3(0.1434484f, -0.4160961f, 0f),
						new Vector3(0.2777853f, -0.4157346f, 0f),
						new Vector3(0.2082547f, -0.3729658f, 0f),
						new Vector3(0.3535536f, -0.3535531f, 0f),
						new Vector3(0.2650578f, -0.3168904f, 0f),
						new Vector3(0.4157349f, -0.2777848f, 0f),
						new Vector3(0.3116749f, -0.2387819f, 0f),
						new Vector3(0.4619399f, -0.1913413f, 0f),
						new Vector3(0.3463146f, -0.1434478f, 0f),
						new Vector3(0.4903927f, -0.09754471f, 0f),
						new Vector3(0.3676455f, -0.07312887f, 0f),
						new Vector3(0.4999999f, 4.827995E-07f, 0f),
						new Vector3(0.3748481f, 3.999914E-07f, 0f),
						new Vector3(0.4903924f, 0.09754567f, 0f),
						new Vector3(0.3676454f, 0.07312965f, 0f),
						new Vector3(0.4619395f, 0.1913422f, 0f),
						new Vector3(0.3463143f, 0.1434486f, 0f),
						new Vector3(0.4157344f, 0.2777856f, 0f),
						new Vector3(0.3116745f, 0.2387826f, 0f),
						new Vector3(0.3535529f, 0.3535538f, 0f),
						new Vector3(0.2650572f, 0.316891f, 0f),
						new Vector3(0.2777845f, 0.4157351f, 0f),
						new Vector3(0.2082539f, 0.3729663f, 0f),
						new Vector3(0.191341f, 0.46194f, 0f),
						new Vector3(0.1434476f, 0.4160965f, 0f),
						new Vector3(0.09754439f, 0.4903927f, 0f),
						new Vector3(0.07312856f, 0.4639711f, 0f),
						new Vector3(0f, 0.4999999f, 0f),
					};

					int[] meshTris = new int[]
					{
 						0,
						1,
						2,
						3,
						0,
						2,
						3,
						2,
						4,
						5,
						3,
						4,
						5,
						4,
						6,
						7,
						5,
						6,
						7,
						6,
						8,
						9,
						7,
						8,
						9,
						8,
						10,
						11,
						9,
						10,
						11,
						10,
						12,
						13,
						11,
						12,
						13,
						12,
						14,
						15,
						13,
						14,
						15,
						14,
						16,
						17,
						15,
						16,
						17,
						16,
						18,
						19,
						17,
						18,
						19,
						18,
						20,
						21,
						19,
						20,
						21,
						20,
						22,
						23,
						21,
						22,
						23,
						22,
						24,
						25,
						23,
						24,
						25,
						24,
						26,
						27,
						25,
						26,
						27,
						26,
						28,
						29,
						27,
						28,
						29,
						28,
						30,
						31,
						29,
						30,
					};

					circleMoonMesh.vertices = meshVerts;
					circleMoonMesh.triangles = meshTris;

					circleMoonMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleMoonMesh.subMeshCount = 1;
					Bounds meshBounds = circleMoonMesh.bounds;
					meshBounds.center = Vector3.zero;
					meshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleMoonMesh.bounds = meshBounds;

					circleMoonMesh.name = "circle_moon";

					meshGameObject.GetComponentInChildren<MeshFilter>().mesh = circleMoonMesh;

					Vector2[] colliderPoints = new Vector2[]
					{
 						new Vector2(0.09754536f, -0.4903926f),
						new Vector2(1.629207E-07f, -0.4999999f),
						new Vector2(0.07312947f, -0.4639708f),
						new Vector2(0.1913419f, -0.4619396f),
						new Vector2(0.1434484f, -0.4160961f),
						new Vector2(0.2777853f, -0.4157346f),
						new Vector2(0.2082547f, -0.3729658f),
						new Vector2(0.3535536f, -0.3535531f),
						new Vector2(0.2650578f, -0.3168904f),
						new Vector2(0.4157349f, -0.2777848f),
						new Vector2(0.3116749f, -0.2387819f),
						new Vector2(0.4619399f, -0.1913413f),
						new Vector2(0.3463146f, -0.1434478f),
						new Vector2(0.4903927f, -0.09754471f),
						new Vector2(0.3676455f, -0.07312887f),
						new Vector2(0.4999999f, 4.827995E-07f),
						new Vector2(0.3748481f, 3.999914E-07f),
						new Vector2(0.4903924f, 0.09754567f),
						new Vector2(0.3676454f, 0.07312965f),
						new Vector2(0.4619395f, 0.1913422f),
						new Vector2(0.3463143f, 0.1434486f),
						new Vector2(0.4157344f, 0.2777856f),
						new Vector2(0.3116745f, 0.2387826f),
						new Vector2(0.3535529f, 0.3535538f),
						new Vector2(0.2650572f, 0.316891f),
						new Vector2(0.2777845f, 0.4157351f),
						new Vector2(0.2082539f, 0.3729663f),
						new Vector2(0.191341f, 0.46194f),
						new Vector2(0.1434476f, 0.4160965f),
						new Vector2(0.09754439f, 0.4903927f),
						new Vector2(0.07312856f, 0.4639711f),
						new Vector2(0f, 0.4999999f),
					};

					meshGameObject.GetComponentInChildren<PolygonCollider2D>().points = colliderPoints;

					miscShapePrefabs.options.Add(meshGameObject);
				}
				
				//Circle Moon Thin
				{
					GameObject meshGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					meshGameObject.name = "circle_moon_thin";
					meshGameObject.layer = 8;

					Vector3[] meshVerts = new Vector3[]
					{
						new Vector3(0.09754536f, -0.4903926f, 0f),
						new Vector3(1.629207E-07f, -0.4999999f, 0f),
						new Vector3(0.0880595f, -0.4752522f, 0f),
						new Vector3(0.1913419f, -0.4619396f, 0f),
						new Vector3(0.1727347f, -0.4397023f, 0f),
						new Vector3(0.2777853f, -0.4157346f, 0f),
						new Vector3(0.2507719f, -0.3928313f, 0f),
						new Vector3(0.3535536f, -0.3535532f, 0f),
						new Vector3(0.3191719f, -0.3316602f, 0f),
						new Vector3(0.4157349f, -0.2777848f, 0f),
						new Vector3(0.3753064f, -0.2507714f, 0f),
						new Vector3(0.4619399f, -0.1913413f, 0f),
						new Vector3(0.4170182f, -0.1727342f, 0f),
						new Vector3(0.4903927f, -0.09754473f, 0f),
						new Vector3(0.442704f, -0.08805889f, 0f),
						new Vector3(0.4999999f, 4.768372E-07f, 0f),
						new Vector3(0.4513771f, 4.768372E-07f, 0f),
						new Vector3(0.4903924f, 0.09754562f, 0f),
						new Vector3(0.4427039f, 0.08805978f, 0f),
						new Vector3(0.4619395f, 0.1913422f, 0f),
						new Vector3(0.4170178f, 0.172735f, 0f),
						new Vector3(0.4157344f, 0.2777855f, 0f),
						new Vector3(0.375306f, 0.2507721f, 0f),
						new Vector3(0.3535529f, 0.3535538f, 0f),
						new Vector3(0.3191713f, 0.3316607f, 0f),
						new Vector3(0.2777845f, 0.4157351f, 0f),
						new Vector3(0.2507711f, 0.3928319f, 0f),
						new Vector3(0.191341f, 0.4619401f, 0f),
						new Vector3(0.1727339f, 0.4397026f, 0f),
						new Vector3(0.09754439f, 0.4903927f, 0f),
						new Vector3(0.08805857f, 0.4752524f, 0f),
						new Vector3(0f, 0.5f, 0f),
					};

					int[] meshTris = new int[]
					{
						0,
						1,
						2,
						3,
						0,
						2,
						3,
						2,
						4,
						5,
						3,
						4,
						5,
						4,
						6,
						7,
						5,
						6,
						7,
						6,
						8,
						9,
						7,
						8,
						9,
						8,
						10,
						11,
						9,
						10,
						11,
						10,
						12,
						13,
						11,
						12,
						13,
						12,
						14,
						15,
						13,
						14,
						15,
						14,
						16,
						17,
						15,
						16,
						17,
						16,
						18,
						19,
						17,
						18,
						19,
						18,
						20,
						21,
						19,
						20,
						21,
						20,
						22,
						23,
						21,
						22,
						23,
						22,
						24,
						25,
						23,
						24,
						25,
						24,
						26,
						27,
						25,
						26,
						27,
						26,
						28,
						29,
						27,
						28,
						29,
						28,
						30,
						31,
						29,
						30,
					};

					circleMoonThinMesh.vertices = meshVerts;
					circleMoonThinMesh.triangles = meshTris;

					circleMoonThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleMoonThinMesh.subMeshCount = 1;
					Bounds meshBounds = circleMoonThinMesh.bounds;
					meshBounds.center = Vector3.zero;
					meshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleMoonThinMesh.bounds = meshBounds;

					circleMoonThinMesh.name = "circle_moon_thin";

					meshGameObject.GetComponentInChildren<MeshFilter>().mesh = circleMoonThinMesh;

					Vector2[] colliderPoints = new Vector2[]
					{
						new Vector2(0.09754536f, -0.4903926f),
						new Vector2(1.629207E-07f, -0.4999999f),
						new Vector2(0.0880595f, -0.4752522f),
						new Vector2(0.1913419f, -0.4619396f),
						new Vector2(0.1727347f, -0.4397023f),
						new Vector2(0.2777853f, -0.4157346f),
						new Vector2(0.2507719f, -0.3928313f),
						new Vector2(0.3535536f, -0.3535532f),
						new Vector2(0.3191719f, -0.3316602f),
						new Vector2(0.4157349f, -0.2777848f),
						new Vector2(0.3753064f, -0.2507714f),
						new Vector2(0.4619399f, -0.1913413f),
						new Vector2(0.4170182f, -0.1727342f),
						new Vector2(0.4903927f, -0.09754473f),
						new Vector2(0.442704f, -0.08805889f),
						new Vector2(0.4999999f, 4.768372E-07f),
						new Vector2(0.4513771f, 4.768372E-07f),
						new Vector2(0.4903924f, 0.09754562f),
						new Vector2(0.4427039f, 0.08805978f),
						new Vector2(0.4619395f, 0.1913422f),
						new Vector2(0.4170178f, 0.172735f),
						new Vector2(0.4157344f, 0.2777855f),
						new Vector2(0.375306f, 0.2507721f),
						new Vector2(0.3535529f, 0.3535538f),
						new Vector2(0.3191713f, 0.3316607f),
						new Vector2(0.2777845f, 0.4157351f),
						new Vector2(0.2507711f, 0.3928319f),
						new Vector2(0.191341f, 0.4619401f),
						new Vector2(0.1727339f, 0.4397026f),
						new Vector2(0.09754439f, 0.4903927f),
						new Vector2(0.08805857f, 0.4752524f),
						new Vector2(0f, 0.5f),
					};

					meshGameObject.GetComponentInChildren<PolygonCollider2D>().points = colliderPoints;

					miscShapePrefabs.options.Add(meshGameObject);
				}
				
				//Circle Moon Thinner
				{
					GameObject meshGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					meshGameObject.name = "circle_moon_thinner";
					meshGameObject.layer = 8;

					Vector3[] meshVerts = new Vector3[]
					{
						new Vector3(0.09754538f, -0.4903927f, 0f),
						new Vector3(1.929872E-07f, -0.5f, 0f),
						new Vector3(0.09349798f, -0.4847064f, 0f),
						new Vector3(0.191342f, -0.4619397f, 0f),
						new Vector3(0.1834027f, -0.4562002f, 0f),
						new Vector3(0.2777854f, -0.4157348f, 0f),
						new Vector3(0.2662593f, -0.409059f, 0f),
						new Vector3(0.3535536f, -0.3535533f, 0f),
						new Vector3(0.3388838f, -0.3460841f, 0f),
						new Vector3(0.415735f, -0.2777849f, 0f),
						new Vector3(0.3984851f, -0.266259f, 0f),
						new Vector3(0.4619399f, -0.1913414f, 0f),
						new Vector3(0.4427729f, -0.1834022f, 0f),
						new Vector3(0.4903927f, -0.09754479f, 0f),
						new Vector3(0.4700451f, -0.0934974f, 0f),
						new Vector3(0.5f, 4.768372E-07f, 0f),
						new Vector3(0.4792537f, 4.768372E-07f, 0f),
						new Vector3(0.4903925f, 0.09754562f, 0f),
						new Vector3(0.4700449f, 0.09349823f, 0f),
						new Vector3(0.4619395f, 0.1913421f, 0f),
						new Vector3(0.4427725f, 0.1834028f, 0f),
						new Vector3(0.4157344f, 0.2777855f, 0f),
						new Vector3(0.3984846f, 0.2662594f, 0f),
						new Vector3(0.3535529f, 0.3535538f, 0f),
						new Vector3(0.3388831f, 0.3460846f, 0f),
						new Vector3(0.2777846f, 0.415735f, 0f),
						new Vector3(0.2662586f, 0.4090595f, 0f),
						new Vector3(0.1913411f, 0.4619398f, 0f),
						new Vector3(0.1834018f, 0.4562004f, 0f),
						new Vector3(0.09754442f, 0.4903927f, 0f),
						new Vector3(0.09349704f, 0.4847064f, 0f),
						new Vector3(3.006657E-08f, 0.4999998f, 0f),
					};

					int[] meshTris = new int[]
					{
						0,
						1,
						2,
						3,
						0,
						2,
						3,
						2,
						4,
						5,
						3,
						4,
						5,
						4,
						6,
						7,
						5,
						6,
						7,
						6,
						8,
						9,
						7,
						8,
						9,
						8,
						10,
						11,
						9,
						10,
						11,
						10,
						12,
						13,
						11,
						12,
						13,
						12,
						14,
						15,
						13,
						14,
						15,
						14,
						16,
						17,
						15,
						16,
						17,
						16,
						18,
						19,
						17,
						18,
						19,
						18,
						20,
						21,
						19,
						20,
						21,
						20,
						22,
						23,
						21,
						22,
						23,
						22,
						24,
						25,
						23,
						24,
						25,
						24,
						26,
						27,
						25,
						26,
						27,
						26,
						28,
						29,
						27,
						28,
						29,
						28,
						30,
						31,
						29,
						30,
					};

					circleMoonThinnerMesh.vertices = meshVerts;
					circleMoonThinnerMesh.triangles = meshTris;

					circleMoonThinnerMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleMoonThinnerMesh.subMeshCount = 1;
					Bounds meshBounds = circleMoonThinnerMesh.bounds;
					meshBounds.center = Vector3.zero;
					meshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleMoonThinnerMesh.bounds = meshBounds;

					circleMoonThinnerMesh.name = "circle_moon_thinner";

					meshGameObject.GetComponentInChildren<MeshFilter>().mesh = circleMoonThinnerMesh;

					Vector2[] colliderPoints = new Vector2[]
					{
						new Vector2(0.09754538f, -0.4903927f),
						new Vector2(1.929872E-07f, -0.5f),
						new Vector2(0.09349798f, -0.4847064f),
						new Vector2(0.191342f, -0.4619397f),
						new Vector2(0.1834027f, -0.4562002f),
						new Vector2(0.2777854f, -0.4157348f),
						new Vector2(0.2662593f, -0.409059f),
						new Vector2(0.3535536f, -0.3535533f),
						new Vector2(0.3388838f, -0.3460841f),
						new Vector2(0.415735f, -0.2777849f),
						new Vector2(0.3984851f, -0.266259f),
						new Vector2(0.4619399f, -0.1913414f),
						new Vector2(0.4427729f, -0.1834022f),
						new Vector2(0.4903927f, -0.09754479f),
						new Vector2(0.4700451f, -0.0934974f),
						new Vector2(0.5f, 4.768372E-07f),
						new Vector2(0.4792537f, 4.768372E-07f),
						new Vector2(0.4903925f, 0.09754562f),
						new Vector2(0.4700449f, 0.09349823f),
						new Vector2(0.4619395f, 0.1913421f),
						new Vector2(0.4427725f, 0.1834028f),
						new Vector2(0.4157344f, 0.2777855f),
						new Vector2(0.3984846f, 0.2662594f),
						new Vector2(0.3535529f, 0.3535538f),
						new Vector2(0.3388831f, 0.3460846f),
						new Vector2(0.2777846f, 0.415735f),
						new Vector2(0.2662586f, 0.4090595f),
						new Vector2(0.1913411f, 0.4619398f),
						new Vector2(0.1834018f, 0.4562004f),
						new Vector2(0.09754442f, 0.4903927f),
						new Vector2(0.09349704f, 0.4847064f),
						new Vector2(3.006657E-08f, 0.4999998f),
					};

					meshGameObject.GetComponentInChildren<PolygonCollider2D>().points = colliderPoints;

					miscShapePrefabs.options.Add(meshGameObject);
				}
				
				//Half Circle Moon
				{
					GameObject meshGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					meshGameObject.name = "half_circle_moon";
					meshGameObject.layer = 8;

					Vector3[] meshVerts = new Vector3[]
					{
						new Vector3(0.4903924f, 0.09754562f, 0f),
						new Vector3(0.4999999f, 4.768372E-07f, 0f),
						new Vector3(0.3748481f, 4.768372E-07f, 0f),
						new Vector3(0.3676454f, 0.07312965f, 0f),
						new Vector3(0.4619395f, 0.1913424f, 0f),
						new Vector3(0.3463143f, 0.1434484f, 0f),
						new Vector3(0.4157344f, 0.2777858f, 0f),
						new Vector3(0.3116745f, 0.2387824f, 0f),
						new Vector3(0.3535529f, 0.3535538f, 0f),
						new Vector3(0.2650572f, 0.3168907f, 0f),
						new Vector3(0.2777845f, 0.4157352f, 0f),
						new Vector3(0.2082539f, 0.3729663f, 0f),
						new Vector3(0.191341f, 0.4619398f, 0f),
						new Vector3(0.1434476f, 0.4160967f, 0f),
						new Vector3(0.09754439f, 0.4903927f, 0f),
						new Vector3(0.07312856f, 0.4639711f, 0f),
						new Vector3(0f, 0.5f, 0f),
					};

					int[] meshTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
					};

					circleHalfMoonMesh.vertices = meshVerts;
					circleHalfMoonMesh.triangles = meshTris;

					circleHalfMoonMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleHalfMoonMesh.subMeshCount = 1;
					Bounds meshBounds = circleHalfMoonMesh.bounds;
					meshBounds.center = Vector3.zero;
					meshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleHalfMoonMesh.bounds = meshBounds;

					circleHalfMoonMesh.name = "half_circle_moon";

					meshGameObject.GetComponentInChildren<MeshFilter>().mesh = circleHalfMoonMesh;

					Vector2[] colliderPoints = new Vector2[]
					{
						new Vector2(0.4903924f, 0.09754562f),
						new Vector2(0.4999999f, 4.768372E-07f),
						new Vector2(0.3748481f, 4.768372E-07f),
						new Vector2(0.3676454f, 0.07312965f),
						new Vector2(0.4619395f, 0.1913424f),
						new Vector2(0.3463143f, 0.1434484f),
						new Vector2(0.4157344f, 0.2777858f),
						new Vector2(0.3116745f, 0.2387824f),
						new Vector2(0.3535529f, 0.3535538f),
						new Vector2(0.2650572f, 0.3168907f),
						new Vector2(0.2777845f, 0.4157352f),
						new Vector2(0.2082539f, 0.3729663f),
						new Vector2(0.191341f, 0.4619398f),
						new Vector2(0.1434476f, 0.4160967f),
						new Vector2(0.09754439f, 0.4903927f),
						new Vector2(0.07312856f, 0.4639711f),
						new Vector2(0f, 0.5f),
					};

					meshGameObject.GetComponentInChildren<PolygonCollider2D>().points = colliderPoints;

					miscShapePrefabs.options.Add(meshGameObject);
				}
				
				//Half Circle Moon Thin
				{
					GameObject meshGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					meshGameObject.name = "half_circle_moon_thin";
					meshGameObject.layer = 8;

					Vector3[] meshVerts = new Vector3[]
					{
						new Vector3(0.4903924f, 0.09754562f, 0f),
						new Vector3(0.4999999f, 4.768372E-07f, 0f),
						new Vector3(0.4513771f, 4.768372E-07f, 0f),
						new Vector3(0.4427039f, 0.0880599f, 0f),
						new Vector3(0.4619395f, 0.1913424f, 0f),
						new Vector3(0.4170178f, 0.1727352f, 0f),
						new Vector3(0.4157344f, 0.2777858f, 0f),
						new Vector3(0.375306f, 0.250772f, 0f),
						new Vector3(0.3535529f, 0.3535538f, 0f),
						new Vector3(0.3191713f, 0.3316607f, 0f),
						new Vector3(0.2777845f, 0.4157352f, 0f),
						new Vector3(0.2507711f, 0.3928318f, 0f),
						new Vector3(0.191341f, 0.4619398f, 0f),
						new Vector3(0.1727339f, 0.4397025f, 0f),
						new Vector3(0.09754439f, 0.4903927f, 0f),
						new Vector3(0.08805857f, 0.4752522f, 0f),
						new Vector3(0f, 0.5f, 0f),
					};

					int[] meshTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
					};

					circleHalfMoonThinMesh.vertices = meshVerts;
					circleHalfMoonThinMesh.triangles = meshTris;

					circleHalfMoonThinMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleHalfMoonThinMesh.subMeshCount = 1;
					Bounds meshBounds = circleHalfMoonThinMesh.bounds;
					meshBounds.center = Vector3.zero;
					meshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleHalfMoonThinMesh.bounds = meshBounds;

					circleHalfMoonThinMesh.name = "half_circle_moon_thin";

					meshGameObject.GetComponentInChildren<MeshFilter>().mesh = circleHalfMoonThinMesh;

					Vector2[] colliderPoints = new Vector2[]
					{
						new Vector2(0.4903924f, 0.09754562f),
						new Vector2(0.4999999f, 4.768372E-07f),
						new Vector2(0.4513771f, 4.768372E-07f),
						new Vector2(0.4427039f, 0.0880599f),
						new Vector2(0.4619395f, 0.1913424f),
						new Vector2(0.4170178f, 0.1727352f),
						new Vector2(0.4157344f, 0.2777858f),
						new Vector2(0.375306f, 0.250772f),
						new Vector2(0.3535529f, 0.3535538f),
						new Vector2(0.3191713f, 0.3316607f),
						new Vector2(0.2777845f, 0.4157352f),
						new Vector2(0.2507711f, 0.3928318f),
						new Vector2(0.191341f, 0.4619398f),
						new Vector2(0.1727339f, 0.4397025f),
						new Vector2(0.09754439f, 0.4903927f),
						new Vector2(0.08805857f, 0.4752522f),
						new Vector2(0f, 0.5f),
					};

					meshGameObject.GetComponentInChildren<PolygonCollider2D>().points = colliderPoints;

					miscShapePrefabs.options.Add(meshGameObject);
				}
				
				//Half Circle Moon Thinner
				{
					GameObject meshGameObject = Instantiate(ObjectManager.inst.objectPrefabs[1].options[0]);
					meshGameObject.name = "half_circle_moon_thinner";
					meshGameObject.layer = 8;

					Vector3[] meshVerts = new Vector3[]
					{
						new Vector3(0.4903925f, 0.09754562f, 0f),
						new Vector3(0.5f, 4.768372E-07f, 0f),
						new Vector3(0.4792537f, 4.768372E-07f, 0f),
						new Vector3(0.4700449f, 0.09349823f, 0f),
						new Vector3(0.4619395f, 0.1913424f, 0f),
						new Vector3(0.4427725f, 0.183403f, 0f),
						new Vector3(0.4157344f, 0.2777853f, 0f),
						new Vector3(0.3984846f, 0.2662597f, 0f),
						new Vector3(0.3535529f, 0.3535538f, 0f),
						new Vector3(0.3388831f, 0.3460846f, 0f),
						new Vector3(0.2777846f, 0.4157352f, 0f),
						new Vector3(0.2662586f, 0.4090595f, 0f),
						new Vector3(0.1913411f, 0.4619398f, 0f),
						new Vector3(0.1834018f, 0.4562006f, 0f),
						new Vector3(0.09754442f, 0.4903927f, 0f),
						new Vector3(0.09349704f, 0.4847064f, 0f),
						new Vector3(3.006657E-08f, 0.5f, 0f),
					};

					int[] meshTris = new int[]
					{
						0,
						1,
						2,
						0,
						2,
						3,
						4,
						0,
						3,
						4,
						3,
						5,
						6,
						4,
						5,
						6,
						5,
						7,
						8,
						6,
						7,
						8,
						7,
						9,
						10,
						8,
						9,
						10,
						9,
						11,
						12,
						10,
						11,
						12,
						11,
						13,
						14,
						12,
						13,
						14,
						13,
						15,
						16,
						14,
						15,
					};

					circleHalfMoonThinnerMesh.vertices = meshVerts;
					circleHalfMoonThinnerMesh.triangles = meshTris;

					circleHalfMoonThinnerMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt16;
					circleHalfMoonThinnerMesh.subMeshCount = 1;
					Bounds meshBounds = circleHalfMoonThinnerMesh.bounds;
					meshBounds.center = Vector3.zero;
					meshBounds.extents = new Vector3(0.5f, 0.5f, 0f);
					circleHalfMoonThinnerMesh.bounds = meshBounds;

					circleHalfMoonThinnerMesh.name = "half_circle_moon_thinner";

					meshGameObject.GetComponentInChildren<MeshFilter>().mesh = circleHalfMoonThinnerMesh;

					Vector2[] colliderPoints = new Vector2[]
					{
						new Vector2(0.4903925f, 0.09754562f),
						new Vector2(0.5f, 4.768372E-07f),
						new Vector2(0.4792537f, 4.768372E-07f),
						new Vector2(0.4700449f, 0.09349823f),
						new Vector2(0.4619395f, 0.1913424f),
						new Vector2(0.4427725f, 0.183403f),
						new Vector2(0.4157344f, 0.2777853f),
						new Vector2(0.3984846f, 0.2662597f),
						new Vector2(0.3535529f, 0.3535538f),
						new Vector2(0.3388831f, 0.3460846f),
						new Vector2(0.2777846f, 0.4157352f),
						new Vector2(0.2662586f, 0.4090595f),
						new Vector2(0.1913411f, 0.4619398f),
						new Vector2(0.1834018f, 0.4562006f),
						new Vector2(0.09754442f, 0.4903927f),
						new Vector2(0.09349704f, 0.4847064f),
						new Vector2(3.006657E-08f, 0.5f),
					};

					meshGameObject.GetComponentInChildren<PolygonCollider2D>().points = colliderPoints;

					miscShapePrefabs.options.Add(meshGameObject);
				}
				
				//Rounded
				//Rounded Hollow
				//Rounded Hollow Thin

				ObjectManager.inst.objectPrefabs.Add(pentagonShapePrefabs);
				ObjectManager.inst.objectPrefabs.Add(miscShapePrefabs);
			}
		}

		private static Vector3 Scale(Vector3 a, Vector2 b) => new Vector3(a.x * b.x, a.y * b.y, a.z);
		private static Vector3 Rotate(Vector3 a, float b) => Quaternion.Euler(0, 0, b) * a;
		private static Vector3 Translate(Vector3 a, Vector2 b) => new Vector3(a.x + b.x, a.y + b.y, a.z);
	}
}
