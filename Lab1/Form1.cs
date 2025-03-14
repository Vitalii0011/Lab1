using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txt1.Text);

                // Перевірка, щоб не було ділення на нуль
                double denominator = Math.Pow(x, 3) - 15 * x;
                if (denominator == 0)
                {
                    txtResult.Text = "Помилка: ділення на нуль!";
                    return;
                }

                // Обчислення виразу
                double result = Math.Abs(Math.Pow(x, 2) - Math.Pow(x, 3)) - (7 * x / denominator);

                // Вивід результату
                txtResult.Text = result.ToString("F4");
            }
            catch
            {
                txtResult.Text = "Помилка вводу!";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                double L = Convert.ToDouble(txtLength.Text);

                if (L <= 0)
                {
                    txtArea.Text = "Помилка: довжина повинна бути більше 0!";
                    return;
                }

                // Обчислення площі круга
                double area = (L * L) / (4 * Math.PI);

                // Вивід результату
                txtArea.Text = area.ToString("F4");
            }
            catch
            {
                txtArea.Text = "Помилка вводу!";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                int N = Convert.ToInt32(txtN.Text);

                if (N <= 0)
                {
                    txtResult1.Text = "Помилка: N повинно бути натуральним числом!";
                    return;
                }

                // Обчислення квадратного кореня
                int sqrtN = (int)Math.Sqrt(N);

                // Перевірка, чи є число точним квадратом
                bool isPerfectSquare = (sqrtN * sqrtN == N);

                // Вивід результату
                txtResult1.Text = isPerfectSquare.ToString();
            }
            catch
            {
                txtResult1.Text = "Помилка вводу!";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо a і b
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);

                // Якщо a і b одночасно нульові - нескінченно багато коренів
                if (a == 0 && b == 0)
                {
                    txtResult2.Text = "Безліч розв’язків";
                    return;
                }

                // Якщо a = 0, рівняння стає bx = 0, отже x = 0 (якщо b ≠ 0, то розв’язків немає)
                if (a == 0)
                {
                    txtResult2.Text = (b == 0) ? "Безліч розв’язків" : "Розв’язків немає";
                    return;
                }

                // Корінь x = 0 завжди існує
                string result = "x1 = 0";

                // Додаємо корені з квадратного рівняння
                double D = -b / a;

                if (D > 0)
                {
                    double x2 = Math.Sqrt(D);
                    double x3 = -Math.Sqrt(D);
                    result += $"; x2 = {x2:F3}; x3 = {x3:F3}";
                }
                else if (D == 0)
                {
                    result += $"; x2 = 0";
                }
                else
                {
                    result += "; Дійсних коренів немає";
                }

                // Вивід результату
                txtResult2.Text = result;
            }
            catch
            {
                txtResult2.Text = "Помилка вводу!";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lbl5.Text = ""; // Очищуємо перед новим виведенням

            if (!int.TryParse(txt5.Text, out int n) || n < 1)
            {
                MessageBox.Show("Будь ласка, введіть натуральне число більше 0!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = "";
            for (int i = 1; i <= n; i++)
            {
                if (IsDivisibleByDigits(i))
                {
                    result += i + " ";
                }
            }

            lbl5.Text = result == "" ? "Немає чисел, що відповідають умові." : result;
        }

        private bool IsDivisibleByDigits(int number)
        {
            int temp = number;
            while (temp > 0)
            {
                int digit = temp % 10;
                if (digit == 0 || number % digit != 0)
                {
                    return false;
                }
                temp /= 10;
            }
            return true;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            // Зчитування кількості покупців
            if (!int.TryParse(txtCount.Text.Trim(), out int n) || n <= 0)
            {
                txtResult3.Text = "Введіть коректну кількість покупців!";
                return;
            }

            // Зчитування часу обслуговування
            string[] parts = txtTime.Text.Trim().Split(' ');

            // Перевірка кількості введених часів
            if (parts.Length != n)
            {
                txtResult3.Text = "Кількість часів не співпадає з кількістю покупців!";
                return;
            }

            // Масив часу обслуговування
            int[] t = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(parts[i], out t[i]) || t[i] < 0)
                {
                    txtResult3.Text = "Некоректний час обслуговування!";
                    return;
                }
            }

            // Обчислення часу перебування
            int sum = 0;
            string result = "";
            for (int i = 0; i < n; i++)
            {
                sum += t[i];
                result += sum + " ";
            }

            // Виведення результату
            txtResult3.Text = result.Trim();

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            // Зчитування рядка з текстового поля txt7
            string input = txt7.Text.Trim();

            // Перевірка, чи введено хоча б один символ
            if (string.IsNullOrEmpty(input))
            {
                txt8.Text = "Введіть текст!";
                return;
            }

            // Розбиття введеного рядка на окремі слова
            string[] words = input.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Список для слів, що містять букву 'k'
            List<string> wordsWithK = new List<string>();

            // Перевірка кожного слова
            foreach (var word in words)
            {
                if (word.Contains('k') || word.Contains('K'))  // Перевірка на наявність 'k' або 'K'
                {
                    wordsWithK.Add(word);
                }
            }

            // Формуємо результат
            if (wordsWithK.Count > 0)
            {
                txt8.Text = "Слова, що містять 'k': " + string.Join(", ", wordsWithK);
            }
            else
            {
                txt8.Text = "Не знайдено слів, що містять 'k'.";
            }
        }
    }
    }
    

