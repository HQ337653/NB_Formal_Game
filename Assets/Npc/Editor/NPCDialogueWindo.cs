using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Callbacks;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UIElements;
using static NBGame.dialogue.NPCDialogueWindo.connection;
using System.Linq;
using static NBGame.dialogue.dialogueData;

namespace NBGame.dialogue
{
    public class NPCDialogueWindo : EditorWindow
    {

        static List<windowType> dialogeWindow = new List<windowType>();

        static List<connection> attachedWindows = new List<connection>();
        static List<int> toRemove = new List<int>();
        static NPCDialogueWindo graphEditorWindow;
        public static dialogueData currentDialogueData;
        static bool inChoosingConnection = false;
        static string path;
        public static int currentEditing = -1;
        #region dataStructure
        public class connection
        {
            public int start = -1;
            public int startIndex = 0;
            public int end = -1;

            public connection(int s, int startInde)
            {
                start = s;
                startIndex = startInde;
            }
            public connection(int s, int startInde, int endNode)
            {
                start = s;
                startIndex = startInde;
                end = endNode;
            }
        }
        public class windowType
        {
            public Rect rect;
            public Vector2 scroll = new Vector2();
            public Type type = Type.dialogue;
            public windowType(Rect rect, Type type)
            {
                this.rect = rect;
                this.type = type;
            }

            public enum Type
            {
                dialogue, choice,charaChange
            }
        }
        #endregion

        void OnGUI()
        {
            #region curves
            if (toRemove.Count == 3)
            {
                removeCurve(toRemove[0], toRemove[1], toRemove[2]);
            }
            Debug.Log(attachedWindows.Count);
            if (attachedWindows.Count >= 1)
            {
                for (int i = 0; i < attachedWindows.Count; i++)
                {
                    Debug.Log("forlllopeeee");
                    if (attachedWindows[i].end != -1)
                    {
                        Rect start = new Rect();
                        if (currentDialogueData.dialagueContents[attachedWindows[i].start] is dialogueData.DialogueChoice)
                        {
                            start = new Rect(dialogeWindow[attachedWindows[i].start].rect.x, dialogeWindow[attachedWindows[i].start].rect.y - 50 + attachedWindows[i].startIndex * 42, dialogeWindow[attachedWindows[i].start].rect.width, dialogeWindow[attachedWindows[i].start].rect.height);
                        }
                        else
                        {
                            start = new Rect(dialogeWindow[attachedWindows[i].start].rect.x, dialogeWindow[attachedWindows[i].start].rect.y, dialogeWindow[attachedWindows[i].start].rect.width, dialogeWindow[attachedWindows[i].start].rect.height);
                        }

                        Rect end = new Rect(dialogeWindow[attachedWindows[i].end].rect.x, dialogeWindow[attachedWindows[i].end].rect.y, dialogeWindow[attachedWindows[i].end].rect.width, dialogeWindow[attachedWindows[i].end].rect.height);
                        DrawNodeCurve(start, end);
                        Debug.Log("drawed!!!!!!!!!!!!!!!!!");
                    }

                }
            }
            #endregion
            BeginWindows();
            #region button on top
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(" dialogue"))
            {
                currentDialogueData.AddSingleDialogue();
                dialogeWindow.Add(new windowType(new Rect(10, 10, 150, 90), windowType.Type.dialogue));
            }
            if (GUILayout.Button(" choice"))
            {
                currentDialogueData.AddDialogueChoice();
                dialogeWindow.Add(new windowType(new Rect(10, 10, 150, 200), windowType.Type.choice));
            }
            if (GUILayout.Button("CharaChange"))
            {
                currentDialogueData.addCharaChange();
                dialogeWindow.Add(new windowType(new Rect(10, 10, 150, 90), windowType.Type.charaChange));
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("save"))
            {
                savedata();
            }
            #endregion
            
            GUILayout.BeginArea(new Rect(position.width - 200, 50, 190, position.height));
            showSpecificContent();
            GUILayout.EndArea();
            #region draw window
            for (int i = 0; i < dialogeWindow.Count; i++)
            {
                string name="";
                if (currentDialogueData.dialagueContents[i] is dialogueData.DialogueChoice)
                {
                    name = "Choice";
                }
                else if (currentDialogueData.dialagueContents[i] is dialogueData.singleDialogue)
                {
                    name = "dialogue";
                }
                else if (currentDialogueData.dialagueContents[i] is dialogueData.characterChange)
                {
                    name = "CharaChange";
                }
                dialogeWindow[i].rect = GUI.Window(i, dialogeWindow[i].rect, DrawDialogeWindow, name + i);
            }
            EndWindows();
            #endregion

        }

        private void savedata()
        {
            Debug.Log(JsonUtility.ToJson(currentDialogueData, true));
            dialogueData d = JsonUtility.FromJson<dialogueData>(JsonUtility.ToJson(currentDialogueData));
            for (int i = 0; i < currentDialogueData.dialagueContents.Count; i++)
            {
                currentDialogueData.dialagueContents[i].positionInEdictor = dialogeWindow[i].rect;
            }
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(JsonUtility.ToJson(currentDialogueData, true));
                }
            }

        }
        #region specific content
        void showSpecificContent()
        {
            if (currentEditing == -1)
            {
                GUILayout.Label("empty");
            }
            else
            {
                dialogueData.DialagueContent c = currentDialogueData.dialagueContents[currentEditing];
                GUILayout.Label(c.index.ToString());
                Debug.Log(currentEditing);
                if (dialogeWindow[currentEditing].type == windowType.Type.dialogue)
                {
                    showDialogueSpecificContent((dialogueData.singleDialogue)c);
                }
                else if (dialogeWindow[currentEditing].type == windowType.Type.choice)
                {
                    showChoiceSpecificContent((dialogueData.DialogueChoice)c);
                }else if (dialogeWindow[currentEditing].type == windowType.Type.charaChange)
                {
                    showCharaChangeSpecificContent((dialogueData.characterChange)c);
                }
            }
        }
        private void showCharaChangeSpecificContent(characterChange dialogue)
        {
            dialogue.characters[0] = (Sprite)EditorGUILayout.ObjectField(dialogue.characters[0], typeof(Sprite));
            dialogue.characters[1] = (Sprite)EditorGUILayout.ObjectField(dialogue.characters[1], typeof(Sprite));
            dialogue.characters[2] = (Sprite)EditorGUILayout.ObjectField(dialogue.characters[2], typeof(Sprite));
        }

        void showChoiceSpecificContent(dialogueData.DialogueChoice dialogue)
        {
            for (int i = 0; i < dialogue.choice.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("content");
                dialogue.choice[i] = EditorGUILayout.TextField(dialogue.choice[i]);
                EditorGUILayout.EndHorizontal();
            }
        }
        void showDialogueSpecificContent(dialogueData.singleDialogue dialogue)
        {
            dialogue.name = EditorGUILayout.TextField("name", dialogue.name);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("content");
            dialogue.dialogueContent = EditorGUILayout.TextField(dialogue.dialogueContent);
            EditorGUILayout.EndHorizontal();
            dialogue.PicturePosition = (DialagueContent.position)EditorGUILayout.EnumPopup(dialogue.PicturePosition);
            dialogue.characterPicture = (Sprite)EditorGUILayout.ObjectField(dialogue.characterPicture, typeof(Sprite));

        }
        #endregion

        #region draw window
        void DrawDialogeWindow(int id)
        {
            #region creating string to button
            string attachString;
            if (inChoosingConnection)
            {
                attachString = "connect to";
            }
            else
            {
                attachString = "connect";

            }
            string RemoveattachString;
            if (toRemove == null || toRemove.Count == 0)
            {
                RemoveattachString = "Remove";
            }
            else
            {
                RemoveattachString = "Removing";

            }
            if (id >= currentDialogueData.dialagueContents.Count)
            {
                Debug.Log("error" + currentDialogueData.dialagueContents.Count + " " + id);
                return;
            }
            else
            {
                // Debug.Log("no err" + currentDialogueData.dialagueContents.Count + " " + id);
            }
            #endregion
            dialogueData.DialagueContent current = currentDialogueData.dialagueContents[id];
            if (dialogeWindow[id].type == windowType.Type.dialogue)//dialogue
            {
                drawDialogeWindow(id, (dialogueData.singleDialogue)current, attachString, RemoveattachString);
            }
            else if (dialogeWindow[id].type == windowType.Type.choice)//choice
            {
                drawChoiceWindow(id, (dialogueData.DialogueChoice)current, attachString, RemoveattachString);
            }
            else//chareChange
            {
                drawCharaChangeWindow(id, (dialogueData.characterChange)current, attachString, RemoveattachString);
            }

            if (GUILayout.Button("focus"))
            {

                currentEditing = id;

            }

            GUI.DragWindow();
        }

        private void drawCharaChangeWindow(int id, characterChange current, string attachString, string removeattachString)
        {
            //GUILayout.Label("dialogue");
            Rect r = EditorGUILayout.BeginHorizontal();
            if (current.next[0] != null)
            {
                GUILayout.Label("next: " + current.next[0].index.ToString());
            }
            else
            {
                GUILayout.Label("empty");
            }
            if (GUILayout.Button(attachString))
            {
                if (!inChoosingConnection)
                {

                    // attachedWindows.Add(new connection(id, 0));
                    createConnection(id, 0);
                }
                else
                {
                    finishConnction(id);
                    //currentDialogueData.setConnection(attachedWindows[attachedWindows.Count - 1].start, id, attachedWindows[attachedWindows.Count - 1].startIndex);
                    Debug.Log(currentDialogueData.dialagueContents[attachedWindows[attachedWindows.Count - 1].start].next[attachedWindows[attachedWindows.Count - 1].startIndex].index);
                    // attachedWindows[attachedWindows.Count - 1].end = id;

                }
                inChoosingConnection = !inChoosingConnection;
                // windowsToAttach.Add(id);

            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button(removeattachString))
            {
                if (toRemove.Count < 2)
                {
                    toRemove.Add(id);
                    toRemove.Add(0);
                }
                else
                {
                    toRemove.Add(id);
                }


            }
        }

        void drawDialogeWindow(int id, dialogueData.singleDialogue current, string attachString, string RemoveattachString)
        {
            //GUILayout.Label("dialogue");
            dialogueData.singleDialogue target = current;
            Rect r = EditorGUILayout.BeginHorizontal();
            if (current.next[0] != null)
            {
                GUILayout.Label("next: " + current.next[0].index.ToString());
            }
            else
            {
                GUILayout.Label("empty");
            }
            if (GUILayout.Button(attachString))
            {
                if (!inChoosingConnection)
                {

                    // attachedWindows.Add(new connection(id, 0));
                    createConnection(id, 0);
                }
                else
                {
                    finishConnction(id);
                    //currentDialogueData.setConnection(attachedWindows[attachedWindows.Count - 1].start, id, attachedWindows[attachedWindows.Count - 1].startIndex);
                    Debug.Log(currentDialogueData.dialagueContents[attachedWindows[attachedWindows.Count - 1].start].next[attachedWindows[attachedWindows.Count - 1].startIndex].index);
                    // attachedWindows[attachedWindows.Count - 1].end = id;

                }
                inChoosingConnection = !inChoosingConnection;
                // windowsToAttach.Add(id);

            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button(RemoveattachString))
            {
                if (toRemove.Count < 2)
                {
                    toRemove.Add(id);
                    toRemove.Add(0);
                }
                else
                {
                    toRemove.Add(id);
                }


            }

        }

        void drawChoiceWindow(int id, dialogueData.DialogueChoice current, string attachString, string RemoveattachString)
        {
            dialogueData.DialogueChoice target = current;
            Debug.Log("next count: " + target.next.Count);
            dialogeWindow[id].scroll = EditorGUILayout.BeginScrollView(dialogeWindow[id].scroll);
            for (int i = 0; i < target.next.Count; i++)
            {
                Debug.Log("count " + i);
                dialogueData.DialagueContent nextContent = target.next[i];
                Rect r = EditorGUILayout.BeginHorizontal();
                if (nextContent != null)
                {
                    GUILayout.Label("next: " + current.next[i].index.ToString());
                }
                else
                {
                    GUILayout.Label("empty");
                }

                if (GUILayout.Button(attachString))
                {
                    if (!inChoosingConnection)
                    {
                        Debug.Log("create");
                        // attachedWindows.Add(new connection(id, i));
                        createConnection(id, i);
                    }
                    else
                    {
                        Debug.Log("connect");
                        //attachedWindows[attachedWindows.Count - 1].end = id;
                        finishConnction(id);
                        //currentDialogueData.setConnection(attachedWindows[attachedWindows.Count - 1].start, id, attachedWindows[attachedWindows.Count - 1].startIndex);
                        //currentDialogueData.dialagueContents[attachedWindows[attachedWindows.Count - 1].start].next[attachedWindows[attachedWindows.Count - 1].startIndex] = target;
                    }
                    inChoosingConnection = !inChoosingConnection;
                }

                EditorGUILayout.EndHorizontal();
                if (GUILayout.Button(RemoveattachString))
                {
                    if (toRemove.Count < 2)
                    {
                        toRemove.Add(id);
                        toRemove.Add(i);
                    }
                    else
                    {
                        toRemove.Add(id);
                    }


                }
            }
            EditorGUILayout.EndScrollView();
            if (GUILayout.Button("add"))
            {
                target.next.Add(null);
                target.choice.Add(null);
            }
        }

        void createConnection(int start, int startIndex)
        {
            attachedWindows.Add(new connection(start, startIndex));
        }

        void finishConnction(int end)
        {
            foreach (connection connection in attachedWindows)
            {
                if (connection.startIndex == attachedWindows[attachedWindows.Count - 1].startIndex && connection.start == attachedWindows[attachedWindows.Count - 1].start && connection.end == end)
                {
                    Debug.Log("duplicated");
                    return;
                }
            }
            attachedWindows[attachedWindows.Count - 1].end = end;
            currentDialogueData.setConnection(attachedWindows[attachedWindows.Count - 1].start, end, attachedWindows[attachedWindows.Count - 1].startIndex);
        }
        #endregion

        #region curve
        void DrawNodeCurve(Rect start, Rect end)
        {
            Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
            Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
            Vector3 startTan = startPos + Vector3.right * 50;
            Vector3 endTan = endPos + Vector3.left * 50;
            Color shadowCol = new Color(0, 0, 0, 0.06f);

            for (int i = 0; i < 3; i++)
            {// Draw a shadow
                Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
            }

            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
            Handles.DrawWireCube(endPos, new Vector3(10, 10, 10));
        }

        void removeCurve(int idFrom, int IndexFrom, int idTo)
        {
            if (attachedWindows.Count >= 1)
            {
                for (int i = 0; i < attachedWindows.Count; i++)
                {
                    if (attachedWindows[i].start == idFrom && attachedWindows[i].startIndex == IndexFrom && attachedWindows[i].end == idTo)
                    {
                        attachedWindows.RemoveAt(i);
                        // foreach(dialogueData.connection c in currentDialogueData.connectionsList)
                        //{
                        //  if (c)
                        //{

                        //}
                        //}
                        if (currentDialogueData.connectionsList[i].begin == idFrom && currentDialogueData.connectionsList[i].beginIndex == IndexFrom && currentDialogueData.connectionsList[i].end == idTo)
                        {
                            currentDialogueData.connectionsList.RemoveAt(i);
                        }
                        else
                        {
                            Debug.Log("wrong");
                        }

                        return;
                    }
                }
                toRemove = new List<int>();
            }
        }
        #endregion
        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceId, int line)
        {
            if (path==null||!path.EndsWith(".dialogue.Json", StringComparison.InvariantCultureIgnoreCase))
                return false;
            #region createWindow

            Debug.Log("loaded");
            var a = (TextAsset)(EditorUtility.InstanceIDToObject(instanceId));
            dialogeWindow = new List<windowType>();
            path = AssetDatabase.GetAssetPath(instanceId);
            graphEditorWindow = CreateInstance<NPCDialogueWindo>();
            graphEditorWindow.Show();
            graphEditorWindow.Focus();
            currentDialogueData = null;
            #endregion
            #region loadDoc
            //load
            if (File.Exists(path))
            {
                try
                {
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(path, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {

                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    currentDialogueData = JsonUtility.FromJson<dialogueData>(dataToLoad);
                }
                catch (Exception e)
                {
                    Debug.Log("erro loading");
                }
            }
            #endregion
            #region loadcontent
            Debug.Log("loaded  " + currentDialogueData);
            if (currentDialogueData == null || currentDialogueData.dialagueContents.Count == 0)
            {
                Debug.Log("null case");
                inChoosingConnection=false;
                attachedWindows = new List<connection>();
                currentDialogueData = new dialogueData();
                currentDialogueData.addCharaChange();
                dialogeWindow = new List<windowType>();
                dialogeWindow.Add(new windowType(new Rect(10, 10, 150, 90), windowType.Type.charaChange));
            }
            else
            {
                Debug.Log("not null case");
                //draw window
                foreach (dialogueData.DialagueContent content in currentDialogueData.dialagueContents)
                {
                    if (content is dialogueData.singleDialogue)
                    {
                        dialogeWindow.Add(new windowType(content.positionInEdictor, windowType.Type.dialogue));
                    }
                    else if (content is dialogueData.DialogueChoice)
                    {
                        dialogeWindow.Add(new windowType(content.positionInEdictor, windowType.Type.choice));
                    }else if (content is dialogueData.characterChange)
                    {
                        dialogeWindow.Add(new windowType(content.positionInEdictor, windowType.Type.charaChange));
                    }
                    else
                    {
                        Debug.Log("????????????????");
                    }
                }
                //draw connetion
                attachedWindows = new List<connection>();
                for (int i = 0; i < currentDialogueData.connectionsList.Count; i++)
                {
                    Debug.Log("add connection");
                    dialogueData.connection c = currentDialogueData.connectionsList[i];
                    attachedWindows.Add(new connection(c.begin, c.beginIndex, c.end));
                }
                Debug.Log("connection: " + attachedWindows.Count);
            }
            currentEditing = -1;

            //draw connetion


            return true;
            #endregion
        }
        [MenuItem("Assets/Create/NBGame/createDialogue")]
        public static void generatefile()
        {
            UnityEngine.Object target = Selection.activeObject;
            string path = AssetDatabase.GetAssetPath(target);
            path = path.Replace("Assets", "");
            if (path.Length > 0 && path.ElementAt(0) == '/')
            {
                path = path.Substring(1);
            }
            path = Application.dataPath + "/" + path + "/";
            string fileName = "Name";
            int i = 1;
            while (File.Exists(path + fileName + ".dialogue.Json"))
            {
                if (fileName.EndsWith("1"))
                {
                    fileName = fileName.Substring(0, fileName.Length - 1);
                }
                fileName = fileName + i;

                i++;
                ;
            }
            Debug.Log(path + fileName + ".dialogue.Json");
            path = path + fileName + ".dialogue.Json";
            // Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("");
                }
            }

            Debug.Log("finished saving");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

    }
}

