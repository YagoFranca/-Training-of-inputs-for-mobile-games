using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject projetil;

    public void Atirar(GameObject a)
    {


        Destroy(Instantiate(projetil, a.transform.position, a.transform.rotation), 3.0f);
   
    }
}
