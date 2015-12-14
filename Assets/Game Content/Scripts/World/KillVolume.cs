using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.tag);

            foreach (var fsm in other.GetComponents<PlayMakerFSM>())
            {
                fsm.SendEvent("PlayerDeath");
            }
        }
    }
}
