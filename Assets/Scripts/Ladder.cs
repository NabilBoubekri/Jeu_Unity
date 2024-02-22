using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    public Text interactUI;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            //descendre de l'echelle
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
            playerMovement.jumpForce = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        playerMovement.isClimbing = false;
        topCollider.isTrigger = false;
        interactUI.enabled = false;
        playerMovement.jumpForce = 400;
    }
}
