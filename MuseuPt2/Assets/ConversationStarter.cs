using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject playerInteractUI; // Referência ao PlayerInteractUI
    [SerializeField] private GameObject playerCapsule; // Referência ao PlayerCapsule

    private void Start()
    {
        // Desativa a UI no início do jogo
        playerInteractUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ativa a UI quando o jogador entra na trigger
            playerInteractUI.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Inicia o diálogo e desativa a UI
                ConversationManager.Instance.StartConversation(myConversation);
                playerInteractUI.SetActive(false);

                // Desativa o script de movimento do jogador dentro do PlayerCapsule
                playerCapsule.GetComponent<MonoBehaviour>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desativa a UI quando o jogador sai da trigger
            playerInteractUI.SetActive(false);
        }
    }

    private void Update()
    {
        // Verifica se o diálogo terminou
        if (!ConversationManager.Instance.IsConversationActive)
        {
            // Reativa o script de movimento do jogador dentro do PlayerCapsule
            playerCapsule.GetComponent<MonoBehaviour>().enabled = true;
        }
    }
}
