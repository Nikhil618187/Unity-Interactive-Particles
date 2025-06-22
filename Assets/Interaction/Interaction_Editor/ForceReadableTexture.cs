using UnityEditor;
using UnityEngine;

public class ForceReadableTexture
{
    [MenuItem("Tools/Make Selected Texture Readable")]
    static void MakeReadable()
    {
        Texture2D tex = Selection.activeObject as Texture2D;
        if (tex == null)
        {
            Debug.LogError("No texture selected.");
            return;
        }

        string path = AssetDatabase.GetAssetPath(tex);
        TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(path);
        importer.textureType = TextureImporterType.Default;
        importer.isReadable = true;
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        Debug.Log("Texture is now readable.");
    }
}
