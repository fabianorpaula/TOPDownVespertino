using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaCena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChamarCena(int numCena)
    {
        if(numCena == 1)
        {
            SceneManager.LoadScene(1);
        }
        if (numCena == 2)
        {
            SceneManager.LoadScene(2);
        }
        if (numCena == 3)
        {
            SceneManager.LoadScene(3);
        }
    }

}
