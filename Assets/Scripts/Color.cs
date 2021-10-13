using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace local {

    public class Color : MonoBehaviour {

        [SerializeField]
        private UnityEngine.Color colorStart;
        [SerializeField]
        private UnityEngine.Color colorEnd;
        [SerializeField]
        private float speed = 0.01f;

        private Renderer renderer;
        private float status;
        private bool forward;
        void Start()
        {
            this.renderer = this.gameObject.GetComponent<Renderer>();
            this.status = 1f;
        }

        // Update is called once per frame
        void Update() {
            //this.renderer.material.color = Mathf.Lerp(colorStart, colorEnd, status);
            LerpColor(colorStart, colorEnd, status);
            UpdateStatus();
        }

        private void LerpColor(UnityEngine.Color colorStart, UnityEngine.Color colorEnd, float status) {
            this.renderer.material.color = UnityEngine.Color.Lerp(colorStart, colorEnd, status);
        }

        private void UpdateStatus() {
            if(status >= 1) {
                forward = false;
            } else if (status <= 0){
                forward = true;
            }

            var add = speed;
            if(!forward) add *= -1;
            
            status += add;
        }
    }

}
