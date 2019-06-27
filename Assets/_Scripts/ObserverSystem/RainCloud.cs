using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern
{
    public class RainCloud : MonoBehaviour
    {


        int _merges;
        bool _activeState = false;
        public GameObject cloud;

        public RainCloud(GameObject cloud)
        {
            this.cloud = cloud;
            this._merges = 0;
        }


        public int merges {
            get
            {
                return this._merges;
            }
            set {

                this._merges = this._merges += value;
                Debug.Log(this._merges);
            } }


        public bool activeState
        {
            get
            {
                return _activeState;
            }

            set
            {
                _activeState = value;
            }
        }



        public void toggleActiveState()
        {
            
            _activeState = true;
            
            cloud.SetActive(_activeState);

        }
    }
}