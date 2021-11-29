using UnityEngine;

public class EnergySphere : MonoBehaviour
{


    ShipController shipController;
    EnemyShip_IA enemyShipIA;
    public float speed;
    public Transform followPoint;
    //N sei pq n está respondendo
    public GameObject yellowShip;
    public GameObject blueShip;
    public GameObject redShip;
    public GameObject playerShip;
    bool scape = true;

    private bool follow = false;

    private Rigidbody2D rgdb;

    public float time = 0.8f;
    private float defineTime;

    public float time2collect;
    private float defineTime2collect;

    private bool ssc1 = false;
    private bool ssc2 = false;
    private bool ssc3 = false;
    private bool ssc4 = false;
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
                time -= Time.deltaTime;//faz o tempo diminuir ate 0 seg
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
                if (ssc3)
                {
                    ScoreS3.instance.ScoreUpdate();
                }
                if (ssc4)
                {
                    ScoreS4.instance.ScoreUpdate();
                }

                //time volta a valer alguma coisa no final para resetar, ou em outra
                //parte do codigo ele volta a valer algo.

                time = defineTime;
            }
        }

        if (!canCollect)
        {

            if (time2collect > 0)
            {
                time2collect -= Time.deltaTime;//faz o tempo diminuir at� 0 seg
                                               //pode ficar acontecendo algo aqui.
            }
            else
            {
                //Quando timer acaba faz algo
                time2collect = 0;

                //time volta a valer alguma coisa no final para resetar, ou em outra
                //parte do c�digo ele volta a valer algo.
                time2collect = defineTime2collect;

                canCollect = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (canCollect)
        {

            if (collider.gameObject.layer == 10)
            {
                followPoint = collider.gameObject.transform.Find("EnergyFollow").transform;

                follow = true;
                //aqui inicia a coleta de pontos
            }
            if (collider.gameObject.CompareTag("SpaceShipYellow"))
            {
                yellowShip.GetComponent<EnemyShip_IA>().scape = true;
                blueShip.GetComponent<EnemyShip_IA>().scape = false;
                redShip.GetComponent<EnemyShip_IA>().scape = false;

                ssc4 = true;
                ssc2 = false;
                ssc3 = false;
                ssc1 = false;

            }
            if (collider.gameObject.CompareTag("SpaceShip"))
            {
                blueShip.GetComponent<EnemyShip_IA>().scape = false;
                redShip.GetComponent<EnemyShip_IA>().scape = false;
                yellowShip.GetComponent<EnemyShip_IA>().scape = false;

                ssc1 = true;
                ssc2 = false;
                ssc3 = false;
                ssc4 = false;

            }
            if (collider.gameObject.CompareTag("SpaceShipRed"))
            {
                redShip.GetComponent<EnemyShip_IA>().scape = true;
                blueShip.GetComponent<EnemyShip_IA>().scape = false;
                yellowShip.GetComponent<EnemyShip_IA>().scape = false;

                ssc2 = true;
                ssc1 = false;
                ssc3 = false;
                ssc4 = false;


            }
            if (collider.gameObject.CompareTag("SpaceShipBlue"))
            {
                redShip.GetComponent<EnemyShip_IA>().scape = false;
                blueShip.GetComponent<EnemyShip_IA>().scape = true;
                yellowShip.GetComponent<EnemyShip_IA>().scape = false;

                ssc3 = true;
                ssc1 = false;
                ssc2 = false;
                ssc4 = false;

            }
            if (collider.gameObject.CompareTag("Parede"))
            {
                Debug.Log("bateu na parede");
            }
            canCollect = false;
        }


    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, followPoint.position, speed * Time.deltaTime);
    }

}