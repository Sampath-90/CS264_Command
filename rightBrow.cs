public class rightBrow:Feature{
  public static int X{get; set;}
  public static int Y{get; set;}
  public static int Width{get; set;}
  public static int Height{get; set;}
  string stroke_width;
  string stroke;
  string transform;
  string transform_origin;
    public rightBrow(){
        X = 143; Y = 70; Width = 6; Height = 25;
        stroke = "black";
        stroke_width = "1";
        transform = "rotate(110)";
        transform_origin = "156px 82px";
    }
    public override string printFeatureA(){
       return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string printFeatureB(){//straight eyebrow
    X=156;Y=62;transform="rotate(90)";transform_origin = "156px 80px";
       return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string printFeatureC(){ //angry
    X=156;Y=62;transform="rotate(230)";transform_origin = "156px 80px";
       return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string rotateFeature(int c){
    transform_origin="50% 50%";transform="rotate("+c+")";
    return "".PadLeft(3,' ') + "<rect width=\"" + Width + "\" height=\"" + Height + "\" x=\"" + X + "\" y=\"" + Y + 
       "\"" + " stroke=\""+stroke+"\" stroke-width=\""+stroke_width+"\" " + "transform=\""+transform +"\" transform-origin=\""+transform_origin +"\" />";
   }
   public override string ToString()
   {
      return "Right-Brow";
   }
}