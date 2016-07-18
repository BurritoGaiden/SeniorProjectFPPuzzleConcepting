using UnityEngine;
using System.Collections;

public enum ObjectKind { Nonusable, Usable};
public enum Seatable { Seatable, Nonseatable};

public class CarryableObject : MonoBehaviour {
    /*
    public class ObjectType {
        ObjectType 

    }
    */

    public ObjectKind thisOK = ObjectKind.Nonusable;
    public Seatable thisST = Seatable.Seatable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
