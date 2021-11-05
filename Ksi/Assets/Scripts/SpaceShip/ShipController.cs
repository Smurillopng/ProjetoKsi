using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    [Header("Ship Settings")]
    public float speed = 30.0f; //velocidade da nave
    public float boostSpeed; // velocidade da nave com turbo
    public float turnFactor = 3.5f; // velocidade da rotação da nave
    public GameObject energyFollow;
    private float defineNormalSpeed; // variável que irá receber a velocidade da nave para as mudanças durante o turbo
    [SerializeField] private Slider fuelSlider;

    // local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    [SerializeField] private float fuel = 100f; //quantidade máxima de turbo
    [SerializeField] private float burnFuel = 20f; //velocidade que o turbo é gasto
    [SerializeField] private float refillFuel = 20f; //velocidade que o turbo recarrega
    [SerializeField] private float fuelCooldown = 2f; //cooldown pra recarregar se o turbo for completamente gasto
    private bool haveFuel = true; //verifica se ainda tem turbo
    private float currentFuel; //quanntidade atual de turbo
    private bool turboOff = true; //verifica se está usando o turbo
    private float timer = 0f; //timer pra começar a recaregar o turbo

    [Header("Ship Take Damage")]
    private bool shipDisable; //define se a nave pode mover ou não
    public float maintenanceShipTime; //tempo que a nave fica sem poder controlar
    public float colorHitSec; //tempo que a nave fica com outra cor

    //Components
    Rigidbody2D shipRigidbody2D;
    SpriteRenderer shipSprite;

    private void Awake()
    {
        shipRigidbody2D = GetComponent<Rigidbody2D>();
        shipSprite = GetComponent<SpriteRenderer>();
        defineNormalSpeed = speed;
        currentFuel = fuel; //inicia o turbo com carga máxima
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Limita o movimento da nave até uma parte específica da tela
    void Update()
    {
        transform.position = new Vector2 (
            Mathf.Clamp(transform.position.x, -50f, 50f),
            Mathf.Clamp(transform.position.y, -25f, 35f));
    }


    private void FixedUpdate()
    {
        if (!shipDisable) 
        {
        ApplyEngineForce();

        ApplySteering();

        FuelBoost();
        }
    }

    private void RefillFuel() { //recarrega o turbo se ele não estiver sendo usado
        if(currentFuel < fuel && turboOff) {
            currentFuel += refillFuel * Time.deltaTime;
            haveFuel = true;
        }
    }

    void ApplyEngineForce()
    {
        //create a force to the engine
        Vector2 engineForceVector = transform.up * accelerationInput * speed;

        //apply force and pushes the ship foward
        shipRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }
    private void ApplySteering()
    {
        //update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        //apply steering by rotating the ship object
        shipRigidbody2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    void FuelBoost()
    {
        fuelSlider.value = currentFuel / fuel; //faz o slider acompanhar a carga de turbo
        if(currentFuel < 0f) { //faz o turbo recarregar com cooldown se for completamente gasto
            haveFuel = false;
            speed = defineNormalSpeed;
            currentFuel = 0;
            turboOff = true;
        }

        if(Input.GetKey(KeyCode.Space) && haveFuel) { //usa o turbo se apertar espaço
            turboOff = false;
            speed = boostSpeed; //velocidade com turbo
            currentFuel -= burnFuel * Time.deltaTime;
            Debug.Log ("Usando turbo!");
        }
        else if(!Input.GetKey(KeyCode.Space) && haveFuel) { //se não tiver apertando espaço recarrrega o turbo
            speed = defineNormalSpeed; //reseta a velocidade
            turboOff = true;
            RefillFuel();
        }

        if(!haveFuel) { //inicia o timer se todo o turbo for gasto
            timer += Time.deltaTime;
            if(timer >= fuelCooldown) { //aqui faz o turbo recarregar de acordo com o cooldown
                haveFuel = true;
                timer = 0;
            }
        }
    }

    public void ShipTakeDamage(int damage)
    {
        Debug.Log("tomou dano");
        
        StartCoroutine(ColorHit()); //chama a função q muda a cor da nave quando leva dano
        StartCoroutine(ShipFixing()); //função q desabilita o movimento por um tempo

    }
    IEnumerator ColorHit()
    {
        shipSprite.color = Color.red; //muda a cor da nave
        yield return new WaitForSeconds(colorHitSec);
        shipSprite.color = Color.white; //volta para a cor normal
    }

    IEnumerator ShipFixing()
    {
        shipDisable = true;
        yield return new WaitForSeconds(maintenanceShipTime);
        shipDisable = false;
    }

}