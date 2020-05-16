using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public Camera cameraPersonagem;
    public float velocidade;
    public float smooth;
    public float distanciaZ;
    private Ray ray;
    private RaycastHit hit;
   

    private Arma arma;
    public GameObject armaObject;
    

    void Update()
    {
        arma = armaObject.GetComponent<Arma>(); 
        Mover( velocidade, ray , hit);
        GerenciarCamera(cameraPersonagem,transform.position, distanciaZ, smooth);
    }

   

    void Mover(float vel, Ray ray, RaycastHit hit)
    {
        //VERIFICA O TOQUE NA TELA
        if (Input.GetButton("Fire1"))
        {
            //CAPTA O TOQUE NA TELA CONVERTE EM INFORMAÇAO CARTESIANA 3D
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //VERIFICA ONDE O FIRE COLIDIU E GUARDA A INFORMACAO DA COLISAO EM HIT, OUT DIZ QUE A DISTACIA DO RAIO É INFINITA
            if (Physics.Raycast(ray, out hit))
            {
                //RECEBE A COORDENADA ATUAL DO TOQUE NO AMBIENTE 3D
                Vector3 destino = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                
                //ORIENTAÇAO DO PERSONAGEM(OLHAR A DIRECAO ONDE ELE ESTA OLHANDO)
                transform.LookAt(destino);
            }

            if(Physics.Raycast.)

            if(hit.collider.tag == "Mapa")
            {
                //MOVE O JOGADOR PARA O DESTINO
                transform.position = Vector3.Lerp(transform.position, destino, vel * Time.deltaTime);
            }
            else if (hit.collider.tag == "Inimigo")
            {
                if(Input.GetButtonDown ("Fire1"))
                {
                    arma.Atirar();
                }
            }
        }
    }

    void GerenciarCamera(Camera cam, Vector3 objetivo, float distanciaZ, float smooth)
    {

        //MOVER A CAMERA COM SUAVIDADE
        Vector3 o = Vector3.zero;
        
        //APOS ATINGIR A DISTANCIA, ATUALIZA O OBJETIVO DA CAMERA
        if (Vector3.Distance(o, cam.transform.position) > 0.5f)
        {
           o = new Vector3(objetivo.x, cam.transform.position.y, objetivo.z - distanciaZ);
        }

        //MOVENDO A CAMERA ATE O DESTINO
        cam.transform.position = Vector3.Lerp(cam.transform.position, o, smooth);
    }  

}
