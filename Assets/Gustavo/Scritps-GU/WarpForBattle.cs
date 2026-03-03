using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpForBattle : MonoBehaviour, ITouchable
{

    public void Active()
    {
       //Troque a cena
       SceneManager.LoadScene("");
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }
}