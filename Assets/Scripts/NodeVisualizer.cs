using UnityEngine;
using TMPro;

public class NodeVisualizer : MonoBehaviour
{
    public TreeNode<GameDecision> node;

    private void Start()
    {
        TextMeshPro textLabel = GetComponentInChildren<TextMeshPro>();
        if (textLabel != null)
        {
            textLabel.text = node.Value.ToString();
        }
    }

    private void OnMouseDown()
    {

        if (node.Children.Count == 0)
        {
            Debug.Log("Este nodo no tiene hijos.");
        }
        else
        {
            Debug.Log("Hijos:");
            foreach (var child in node.Children)
            {
                Debug.Log($" - {child.Value}");
            }
        }
    }
}
