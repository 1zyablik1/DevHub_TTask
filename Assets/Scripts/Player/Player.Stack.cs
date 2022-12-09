using UnityEngine;
using DG.Tweening;

public partial class Player
{
    [SerializeField] private GameObject stackContainer;
    [SerializeField] private GameObject pizza;
    private ProductStack stack;
    private Sequence moveSequence;

    private void StackAwake()
    {
        stack = new ProductStack(pizza, stackContainer, 6);
    }

    public void GetFromStack(Transform positon)
    {
        var pizza = stack.GetFromStack();
        pizza.transform.SetParent(null);

        moveSequence = DOTween.Sequence();

        moveSequence.Append(pizza.transform.DOMove(positon.position, 0.5f));
    }
}
