using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase;
using UnityEngine.Assertions;
using Firebase.Extensions;

public class DataBridge : MonoBehaviour
{

    [SerializeField]
    public InputField nameFeild;
    public Text namef;
    public Text passf;

    [SerializeField]
    public InputField pass;
    private string childPath = "Children/one_cool_Dude";
    private ListenerRegistration listenerRegistration;

    void Start()
    {
         var firestore = FirebaseFirestore.DefaultInstance;
            listenerRegistration =firestore.Document(childPath).Listen(snapshot=>{
            var childData = snapshot.ConvertTo<Child>();
            namef.text = childData.name;
            passf.text = childData.password;

                 });


    }

      void OnDestroy() {

    listenerRegistration.Stop();
    }

    void Update()
    {
        
    }

    public void saveData()
    {   var firestore = FirebaseFirestore.DefaultInstance;
        var childData = new Child
        {
        name = nameFeild.text,
        password = pass.text
        };
        firestore.Document(childPath).SetAsync(childData);
    }


    public void loadData()
    {
        var firestore = FirebaseFirestore.DefaultInstance;
        firestore.Document(childPath).GetSnapshotAsync().ContinueWithOnMainThread((task =>
        {
            Assert.IsNull(task.Exception);

            var childData = task.Result.ConvertTo<Child>();
            nameFeild.text = childData.name;
            pass.text = childData.password;

            print("Name  "+ childData.name);
            print("pass  "+ childData.name);
        }
        ));
    }
}
