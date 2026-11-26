using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    //public GameObject uiObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        // Vérifie si c'est bien le joueur qui est entré
        if(player.gameObject.tag == "Player")
        {
           // uiObject.SetActive(true);
            Debug.Log("Joueur entré !");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
