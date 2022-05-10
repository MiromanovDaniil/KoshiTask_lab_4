using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace KoshiTask_lab_4
{
    public partial class Form1 : Form
    {
        //Создаю массив координат концов кривых.
        PointPairList end_point = new PointPairList();

        double eps = 0.1;
        double h = 0.002;
        double t0 = 1;
        string zedGraph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            // Получим точку, около которой находимся
            PointPair point = curve[iPt];

            //Результат наведения;
            string result = "";
            // Сформируем строку
            result = string.Format("X: {0:F3}\nY: {1:F3}", point.X, point.Y);

            if (point.X == 0 && point.Y == 1 || point.X == 0 && point.Y == -1 || point.X == 1 && point.Y == 0 || point.X == -3 && point.Y == 2)
            {
                result = string.Format("X: {0:F3}\nY: {1:F3}\nОсобая точка!", point.X, point.Y);
            }

            if (end_point.Contains(new PointPair(point.X, point.Y)))
            {
                result = string.Format("X: {0:F3}\nY: {1:F3}\nКонец кривой!", point.X, point.Y);
            }

            return result;
        }
        public Form1()
        {
            InitializeComponent();
            // Включим показ всплывающих подсказок при наведении курсора на график
            zedGraphControl.IsShowPointValues = true;
            // Будем обрабатывать событие PointValueEvent, чтобы изменить формат представления координат
            zedGraphControl.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);
        }

        double f1(double t, double x, double y) { 
            return ((x + y) * (x + y) - 1);
        }

        double f2(double t, double x, double y) {
            return (-(y * y) - x + 1);
        }

        PointPairList Runge_Kutta_Method_3(double x, double y)
        {
            PointPairList result_curve = new PointPairList();
            double t;

            result_curve.Add(x, y);

            for (t = 0; t <= t0; t += h) {
                //Расчет нужных коэффициентов для формулы. 
                double Q1x = h * f1(t, x, y);
                double Q1y = h * f2(t, x, y);

                double Q2x = h * f1(t + h / 2, x + Q1x / 2, y + Q1y / 2);
                double Q2y = h * f2(t + h / 2, x + Q1x / 2, y + Q1y / 2);

                double Q3x = h * f1(t + h, x - Q1x + 2 * Q2x, y - Q1y + 2 * Q2y);
                double Q3y = h * f2(t + h, x - Q1x + 2 * Q2x, y - Q1y + 2 * Q2y);

                //Расчет новой точки. 
                x += (Q1x + 4 * Q2x + Q3x) / 6;
                y += (Q1y + 4 * Q2y + Q3y) / 6;

                //Добавление полученной точки в список точек кривой. 
                result_curve.Add(x, y);
            }
            return result_curve;
        }

        private void Draw()
        {
            GraphPane pane = zedGraphControl.GraphPane;
            pane.Title.Text = "Метод Рунге-Кутта 3 порядка.";

            //Меняем цвет рамки.
            pane.Fill.Type = FillType.Solid;
            pane.Fill.Color = Color.Silver;


            zedGraphControl.PanButtons = MouseButtons.Left;
            zedGraphControl.PanModifierKeys = Keys.None;

            pane.CurveList.Clear();

            //Создаю массив кривых, которые будут отображаться на графике. 
            List<LineItem> myCurve = new List<LineItem> { };
            //Создаю массив особых точек.
            PointPairList specific_point = new PointPairList();
            //Добавляю особые точки.
            specific_point.Add(0, 1);
            specific_point.Add(0, -1);
            specific_point.Add(1, 0);
            specific_point.Add(-3, 2);

            //Вспомогательная переменная для того чтобы обращаться к кривым. 
            int t = 0;

            for (int i = 0; i < 4; i++) {
                //Отрисовка кривых вокруг i-ой особой точки.
                myCurve.Add(pane.AddCurve("", Runge_Kutta_Method_3(specific_point[i].X + eps, specific_point[i].Y), Color.Blue, SymbolType.Circle));
                myCurve.Add(pane.AddCurve("", Runge_Kutta_Method_3(specific_point[i].X - eps, specific_point[i].Y), Color.Red, SymbolType.Circle));
                myCurve.Add(pane.AddCurve("", Runge_Kutta_Method_3(specific_point[i].X, specific_point[i].Y + eps), Color.Green, SymbolType.Circle));
                myCurve.Add(pane.AddCurve("", Runge_Kutta_Method_3(specific_point[i].X, specific_point[i].Y - eps), Color.Yellow, SymbolType.Circle));

                myCurve[i + t].Line.IsVisible = false;            //Видимость линий между точками.
                myCurve[i + t].Symbol.Fill.Color = Color.Blue;    //Цвет заполнения кружков.
                myCurve[i + t].Symbol.Fill.Type = FillType.Solid; //Тип заполнения - сплошная заливка.
                myCurve[i + t].Symbol.Size = 3;                   //Размер кружков.

                // Добавляю концы кривой в массив концов кривых, для их отображения при наведении.
                end_point.Add(myCurve[i + t][0].X, myCurve[i + t][0].Y);
                end_point.Add(myCurve[i + t][myCurve[i + t].Points.Count - 1].X, myCurve[i + t][myCurve[i + t].Points.Count - 1].Y);

                myCurve[i + t + 1].Line.IsVisible = false;
                myCurve[i + t + 1].Symbol.Fill.Color = Color.Red;
                myCurve[i + t + 1].Symbol.Fill.Type = FillType.Solid;
                myCurve[i + t + 1].Symbol.Size = 3;

                end_point.Add(myCurve[i + t + 1][0].X, myCurve[i + t + 1][0].Y);
                end_point.Add(myCurve[i + t + 1][myCurve[i + t + 1].Points.Count - 1].X, myCurve[i + t + 1][myCurve[i + t + 1].Points.Count - 1].Y);

                myCurve[i + t + 2].Line.IsVisible = false;
                myCurve[i + t + 2].Symbol.Fill.Color = Color.Green;
                myCurve[i + t + 2].Symbol.Fill.Type = FillType.Solid;
                myCurve[i + t + 2].Symbol.Size = 3;

                end_point.Add(myCurve[i + t + 2][0].X, myCurve[i + t + 2][0].Y);
                end_point.Add(myCurve[i + t + 2][myCurve[i + t + 2].Points.Count - 1].X, myCurve[i + t + 2][myCurve[i + t + 2].Points.Count - 1].Y);

                myCurve[i + t + 3].Line.IsVisible = false;
                myCurve[i + t + 3].Symbol.Fill.Color = Color.Yellow;
                myCurve[i + t + 3].Symbol.Fill.Type = FillType.Solid;
                myCurve[i + t + 3].Symbol.Size = 3;

                end_point.Add(myCurve[i + t + 3][0].X, myCurve[i + t + 3][0].Y);
                end_point.Add(myCurve[i + t + 3][myCurve[i + t + 3].Points.Count - 1].X, myCurve[i + t + 3][myCurve[i + t + 3].Points.Count - 1].Y);

                t += 3;
            }

            //Отрисовка особых точек. 
            LineItem sp_points =  pane.AddCurve("",specific_point, Color.Chocolate, SymbolType.Circle);
            sp_points.Line.IsVisible = false;
            sp_points.Symbol.Fill.Color = Color.Chocolate;
            sp_points.Symbol.Fill.Type = FillType.Solid;
            sp_points.Symbol.Size = 6;

            //Добавление линий сетки на график и окраска их в серый.
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.Color = Color.Black;
            pane.YAxis.MajorGrid.Color = Color.Black;

            // Ось X будет пересекаться с осью Y на уровне Y = 0
            pane.XAxis.Cross = 0.0;

            // Ось Y будет пересекаться с осью X на уровне X = 0
            pane.YAxis.Cross = 0.0;

            // Отключим отображение первых и последних меток по осям
            pane.XAxis.Scale.IsSkipFirstLabel = true;
            pane.XAxis.Scale.IsSkipLastLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.XAxis.Scale.IsSkipCrossLabel = true;

            // Спрячем заголовки осей
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;

            // Обновляем график
            zedGraphControl.Invalidate();
        }

        private void Run_Runge_Kutta_3_Click(object sender, EventArgs e)
        {
            if (F_eps.Text != "")
            {
                eps = Convert.ToDouble(F_eps.Text);
            }
            if (F_h.Text != "")
            {
                h = Convert.ToDouble(F_h.Text);
            }
            if (F_t0.Text != "")
            {
                t0 = Convert.ToDouble(F_t0.Text);
            }
            Draw();
        }
    }
}
