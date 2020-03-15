﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private string loadLevel;
        void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player")
            {
                SceneManager.LoadScene (loadLevel);
            }
        }
}