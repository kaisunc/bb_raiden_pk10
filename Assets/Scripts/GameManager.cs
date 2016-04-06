using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject[] spaceShips;
	public Color[] team_colors;
	private float xpos = -4.793f;
	public float GameTime;
    private WaitForSeconds m_StartWait;     
    private WaitForSeconds m_EndWait; 
    
    public float m_StartDelay = 3f;         
    public float m_EndDelay = 3f;  
    List<GameObject> goList;
    //public bool Finish = false;

    private GameObject bg;
    private GameObject pm;


	void Start () {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);		
        SpawnPlanes();
		StartCoroutine(GameLoop());
        bg = GameObject.Find("Runway");
        bg.GetComponent<PlanetMover>().enabled = false;
        pm = GameObject.Find("PlanetManager");
        pm.GetComponent<PlanetManager>().enabled = false;


	}
	
	private void SpawnPlanes(){
        goList = new List<GameObject>();
		for(int i=0; i<spaceShips.Length;i++){
			Vector3 position = new Vector3(xpos, 0, -1);
			GameObject go = (GameObject)Instantiate(spaceShips[i], position, Quaternion.identity);
            go.GetComponent<ShipMover>().enabled = false;
            go.GetComponent<ShipMover>().EngineStart();
            goList.Add(go);
			xpos += 1.07f;
		}
	}


    private void GoGo(){
        foreach (GameObject go in goList) {
            go.GetComponent<ShipMover>().enabled = true;
        }

        bg.GetComponent<PlanetMover>().enabled = true;
        pm.GetComponent<PlanetManager>().enabled = true;
        //pm.GetComponent<PlanetManager>().enabled = true;
    }

   private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        //yield return StartCoroutine(RoundEnding());

    }	
 
    private IEnumerator RoundStarting()
    {
        yield return m_StartWait;
    }    

    private IEnumerator RoundPlaying()
    {
        GoGo();
        yield return null;
        
    }    
/*
    private IEnumerator RoundEnding()
    {
        DisableTankControl();
        m_RoundWinner = null;
        m_RoundWinner = GetRoundWinner();
        if(m_RoundWinner != null){
            m_RoundWinner.m_Wins++;
        }
        m_GameWinner = GetGameWinner();
        string message = EndMessage();
        m_MessageText.text = message;
        yield return m_EndWait;
    }*/
}

