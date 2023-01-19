public class leftEye:Feature{
  public static int  CX{get;set;}
    public static int  CY{get; set;}
    public static int R{get; set;}
   string fill;
    string stroke_width;
    string stroke;
    public static string ?transform;
  public string ?transform_origin;
    public leftEye(){
        CX = 100; CY = 104; R = 7;
        stroke = "black";
        stroke_width = "4";
        fill = "";
        transform = "";
        transform_origin = "";
    }
    public override string printFeatureA(){ //normal eye
        return "".PadLeft(3,' ') + "<circle cx=\"" + CX + "\" cy=\"" + CY +  "\" r=\"" + R + 
        "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + " />";
   }
   public override string printFeatureB(){  //red eye
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
   public override string ToString(){return "Left-Eye";}
}