using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInvocateur : MonoBehaviour
{
    private Ghost ghostScript;
    private InvocateurModifierBoss invocateurScript;
    private float tempTransition;
    public float TempTotalTransition = 10f;
    public GameObject energyShield;
    private bool InvocateurDead = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
        ghostScript = GetComponent<Ghost>();
        invocateurScript = GetComponent<InvocateurModifierBoss>();
        invocateurScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");


            for (int i = 0; i < list.Length; i++)
            {

                Destroy(list[i].gameObject);
            }
        }
            if (InvocateurDead) tempTransition = tempTransition + 1 * Time.deltaTime;
        if (tempTransition >= TempTotalTransition)
        {
            ChangerScript();
            tempTransition = 0;

        }
    }

    public void ChangerScript()
    {

        if(ghostScript.enabled == true)
        {
            ghostScript.enabled = false;
            invocateurScript.enabled = true;
            InvocateurDead = false;
            Instantiate(energyShield, transform.position, Quaternion.identity);

        }
        else
        {
            InvocateurDead = true;
            ghostScript.enabled = true;
            invocateurScript.enabled = false;
            GameObject temp =GameObject.FindGameObjectWithTag("EnergyShield");
            if (temp != null) Destroy(temp);
            invocateurScript.resetScript();
        }
       
    }
}
