﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string cena;
    

    public void CarregaCena()
    {
         SceneManager.LoadScene(cena);
    }
}
