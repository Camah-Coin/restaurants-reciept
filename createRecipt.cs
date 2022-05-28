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

    public void uploadText()
    {
        // TODO: replace with the URL of Swift webservice
        string url = "https://www.swiftpos.com.au";

        // TODO: Obtain name and content of the file you want to upload
        string filename = "hello.text"; // Text you made
        string content = "Hello World";

        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("fileContent", content);
        form.AddField("fileName", filename);

        // Upload to a cgi script
        WWW w = new WWW(url, form);
        yield return w;
        if (!string.IsNullOrEmpty(w.error)) {
            print(w.error);
        }
        else {
            print("Finished Uploading File");
        }
    }
}
