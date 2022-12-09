using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductStack
{
    private Pool pizzasPool;
    private List<GameObject> pizzas;
    private GameObject pizza;
    private GameObject parent;
    private float pizzasStartCount;

    public ProductStack(GameObject pizza, GameObject parent, float pizzasStartCount)
    {
        pizzas = new List<GameObject>();

        this.pizza = pizza;
        this.parent = parent;
        this.pizzasStartCount = pizzasStartCount;

        pizzasPool = new Pool(pizza, parent);

        ResetStack();
    }

    public void  ResetStack()
    {
        pizzasPool.DisablePool();

        pizzas.Clear();

        CreateStack();
    }

    private void CreateStack()
    {
        for(int i = 0; i < pizzasStartCount; i++)
        {
            Vector3 pos = new Vector3(parent.transform.position.x, parent.transform.position.y + (0.05f * i), parent.transform.position.z);

            var temp = pizzasPool.GetFreeElement(pos, Quaternion.Euler(Vector3.zero));
            pizzas.Add(temp);
        }
    }

    public GameObject GetFromStack()
    {
        var temp = pizzas[pizzas.Count - 1];
        pizzas.RemoveAt(pizzas.Count - 1);
        return temp;
    }
}
