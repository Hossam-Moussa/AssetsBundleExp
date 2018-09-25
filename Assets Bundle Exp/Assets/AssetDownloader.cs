using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetDownloader : MonoBehaviour 
{
	
	GameObject Asset;
	public string url;
	public Transform firstpos;
	public Transform secpos;
	public Transform thpos;
	private float loadin;
	IEnumerator LoadBundle(string assetname, Transform tra) 
	{
		while (!Caching.ready)
		{
			yield return null;
		}

		//Begin download
		WWW www = WWW.LoadFromCacheOrDownload (url, 0);
		yield return www;

		//Load the downloaded bundle
		AssetBundle bundle = www.assetBundle;

		//Load an asset from the loaded bundle
		AssetBundleRequest bundleRequest = bundle.LoadAssetAsync (assetname, typeof(GameObject));
		yield return bundleRequest;

		//get object
		GameObject obj = bundleRequest.asset as GameObject;

		Asset = Instantiate(obj, tra.position, Quaternion.identity) as GameObject;

		bundle.Unload(false);
		www.Dispose();
		loadin++;
	}

	void Start()
	{
		loadin = 0f;

		StartCoroutine(LoadBundle("Sphere", firstpos));    
	}
	void Update(){
		if (loadin == 1f) {

			StartCoroutine (LoadBundle ("Cube", secpos));  
		} else if (loadin == 2f) {

			StartCoroutine(LoadBundle("Capsule", thpos));  
		}
	}
}