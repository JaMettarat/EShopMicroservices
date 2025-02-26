namespace ConsoleApp2
{
    public abstract class Shape
    {
        public abstract double GetArea();

        public void Show()
        {
            Console.WriteLine("Shape.Show");
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return 0.5 * Width * Height;
        }
    }

}
