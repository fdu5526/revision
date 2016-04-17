using UnityEngine;
using System.Collections;

public class InScreen : MonoBehaviour {
   
        Transform camera;
        [SerializeField] bool _flip;
        [SerializeField] Transform _followCharacter;
        //  [SerializeField] float _yOffset = 0f;


        [SerializeField] GameObject bubble;
        [SerializeField] GameObject uiText;
        Vector3 p;
        bool _fi = false;
        RectTransform _rectTrans;
        RectTransform _rectTrans2;
   

        void Awake () {
            camera = Camera.main.transform;

            p = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f, 0f));
            _rectTrans = uiText.GetComponent <RectTransform> ();
            _rectTrans2 = bubble.GetComponent <RectTransform> ();
        }

        void Update () {
            Vector3 lookAtCamera = (camera.position - transform.position);
            lookAtCamera.y = 0;
            //keep the x coordinate still
            //      lookAtCamera.x = transform.position.x;
            transform.forward = _flip? -lookAtCamera : lookAtCamera;

            //      transform.position = new Vector3 (_followCharacter.transform.position.x, _followCharacter.transform.position.y + _yOffset, _followCharacter.transform.position.z);
            transform.position = new Vector3 (_followCharacter.transform.position.x, transform.position.y, _followCharacter.transform.position.z);




//            if(uiText.transform.position.x < p.x){
//                //            Debug.Log ("false ran");
//                //            Debug.Log (_rectTrans.localPosition.x);
//            _rectTrans.localPosition = new Vector3 (_rectTrans.localPosition.x + 150f, _rectTrans.localPosition.y, _rectTrans.localPosition.z);
//
//                _fi = true;
//                //            Debug.Log (_rectTrans.localPosition.x);
//
//            } else if (_fi == true && uiText.transform.position.x >= p.x){
//                //            Debug.Log ("true ran");
//                //            _rectTrans.localPosition = new Vector3 (p.x, _rectTrans.localPosition.y, _rectTrans.localPosition.z);
//                _rectTrans.localPosition = new Vector3 (150f, _rectTrans.localPosition.y, _rectTrans.localPosition.z);

//            }
        }
    }


