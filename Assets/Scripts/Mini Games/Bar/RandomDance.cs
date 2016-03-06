using UnityEngine;
using System.Collections;

namespace Bar{
	public class RandomDance : MonoBehaviour {
		[SerializeField] float MinAngle = -30.0f;
		[SerializeField] float MaxAngle = 30.0f;
		[SerializeField] float speed = 200.0f;
		private float originalSpeed;
		private float curAngle;
		private float decay;
		private Vector3 dancerAngle;


		// Use this for initialization
		void Start () {
			dancerAngle = gameObject.transform.rotation.eulerAngles;
			decay = 0.02f;
			originalSpeed = speed;
		}

		// Update is called once per frame
		void Update () {
			float tempAngleX = gameObject.transform.rotation.eulerAngles.z;

			if (tempAngleX <= MinAngle || tempAngleX >= MaxAngle) {
				//originalSpeed = -originalSpeed;
				speed = -speed;
			}
				
			transform.Rotate (Vector3.forward, speed * Time.deltaTime);
				
		}

		void setDancerRotation()
		{
			float randomAngle = Random.Range (MinAngle, MaxAngle);
			curAngle = randomAngle;
		}
	}
	
}

