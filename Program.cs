/*
Name: Saisampath Adusumilli
Student Number: 20251888
Command Design
*/
using System.Text;
namespace Program{
  public class Program{
    static void Main(string [] args){
      FeatureFactory featureFactory = new FeatureFactory();
      var final_output1 = new Dictionary<string,string>();
      var temp_dict = new Dictionary<string,string>();

      string ? output_file = ""; 
      StringBuilder svg_text = new StringBuilder();
      string svg_header = "<svg height=\"250\" width=\"250\"  xmlns=\"http://www.w3.org/2000/svg\" >" +
        Environment.NewLine + "".PadLeft(3,' ') +"<circle cx=\"128\" cy=\"128\" r=\"120\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\" />";
      svg_text.Append(svg_header);

      // Create a Canvas which will hold the list of features drawn on canvas
      Canvas canvas = new Canvas();
      Console.WriteLine(canvas);

      // Create user and allow user actions
      User user = new User();

      //command list
      Console.WriteLine("Commands:" + Environment.NewLine +
                                                "add\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                                "remove\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                                "move\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {up| down| left| right} value" + Environment.NewLine +
                                                "rotate\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {clockwise| anticlockwise} degrees" + Environment.NewLine +
                                                "style\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {A|B|C}" + Environment.NewLine +
                                                "save\t\t {<file>}" + Environment.NewLine +
                                                "draw" + Environment.NewLine+
                                                "undo" + Environment.NewLine+
                                                "redo" + Environment.NewLine+
                                                "help" + Environment.NewLine+
                                                "quit");
                                                
            Console.WriteLine("Canvas created - use commands to add features to the canvas");


            string input = "";
            do{
              input = Console.ReadLine()!.ToLower();
              switch (input.Split(" ")[0]){
                case "add": Add_feature(input.Split(" ")[1]);break;
                case "move": Move_feature(input.Split(" ")[1],input.Split(" ")[2],Int32.Parse(input.Split(" ")[3]));break;
                case "style": Style_feature(input.Split(" ")[1],input.Split(" ")[2].ToUpper());break;
                case "remove": Remove_feature(input.Split(" ")[1]);break;
                case "rotate": Rotate_feature(input.Split(" ")[1],input.Split(" ")[2],Int32.Parse(input.Split(" ")[3]));break;
                case "undo":
                if(final_output1.Count == 0){Console.WriteLine("Cannot Undo!");}
                else{user.Undo();temp_dict.Add(final_output1.Keys.Last(),final_output1.Values.Last());final_output1.Remove(final_output1.Keys.Last());}
                break;
                case "redo": 
                if(temp_dict.Count == 0){Console.WriteLine("Cannot Redo!");}
                else{user.Redo();final_output1.Add(temp_dict.Keys.Last(),temp_dict.Values.Last());temp_dict.Remove(final_output1.Keys.Last());}
                break;
                case "help":{
                  Console.WriteLine("Commands:" + Environment.NewLine +
                                    "add\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                    "remove\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                    "move\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {up| down| left| right} value" + Environment.NewLine +
                                    "rotate\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {clockwise| anticlockwise} degrees" + Environment.NewLine +
                                    "style\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {A|B|C}" + Environment.NewLine +
                                    "save\t\t {<file>}" + Environment.NewLine +
                                    "draw" + Environment.NewLine+
                                    "undo" + Environment.NewLine+
                                    "redo" + Environment.NewLine+
                                    "help" + Environment.NewLine+
                                    "quit");break;                  
                }
                case "save":{output_file = input.Split(" ")[1];
                Console.WriteLine("Emoticon saved to file: " + output_file);break;} 
                case "draw": {Draw_feature();break;}
                case "quit":{if(output_file!.Length == 0){Console.WriteLine("Enter the name of the file to save:");output_file = Console.ReadLine();}
                Console.WriteLine("Exiting Application");break;}
                default: Console.WriteLine("Please enter a valid command");break;
              }
            }while(!(input.Equals("quit")));



            //add feature
            void Add_feature(string a){
              switch(a){
                case "left-eye":{
                  Feature feature = featureFactory.GetFeature("left-eye");
                  if(final_output1.ContainsKey("left-eye")){
                    Console.WriteLine("Already added, can't add again!");
                    break;
                  }
                  user.Action(new AddFeature(feature,canvas)); //adds the feature
                  final_output1.Add("left-eye",feature.printFeatureA());
                  break;}
                  case "right-eye":{
                    Feature feature = featureFactory.GetFeature("right-eye");
                    if(final_output1.ContainsKey("right-eye")){
                    Console.WriteLine("Already added, can't add again!");
                    break;
                    }  
                    user.Action(new AddFeature(feature,canvas)); //adds the feature
                    final_output1.Add("right-eye",feature.printFeatureA());
                    break;}
                    case "left-brow":{
                    Feature feature = featureFactory.GetFeature("left-brow");
                    if(final_output1.ContainsKey("left-brow")){
                    Console.WriteLine("Already added, can't add again!");
                    break;
                    }
                    user.Action(new AddFeature(feature,canvas)); //adds the feature
                    final_output1.Add("left-brow",feature.printFeatureA());
                    break;}
                    case "right-brow":{
                    Feature feature = featureFactory.GetFeature("right-brow");
                    if(final_output1.ContainsKey("right-brow")){
                    Console.WriteLine("Already added, can't add again!");
                    break;
                    }
                    user.Action(new AddFeature(feature,canvas)); //adds the feature
                    final_output1.Add("right-brow",feature.printFeatureA());
                    break;}
                    case "mouth":{
                    Feature feature = featureFactory.GetFeature("mouth");
                    if(final_output1.ContainsKey("mouth")){
                    Console.WriteLine("Already added, can't add again!");
                    break;
                    }
                    user.Action(new AddFeature(feature,canvas)); //adds the feature
                    final_output1.Add("mouth",feature.printFeatureA());
                    break;}
                default: Console.WriteLine("Please enter a valid feature");break;
              }
            }

            //remove feature
            void Remove_feature(string a){
              if(final_output1.ContainsKey(a)){ //checking if the feature is created or not
                switch(a){
                case "left-eye":{
                  if(final_output1.ContainsKey("left-eye")){
                    temp_dict.Add("left-eye",final_output1["left-eye"]);
                    user.Action(new RemoveFeature(canvas));
                    final_output1.Remove("left-eye");
                  }
                  else
                    Console.WriteLine("Cannot be removed as feature not created yet!");  
                  break;
                }
                case "right-eye":{
                  if(final_output1.ContainsKey("right-eye")){
                    temp_dict.Add("right-eye",final_output1["right-eye"]);
                    user.Action(new RemoveFeature(canvas));
                    final_output1.Remove("right-eye");
                  }
                  else
                    Console.WriteLine("Cannot be removed as feature not created yet!");  
                  break;
                }
                case "left-brow":{
                  if(final_output1.ContainsKey("left-brow")){
                    temp_dict.Add(key: "left-brow",final_output1["left-brow"]);
                    user.Action(new RemoveFeature(canvas));
                    final_output1.Remove("left-brow");
                  }
                  else
                    Console.WriteLine("Cannot be removed as feature not created yet!");  
                  break;
                }
                case "right-brow":{
                  if(final_output1.ContainsKey("right-brow")){
                    temp_dict.Add("right-brow",final_output1["right-brow"]);
                    user.Action(new RemoveFeature(canvas));
                    final_output1.Remove("right-brow");
                  }
                  else
                    Console.WriteLine("Cannot be removed as feature not created yet!");  
                  break;
                }
                case "mouth":{
                  if(final_output1.ContainsKey("mouth")){
                    temp_dict.Add("mouth",final_output1["mouth"]);
                    user.Action(new RemoveFeature(canvas));
                    final_output1.Remove("mouth");
                  }
                  else
                    Console.WriteLine("Cannot be removed as feature not created yet!");  
                  break;
                }
                default: Console.WriteLine("Please enter a valid feature");break;
              }
            }
             else
                Console.WriteLine("Cannot remove as the feature is not added");
            }

            //move feature
            void Move_feature(string a,string b,int c){
              if(final_output1.ContainsKey(a)){
                switch(a){
                case "left-eye":{temp_dict.Add("left-eye",final_output1["left-eye"]);
                Feature feature = featureFactory.GetFeature("left-eye");
                  switch(b){
                    case "up":{final_output1.Remove("left-eye");leftEye.CY -= c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved up " + c+"px");break;}
                    case "down":{final_output1.Remove("left-eye");leftEye.CY += c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved down " + c+"px");break;}
                    case "left":{final_output1.Remove("left-eye");leftEye.CX -= c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved left " + c+"px");break;}
                    case "right":{final_output1.Remove("left-eye");leftEye.CY += c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved right " + c+"px");break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                case "right-eye":{temp_dict.Add("right-eye",final_output1["right-eye"]);
                Feature feature = featureFactory.GetFeature("right-eye");
                  switch(b){
                    case "up":{final_output1.Remove("right-eye");rightEye.CY -= c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved up " + c+"px");break;}
                    case "down":{final_output1.Remove("right-eye");rightEye.CY += c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved down " + c+"px");break;}
                    case "left":{final_output1.Remove("right-eye");rightEye.CX -= c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved left " + c+"px");break;}
                    case "right":{final_output1.Remove("right-eye");rightEye.CY += c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved right " + c+"px");break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                case "right-brow":{temp_dict.Add("right-brow",final_output1["right-brow"]);
                Feature feature = featureFactory.GetFeature("right-brow");
                  switch(b){
                    case "up":{final_output1.Remove("right-brow");rightBrow.X -= c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved up " + c+"px");break;}
                    case "down":{final_output1.Remove("right-brow");rightBrow.X += c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved down " + c+"px");break;}
                    case "left":{final_output1.Remove("right-brow");rightBrow.Y += c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved left " + c+"px");break;}
                    case "right":{final_output1.Remove("right-brow");rightBrow.Y -= c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved right " + c+"px");break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                case "left-brow":{temp_dict.Add("left-brow",final_output1["left-brow"]);
                Feature feature = featureFactory.GetFeature("left-brow");
                  switch(b){
                    case "up":{final_output1.Remove("left-brow");leftBrow.X -= c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved up " + c+"px");break;}
                    case "down":{final_output1.Remove("left-brow");leftBrow.X += c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved down " + c+"px");break;}
                    case "left":{final_output1.Remove("left-brow");leftBrow.Y += c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved left " + c+"px");break;}
                    case "right":{final_output1.Remove("left-brow");leftBrow.Y -= c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved right " + c+"px");break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                default: Console.WriteLine("Please enter a valid feature");break;
              }
              }
              else
                Console.WriteLine("Cannot move as feature is not added");
            }

      //styling
      void Style_feature(string a,string b){
        if(final_output1.ContainsKey(a)){ //checking if the feature is created or not
          switch(a){
          case "left-eye":{
            Feature feature = featureFactory.GetFeature("left-eye");
            temp_dict.Add("left-eye",final_output1["left-eye"]);
            switch(b){
              case "A":{final_output1.Remove("left-eye");
                final_output1.Add("left-eye",feature.printFeatureA());
                Console.WriteLine("Left-Eye to style A");break;}
              case "B":{final_output1.Remove("left-eye");
                final_output1.Add("left-eye",feature.printFeatureB());
                Console.WriteLine("Left-Eye to style B");break;}
              case "C":{final_output1.Remove("left-eye");
                final_output1.Add("left-eye",feature.printFeatureC());
                Console.WriteLine("Left-Eye to style C");break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          case "right-eye":{
            Feature feature = featureFactory.GetFeature("right-eye");
            temp_dict.Add(key: "right-eye",final_output1["right-eye"]);
            switch(b){
              case "A":{final_output1.Remove("right-eye");
                final_output1.Add("right-eye",feature.printFeatureA());
                Console.WriteLine("Right-Eye to style A");break;}
              case "B":{final_output1.Remove(key: "right-eye");
                final_output1.Add("right-eye",feature.printFeatureB());
                Console.WriteLine(value: "Right-Eye to style B");break;}
              case "C":{final_output1.Remove(key: "right-eye");
                final_output1.Add("right-eye",feature.printFeatureC());
                Console.WriteLine("Right-Eye to style C");break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          case "left-brow":{
            Feature feature = featureFactory.GetFeature("left-brow");
            temp_dict.Add(key: "left-brow",final_output1["left-brow"]);
            switch(b){
              case "A":{final_output1.Remove("left-brow");
                final_output1.Add("left-brow",feature.printFeatureA());
                Console.WriteLine("Left-Brow to style A");break;}
              case "B":{final_output1.Remove(key: "left-brow");
                final_output1.Add("left-brow",feature.printFeatureB());
                Console.WriteLine("Left-Brow to style B");break;}
              case "C":{final_output1.Remove("left-brow");
                final_output1.Add("left-brow",feature.printFeatureC());
                Console.WriteLine("Left-Brow to style C");break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }break;
          }
          case "right-brow":{
            Feature feature = featureFactory.GetFeature("right-brow");
           temp_dict.Add(key: "right-brow",final_output1["right-brow"]);
            switch(b){
              case "A":{final_output1.Remove("right-brow");
                final_output1.Add("right-brow",feature.printFeatureA());
                Console.WriteLine("Right-Brow to style A");break;}
              case "B":{final_output1.Remove(key: "right-brow");
                final_output1.Add("right-brow",feature.printFeatureB());
                Console.WriteLine("Right-Brow to style B");break;}
              case "C":{final_output1.Remove("right-brow");
                final_output1.Add("right-brow",feature.printFeatureC());
                Console.WriteLine("Right-Brow to style C");break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }break;
          }
          case "mouth":{
            Feature feature = featureFactory.GetFeature("mouth");
            temp_dict.Add(key: "mouth",final_output1["mouth"]);
            switch(b){
              case "A":{final_output1.Remove("mouth");
                final_output1.Add("mouth",feature.printFeatureA());
                Console.WriteLine("Mouth to style A");break;}
              case "B":{final_output1.Remove(key: "mouth");
                final_output1.Add("mouth",feature.printFeatureB());
                Console.WriteLine("Mouth to style B");break;}
              case "C":{final_output1.Remove("mouth");
                final_output1.Add("mouth",feature.printFeatureC());
                Console.WriteLine("Mouth to style C");break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }break;
          }
          default: Console.WriteLine("Please enter a valid feature");break;
        }
       }
       else
           Console.WriteLine("Cannot add Styles as feature is not added");       
      } 

      //rotating
      void Rotate_feature(string a, string b, int c){
        if(final_output1.ContainsKey(a)){
          switch(a){
            case "left-eye":{Feature feature = featureFactory.GetFeature("left-eye");
              temp_dict.Add("left-eye",final_output1["left-eye"]);
              final_output1.Remove("left-eye");
              switch(b){
                case "clockwise":{
                  final_output1.Add("left-eye",feature.rotateFeature(c));
                  Console.WriteLine("Left-Eye rotated "+ c + "degrees clockwise");break;
                }
                case "anticlockwise":{
                  final_output1.Add("left-eye",feature.rotateFeature(-c));
                  Console.WriteLine("Left-Eye rotated "+ c + "degrees anticlockwise");break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "right-eye":{Feature feature = featureFactory.GetFeature("right-eye");
              temp_dict.Add("right-eye",final_output1["right-eye"]);
              final_output1.Remove("right-eye");
              switch(b){
                case "clockwise":{
                  final_output1.Add("right-eye",feature.rotateFeature(c));
                  Console.WriteLine("Right-Eye rotated "+ c + "degrees clockwise");break;
                }
                case "anticlockwise":{
                  final_output1.Add("right-eye",feature.rotateFeature(-c));
                  Console.WriteLine("Right-Eye rotated "+ c + "degrees clockwise");break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "left-brow":{Feature feature = featureFactory.GetFeature("left-brow");
              temp_dict.Add("left-brow",final_output1["left-brow"]);
              final_output1.Remove("left-brow");
              switch(b){
                case "clockwise":{
                  final_output1.Add("left-brow",feature.rotateFeature(c));
                  Console.WriteLine("Left-Brow rotated "+ c + "degrees clockwise");break;
                }
                case "anticlockwise":{
                  final_output1.Add("left-brow",feature.rotateFeature(-c));
                  Console.WriteLine("Left-Brow rotated "+ c + "degrees anticlockwise");break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "right-brow":{Feature feature = featureFactory.GetFeature("right-brow");
              temp_dict.Add("right-brow",final_output1["right-brow"]);
              final_output1.Remove("right-brow");
              switch(b){
                case "clockwise":{
                  final_output1.Add("right-brow",feature.rotateFeature(c));
                  Console.WriteLine("Right-brow rotated "+ c + "degrees clockwise");break;
                }
                case "anticlockwise":{
                  final_output1.Add("right-brow",feature.rotateFeature(-c));
                  Console.WriteLine("Right-brow rotated "+ c + "degrees anticlockwise");break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "mouth":{Feature feature = featureFactory.GetFeature("mouth");
              temp_dict.Add("mouth",final_output1["mouth"]);
              final_output1.Remove("mouth");
              switch(b){
                case "clockwise":{
                  final_output1.Add("mouth",feature.rotateFeature(c));
                  Console.WriteLine("mouth rotated "+ c + "degrees clockwise");break;
                }
                case "anticlockwise":{
                  final_output1.Add("mouth",feature.rotateFeature(-c));
                  Console.WriteLine("mouth rotated "+ c + "degrees anticlockwise");break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            default: Console.WriteLine("Please enter a valid feature");break;
          }
        }
        else
           Console.WriteLine("Cannot rotate as feature is not added");
      }

      //displays the features added so far
      void Draw_feature(){
        Console.WriteLine(svg_header);
        for(int i= final_output1!.Count-1; i >= 0; i--){
          Console.WriteLine(final_output1.ElementAt(i).Value);//printing the shapes on the terminal
        }
        Console.WriteLine("</svg>");
      }
      
      //printing on the command line after the user quits the application
      Console.WriteLine(svg_header);
      for(int i= final_output1!.Count-1; i >= 0; i--){
          svg_text.Append(final_output1.ElementAt(i).Value);
          //printing the shapes on the terminal
          Console.WriteLine(final_output1.ElementAt(i).Value);
        }
        Console.WriteLine("</svg>");

      svg_text.Append("</svg>");
      System.IO.File.WriteAllText(output_file!, svg_text.ToString());
    }
  }
}
