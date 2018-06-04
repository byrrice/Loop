using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit2D
{
	public class myHealthUI : MonoBehaviour {
		public Damageable representedDamageable;
		public RawImage ballIcon;
		protected RawImage[] icons;
		// Use this for initialization
		IEnumerator Start () {
			if(representedDamageable == null)
					yield break;

			yield return null;
			icons = new RawImage[representedDamageable.startingHealth];
			Debug.Log("Here");
			for (int i = 0; i < representedDamageable.startingHealth; i++){
				RawImage icon = Instantiate (ballIcon);
				icon.transform.SetParent (transform);
				RectTransform iconRect = icon.transform as RectTransform;
				iconRect.anchoredPosition = new Vector2(50 * (i+1), -50);
				// iconRect.sizeDelta = new Vector2(100, 100);
				// iconRect.anchorMin += new Vector2(50, 0f) * i;
				// iconRect.anchorMax += new Vector2(50, 0f) * i;
				icons[i] = icon;

				
			}
		}
		
		public void myUpdate (int numShadowsLeft) {
			icons[numShadowsLeft].enabled = false;
		}
	}
}