using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class InteractionOrdinateur : MonoBehaviour
{
    [SerializeField] GameObject uiObject;
    [SerializeField] GameObject hudObject;

    private InputAction interactInput;

    private bool isPlayer = false;

    //Pour personnaliser le texte de l'UI
    [SerializeField] private TMP_Text expediteurTmp;
    [SerializeField] string expediteurText;

    [SerializeField] private TMP_Text destinataireTmp;
    [SerializeField] string destinataireText;

    [SerializeField] private TMP_Text dateHeureTmp;
    [SerializeField] string dateHeureText;

    [SerializeField] private TMP_Text objetTmp;
    [SerializeField] string objetText;

    [SerializeField] private TMP_Text messageTmp;
    [SerializeField] string messageText;

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
            SetTexteOrdinateur();
        }
    }

    private void SetTexteOrdinateur()
    {
        expediteurTmp.SetText(expediteurText);

        destinataireTmp.SetText(destinataireText);

        dateHeureTmp.SetText(dateHeureText);

        objetTmp.SetText(objetText);

        messageTmp.SetText(messageText);

    }
}
