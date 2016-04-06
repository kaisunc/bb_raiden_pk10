using UnityEngine;
using System.Collections;

public class enginePresets : MonoBehaviour {
	//public int engineState = 1; //1 start, 2 cruise, 3 ab


	public void setEngine(int engineState){
		if(engineState == 1){
			this.GetComponent<ParticleSystem>().startLifetime = Random.Range(0.9f, 1f);
			this.GetComponent<ParticleSystem>().emissionRate = 25;
		}

		else if(engineState == 2){
			this.GetComponent<ParticleSystem>().startLifetime = Random.Range(1.9f, 2f);	
			this.GetComponent<ParticleSystem>().emissionRate = 50;

		}

		else if(engineState == 3){
			this.GetComponent<ParticleSystem>().startLifetime = Random.Range(2.9f, 3f);	
			this.GetComponent<ParticleSystem>().emissionRate = 100;			
		}


	}
}
