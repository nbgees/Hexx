using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hex
{
    public partial class Form1 : Form
    {
        #region HSL
        float i_HSL_H = 0;
        float i_HSL_S = 0;
        float i_HSL_L = 0;

        float in_HSL_H = 0;
        float in_HSL_S = 0;
        float in_HSL_L = 0;

        float HSL___R = 0;
        float HSL___G = 0;
        float HSL___B = 0;
        #endregion
        #region RGB
        int iHSL___R = 0;
        int iHSL___G = 0;
        int iHSL___B = 0;

        int RGB___R = 0;
        int RGB___G = 0;
        int RGB___B = 0;

        String HEX___R = "";
        String HEX___G = "";
        String HEX___B = "";

        String HEX___RGB = "";
        #endregion



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRandom();
            RGBtoHSL(RGB___R,RGB___G,RGB___B);
            InvertHSL(i_HSL_H, i_HSL_S, i_HSL_L);
            inHSLtoRGB(in_HSL_H, in_HSL_S, in_HSL_L);
            HSLtoRGB(i_HSL_H,i_HSL_S,i_HSL_L);
            RichTextBox rt = (RichTextBox)richTextBox1;
            rt.AppendText(Environment.NewLine + HEX___RGB);



            DISPLAY();
            ADDCOLORSTRIPP();
        }

        public void CreateRandom()
        {
            Random rnd = new Random();
            RGB___R = rnd.Next(256);
            RGB___G = rnd.Next(256);
            RGB___B = rnd.Next(256);

            HEX___R = String.Format(RGB___R.ToString("X"));
            HEX___G = String.Format(RGB___G.ToString("X"));
            HEX___B = String.Format(RGB___B.ToString("X"));
            if (HEX___R.Length == 1) { HEX___R = "0" + HEX___R; }
            if (HEX___G.Length == 1) { HEX___G = "0" + HEX___G; }
            if (HEX___B.Length == 1) { HEX___B = "0" + HEX___B; }

            HEX___RGB = "#" + HEX___R + HEX___G + HEX___B;
        }

        public void ADDCOLORSTRIPP()
        {
            Label L1 = (Label)label24;
            Label L2 = (Label)label17;
            Label L3 = (Label)label18;
            Label L4 = (Label)label19;
            Label L5 = (Label)label20;
            Label L6 = (Label)label21;
            Label L7 = (Label)label22;
            Label L8 = (Label)label23;
            Label L9 = (Label)label25;
            Label L10 = (Label)label26;
            Label L11 = (Label)label27;
            Label L12 = (Label)label28;
            Label L13 = (Label)label29;
            Label L14 = (Label)label30;

            #region L1-L14
            L14.Text = L13.Text;
            L14.BackColor = L13.BackColor;
            L14.ForeColor = L13.ForeColor;

            L13.Text = L12.Text;
            L13.BackColor = L12.BackColor;
            L13.ForeColor = L12.ForeColor;

            L12.Text = L11.Text;
            L12.BackColor = L11.BackColor;
            L12.ForeColor = L11.ForeColor;

            L11.Text = L10.Text;
            L11.BackColor = L10.BackColor;
            L11.ForeColor = L10.ForeColor;

            L10.Text = L9.Text;
            L10.BackColor = L9.BackColor;
            L10.ForeColor = L9.ForeColor;

            L9.Text = L8.Text;
            L9.BackColor = L8.BackColor;
            L9.ForeColor = L8.ForeColor;

            L8.Text = L7.Text;
            L8.BackColor = L7.BackColor;
            L8.ForeColor = L7.ForeColor;

            L7.Text = L6.Text;
            L7.BackColor = L6.BackColor;
            L7.ForeColor = L6.ForeColor;

            L6.Text = L5.Text;
            L6.BackColor = L5.BackColor;
            L6.ForeColor = L5.ForeColor;

            L5.Text = L4.Text;
            L5.BackColor = L4.BackColor;
            L5.ForeColor = L4.ForeColor;

            L4.Text = L3.Text;
            L4.BackColor = L3.BackColor;
            L4.ForeColor = L3.ForeColor;

            L3.Text = L2.Text;
            L3.BackColor = L2.BackColor;
            L3.ForeColor = L2.ForeColor;

            L2.Text = L1.Text;
            L2.BackColor = L1.BackColor;
            L2.ForeColor = L1.ForeColor;

            Button B1 = (Button)button1;

            L1.Text = B1.Text;
            L1.BackColor = B1.BackColor;
            L1.ForeColor = B1.ForeColor;

            
            B1.BackColor = Color.FromArgb(RGB___R, RGB___G, RGB___B);
            B1.Text = HEX___RGB;
            B1.ForeColor = Color.FromArgb(iHSL___R, iHSL___G, iHSL___B);
            #endregion


        }

        public void DISPLAY()
        {

            Button B1 = (Button)button1;
        }

        public void InvertHSL(float IHSL_H, float IHSL_S, float IHSL_L)
        {
            IHSL_H += 180;
            if(IHSL_H >= 360) { IHSL_H -= 360; }

            IHSL_S = 1 - IHSL_S;

            in_HSL_H = IHSL_H;
            in_HSL_S = IHSL_S;
            in_HSL_L = IHSL_L;
        }

        public void RGBtoHSL(int R, int G, int B)
        {
            System.Drawing.Color HSL = System.Drawing.Color.FromArgb(R, G, B);
            i_HSL_H = HSL.GetHue();
            i_HSL_S = HSL.GetSaturation();
            i_HSL_L = HSL.GetBrightness();
        }

        public void inHSLtoRGB(float iHSL_H, float iHSL_S, float iHSL_L)
        {
            float HSL_H = iHSL_H;
            float HSL_S = iHSL_S;
            float HSL_L = iHSL_L;

            float HSL_C = (1 - Math.Abs((2 * HSL_L) - 1)) * HSL_S;
            float HSL_X = HSL_C * (1 - Math.Abs(((HSL_H / 60) % 2) - 1));
            float HSL_m = HSL_L - (HSL_C / 2);

            float HSL__R = 0;
            float HSL__G = 0;
            float HSL__B = 0;

            float HSL_R = 0;
            float HSL_G = 0;
            float HSL_B = 0;

            if (HSL_H < 60)
            {
                HSL__R = HSL_C;
                HSL__G = HSL_X;
                HSL__B = 0;

                HSL___R = (HSL__R + HSL_m) * 255;
                HSL___G = (HSL__G + HSL_m) * 255;
                HSL___B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 120)
            {
                HSL__R = HSL_X;
                HSL__G = HSL_C;
                HSL__B = 0;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255; 
            }
            else if (HSL_H < 180)
            {
                HSL__R = 0;
                HSL__G = HSL_X;
                HSL__B = HSL_C;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 240)
            {
                HSL__R = 0;
                HSL__G = HSL_X;
                HSL__B = HSL_C;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255; 
            }
            else if (HSL_H < 300)
            {
                HSL__R = HSL_X;
                HSL__G = 0;
                HSL__B = HSL_C;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;   
            }
            else if (HSL_H < 360)
            {
                HSL__R = HSL_C;
                HSL__G = 0;
                HSL__B = HSL_X;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }

            iHSL___R = (int)HSL_R;
            iHSL___G = (int)HSL_G;
            iHSL___B = (int)HSL_B;
        }

        public void HSLtoRGB(float iHSL_H, float iHSL_S, float iHSL_L)
        {
            float HSL_H = iHSL_H;
            float HSL_S = iHSL_S;
            float HSL_L = iHSL_L;

            float HSL_C = (1 - Math.Abs((2 * HSL_L) - 1)) * HSL_S;
            float HSL_X = HSL_C * (1 - Math.Abs(((HSL_H / 60) % 2) - 1));
            float HSL_m = HSL_L - (HSL_C / 2);

            float HSL__R = 0;
            float HSL__G = 0;
            float HSL__B = 0;

            float HSL_R = 0;
            float HSL_G = 0;
            float HSL_B = 0;

            if (HSL_H < 60)
            {
                HSL__R = HSL_C;
                HSL__G = HSL_X;
                HSL__B = 0;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 120)
            {
                HSL__R = HSL_X;
                HSL__G = HSL_C;
                HSL__B = 0;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 180)
            {
                HSL__R = 0;
                HSL__G = HSL_X;
                HSL__B = HSL_C;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 240)
            {
                HSL__R = 0;
                HSL__G = HSL_X;
                HSL__B = HSL_C;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 300)
            {
                HSL__R = HSL_X;
                HSL__G = 0;
                HSL__B = HSL_C;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }
            else if (HSL_H < 360)
            {
                HSL__R = HSL_C;
                HSL__G = 0;
                HSL__B = HSL_X;

                HSL_R = (HSL__R + HSL_m) * 255;
                HSL_G = (HSL__G + HSL_m) * 255;
                HSL_B = (HSL__B + HSL_m) * 255;
            }

            HSL___R = HSL_R;
            HSL___G = HSL_G;
            HSL___B = HSL_B;
        }
        #region 123
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
