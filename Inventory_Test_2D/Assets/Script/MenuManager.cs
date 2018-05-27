using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public delegate void AddingButtonHandler();
    public static event AddingButtonHandler ButtonAdded;

    private Transform m_transform;
    public GameObject testObj;

    [SerializeField]
    private int elementCount;
    // Use this for initialization

    private void Awake()
    {
        m_transform = this.GetComponent<Transform>().transform;
        elementCount = 0;
    }
    void Start () {
        ButtonAdded += ItemAdding;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ItemAdding() {
        GameObject instance = Instantiate(Resources.Load("Element", typeof(GameObject))) as GameObject;
        //testObj = Instantiate(Resources.Load("Element", typeof(GameObject))) as GameObject;
        instance.transform.parent = m_transform;
        instance.name = "Element" + elementCount;
        elementCount++;
    }
}
