using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    public static CommandInvoker Instance { get; private set; }

    private static readonly Stack<ICommand> UndoStack = new Stack<ICommand>();

    private static readonly List<ICommand> CommandHistory = new List<ICommand>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        UndoStack.Push(command);
        CommandHistory.Add(command);
    }

    public static void UndoCommand()
    {
        if (UndoStack.Count > 0)
        {
            var command = UndoStack.Pop();
            command?.Undo();
            //son işlemi geri alırken komut geçmişinden de kaldırıyors
            var commandIndex = CommandHistory.LastIndexOf(command);
            if(commandIndex >= 0)
            {
                CommandHistory.RemoveAt(commandIndex);
            }
        }
    }

    public void StartReplay(Transform targetTransform, Vector3 StartPosition)
    {
        StartCoroutine(ReplayRoutine(targetTransform, StartPosition));
    }

    private IEnumerator ReplayRoutine(Transform targetTransform, Vector3 startPosition)
    {
        targetTransform.position = startPosition;
        yield return new WaitForSeconds(0.5f);
        foreach (ICommand command in CommandHistory)
        {
            command?.Execute();
            yield return new WaitForSeconds(0.3f);
        }

        CommandHistory.Clear();
    }
}
