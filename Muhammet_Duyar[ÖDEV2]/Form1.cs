using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhammet_Duyar_ÖDEV2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FontDialog yenifont = new FontDialog();
        private void pictureboxayazdir()
        {
            /*Kullanıcıdan aldığım fontu yeni bir font değişkenine atıyorum*/
            Font kullanilacakfont = yenifont.Font;
            /*Resim adında Formun İçindeki Picturboxın Boyutu Kadar bir bitmap piksellerini oluşturuyorum */
            Bitmap resim = new Bitmap(this.pictureBox1.Size.Width,this.pictureBox1.Size.Height);
            /*Oluşturmuş Olduğum Resmi Graphics nesnesi ile resme dönüştürdüm*/
            Graphics yenigörüntü = Graphics.FromImage(resim);
            /*Oluşturmuş olduğum yeni görüntüyü drawstring fonksiyonu ile girdiğim textboxtaki degeri seçtiğim font , renk  ve yazının konumunun ayarlanmasını sağlıyorum*/
            yenigörüntü.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            yenigörüntü.DrawString(textBox1.Text, kullanilacakfont, Brushes.OrangeRed, 0, 0);
            /* En sonda ise pictureboxın içinde gösteriyorum*/
            this.pictureBox1.Image = resim;
            /*Debug içine direkt olarak jpg resim dosyası olarak kalmaktadır.*/
            resim.Save("Yeni.jpg");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Yazı için Bir Font Belirleyiniz","Mesaj",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            yenifont.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Metin Girilip Enter Tuşuna Basıldığında Pictureboxa direk resim olarak atayacaktır.....
            if (e.KeyChar == (char)Keys.Enter)
            {
                pictureboxayazdir();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yenifont.ShowDialog();
            pictureboxayazdir();
        }
        /* Bitmap  bmp = new Bitmap(2480,3500);
Şeklinde resmin width ve height değerini vererek oluşturabiliriz. Dilersek aşağıdaki kodu kullanarak oluşturduğumuz resmin pixel formatını da belirleyebiliriz.

Bitmap bmp = new Bitmap(2480,3500,PixelFormat.Format24bppRgb);
Resmi oluşturduktan sonra dpi değerini belirlemek istersek aşağıdaki kodu kullanabiliriz.

bmp.SetResolution(300,300);
Oluşturduğumuz resmin arka planını ise FillRectangle kullanarak istediğimiz renge boyayabiliriz.

using (Graphics grp = Graphics.FromImage(bmp))
{
grp.FillRectangle( Brushes.White, 0, 0, bmp.Width, bmp.Height);
}
Bir bitmap nesnesini transparan yapmak istiyorsak ;

bmp.MakeTransparent();
methodunu kullanabiliriz. Bir Resmin herhangi bir pixelde rengini değiştirmek istiyorsak setpixel methodunu kullanabiliriz.Örnek olarak;

Color mavi = Color.Blue;
bmp.SetPixel(100,200,mavi);
yaparsak yukarıda x=100 ve y=200 pixelin rengini mavi renge çevirmiş olur.

Eğer oluşturduğumuz resmi kaydetmek istersek save methodunu kullanırız. Resim kaydedileceği dosya yolunu girdikten sonra nokta kullanarak resmin hangi formatta kaydedileceğini belirleriz.

bmp.Save("resim.jpg"); */
    }
}
