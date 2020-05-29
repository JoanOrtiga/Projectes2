using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakBarrido : BossController
{
    public float atackSpeed;
    public GameObject p1, p2, p3, p4;
    public int pathChoser;
    private bool inpath;
    void Start()
    {
        Random.Range(0, 1);
    }

    private void Update()
    {
        if (!inpath)
        {
            pathChoser = Random.Range(0, 1);
        }
        else
        {

        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //falta implementar: saber hacia que lado mira para que vaya hacia ese lado con otro if en plan:
        //
        //
        //if(pathChoser==1 && facedirection==1) {vas a la derecha }
        //
        //pathchoser es lo que escoge el recorrido entre el de arriba y el de abajo y facedirection escogeria
        //hacia donde mira para que cuando salga del follow player o de donde sea vaya hacia el mismo sentido.
        //
        if (pathChoser == 1) 
        { 
            transform.position = Vector2.MoveTowards(transform.position, p1.transform.position, atackSpeed * Time.deltaTime);
        }
        else if(pathChoser == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, p3.transform.position, atackSpeed * Time.deltaTime);

        }
    }
}
