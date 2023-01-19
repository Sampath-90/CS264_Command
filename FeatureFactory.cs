public class FeatureFactory{

  public Feature GetFeature(string Type){
    Feature ?feature = null;

    switch(Type){
      case "left-eye": feature = new leftEye();break;
      case "right-eye": feature = new rightEye();break;
      case "left-brow": feature = new leftBrow();break;
      case "right-brow": feature = new rightBrow();break;
      case "mouth": feature = new mouth();break;
    }

    return feature!;
  }
}