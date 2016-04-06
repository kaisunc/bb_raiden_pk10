using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMover : MonoBehaviour {
    public float m_Speed = 2f;            
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private Vector3 base_pos;
    private float nextActionTime = 0.0f;
    public float period = 1.5f;
    private float randPos = 0;
    private GameObject jetflare;
    List<GameObject> effectList;

    public int engineState = 1;
    private void Start(){
        
    }

    void Awake () {
        int randCol = Random.Range(0, 3);
        GameObject sm = GameObject.Find("GameManager");
        GetComponent<Renderer>().material.SetColor("_TeamColor", sm.GetComponent<GameManager>().team_colors[randCol]);
        int engines = transform.childCount;

        effectList = new List<GameObject>();
        for(int i=0; i<engines; i++){
            effectList.Add(this.gameObject.transform.GetChild(i).GetChild(0).gameObject);
        }

        EngineStart();
    }


    private void EngineStart(){
        foreach( GameObject go in effectList){
            go.GetComponent<enginePresets>().setEngine(1);
        }
    }

    private void EngineCruise(){
        foreach( GameObject go in effectList){
            go.GetComponent<enginePresets>().setEngine(2);

        }        
    }

    private void EngineAB(){
        foreach( GameObject go in effectList){
            go.GetComponent<enginePresets>().setEngine(3);
        }        
    }

    public void SetEngine(int engineState){
        if(engineState == 1){
            EngineStart();
        }

        else if(engineState == 2){
            EngineCruise();
        }
        else if(engineState == 3){
            EngineAB();
        }  
    }

    private void FixedUpdate(){
      
        Move();
    }

    private void Move(){
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            int x = Random.Range(0,6);
            randPos = x/2;
        }
        
        if(transform.position.z < randPos + 0.0001f && transform.position.z > randPos - 0.0001f ){ //|| transform.position.z > (randPos - 0.1f)){
        }
        else if(transform.position.z < randPos){
            float step = m_Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y , randPos), step);
        }
        else if(transform.position.z > randPos){
            float step = m_Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y , randPos), step);
        }
    }
}
