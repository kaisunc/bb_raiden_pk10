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

    private void Start(){
        
    }

    void Awake () {
        int randCol = Random.Range(0, 3);
        GameObject sm = GameObject.Find("GameManager");
        GetComponent<Renderer>().material.SetColor("_TeamColor", sm.GetComponent<GameManager>().team_colors[randCol]);
        //jetflare = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        //jetflare = this.gameObject.transform.GetChild(2).GetChild(0).gameObject;
        effectList = new List<GameObject>();
        print(this.gameObject.name);
        //effectList.Add(this.gameObject.transform.GetChild(1).GetChild(0).gameObject);
        //effectList.Add(this.gameObject.transform.GetChild(2).GetChild(0).gameObject);
        EngineStart();

    }


    public void EngineStart(){
        foreach( GameObject go in effectList){
            go.GetComponent<ParticleSystem>().startLifetime = 0.2f;
            go.GetComponent<ParticleSystem>().startSpeed = 1f;            
        }
    }

    private void EngineCruise(){
        foreach( GameObject go in effectList){
            go.GetComponent<ParticleSystem>().startLifetime = 0.4f;
            go.GetComponent<ParticleSystem>().startSpeed = 1.5f;            
        }        
    }

    private void EngineAB(){
        foreach( GameObject go in effectList){
            go.GetComponent<ParticleSystem>().startLifetime = 0.8f;
            go.GetComponent<ParticleSystem>().startSpeed = 2f;            
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
            EngineCruise();

        }
        else if(transform.position.z < randPos){
            EngineAB();            
            float step = m_Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y , randPos), step);
        }
        else if(transform.position.z > randPos){
            EngineCruise();
            float step = m_Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y , randPos), step);
        }
    }
}
