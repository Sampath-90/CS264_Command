public class leftBrow:Feature{
  public static int X{get; set;}
  public static int Y{get; set;}
  public static int Width{get; set;}
  public static int Height{get; set;}
  string stroke_width;
  string stroke;
  public static string ?transform{get;set;}
  string transform_origin;
    public leftBrow(){
        X = 87; Y = 70; Width = 6; Height = 25;
        stroke = "black";
        stroke_width = "1";
        transform = "rotate(70)";
        transform_origin = "100px 82px";
    }
    public override string printFeatureA(){
       return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string printFeatureB(){ //straight eyebrow
    X=95;Y=60;transform="rotate(90)";transform_origin = "95px 82px";
    return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string printFeatureC(){ //angry
    X=85;Y=56;transform="rotate(-240)";transform_origin = "95px 82px";
       return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string rotateFeature(int c){
    transform_origin="50% 50%";transform="rotate("+c+")";
    return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }

   public override string ToString()
   {
      return "Left-Brow";
   }
}