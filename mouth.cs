public class mouth:Feature{
  public static string ?path{get; set;}
  string fill;
  string stroke_width;
  string stroke;
  public static string ?transform;
  public string ?transform_origin;
  
  public mouth(){
    path = "M100,160 Q128,190 156,160";
    fill = "transparent";
    stroke = "black";
    stroke_width = "5";
  }
  public override string printFeatureA(){//smiley face
      return "".PadLeft(3,' ') + "<path d=\"" + path + "\"" + " fill=\""+fill+"\""+ " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" "+ "/>";
  }
  public override string printFeatureB(){
    path = "M100,160 Q128,160 156,160";  //neutral face
      return "".PadLeft(3,' ') + "<path d=\"" + path + "\"" + " fill=\""+fill+"\""+ " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" "+ "/>";
  }
  public override string printFeatureC(){
    path = "M100,160 Q128,130 156,160";  //sad face
      return "".PadLeft(3,' ') + "<path d=\"" + path + "\"" + " fill=\""+fill+"\""+ " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" "+ "/>";
  }
  public override string rotateFeature(int c){
    transform_origin="50% 50%";transform="rotate("+c+")";
      return "".PadLeft(3,' ') + "<path d=\"" + path + "\"" + " fill=\""+fill+"\""+ " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\"  transform=\""+transform+ "\" transform-origin=\""+transform_origin+"\" />";
  }

  public override string ToString()
   {
      return "Mouth";
   }
}