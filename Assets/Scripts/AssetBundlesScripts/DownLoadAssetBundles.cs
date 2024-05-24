using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DownLoadAssetBundles : MonoBehaviour
{
 
    void Start()
    {
        StartCoroutine(DownLoadAssetBundleFromServer());
    }

 
    private IEnumerator DownLoadAssetBundleFromServer()
    {
        GameObject go = null;
        string url = "https://drive.usercontent.google.com/uc?id=17HVIUjN6uQ3AgH_QRDigm2wR_uhZCeO3&export=download";
        using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning("Erron On the get request "+url+" "+request.error);
            }
            else
            {
                AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                go = assetBundle.LoadAsset(assetBundle.GetAllAssetNames()[0]) as GameObject;    
                assetBundle.Unload(false);

                yield return new WaitForEndOfFrame();
            }
            request.Dispose();
        }
        InsantiateGameObjects(go);
        yield return new WaitForSeconds(1);
        LoadNextScene();
    }

    private void InsantiateGameObjects(GameObject gameObject)
    {
        if(gameObject != null)
        {
            GameObject instanceObject = Instantiate(gameObject);
            DontDestroyOnLoad(instanceObject);
        }
        else
        {
            Debug.LogWarning("Failed to intantiate");
        }
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
