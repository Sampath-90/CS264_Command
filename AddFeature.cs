public class AddFeature : Command{
    Feature feature;
    Canvas canvas;

    public AddFeature(Feature f, Canvas c){
        feature = f;
        canvas = c;
    }

    // Adds a feature to the canvas as "Do" action
    public override void Do(){
        canvas.Add(feature);
    }
    // Removes a feature from the canvas as "Undo" action
    public override void Undo(){
        feature = canvas.Remove();
    }

}