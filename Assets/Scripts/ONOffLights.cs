﻿using System;

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class ONOffLights : MonoBehaviour
    {
        public event Action<ONOffLights> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

        public GameObject _Lights;
        public AudioClip[] LightAudio;
        public AudioSource LightSource;
        int _Time = 0;
        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
        }


        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();

            m_GazeOver = true;

        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;

        }


        public void HandleSelectionComplete()
        {
            Debug.Log(_Time);
            
            if (_Time % 2 == 0)
            {
                
                _Lights.SetActive(false);

                LightSource.clip = LightAudio[0];
                LightSource.Play();

            }
            else
            {
                
                _Lights.SetActive(true);

                LightSource.clip = LightAudio[1];
                LightSource.Play();
            }
            _Time++;

            m_GazeOver = false;
        }

    }


}