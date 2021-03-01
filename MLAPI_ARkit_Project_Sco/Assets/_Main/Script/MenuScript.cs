using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Host()
    {
        NetworkingManager.Singleton.StartHost();
        menuPanel.SetActive(false);
    }
    public void Join()
    {
        NetworkingManager.Singleton.StartClient();
        menuPanel.SetActive(false);
    }
}
