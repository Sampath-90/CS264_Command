public class Canvas{
    public Stack<Feature> canvas = new Stack<Feature>();

    public void Add(Feature f){
        canvas.Push(f); //adds the feature to the canvas
        Console.WriteLine(f + " added to emoticon.");
    }

    public Feature Remove(){
        Feature f = canvas.Pop(); //removes the feature from the canvas
        Console.WriteLine(f + " removed from emoticon.");
        return f;

    }
    public Canvas(){
        Console.WriteLine("\nCreated a new Canvas!"); Console.WriteLine();
    }

}