using System;
using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor.Ui
{
    public static class GuiLayoutHelper
    {
        public static void DrawUiHorizontalLine(Color color, int thickness = 1, int padding = 10)
        {
            var r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            r.height = thickness;

            r.y += (int)(padding / 2);
            r.x -= 2;
            r.width += 6;
            EditorGUI.DrawRect(r, color);
        }

        public static void InHorizontal(Action layoutBuilder)
        {
            GUILayout.BeginHorizontal();

            layoutBuilder();

            GUILayout.EndHorizontal();
        }

        public static void Label(string text, TextAnchor alignment = TextAnchor.MiddleCenter)
        {
            var style = new GUIStyle(GUI.skin.label) { alignment = alignment, wordWrap = true };
            EditorGUILayout.LabelField(text, style, GUILayout.ExpandWidth(true));
        }

        public static bool Button(string text, RectOffset margin = null, RectOffset padding = null)
        {
            var style = new GUIStyle(GUI.skin.button);

            if (!(margin is null)) style.margin = margin;
            if (!(padding is null)) style.padding = padding;

            return GUILayout.Button(text, style);
        }
    }
}