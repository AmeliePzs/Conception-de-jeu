using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class Flashlight : MonoBehaviour
{
    private bool isLightOn = true;

    [SerializeField] private float maxlightintensity = 20f;

    //[SerializeField] GameObject flashlight;

    private InputAction lightInput;

    private Light flashlight;

    void Start()
    {
        lightInput = InputSystem.actions.FindAction("Light");

        flashlight = GetComponentInChildren<Light>();

        flashlight.intensity = maxlightintensity;
        isLightOn = true;
    }

    private void Update()
    {
        if (lightInput.WasPressedThisFrame()) 
        {
            StartCoroutine(SwitchLight());
        }
    }


    // C'est pour éviter un spam, mais ça fait que ça marche plus ou moins bien, voir si j'ai le temps de mieux le faire
    // Faire des debugs pour voir combien de fois la coroutine est lancée ici et dans l'update
    public IEnumerator SwitchLight()
    {

        if (!isLightOn)
        {
            flashlight.intensity = maxlightintensity;
        }
        else
        {
            flashlight.intensity = 0;
        }

        yield return new WaitForSeconds(0.2f);
        isLightOn = !isLightOn;

    }

}
