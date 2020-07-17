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

        public static void LabelCentered(string text)
        {
            var style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, wordWrap = true };
            EditorGUILayout.LabelField(text, style, GUILayout.ExpandWidth(true));
        }

        public static void LabelRight(string text)
        {
            var style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleRight, wordWrap = true };
            EditorGUILayout.LabelField(text, style, GUILayout.ExpandWidth(true));
        }

        public static void LabelLeft(string text)
        {
            var style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleLeft, wordWrap = true };
            EditorGUILayout.LabelField(text, style, GUILayout.ExpandWidth(true));
        }
    }
}