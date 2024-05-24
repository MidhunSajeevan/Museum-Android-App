using System;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundle
{
    [MenuItem("Assets/Create Asset Bunles")]
    private static void BuildAllAssetBundles()
    {
        string assetBundlesDirectoryPath = Application.dataPath + "/../AssetBundles";

        try
        { 
            BuildPipeline.BuildAssetBundles(assetBundlesDirectoryPath , BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget );

        }catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }
}
