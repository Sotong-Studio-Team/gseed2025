#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomPropertyDrawer(typeof(GridVisualizer))]
public class GridVisualizerDrawer : PropertyDrawer
{
    private const float CELL_SIZE = 25f;
    private const float PADDING = 2f;
    private const float ORIGIN_SIZE = 6f;
    private const float ARROW_SIZE = 20f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var grid = (GridVisualizer)fieldInfo.GetValue(property.serializedObject.targetObject);
        var sizeProp = property.FindPropertyRelative("_gridSize");

        // Layout
        float yPos = position.y;

        // 1. Header and Controls
        Rect headerRect = new Rect(position.x, yPos, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(headerRect, label, EditorStyles.boldLabel);
        yPos += headerRect.height;

        // 2. Grid Size Control
        Rect sizeRect = new Rect(position.x, yPos, position.width, EditorGUIUtility.singleLineHeight * 2);
        EditorGUI.PropertyField(sizeRect, sizeProp);
        yPos += sizeRect.height + PADDING;

        // 4. Grid Visualization
        Rect gridRect = new Rect(
            position.x,
            yPos,
            grid.GridSize.x * (CELL_SIZE + PADDING) + PADDING,
            grid.GridSize.y * (CELL_SIZE + PADDING) + PADDING
        );
        DrawGrid(gridRect, grid);
        yPos += gridRect.height + PADDING;

        // 5. Update Button
        //Rect buttonRect = new Rect(position.x, yPos, position.width, EditorGUIUtility.singleLineHeight * 1.5f);
        //if (GUI.Button(buttonRect, "Update Target Array"))
        //{
            //EditorUtility.SetDirty(property.serializedObject.targetObject);
        //}

        EditorGUI.EndProperty();
    }

    private void DrawGrid(Rect gridRect, GridVisualizer grid)
    {
        EditorGUI.DrawRect(gridRect, new Color(0.1f, 0.1f, 0.1f, 0.2f));

        RectInt bounds = grid.GetGridBounds();
        int cols = bounds.width;
        int rows = bounds.height;

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector2Int cellPos = new Vector2Int(
                    bounds.xMin + x,
                    bounds.yMin + y
                );

                Rect cellRect = new Rect(
                    gridRect.x + PADDING + x * (CELL_SIZE + PADDING),
                    gridRect.y + PADDING + (rows - 1 - y) * (CELL_SIZE + PADDING),
                    CELL_SIZE,
                    CELL_SIZE
                );

                // Draw cell
                bool isActive = grid.GetActiveCells().Contains(cellPos);
                EditorGUI.DrawRect(cellRect, isActive ? Color.black : Color.white);
                GUI.Box(cellRect, "");

                // Draw origin
                if (cellPos == Vector2Int.zero)
                {
                    //DrawOriginMarker(cellRect);
                    //DrawDirectionIndicator(cellRect);
                }

                // Handle click
                if (Event.current.type == EventType.MouseDown 
                    && cellRect.Contains(Event.current.mousePosition))
                {
                    grid.ToggleCell(cellPos);
                    GUI.changed = true;
                    Event.current.Use();

                    //grid.;
                }
            }
        }
    }

    private void DrawOriginMarker(Rect cellRect)
    {
        Rect originRect = new Rect(
            cellRect.center.x - ORIGIN_SIZE / 2,
            cellRect.center.y - ORIGIN_SIZE / 2,
            ORIGIN_SIZE,
            ORIGIN_SIZE
        );
        EditorGUI.DrawRect(originRect, Color.red);
    }

    private void DrawDirectionIndicator(Rect cellRect)
    {
        Handles.BeginGUI();

        // Arrow points to the left
        Vector2 center = new(cellRect.xMax, cellRect.center.y);
        Vector3[] arrowPoints = new Vector3[3] {
            new Vector2(center.x, center.y - ARROW_SIZE/2),
            new Vector2(center.x - ARROW_SIZE, center.y),
            new Vector2(center.x, center.y + ARROW_SIZE/2)
        };

        Handles.color = Color.red;
        Handles.DrawAAConvexPolygon(arrowPoints);
        Handles.EndGUI();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var grid = (GridVisualizer)fieldInfo.GetValue(property.serializedObject.targetObject);
        return EditorGUIUtility.singleLineHeight * 4.5f + // Header + size + direction + button
               grid.GridSize.y * (CELL_SIZE + PADDING) + // Grid
               PADDING * 5; // Padding
    }
}
#endif