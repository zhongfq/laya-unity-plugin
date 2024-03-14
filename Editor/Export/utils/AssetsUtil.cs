using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using System.IO;

internal class AssetsUtil 
{
    public static string GetTextureFile(Texture texture)
    {
        return AssetDatabase.GetAssetPath(texture.GetInstanceID());
    }

    public static string GetFileName(string path, string fileName)
    {
        string pathFileName = Path.GetFileName(path);
        return pathFileName == fileName ? null : fileName;
    }

    public static string GetAnimationClipPath(AnimationClip clip)
    {
        string path = AssetDatabase.GetAssetPath(clip.GetInstanceID());
        string fileName = AssetsUtil.GetFileName(path, clip.name);
        return AssetsUtil.GetFilePath(AssetDatabase.GetAssetPath(clip.GetInstanceID()), ".lani", fileName);
    }
    public static string GetAnimatorControllerPath(AnimatorController animatorController)
    {
        string path = AssetDatabase.GetAssetPath(animatorController.GetInstanceID());
        string fileName = AssetsUtil.GetFileName(path, animatorController.name);
        return AssetsUtil.GetFilePath(AssetDatabase.GetAssetPath(animatorController.GetInstanceID()), ".controller", fileName);
    }
    public static string GetMaterialPath(Material material)
    {
        string materialPath = AssetDatabase.GetAssetPath(material.GetInstanceID());
        if (materialPath.Length < 1)
        {
            return material.name + ".lmat";
        }else if (materialPath == "Resources/unity_builtin_extra")
        {
            return "Resources/" + material.name+ ".lmat";
        }
        else
        {
            return AssetsUtil.GetFilePath(materialPath, ".lmat");
        }
    }

    public static string GetMeshPath(Mesh mesh)
    {
        return AssetsUtil.GetFilePath(AssetDatabase.GetAssetPath(mesh.GetInstanceID()), ".lm", mesh.name); ;
    }
    private static string GetFilePath(string path, string exit, string fileName  = null)
    {
        string basePath = GameObjectUitls.cleanIllegalChar(path.Split('.')[0], false);
        if (fileName != null)
        {
            basePath += "-" + GameObjectUitls.cleanIllegalChar(fileName,true);
        }
        return basePath + exit;
    }

}
