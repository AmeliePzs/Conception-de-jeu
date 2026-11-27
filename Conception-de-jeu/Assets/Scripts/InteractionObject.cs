using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] GameObject uiObject;

    [SerializeField] GameObject hudObject;

    private InputAction interactInput;

    private bool isPlayer = false;

    //Pour personnaliser le texte de l'UI
    [SerializeField] private TMP_Text descriptionTmp;
    [SerializeField] string descriptionText;

    void Start()
    {
        uiObject.SetActive(false);
        hudObject.SetActive(false);
        interactInput = InputSystem.actions.FindAction("Interact");
    }

    private void OnTriggerEnter(Collider player)
    {
        // Vérifie si c'est bien le joueur qui est entré
        if(player.gameObject.tag == "Player")
        {
            Debug.Log("Joueur entré !");
            hudObject.SetActive(true);
            isPlayer = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        // Vérifie si c'est bien le joueur qui est sorti
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            hudObject.SetActive(false);
            Debug.Log("Joueur sortie !");
            isPlayer = false;

        }
    }
    void Update()
    {
        if (interactInput.IsPressed() && isPlayer)
        {
            Debug.Log("Ui à afficher !");
            uiObject.SetActive(true);
            descriptionTmp.SetText(descriptionText);
        } 
    }
}
