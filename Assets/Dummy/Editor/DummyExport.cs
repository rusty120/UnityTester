using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Net;
using System.IO;


public class DummyExport : ScriptableObject {

  [MenuItem ("Tools/Dummy Intenral/Package Dummy SDK", false, 1)]
  static void PackageDummySDK() {
    DownloadDummySDK();

    Debug.Log("Packaging Dummy SDK...");

    string[] sdkFiles = {
      "Assets/Dummy/Plugins/DummySDK.cs",
      "Assets/Dummy/Plugins/Bin/downloaded_sdk.txt"
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

  public static void DownloadDummySDK() {
    WebClient client = new WebClient();
    Debug.Log("Download file");
    client.DownloadFile("https://docs.google.com/uc?export=download&id=0B-JHy47z_9LTTUo1Y0NKOURFeGc", "Assets/Dummy/Plugins/Bin/downloaded_sdk.txt");
    Debug.Log("Downloading");
  }

  public static void CloudBuildPreHook( )
  {
    Debug.Log("CloudBuildPreHook Build - Start");
    PackageDummySDK();
    Debug.Log("CloudBuildPreHook Build - Start");
  }
}
