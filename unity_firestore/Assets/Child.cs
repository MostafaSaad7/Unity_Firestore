using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Child
{
    [FirestoreProperty]
    public string name { get; set; }


    [FirestoreProperty]
    public string password { get; set; }

}
