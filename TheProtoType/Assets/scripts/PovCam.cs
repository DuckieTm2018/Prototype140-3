using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovCam : MonoBehaviour {

    
   

        public Transform Player;
        public Camera  MainCamera, CameraB;
        public KeyCode TKey;
        public bool camSwitch = false;

        void Update()
        {
            if (Input.GetKeyDown(TKey))
            {
                camSwitch = !camSwitch;
                CameraB.gameObject.SetActive(camSwitch);
                MainCamera.gameObject.SetActive(!camSwitch);
            }
        }
    
}
