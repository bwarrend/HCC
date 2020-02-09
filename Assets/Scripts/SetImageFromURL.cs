using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageFromURL : MonoBehaviour{

	public Image img;
	public string url;
	IEnumerator Start()
	{
		WWW www = new WWW(url);
		//UnityWebRequest www = UnityWebRequest.Get(url);
		yield return www;
		img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
	}
}
