using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour {
	public GameObject[] planets;
	float xpos;
	float zpos;
    public int NumberOfPlanets01;
    public int NumberOfPlanets02;
    public int NumberOfPlanets03;

	void Start () {
		SpawnPlanets();
	}
	
	public void SpawnPlanets(){
		float ypos = 0.01f;		
        for (int i = 0; i < NumberOfPlanets01; i++){
			xpos = Random.Range(-10f, 10f);
			zpos = Random.Range(200f, 20f);
			Vector3 position = new Vector3(xpos,-3f + ypos, zpos);
			GameObject large_planet = (GameObject)Instantiate(planets[2], position, Quaternion.identity);
			large_planet.name = "large_planet"+i;			
			ypos = ypos + 0.01f;
		}

		for (int i = 0; i < NumberOfPlanets02; i++){
			xpos = Random.Range(-10f, 10f);
			zpos = Random.Range(200f, 20f);
			Vector3 position = new Vector3(xpos, -4f + ypos, zpos);			
			GameObject small_planet = (GameObject)Instantiate(planets[1], position, Quaternion.identity);
			small_planet.name = "small_planet"+i;

			ypos = ypos + 0.01f;
		}

		for (int i = 0; i < NumberOfPlanets03; i++){
			xpos = Random.Range(-10f, 10f);
			zpos = Random.Range(200f, 20f);
			Vector3 position = new Vector3(xpos, -5f + ypos, zpos);			
			Instantiate(planets[0], position, Quaternion.identity);	
			ypos = ypos + 0.01f;			
		}
	}	

}
