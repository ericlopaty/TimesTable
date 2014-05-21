using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimesTable
{
    public partial class FormMain : Form
    {
        private DateTime startTime;
        private List<Label> table;
        Random r = new Random(DateTime.Now.Millisecond);
        int op1, op2, answer;
        int counter;
        int correct;
        double grade;
        Label currentQuestionLabel;
        Question currentQuestion;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            counter++;
            int a = int.Parse(tbAnswer.Text);
            currentQuestionLabel.Text = string.Format("{0}", a);
            if (a == answer)
            {
                correct++;
                currentQuestionLabel.BackColor = Color.Green;
            }
            else
            {
                currentQuestionLabel.BackColor = Color.Red;
            }
            grade = ((double)correct / counter) * 100;
            lblCorrect.Text = string.Format("Correct: {0}", correct);
            lblGrade.Text = string.Format("Grade: {0:0}%", grade);
            if (table.Count > 0)
                ShowQuestion();
            else
            {
                timer.Enabled = false;
                lblRemaining.Text = "Remaining: 0";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now.Subtract(startTime);
            int seconds = (int)elapsed.TotalSeconds;
            int minutes = seconds / 60;
            seconds -= (minutes * 60);
            lblTime.Text = string.Format("Time: {0:0}:{1,2:00}", minutes, seconds);
        }

        private void ShowQuestion()
        {
            lblRemaining.Text = string.Format("Remaining: {0}", table.Count);
            int i = r.Next(table.Count);
            currentQuestionLabel = table[i];
            currentQuestion = (Question)currentQuestionLabel.Tag;
            table.RemoveAt(i);
            op1 = currentQuestion.Op1;
            op2 = currentQuestion.Op2;
            answer = op1 * op2;
            lblQuestion.Text = string.Format("{0} x {1} =", currentQuestion.Op1, currentQuestion.Op2);
            tbAnswer.Text = "";
            tbAnswer.Focus();
        }

        private void ResetQuestions()
        {
            tbAnswer.Text = "";
            timer.Enabled = false;
            table = new List<Label>();
            table.AddRange(new Label[] { 
                lbl1x1, lbl1x2, lbl1x3, lbl1x4, lbl1x5, lbl1x6, lbl1x7, lbl1x8, lbl1x9, lbl1x10, lbl1x11, lbl1x12,
                lbl2x1, lbl2x2, lbl2x3, lbl2x4, lbl2x5, lbl2x6, lbl2x7, lbl2x8, lbl2x9, lbl2x10, lbl2x11, lbl2x12,
                lbl3x1, lbl3x2, lbl3x3, lbl3x4, lbl3x5, lbl3x6, lbl3x7, lbl3x8, lbl3x9, lbl3x10, lbl3x11, lbl3x12,
                lbl4x1, lbl4x2, lbl4x3, lbl4x4, lbl4x5, lbl4x6, lbl4x7, lbl4x8, lbl4x9, lbl4x10, lbl4x11, lbl4x12,
                lbl5x1, lbl5x2, lbl5x3, lbl5x4, lbl5x5, lbl5x6, lbl5x7, lbl5x8, lbl5x9, lbl5x10, lbl5x11, lbl5x12,
                lbl6x1, lbl6x2, lbl6x3, lbl6x4, lbl6x5, lbl6x6, lbl6x7, lbl6x8, lbl6x9, lbl6x10, lbl6x11, lbl6x12,
                lbl7x1, lbl7x2, lbl7x3, lbl7x4, lbl7x5, lbl7x6, lbl7x7, lbl7x8, lbl7x9, lbl7x10, lbl7x11, lbl7x12,
                lbl8x1, lbl8x2, lbl8x3, lbl8x4, lbl8x5, lbl8x6, lbl8x7, lbl8x8, lbl8x9, lbl8x10, lbl8x11, lbl8x12,
                lbl9x1, lbl9x2, lbl9x3, lbl9x4, lbl9x5, lbl9x6, lbl9x7, lbl9x8, lbl9x9, lbl9x10, lbl9x11, lbl9x12,
                lbl10x1, lbl10x2, lbl10x3, lbl10x4, lbl10x5, lbl10x6, lbl10x7, lbl10x8, lbl10x9, lbl10x10, lbl10x11, lbl10x12,
                lbl11x1, lbl11x2, lbl11x3, lbl11x4, lbl11x5, lbl11x6, lbl11x7, lbl11x8, lbl11x9, lbl11x10, lbl11x11, lbl11x12,
                lbl12x1, lbl12x2, lbl12x3, lbl12x4, lbl12x5, lbl12x6, lbl12x7, lbl12x8, lbl12x9, lbl12x10, lbl12x11, lbl12x12});
            foreach (Label l in table)
            {
                l.Text = "";
                l.BackColor = lblQuestion.BackColor;
            }
            counter = 0;
            correct = 0;
            grade = 0;
            lblQuestion.Text = "";
            lblCorrect.Text = "Correct:";
            lblGrade.Text = "Grade:";
            lblTime.Text = "Time:";
            lblRemaining.Text = "Remaining:";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetQuestions();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            timer.Enabled = true;
            ShowQuestion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl1x1.Tag = new Question(1, 1); lbl1x2.Tag = new Question(1, 2); lbl1x3.Tag = new Question(1, 3);
            lbl1x4.Tag = new Question(1, 4); lbl1x5.Tag = new Question(1, 5); lbl1x6.Tag = new Question(1, 6);
            lbl1x7.Tag = new Question(1, 7); lbl1x8.Tag = new Question(1, 8); lbl1x9.Tag = new Question(1, 9);
            lbl1x10.Tag = new Question(1, 10); lbl1x11.Tag = new Question(1, 11); lbl1x12.Tag = new Question(1, 12);
            lbl2x1.Tag = new Question(2, 1); lbl2x2.Tag = new Question(2, 2); lbl2x3.Tag = new Question(2, 3);
            lbl2x4.Tag = new Question(2, 4); lbl2x5.Tag = new Question(2, 5); lbl2x6.Tag = new Question(2, 6);
            lbl2x7.Tag = new Question(2, 7); lbl2x8.Tag = new Question(2, 8); lbl2x9.Tag = new Question(2, 9);
            lbl2x10.Tag = new Question(2, 10); lbl2x11.Tag = new Question(2, 11); lbl2x12.Tag = new Question(2, 12);
            lbl3x1.Tag = new Question(3, 1); lbl3x2.Tag = new Question(3, 2); lbl3x3.Tag = new Question(3, 3);
            lbl3x4.Tag = new Question(3, 4); lbl3x5.Tag = new Question(3, 5); lbl3x6.Tag = new Question(3, 6);
            lbl3x7.Tag = new Question(3, 7); lbl3x8.Tag = new Question(3, 8); lbl3x9.Tag = new Question(3, 9);
            lbl3x10.Tag = new Question(3, 10); lbl3x11.Tag = new Question(3, 11); lbl3x12.Tag = new Question(3, 12);
            lbl4x1.Tag = new Question(4, 1); lbl4x2.Tag = new Question(4, 2); lbl4x3.Tag = new Question(4, 3);
            lbl4x4.Tag = new Question(4, 4); lbl4x5.Tag = new Question(4, 5); lbl4x6.Tag = new Question(4, 6);
            lbl4x7.Tag = new Question(4, 7); lbl4x8.Tag = new Question(4, 8); lbl4x9.Tag = new Question(4, 9);
            lbl4x10.Tag = new Question(4, 10); lbl4x11.Tag = new Question(4, 11); lbl4x12.Tag = new Question(4, 12);
            lbl5x1.Tag = new Question(5, 1); lbl5x2.Tag = new Question(5, 2); lbl5x3.Tag = new Question(5, 3);
            lbl5x4.Tag = new Question(5, 4); lbl5x5.Tag = new Question(5, 5); lbl5x6.Tag = new Question(5, 6);
            lbl5x7.Tag = new Question(5, 7); lbl5x8.Tag = new Question(5, 8); lbl5x9.Tag = new Question(5, 9);
            lbl5x10.Tag = new Question(5, 10); lbl5x11.Tag = new Question(5, 11); lbl5x12.Tag = new Question(5, 12);
            lbl6x1.Tag = new Question(6, 1); lbl6x2.Tag = new Question(6, 2); lbl6x3.Tag = new Question(6, 3);
            lbl6x4.Tag = new Question(6, 4); lbl6x5.Tag = new Question(6, 5); lbl6x6.Tag = new Question(6, 6);
            lbl6x7.Tag = new Question(6, 7); lbl6x8.Tag = new Question(6, 8); lbl6x9.Tag = new Question(6, 9);
            lbl6x10.Tag = new Question(6, 10); lbl6x11.Tag = new Question(6, 11); lbl6x12.Tag = new Question(6, 12);
            lbl7x1.Tag = new Question(7, 1); lbl7x2.Tag = new Question(7, 2); lbl7x3.Tag = new Question(7, 3);
            lbl7x4.Tag = new Question(7, 4); lbl7x5.Tag = new Question(7, 5); lbl7x6.Tag = new Question(7, 6);
            lbl7x7.Tag = new Question(7, 7); lbl7x8.Tag = new Question(7, 8); lbl7x9.Tag = new Question(7, 9);
            lbl7x10.Tag = new Question(7, 10); lbl7x11.Tag = new Question(7, 11); lbl7x12.Tag = new Question(7, 12);
            lbl8x1.Tag = new Question(8, 1); lbl8x2.Tag = new Question(8, 2); lbl8x3.Tag = new Question(8, 3);
            lbl8x4.Tag = new Question(8, 4); lbl8x5.Tag = new Question(8, 5); lbl8x6.Tag = new Question(8, 6);
            lbl8x7.Tag = new Question(8, 7); lbl8x8.Tag = new Question(8, 8); lbl8x9.Tag = new Question(8, 9);
            lbl8x10.Tag = new Question(8, 10); lbl8x11.Tag = new Question(8, 11); lbl8x12.Tag = new Question(8, 12);
            lbl9x1.Tag = new Question(9, 1); lbl9x2.Tag = new Question(9, 2); lbl9x3.Tag = new Question(9, 3);
            lbl9x4.Tag = new Question(9, 4); lbl9x5.Tag = new Question(9, 5); lbl9x6.Tag = new Question(9, 6);
            lbl9x7.Tag = new Question(9, 7); lbl9x8.Tag = new Question(9, 8); lbl9x9.Tag = new Question(9, 9);
            lbl9x10.Tag = new Question(9, 10); lbl9x11.Tag = new Question(9, 11); lbl9x12.Tag = new Question(9, 12);
            lbl10x1.Tag = new Question(10, 1); lbl10x2.Tag = new Question(10, 2); lbl10x3.Tag = new Question(10, 3);
            lbl10x4.Tag = new Question(10, 4); lbl10x5.Tag = new Question(10, 5); lbl10x6.Tag = new Question(10, 6);
            lbl10x7.Tag = new Question(10, 7); lbl10x8.Tag = new Question(10, 8); lbl10x9.Tag = new Question(10, 9);
            lbl10x10.Tag = new Question(10, 10); lbl10x11.Tag = new Question(10, 11); lbl10x12.Tag = new Question(10, 12);
            lbl11x1.Tag = new Question(11, 1); lbl11x2.Tag = new Question(11, 2); lbl11x3.Tag = new Question(11, 3);
            lbl11x4.Tag = new Question(11, 4); lbl11x5.Tag = new Question(11, 5); lbl11x6.Tag = new Question(11, 6);
            lbl11x7.Tag = new Question(11, 7); lbl11x8.Tag = new Question(11, 8); lbl11x9.Tag = new Question(11, 9);
            lbl11x10.Tag = new Question(11, 10); lbl11x11.Tag = new Question(11, 11); lbl11x12.Tag = new Question(11, 12);
            lbl12x1.Tag = new Question(12, 1); lbl12x2.Tag = new Question(12, 2); lbl12x3.Tag = new Question(12, 3);
            lbl12x4.Tag = new Question(12, 4); lbl12x5.Tag = new Question(12, 5); lbl12x6.Tag = new Question(12, 6);
            lbl12x7.Tag = new Question(12, 7); lbl12x8.Tag = new Question(12, 8); lbl12x9.Tag = new Question(12, 9);
            lbl12x10.Tag = new Question(12, 10); lbl12x11.Tag = new Question(12, 11); lbl12x12.Tag = new Question(12, 12);
            ResetQuestions();

        }
    }

    class Question
    {
        public Question(int Op1, int Op2)
        {
            this.Op1 = Op1;
            this.Op2 = Op2;
        }
        public int Op1;
        public int Op2;
    }
}
