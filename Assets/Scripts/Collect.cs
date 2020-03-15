using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
   public AudioSource collectSound;

   void OnTriggerEnter(Collider other)
   {
       if (other.tag == "Player")
       {
            collectSound.Play();
            ScoringSystem.theScore += 50;
            Destroy(this.gameObject);
       }
   }
   
}
