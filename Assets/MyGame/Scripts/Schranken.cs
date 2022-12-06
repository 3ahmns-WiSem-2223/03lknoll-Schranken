using UnityEngine;
using UnityEngine.SceneManagement;

public class Schranken : MonoBehaviour
{
    private bool schranken1 = false;
    private bool schranken2 = false;
    [SerializeField] GameObject schranken1Objekt;
    [SerializeField] GameObject schranken2Objekt;
    [SerializeField] GameObject cat;
    int mausKlick = 0;
    [SerializeField] GameObject textGewonnen;
    float catMove = -7.5f;
    void Start()
    {
        cat.transform.position = new Vector3(-7.5f, -0.5f, 0f);
        textGewonnen.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mausKlick++;
        }
        if (mausKlick % 2 != 0)
        {
            schranken1 = true;
            schranken1Objekt.transform.position = new Vector3(-4, 3, 0);
        }
        if (mausKlick % 2 == 0 && mausKlick != 0)
        {
            schranken2 = true;
            schranken2Objekt.transform.position = new Vector3(4, 3, 0);
        }
        
        if (Input.GetKey("d"))
        {
            catMove = catMove + 0.01f;
            cat.transform.position = new Vector3(catMove, -0.5f, 0f);
            if (catMove >= -6.55 && schranken1 == false)
            {
                catMove = -6.55f;
            }
            if (catMove >= 1.50f && schranken2 == false)
            {
                catMove = 1.5f;
            }
        }

        if (catMove >= 7.5f)
        {
            textGewonnen.SetActive(true);
        } 
    }
}
