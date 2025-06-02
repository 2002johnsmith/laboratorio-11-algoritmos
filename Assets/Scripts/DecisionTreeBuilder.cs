using UnityEngine;

public class DecisionTreeBuilder : MonoBehaviour
{
    public Tree<GameDecision> decisionTree;
    public GameObject nodePrefab;

    void Start()
    {
        // Nivel 0 (Raíz)
        var root = new GameDecision("¿Enfrentar enemigo?");
        decisionTree = new Tree<GameDecision>(root);

        // Nivel 1
        var optionYes = new TreeNode<GameDecision>(new GameDecision("Sí"));
        var optionNo = new TreeNode<GameDecision>(new GameDecision("No"));
        decisionTree.Root.AddChild(optionYes);
        decisionTree.Root.AddChild(optionNo);

        // Nivel 2 para "Sí"
        optionYes.AddChild(new TreeNode<GameDecision>(new GameDecision("Usar Espada.")));
        optionYes.AddChild(new TreeNode<GameDecision>(new GameDecision("Usar Arco.")));
        optionYes.AddChild(new TreeNode<GameDecision>(new GameDecision("Usar Poder.")));

        // Nivel 2 para "No"
        optionNo.AddChild(new TreeNode<GameDecision>(new GameDecision("Huir.")));
        optionNo.AddChild(new TreeNode<GameDecision>(new GameDecision("Esconderse.")));

        // Crear visualmente el árbol
        CreateVisual(decisionTree.Root, new Vector3(0, 5f, 0), 6f);
    }
    void CreateVisual(TreeNode<GameDecision> node, Vector3 position, float spacing, int depth = 0)
    {
        GameObject go = Instantiate(nodePrefab, position, Quaternion.identity);
        go.name = node.Value.ToString();

        var visual = go.AddComponent<NodeVisualizer>();
        visual.node = node;

        int count = node.Children.Count;
        float adjustedSpacing = Mathf.Max(spacing - depth * 0.5f, 2f);

        for (int i = 0; i < count; i++)
        {
            float offsetX = (i - (count - 1) / 2f) * adjustedSpacing;
            Vector3 childPos = position + new Vector3(offsetX, -2.5f, 0);
            CreateVisual(node.Children[i], childPos, spacing, depth + 1);
        }
    }
}
