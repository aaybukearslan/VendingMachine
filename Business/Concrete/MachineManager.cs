using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
    public class MachineManager : MachineService
    {
        public int Total { get; set; }

        public bool Control = false;

        const int Water = 25;
        const int Coke = 35;
        const int Soda = 45;

        public int Temperature = 2;

        public int Watt = 2;

        public int GiveBack = 0;

        public int birikmis = 0;
        public MachineManager()
        {
            Total = 0;
        }



        public void SecimEkranı()
        {

            Console.WriteLine("#################################");
            Console.WriteLine("#          A - Water  = 25      #");
            Console.WriteLine("#          B - Coke   = 35      #");
            Console.WriteLine("#          C - Soda   = 45      #");
            Console.WriteLine("#################################");
            Console.WriteLine("");
            Console.WriteLine("Yatırdığınız tutar {0} Lütfen Seçim yapınız.", Total);
            SecimYap(Console.ReadLine().ToUpper());
            Console.WriteLine("Tamamlamak için Basınız (T). Ürün veya Para İade için basınız(Q)  ");
            char iade = (Convert.ToChar(Console.ReadLine().ToUpper()));

            if (iade == 'Q')
            {
                Console.WriteLine("Ürün iade yapıldı.İade edilen tutar:" + GiveBack);
                Total = Total - Total;
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();
                GirisEkran();
                Total = 0;
            }

            if (iade == 'T')
            {
                birikmis += Total;
                Console.WriteLine("Alışveriş tamamlandı.Teşekkür ederiz.");
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Total = 0;
                Console.Clear();
                GirisEkran();


            }


        }

        public void SecimYap(string secim)
        {
            bool secimx = false;
            while (!secimx)
            {
                switch (secim)
                {
                    case "A":
                        Console.WriteLine("Su Aldınız");
                        secimx = true;
                        break;
                    case "B":
                        Console.WriteLine("Kola Aldınız");
                        secimx = true;
                        break;
                    case "C":
                        Console.WriteLine("Soda Aldınız");
                        secimx = true;
                        break;

                    default:
                        Console.WriteLine("Hatalı seçim.Lütfen Tekrar deneyiniz.");
                        for (int i = 1; i <= 3; i++)
                        {
                            Console.WriteLine(i);
                            System.Threading.Thread.Sleep(1000);
                        }
                        Console.Clear();
                        SecimEkranı();
                        break;
                }
                
                if (secim == "A" && Total < Water)
                {
                    Console.WriteLine("Yetersiz bakiye. ");
                    GirisEkran();
                }

                if (secim == "B" && Total < Coke)
                {
                    Console.WriteLine("Yetersiz bakiye.");
                    GirisEkran();
                }
                else if (secim == "C" && Total < Soda)
                {
                    Console.WriteLine("Yetersiz bakiye.");
                    GirisEkran();
                }
                else
                {


                    if (secim == "A")
                    {
                        GiveBack = Total;
                        int iade = Total - Water;
                        Console.WriteLine("Para iadesi:{0} ", iade);
                        Total = Total - iade;
                    }

                    if (secim == "B")
                    {
                        GiveBack = Total;
                        int iade = Total - Coke;
                        Console.WriteLine("Para iadesi:{0} ", Total - Coke);
                        Total = Total - iade;
                    }

                    if (secim == "C")
                    {
                        GiveBack = Total;
                        int iade = Total - Soda;
                        Console.WriteLine("Para iadesi:{0} ", Total - Soda);
                        Total = Total - iade;
                    }


                }




            }
        }


        public void YatırılanPara(string para)
        {

            switch (para)
            {
                case ("1"):
                    Total += 1;
                    break;
                case ("5"):
                    Total += 5;
                    break;
                case ("10"):
                    Total += 10;
                    break;
                case ("20"):
                    Total += 20;
                    break;
                case ("B"):
                    if (Total == 0)
                    {
                        Console.WriteLine("Lütfen para girişi yapınız");
                        for (int i = 1; i <= 3; i++)
                        {
                            Console.WriteLine(i);
                            System.Threading.Thread.Sleep(1000);
                            
                        }
                        Console.Clear();
                        GirisEkran();
                    }
                    
                    else
                    SecimEkranı();
                    Control = true;
                    break;
                case ("b"):
                    if (Total == 0)
                    {
                        Console.WriteLine("Lütfen para girişi yapınız");
                        for (int i = 1; i <= 3; i++)
                        {
                            Console.WriteLine(i);
                            System.Threading.Thread.Sleep(1000);
                        }
                        Console.Clear();
                        GirisEkran();
                    }
                    else
                        SecimEkranı();
                    Control = true;
                    break;
                case ("*1234*"):
                    {
                        Control = true;
                        AdminPanel();
                        break;
                    }

                default:
                    Console.WriteLine("Yanlıs para birimi girdiniz.");
                    break;
            }




        }

        public void AdminPanel()
        {
            Console.WriteLine("############Admin Panel############");
            Console.WriteLine("#      1-Biriken Tutarı Çek       #");
            Console.WriteLine("#      2-Sıcaklık Belirle         #");
            Console.WriteLine("#      3-Saatlik Tüketim Belirle  #");           
            Console.WriteLine("#      4-Kaydet ve Çıkış yap      #");
            Console.WriteLine("#      5-Makineyi Sıfırla         #");
            Console.WriteLine("###################################");
            Console.Write("Seçim yapınız:");
            string select = Console.ReadLine();

            if (select == "1")
            {
                Console.WriteLine("Biriken tutar: " + birikmis);
                Console.Write("Çekmek istediğiniz tutarı giriniz: ");
                int cek = Convert.ToInt32(Console.ReadLine());
                if (cek <= birikmis)
                {
                    birikmis = birikmis - cek;
                    Console.WriteLine("Kalan bakiye :" + birikmis);
                    Console.WriteLine("Degişiklikler uygulandı.");
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();

                    AdminPanel();
                }
                else
                {
                    Console.WriteLine("Çekilmek istenen bakiye birikmiş bakiyeden büyük olamaz!");
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();
                    AdminPanel();
                }
            }

            if (select == "2")
            {
                Console.WriteLine("Sıcaklık: " + Temperature + "°C");
                Console.Write("Yeni sıcaklık değeri giriniz: ");
                int newC = Convert.ToInt32(Console.ReadLine());
                Temperature = newC;
                Console.WriteLine("Degişiklikler uygulandı.");
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();

                AdminPanel();
            }

            if (select == "3")
            {
                Console.WriteLine("Saatlik tüketim şuan:"+Watt+"W");
                Console.Write("Saatlik tüketim belirle:");
                int tuketim = Convert.ToInt32(Console.ReadLine());

                if(tuketim>5)
                {
                    Console.WriteLine("Enerji tüketimi saatlik 5 birim/saat den fazla olamaz ! ");
                    Console.WriteLine("Admin menüsüne dönülüyor");
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();

                    AdminPanel();

                }
                else if(tuketim<1)
                {
                    Console.WriteLine("Enerji tüketimi saatlik 1 birim/saat den düşük olamaz ! ");
                    Console.WriteLine("Admin menüsüne dönülüyor");
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();

                    AdminPanel();
                }
                else
                {
                    Watt = tuketim;
                    Console.WriteLine("Degişiklikler Kaydedildi Admin menüsüne dönülüyor.");
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();

                    AdminPanel();

                }

              
                


            }


            if (select == "4")
            {
                Console.WriteLine("İşlemler kaydedildi...");
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();
                Control = false;
                GirisEkran();
            }

            if(select=="5")
            {
                Console.WriteLine("Makineyi sıfırlamak istegininizden eminmisiniz (Y / N) :");
                string sifirla = Console.ReadLine().ToUpper();
                if(sifirla=="Y")
                {
                    Console.WriteLine("Makine sıfırlanıyor...");
                    Watt = 0;
                    Temperature = 0;
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();
                    AdminPanel();
                }
                else if(sifirla=="N")
                {
                    Console.WriteLine("Admin menüsüne dönülüyor...");
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();
                    AdminPanel();
                }
            }
            if(select!="1"||select!="2"|| select != "3"|| select != "4" || select!="5")
            {
                Console.WriteLine("Hatalı giriş lütfen belirlenen rakamları giriniz.");
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();

                AdminPanel();
            }

        }

        public void GirisEkran()
        {
            while (!Control == true)
            {
                Console.WriteLine("Yatırmak istediginiz tutarı giriniz (1,5,10,20). Para girişi tamamlandıysa bitir ( B ) basınız. ");
                YatırılanPara(Console.ReadLine());

            }

        }

        public void Sayac()
        {
            
                //for (int i = 1; i <= 10; i++)
                //{
                
                //    System.Threading.Thread.Sleep(1000);
                //}
                //Console.WriteLine("işlem zaman aşımına ugradı paranız iade ediliyor..");
                //Console.WriteLine("İade edilen tutar:" + Total);
                //for (int i = 1; i <= 2; i++)
                //{

                //    System.Threading.Thread.Sleep(1000);
                //}
                //Console.Clear();
                //GirisEkran();
            
        }
    }
}



