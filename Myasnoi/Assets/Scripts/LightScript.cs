using UnityEngine;

public class LightScript : MonoBehaviour
{
    public GameObject FlashlightGround, FlashlightPlayer, FlashlightHelpText;
    public string PlayerName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == PlayerName)
        {
            FlashlightGround.SetActive(false);
            FlashlightPlayer.SetActive(true);
            FlashlightHelpText.SetActive(true);
        }
    }
}
