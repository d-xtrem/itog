using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itog
{
    public partial class Form1 : Form
    {
        public Form2 frm2;
        int[,] map_box = new int[10, 10];
        const int map_size = 12;
        Button[,] cells = new Button[map_size, map_size];
        int CellW = 70;
        int CellH = 70;
        Image w, b, w_d, b_d;
        int click = 0;
        int i1_click, k1_click;
        int i2_click, k2_click;
        bool turn = false;
        bool first_turn = false;
        bool attack_turn = false;
        bool restart = false;
        int Point_Win_White = 0;
        int Point_Win_Black = 0;

        



        public Form1()
        {
            InitializeComponent();
            Size = new Size(1600, 900);
            w = new Bitmap(new Bitmap("C:/Users/kiril/Desktop/Shashechki/white.png"), new Size(CellW - 10, CellH - 10));
            w_d = new Bitmap(new Bitmap("C:/Users/kiril/Desktop/Shashechki/white_d.png"), new Size(CellW - 10, CellH - 10));
            b = new Bitmap(new Bitmap("C:/Users/kiril/Desktop/Shashechki/black.png"), new Size(CellW - 10, CellH - 10));
            b_d = new Bitmap(new Bitmap("C:/Users/kiril/Desktop/Shashechki/black_d.png"), new Size(CellW - 10, CellH - 10));
            Generate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((first_turn == true) || (attack_turn == true))
            {
                if (turn == true)
                {
                    turn = false;
                    first_turn = false;
                    attack_turn = false;
                    click = 0;
                }
                else
                {
                    turn = true;
                    first_turn = false;
                    attack_turn = false;
                    click = 0;
                }
            }
        }

        public void Generate()
        {
            map_box = new int[map_size, map_size] {
            {3,3,3,3,3,3,3,3,3,3,3,3},
            {3,1,0,1,0,1,0,1,0,1,0,3},
            {3,0,1,0,1,0,1,0,1,0,1,3},
            {3,1,0,1,0,1,0,1,0,1,0,3},
            {3,0,0,0,0,0,0,0,0,0,0,3},
            {3,0,0,0,0,0,0,0,0,0,0,3},
            {3,0,0,0,0,0,0,0,0,0,0,3},
            {3,0,0,0,0,0,0,0,0,0,0,3},
            {3,0,2,0,2,0,2,0,2,0,2,3},
            {3,2,0,2,0,2,0,2,0,2,0,3},
            {3,0,2,0,2,0,2,0,2,0,2,3},
            {3,3,3,3,3,3,3,3,3,3,3,3}
            };

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    cells[i, j] = new Button();
                    cells[i, j].Size = new Size(CellW, CellH);
                    cells[i, j].Left = CellW * j;
                    cells[i, j].Top = i * CellH;

                    if (((j % 2 == 0) && (i % 2 == 0)) || (((j % 2 != 0) && (i % 2 != 0))))
                    {
                        cells[i, j].BackColor = Color.Gray;
                    }


                    if (map_box[i, j] == 1)
                    {
                        cells[i, j].Image = w;
                    }
                    else if (map_box[i, j] == 2)
                    {
                        cells[i, j].Image = b;
                    }

                    cells[i, j].Click += cells_Click;

                    Controls.Add(cells[i, j]);
                }
            }
            
        }
        private void cells_Click(object sender, EventArgs e)
        {
            click++;
            int k, i;
            Button Tb;
            Tb = (Button)sender;
            k = (Tb.Left) / CellW;
            i = (Tb.Top) / CellH;

            int color = map_box[i, k];
            if (click % 2 == 1)
            {
                if ((color == 1) || (color == 2) || (color == 9) || (color == 8))
                {


                    i1_click = i;
                    k1_click = k;
                    i2_click = 0;
                    k2_click = 0;
                }
                else
                {
                    click = 0;
                }
            }

            else
            {
                if (color == 0)
                {
                    i2_click = i;
                    k2_click = k;
                    Turns_Check();

                }
                else
                {
                    click = 1;
                }
            }
        }
        public void White_Turn()
        {
            if ((((i2_click == i1_click + 1) && (k2_click == k1_click + 1)) || ((i2_click == i1_click + 1) && (k2_click == k1_click - 1))) && (first_turn == false))
            {
                cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                cells[i1_click, k1_click].Image = null;
                map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                map_box[i1_click, k1_click] = 0;
                click = 0;
                first_turn = true;
                white_queen();
            }

        }
        public void White_Attack()
        {
            if ((map_box[i1_click + 1, k1_click + 1] == 2) || (map_box[i1_click + 1, k1_click + 1] == 8))
            {
                if ((map_box[i1_click + 2, k1_click + 2] == 0) && (i2_click == i1_click + 2) && (k2_click == k1_click + 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click + 1, k1_click + 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click + 1,k1_click +1] = 0;
                    click = 0;
                    attack_turn = true;
                    Win_Check();
                    white_queen();

                }
            }
            if ((map_box[i1_click - 1, k1_click - 1] == 2) || (map_box[i1_click - 1, k1_click - 1] == 8))
            {
                if ((map_box[i1_click - 2, k1_click - 2] == 0) && (i2_click == i1_click - 2) && (k2_click == k1_click - 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click - 1, k1_click - 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click - 1, k1_click - 1] = 0;
                    click = 0;
                    attack_turn = true;
                    Win_Check();
                    white_queen();

                }
            }
            if ((map_box[i1_click - 1, k1_click + 1] == 2) || (map_box[i1_click - 1, k1_click + 1] == 8))
            {
                if ((map_box[i1_click - 2, k1_click + 2] == 0) && (i2_click == i1_click - 2) && (k2_click == k1_click + 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click - 1, k1_click + 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click - 1, k1_click + 1] = 0;
                    click = 0;
                    attack_turn = true;
                    Win_Check();
                    white_queen();

                }
            }
            if ((map_box[i1_click + 1, k1_click - 1] == 2) || (map_box[i1_click + 1, k1_click - 1] == 8))
            {
                if ((map_box[i1_click + 2, k1_click - 2] == 0) && (i2_click == i1_click + 2) && (k2_click == k1_click - 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click + 1, k1_click - 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click + 1, k1_click - 1] = 0;
                    click = 0;
                    attack_turn = true;
                    Win_Check();
                    white_queen();

                }
            }
        }

        private void white_queen()
        {
            if (i2_click == 10)
            {
                map_box[i2_click, k2_click] = 9;
                cells[i2_click, k2_click].Image = w_d;
            }
        }

        private void white_queen_turn()
        {
            if ((((i2_click == i1_click - 1) && (k2_click == k1_click + 1)) || ((i2_click == i1_click - 1) && (k2_click == k1_click - 1))) && (first_turn == false))
            {
                cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                cells[i1_click, k1_click].Image = null;
                map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                map_box[i1_click, k1_click] = 0;
                click = 0;
                first_turn = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (turn == false)
            {
                label1.Text = "Ход белых";
            }
            else
            {
                label1.Text = "Ход черных";
            }
            label2.Text = first_turn.ToString();
            label3.Text = attack_turn.ToString();
        }
        private void black_queen()
        {
            if (i2_click == 1)
            {
                map_box[i2_click, k2_click] = 8;
                cells[i2_click, k2_click].Image = b_d;
            }
        }

        public void Black_Turn()
        {
            if ((((i2_click == i1_click - 1) && (k2_click == k1_click + 1)) || ((i2_click == i1_click - 1) && (k2_click == k1_click - 1))) && (first_turn == false))
            {
                cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                cells[i1_click, k1_click].Image = null;
                map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                map_box[i1_click, k1_click] = 0;
                click = 0;
                first_turn = true;
                black_queen();
            }

        }
        public void Black_Attack()
        {
            if ((map_box[i1_click + 1, k1_click + 1] == 1) || (map_box[i1_click + 1, k1_click + 1] == 9))
            {
                if ((map_box[i1_click + 2, k1_click + 2] == 0) && (i2_click == i1_click + 2) && (k2_click == k1_click + 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click + 1, k1_click + 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click + 1, k1_click + 1] = 0;
                    click = 0;
                    attack_turn = true;
                    black_queen();
                    Win_Check();
                }
            }
            if ((map_box[i1_click - 1, k1_click - 1] == 1) || (map_box[i1_click - 1, k1_click - 1] == 9))
            {
                if ((map_box[i1_click - 2, k1_click - 2] == 0) && (i2_click == i1_click - 2) && (k2_click == k1_click - 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click - 1, k1_click - 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click - 1, k1_click - 1] = 0;
                    click = 0;
                    attack_turn = true;
                    black_queen();
                    Win_Check();

                }
            }
            if ((map_box[i1_click - 1, k1_click + 1] == 1) || (map_box[i1_click - 1, k1_click + 1] == 9))
            {
                if ((map_box[i1_click - 2, k1_click + 2] == 0) && (i2_click == i1_click - 2) && (k2_click == k1_click + 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click - 1, k1_click + 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click - 1, k1_click + 1] = 0;
                    click = 0;
                    attack_turn = true;
                    black_queen();
                    Win_Check();

                }
            }
            if ((map_box[i1_click + 1, k1_click - 1] == 1) || (map_box[i1_click + 1, k1_click - 1] == 9))
            {
                if ((map_box[i1_click + 2, k1_click - 2] == 0) && (i2_click == i1_click + 2) && (k2_click == k1_click - 2))
                {
                    cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                    cells[i1_click, k1_click].Image = null;
                    cells[i1_click + 1, k1_click - 1].Image = null;
                    map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                    map_box[i1_click, k1_click] = 0;
                    map_box[i1_click + 1, k1_click - 1] = 0;
                    click = 0;
                    attack_turn = true;
                    black_queen();
                    Win_Check();

                }
            }

        }
        private void black_queen_turn()
        {
            if ((((i2_click == i1_click + 1) && (k2_click == k1_click + 1)) || ((i2_click == i1_click + 1) && (k2_click == k1_click - 1))) && (first_turn == false))
            {
                cells[i2_click, k2_click].Image = cells[i1_click, k1_click].Image;
                cells[i1_click, k1_click].Image = null;
                map_box[i2_click, k2_click] = map_box[i1_click, k1_click];
                map_box[i1_click, k1_click] = 0;
                click = 0;
                first_turn = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < map_size; i++)
            {
                for(int j = 0;  j < map_size; j++)
                {
                    this.Controls.Remove(cells[i, j]);
                }
            }
            turn = false;
            attack_turn = false;
            first_turn = false;
            Generate();


            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        public void Turns_Check()
        {
            if (((map_box[i1_click, k1_click] == 1) || (map_box[i1_click,k1_click] == 9)) && (turn == false)) // ход белых
            {
                if (attack_turn == false)
                {
                    White_Turn();
                    if (map_box[i1_click,k1_click] == 9)
                    {
                        white_queen_turn();
                    }
                }
                if (first_turn == false)
                {
                    White_Attack();
                }
            }

            if (((map_box[i1_click, k1_click] == 2) || (map_box[i1_click ,k1_click] == 8)) && (turn == true)) // ход черных
            {
                if (attack_turn == false)
                {
                    Black_Turn();
                    if (map_box[i1_click, k1_click] == 8)
                    {
                        black_queen_turn();
                    }
                }
                if (first_turn == false)
                {
                    Black_Attack();
                }

            }
        }
        public void Win_Check()
        {
            for (int i = 0; i < map_size; i++)
            {
                for (int j = 0; j < map_size; j++)
                {
                    if ((map_box[i, j] == 2) || (map_box[i, j] == 8))
                    {
                        Point_Win_White++;
                    }
                }
            }
            if (Point_Win_White == 0)
            {
                label4.Text = "Победа белых";
            }
            else
            {
                Point_Win_White = 0;
            }
            
            for (int i = 0; i < map_size; i++)
            {
                for (int j = 0; j < map_size; j++)
                {
                    if ((map_box[i, j] == 1) || (map_box[i,j] == 9))
                    {
                        Point_Win_Black++;
                    }
                }
            }
            if (Point_Win_Black == 0)
            {
                label4.Text = "Победа черных";
            }
            else
            {
                Point_Win_Black = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
