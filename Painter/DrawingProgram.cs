using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Painter
    {
        static float x, y;
        static Graphics graphics;

        public static void Initialize (Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void Set_position(float x0, float y0)
        {x = x0; y = y0;}

        public static void MakeIt(Pen pen, double length, double angle)
            {
                //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
                var x1 = (float)(x + length * Math.Cos(angle));
                var y1 = (float)(y + length * Math.Sin(angle));
                graphics.DrawLine(pen, x, y, x1, y1);
                x = x1;
                y = y1;
            }

        public static void Change(double length, double angle)
        {
           x = (float)(x + length * Math.Cos(angle)); 
           y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angleOfRotation, Graphics graphics)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Painter.Initialize(graphics);

            var sz = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.Set_position(x0, y0);

            //Рисуем 1-ую сторону
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, 0);
            Painter.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, Math.PI / 2);

            Painter.Change(sz * 0.04f, -Math.PI);
            Painter.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

            //Рисуем 2-ую сторону
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, -Math.PI / 2);
            Painter.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, -Math.PI / 2 + Math.PI);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2);

            Painter.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
            Painter.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            //Рисуем 3-ю сторону
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI);
            Painter.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI + Math.PI);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2);

            Painter.Change(sz * 0.04f, Math.PI - Math.PI);
            Painter.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            //Рисуем 4-ую сторону
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI / 2);
            Painter.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI / 2 + Math.PI);
            Painter.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2);

            Painter.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
            Painter.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}
