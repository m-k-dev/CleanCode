using Microsoft.VisualBasic.FileIO;
using f32 = double;

/* ========================================================================
LISTING 22 (shap_base and childs)
======================================================================== */

namespace CleanCode
{
    public abstract class shape_base
    {
        public abstract f32 Area();
        static public shape_base Create(shape_type type)
        {
            f32 width = ((f32)type + 30.5d) * 12;

            shape_base shape;
            switch (type)
            {
                case shape_type.Shape_Square:
                    shape = new square(width);
                    break;
                case shape_type.Shape_Rectangle:
                    shape = new rectangle(width, width * 2);
                    break;
                case shape_type.Shape_Triangle:
                    shape = new triangle(width, width * 4);
                    break;
                case shape_type.Shape_Circle:
                    shape = new circle(width * 8);
                    break;
                default:
                    throw new ArgumentException("Unknown shape type");
            }
            return shape;
        }
    }

    public class square : shape_base
    {
        public square(f32 SideInit) { Side = SideInit; }
        public override f32 Area() { return Side * Side; }

        private readonly
        f32 Side;
    };

    public class rectangle : shape_base
    {
        public rectangle(f32 WidthInit, f32 HeightInit) { Width = WidthInit; Height = HeightInit; }
        public override f32 Area() { return Width * Height; }

        private readonly
        f32 Width, Height;
    };

    public class triangle : shape_base
    {
        public triangle(f32 BaseInit, f32 HeightInit) { Base = BaseInit; Height = HeightInit; }
        public override f32 Area() { return 0.5f * Base * Height; }

        private readonly
        f32 Base, Height;
    };

    public class circle : shape_base
    {
        public circle(f32 RadiusInit) { Radius = RadiusInit; }
        public override f32 Area() { return Math.PI * Radius * Radius; }

        private readonly
        f32 Radius;
    };

    public enum shape_type : int
    {
        Shape_Square, Shape_Rectangle, Shape_Triangle, Shape_Circle, Shape_Count
    }

    public class VTBL_Tests : IDisposable
    {
        shape_base[]? shapes = new shape_base[Settings.Lim];

        public void Dispose()
        {
            shapes = null;
        }

        public void CreateaShapes()
        {
            Random rand = new();
            for (int i = 0; i < Settings.Lim; ++i)
            {
                shape_type type = (shape_type)rand.Next((int)shape_type.Shape_Count);
                shapes[i] = shape_base.Create(type);
            }
        }

        public void Run()
        {
            f32 area = 0;
            for (int i = 0; i < Settings.Lim; ++i)
            {
                area += shapes[i].Area();
            }
        }
    }
}
