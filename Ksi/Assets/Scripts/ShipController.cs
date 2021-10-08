using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    [Header("Ship Settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
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



    //Components
    Rigidbody2D shipRigidbody2D;

    private void Awake()
    {
        shipRigidbody2D = GetComponent<Rigidbody2D>();
        currentFuel = fuel; //inicia o turbo com carga máxima
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = currentFuel / fuel; //faz o slider acompanhar a carga de turbo
        if(currentFuel < 0f) { //faz o turbo recarregar com cooldown se for completamente gasto
            haveFuel = false;
            accelerationFactor = 6.0f;
            currentFuel = 0;
            turboOff = true;
        }

        if(Input.GetKey(KeyCode.Space) && haveFuel) { //usa o turbo se apertar espaço
            turboOff = false;
            accelerationFactor = 8.0f; //velocidade com turbo
            currentFuel -= burnFuel * Time.deltaTime;
            Debug.Log ("Usando turbo!");
        }
        else if(!Input.GetKey(KeyCode.Space) && haveFuel) { //se não tiver apertando espaço recarrrega o turbo
            accelerationFactor = 6.0f; //reseta a velocidade
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

    private void RefillFuel() { //recarrega o turbo se ele não estiver sendo usado
        if(currentFuel < fuel && turboOff) {
            currentFuel += refillFuel * Time.deltaTime;
            haveFuel = true;
        }
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        //create a force to the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

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

}
