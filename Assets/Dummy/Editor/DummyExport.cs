using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;


public class DummyExport : ScriptableObject {

  [MenuItem ("Tools/Dummy Intenral/Package Dummy SDK", false, 1)]
  static void PackageDummySDK() {
    Debug.Log("Packaging Dummy SDK...");

    string[] sdkFiles = {
      "Assets/Dummy/Plugins/DummySDK.cs"
    };

    string outDir = "Assets/StreamingAssets";
    if (!Directory.Exists(outDir)) {
      Directory.CreateDirectory(outDir);
    }

    string fileName = outDir + "/dummySDK.unitypackage";
    AssetDatabase.ExportPackage(sdkFiles, fileName, ExportPackageOptions.Recurse);
    Debug.Log("Exported package to "+fileName);
    Debug.Log("Streaming asset path: " + Application.streamingAssetsPath);
  }

  public static void CloudBuildPreHook( )
  {
//    if (target != BuildTarget.StandaloneOSXIntel) {
//      Debug.Log("Only run post process build on OSX");
//      return;
//    }
    
    Debug.Log("CloudBuildPreHook Build - Start");
    PackageDummySDK();
    Debug.Log("CloudBuildPreHook Build - Start");
  }
}
