using UnityEngine;
using System.Collections;

public class PlanetMover : MonoBehaviour {
    public float speed;
    void Update() {
    	//speed = Random.Range(8f, 13f);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y , -21f), step);
    }
}
