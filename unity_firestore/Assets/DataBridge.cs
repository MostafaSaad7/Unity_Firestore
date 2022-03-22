using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;

public class DataBridge : MonoBehaviour
{

    public InputField name;
    public InputField pass;
    private string childPath = "Children/one cool Dude";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveData()
    {
        var childData = new Child
        {
            name = name.text,
        password = pass.text

        };
  

        var firestore = FirebaseFirestore.DefaultInstance;
        firestore.Document(childPath).SetAsync(childData);

    }
}
