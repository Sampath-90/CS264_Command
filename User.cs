public class User{
    private Stack<Command> ?undo;
    private Stack<Command> ?redo;

    public int UndoCount { get => undo!.Count; }
    public int RedoCount { get => redo!.Count; }
    public User(){
        Reset();
    }
    public void Reset(){
        undo = new Stack<Command>();
        redo = new Stack<Command>();
    }

    public void Action(Command command){
        if(UndoCount == 0 && RedoCount != 0){
            /*if a user uses undo to remove all the features created so far and then tries to add a 
            new one which isn't the one the user created earlier. Then the redo list should be cleared*/
            redo!.Clear();
            undo!.Push(command);
        }
        else{
            // first update the undo - redo stacks
           undo!.Push(command);  // save the command to the undo command
        }
        
        Type t = command.GetType();
        if (t.Equals(typeof(AddFeature))){
            //Console.WriteLine("Added to emoticon");
            command.Do();
        }
        if (t.Equals(typeof(RemoveFeature))){
            //Console.WriteLine("Removed feature from emoticon");
            command.Do();
        }
    }

    // Undo
    public void Undo(){
        if(UndoCount == 0){
            //if there isn't anything on the undo list and the user tries to press undo
            Console.WriteLine("Cannot Undo!");
            return;
        }
        if (undo!.Count > 0){
            Command c = undo.Pop(); c.Undo(); redo!.Push(c);
        }
    }

    // Redo
    public void Redo(){
        if(RedoCount == 0){
            //if there isn't anything on the redo list and the user tries to press redo
            Console.WriteLine("Cannot Redo!");
            return;
        }
        if (redo!.Count > 0){
            Command c = redo.Pop(); c.Do(); undo!.Push(c);
        }
    }
    //clear
    public void Clear(){
        undo!.Clear();
        redo!.Clear();
    }
}