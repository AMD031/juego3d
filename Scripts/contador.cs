using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class contador : MonoBehaviour
{
    private Text text;
    private int cantidad = 0;

    // Start is called before the first frame update
    void Awake()
    {
        cantidad = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        text = gameObject.GetComponent<Text>();
        text.text = cantidad+"";
    }





    public void disminuirCantidad()
    {
        //Debug.Log(cantidad);
        cantidad -= 1;
        text.text = cantidad + "";
        if (cantidad <= 0)
        {
            SceneManager.LoadScene("ganar");
            Debug.Log("has ganado");
        }
    }
  


}
