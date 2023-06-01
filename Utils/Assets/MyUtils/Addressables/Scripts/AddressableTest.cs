using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableTest : MonoBehaviour
{
    [SerializeField]
    AssetReference _reference;
    AsyncOperationHandle _handle;
    GameObject _instance;

    public void LoadAssetWithName()
    {
        Addressables.LoadAssetAsync<GameObject>("Cube").Completed += (AsyncOperationHandle<GameObject> obj) =>
        {
            _handle = obj;
            Instantiate(obj.Result);
        };
    }

    public void LoadAssetWithRef()
    {
        _reference.InstantiateAsync().Completed += (AsyncOperationHandle<GameObject> obj) =>
        {
            _instance = obj.Result;
            Invoke("UnloadAsset", 3.0f);
        };
    }

    public void UnloadAsset()
    {
        //Addressables.Release(_reference);
        Addressables.ReleaseInstance(_instance);
    }
}
