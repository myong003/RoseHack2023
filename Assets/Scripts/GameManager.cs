using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image overlay;
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("Fading to white");
        StartCoroutine(FadeToWhite());
    }

    private IEnumerator FadeToWhite() {
        while (overlay.color.a < 1) {
            Color newColor = overlay.color;
            newColor.a += fadeSpeed * Time.deltaTime;
            overlay.color = newColor;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
