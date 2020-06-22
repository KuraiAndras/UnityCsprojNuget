using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor.Ui
{
    public static class GuiLayoutHelper
    {
        public static void DrawUiLine(Color color, int thickness = 2, int padding = 10)
        {
            var r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            r.height = thickness;

            r.y += (int)(padding / 2);
            r.x -= 2;
            r.width += 6;
            EditorGUI.DrawRect(r, color);
        }
    }
}