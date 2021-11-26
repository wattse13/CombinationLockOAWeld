using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public class AddressablesTest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/Resources_moved/TestDataSO1/acetyleneTank.png");
        spriteHandle.Completed += LoadSpritesWhenReady;
    }

    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
            Debug.Log(handleToCheck.Result);
        }
        // Debug.Log(spriteArray[0]);
    }


    //public string myString;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    AsyncOperationHandle<string> stringHandle = Addressables.LoadAssetAsync<string>("TestDataSO1/Object1S2");
    //    stringHandle.Completed += LoadStringWhenReady;
    //}

    //public void LoadStringWhenReady(AsyncOperationHandle<string> handleToCheck)
    //{
    //    if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        myString = handleToCheck.Result;
    //    }
    //    Debug.Log(myString);
    //}
}
