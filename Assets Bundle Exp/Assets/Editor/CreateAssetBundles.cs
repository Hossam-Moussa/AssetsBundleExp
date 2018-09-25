using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAssetBundles : Editor 
{
	[MenuItem("Assets/Create Asset Bundle")]
	static void ExportBundle()
	{
		string bundlePath = "Assets/AssetBundle/basicshapes.unity3d";
		Object[] selectedAssets = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
		BuildPipeline.BuildAssetBundle(Selection.activeObject, selectedAssets, bundlePath,BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets,BuildTarget.StandaloneOSX);

	}


}