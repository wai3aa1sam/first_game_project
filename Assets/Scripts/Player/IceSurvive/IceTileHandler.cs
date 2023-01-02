using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Party.IceSurvive
{
    public class IceTileHandler : MonoBehaviour
    {
        public Material iceMaterial;
        private Renderer[] _renderers;
        private Material[] _originalMaterials;

        private Player _player;

        public bool waitForFrozen = false;
        public float frozenTime = 3.0f;
        public bool isFrozen = false;
    
        // Start is called before the first frame update
        private void Awake()
        {
            var realParent = transform.parent.transform.parent;
            _player = realParent.GetComponent<Player>();
            _renderers = realParent.GetComponentsInChildren<Renderer>();
            _originalMaterials = new Material[ _renderers.Length ];
            for ( int i = 0; i < _renderers.Length; i++ )
            {
                _originalMaterials[ i ] = _renderers[ i ].material;
            }
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // End Frozen after 3s (frozenTime)
            if ( waitForFrozen )
            {
                StartCoroutine( WaitForFrozen( frozenTime ) );
            }
        }

        public void OnFrozen()
        {
            //Debug.Log( "OnFrozen" );
            if ( !isFrozen )
            {
                for ( int i = 0; i < _renderers.Length; i++ )
                {
                    _renderers[i].material = iceMaterial;
                }
                _player.playerInputHandler.DisablePlayerInputHandler();
                waitForFrozen = true;
                isFrozen = true;
            }
        }

        public void OffFrozen()
        {
            for ( int i = 0; i < _renderers.Length; i++ )
            {
                _renderers[ i ].material = _originalMaterials[ i ];
            }
            isFrozen = false;
            _player.playerInputHandler.EnablePlayerInputHandler();
        }

        public IEnumerator WaitForFrozen( float frozenTime )
        {
            waitForFrozen = false;
            yield return new WaitForSeconds( frozenTime );
            OffFrozen();
        }
    }
}


