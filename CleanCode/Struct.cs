using System.Runtime;
using f32 = double;

/* ========================================================================
LISTING 27
======================================================================== */

namespace CleanCode
{
    struct shape_union
    {
        public shape_type Type;
        public f32 Width;
        public f32 Height;
    };

    class Struct_Tests : IDisposable
    {
        static shape_union[]? shapes = new shape_union[Settings.Lim];
        static readonly f32[] CTable = { 1.0f, 1.0f, 0.5f, Math.PI };

        static f32 GetAreaUnion(shape_union Shape)
        {
            f32 Result = CTable[(int)Shape.Type] * Shape.Width * Shape.Height;
            return Result;
        }

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
                ref shape_union shape = ref shapes[i];
                shape.Type = type;

                f32 width = ((f32)type + 30.5d) * 12;

                switch (type)
                {
                    case shape_type.Shape_Square:
                        shape.Width = width;
                        shape.Height = shape.Width;
                        break;
                    case shape_type.Shape_Rectangle:
                        shape.Width = width;
                        shape.Height = width * 2;
                        break;
                    case shape_type.Shape_Triangle:
                        shape.Width = width;
                        shape.Height = width * 4;
                        break;
                    case shape_type.Shape_Circle:
                        shape.Width = width * 8;
                        shape.Height = shape.Width;
                        break;
                }
            }
        }

        public void Run()
        {
            f32 area = 0;
            for (int i = 0; i < Settings.Lim; ++i)
            {
                area += GetAreaUnion(shapes[i]);
            }
        }

    }
}