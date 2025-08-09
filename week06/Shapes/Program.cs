using Shapes;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square square = new Square("Red", 3.0);
        shapes.Add(square);
        
        Rectangle rectangle = new Rectangle("Blue", 3.0, 2.0);
        shapes.Add(rectangle);
        
        Circle circle = new Circle("Yellow", 2.0);
        shapes.Add(circle);
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has a calculated area of {shape.GetArea():F2}");
        }
    }
}