using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class createRecipt : MonoBehaviour
{
    public GameObject order;

    public void createText()
    {
        string path = Application.persistentDataPath + "/Log.txt";
        string content = order.GetComponent<deleteOrder>().wholeOrder;

        File.WriteAllText(path, content);

        string price = Application.persistentDataPath + "/Price.txt";
        string priceN = order.GetComponent<deleteOrder>().total.ToString("F2");

        File.WriteAllText(price, priceN);

        SceneManager.LoadScene(sceneBuildIndex:1);
    }
}
