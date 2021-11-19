using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShip_IA : MonoBehaviour
{
    
    public Transform target;
    public Transform escapeTarget;

    public Transform enemyGFX;

    public float speed = 200f;
    public float nextWaypointDistance = 2f;

    private float time = 0;

    private Vector3 positionEscape;
    public bool scape;

    public float defineTime = 0.4f;
    

    Path path;//talvez usar mais de um caminho
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        InvokeRepeating("UpdatePath", 0f, .5f);   
    }

    void UpdatePath()
    {
        if(seeker.IsDone() && scape == false){//Calcula um novo trajeto após o ultimo trajeto já ter sido calculado.
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else if(seeker.IsDone() && scape == true){
            if(time>0){
                time -= Time.deltaTime;
            }
            else{
                time = 0;
                positionEscape = new Vector3(Random.Range(-18.0f, 18.0f),Random.Range(30.0f, -20.0f), 0);
                time = defineTime;
            }
            
            seeker.StartPath(rb.position, positionEscape, OnPathComplete);
        }
       
    }

   public void Escape(){ 
        if(scape == true){
            scape = false;
        }
        else{
            scape = true;
        }
    }

    void OnPathComplete (Path p)
    {
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null){
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance){
            currentWaypoint++;
        }


    }
}
