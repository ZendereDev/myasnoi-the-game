using UnityEngine;

public class TextVisibilityScript : MonoBehaviour
{
    public GameObject Text;
    public float TimeRemaining = 5;

    private void Start()
    {
        GameObject helpTextsParent = Text.transform.parent.gameObject;
        for (int i = 0; i < helpTextsParent.transform.childCount; i++)
            helpTextsParent.transform.GetChild(i).gameObject.SetActive(false);
        Text.SetActive(true);
    }

    void Update()
    {
        if (TimeRemaining > 0) TimeRemaining -= Time.deltaTime;
        else Text.SetActive(false);
    }
}