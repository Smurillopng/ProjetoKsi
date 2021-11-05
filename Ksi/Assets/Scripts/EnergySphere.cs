using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : MonoBehaviour
{
    ShipController shipController;
    public float speed;
    public Transform followPoint;

    private bool follow = false;

    private Rigidbody2D rgdb;

    public float time = 0.8f;
    private float defineTime;

    public float time2collect;
    private float defineTime2collect;

    private bool ssc1 = false;
    private bool ssc2 = false;
    //private bool ssc3 = false;
    //private bool ssc4 = false;

    private bool canCollect = true;

    // Start is called before the first frame update
    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
        defineTime = time;
        defineTime2collect = time2collect;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            Follow();

            if (time > 0)
            {
                time -= Time.deltaTime;//faz o tempo diminuir até 0 seg
                                       //pode ficar acontecendo algo aqui.
            }
            else
            {
                //Quando timer acaba faz algo
                time = 0;

                if (ssc1)
                {
                    ScoreS1.instance.ScoreUpdate();
                }
                if (ssc2)
                {
                    ScoreS2.instance.ScoreUpdate();
                }

                //time volta a valer alguma coisa no final para resetar, ou em outra
                //parte do código ele volta a valer algo.

                time = defineTime;
            }
        }

        if (!canCollect)
        {

            if (time2collect > 0)
            {
                time2collect -= Time.deltaTime;//faz o tempo diminuir até 0 seg
                                   //pode ficar acontecendo algo aqui.
            }
            else
            {
                //Quando timer acaba faz algo
                time2collect = 0;

                //time volta a valer alguma coisa no final para resetar, ou em outra
                //parte do código ele volta a valer algo.
                time2collect = defineTime2collect;

                canCollect = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (canCollect)
        {

            if (collider.gameObject.layer == 10)
            {
                followPoint = collider.gameObject.transform.Find("EnergyFollow").transform;
                follow = true;
                //aqui inicia a coleta de pontos
            }
            if (collider.gameObject.CompareTag("SpaceShip"))
            {
                ssc1 = true;
                ssc2 = false; //ssc3 = false; ssc3 = false;

            }
            if (collider.gameObject.CompareTag("SpaceShipRed"))
            {
                ssc2 = true;
                ssc1 = false; //ssc3 = false; ssc3 = false;

            }
            canCollect = false;
        }


    }
    
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, followPoint.position, speed * Time.deltaTime);
    }

}