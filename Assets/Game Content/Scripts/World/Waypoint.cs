using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
    {
        float distance = (transform.position - Camera.main.transform.position).sqrMagnitude;
        float scale = Mathf.Clamp(distance * 0.02f, 0.05f, 0.5f);
        transform.localScale = new Vector3(scale, scale, transform.localScale.z);
	}
}
