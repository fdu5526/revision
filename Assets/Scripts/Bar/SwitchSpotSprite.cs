using UnityEngine;
using System.Collections;

namespace Bar{
	public class SwitchSpotSprite : MonoBehaviour {
		public Sprite alter1;
		public Sprite alter2;
		public Sprite [] alters;
		private float startTime;
		private int spriteIdx;
		public float interval = 2.0F;


		// Use this for initialization
		void Start () {
			spriteIdx = 0;
			startTime = Time.time;
			alters = new Sprite[3];
			alters [2] = gameObject.GetComponent<SpriteRenderer> ().sprite;
			alters [0] = alter1;
			alters [1] = alter2;

		}

		// Update is called once per frame
		void Update () {
			if (Time.time - startTime >= interval) {
				spriteIdx++;
				switchSprite (spriteIdx);
				startTime = Time.time;

			}


		}

		void switchSprite(int idx){
			int tempidx = idx % 3;
			gameObject.GetComponent<SpriteRenderer> ().sprite = alters [tempidx];
		}	
			

	}
	
}

