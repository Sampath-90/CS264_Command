public class rightEye:Feature{
  public static int  CX{get; set;}
    public static int  CY{get; set;}
    public static int R{get; set;}
   string fill;
    string stroke_width;
    string stroke;
    public static string ?transform;
  public static string ?transform_origin;
    public rightEye(){
        CX = 156; CY = 104; R = 7;
        stroke_width = "4";
        stroke = "black";
        fill = "";
        transform = "";
        transform_origin = "";
    }
    public override string printFeatureA(){
        return "".PadLeft(3,' ') + "<circle cx=\"" + CX + "\" cy=\"" + CY +  "\" r=\"" + R + 
        "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + " />";
   }
   public override string printFeatureB(){ //red eye
      fill = "red";
   return "".PadLeft(3,' ') + "<circle cx=\"" + CX + "\" cy=\"" + CY +  "\" r=\"" + R + 
        "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + " fill=\""+fill+"\" />";
   }
   public override string printFeatureC(){  //green eye
      fill = "green";
   return "".PadLeft(3,' ') + "<circle cx=\"" + CX + "\" cy=\"" + CY +  "\" r=\"" + R + 
        "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + " fill=\""+fill+"\" />";
   }
   public override string rotateFeature(int c){
    transform_origin="50% 50%";transform="rotate("+c+")";
    return "".PadLeft(3,' ') + "<circle cx=\"" + CX + "\" cy=\"" + CY +  "\" r=\"" + R + 
        "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" transform=\""+transform+"\" transform-origin=\""+transform_origin+"\"" +" />";
   }
   public override string ToString()
   {
      return "Right-Eye";
   }
}