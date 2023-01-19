public class RemoveFeature : Command{
    Feature ?feature;
    Canvas canvas;

    public RemoveFeature(Canvas c){
        canvas = c;
    }

    // Removes a feature from the canvas as "Do" action
    public override void Do(){

      feature = canvas.Remove();
    }    

    // Restores a feature to the canvas as an "Undo" action
    public override void Undo()
    {
      canvas.Add(feature!);
    }

}