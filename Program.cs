using System;

namespace ShooterGame // Note: actual namespace depends on the project name.
{
    public class InSufficientBulletCountException : Exception
    {

        public InSufficientBulletCountException(string message)
            : base(message)
        {

        }
    }
        public interface IZoomable
    {
        void Zoom();
    }
    public abstract class Gun{
        public int TotalBulletCount { get; set; }
        public int CurrentBulletCount { get; private set; }
        public void Shoot() 
        {
            if (CurrentBulletCount > 0)
            {
                Console.WriteLine("Shooting...");
                CurrentBulletCount = CurrentBulletCount - 1;
            }
        }

    
        public void Reload()
        {
            CurrentBulletCount = TotalBulletCount;
            Console.WriteLine("Reloaded... ");
        }

        
    }

    public class M4 : Gun
    {
        public M4(int maksimumgulle)
        {
            TotalBulletCount = maksimumgulle;
        }
    }

    public class AK74 : Gun
    {
        public AK74(int maksimumgulle)
        {
            TotalBulletCount = maksimumgulle;
        }
    }

    public class P92 : Gun, IZoomable
    {
        public P92(int maksimumgulle)
        {
            TotalBulletCount = maksimumgulle;
        }

        public void Zoom()
        {
            Console.WriteLine("Zoom...");
        }
    }

    public class AWP : Gun, IZoomable
    {
        public AWP(int maksimumgulle)
        {
            TotalBulletCount = maksimumgulle;
        }

        public void Zoom()
        {
            Console.WriteLine("Zoom...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                M4 m4 = new M4(30);
                m4.Reload();
                m4.Shoot();
                m4.Shoot();
                m4.Shoot();

                Console.WriteLine("M4 silahinda qalan gulle sayi : " + m4.CurrentBulletCount);
            }
            catch (InSufficientBulletCountException ex)
            {
                Console.WriteLine(ex.Message);
            }



            try
            {
                AK74 AK74 = new AK74(32);
                AK74.Reload();
                AK74.Shoot();
                AK74.Shoot();
                AK74.Shoot();

                if (AK74.CurrentBulletCount <= 0)
                {
                    throw new InSufficientBulletCountException("Gulle sayi sifirdan kicik ola bilmez");
                }
                Console.WriteLine("AK-74 de qalan gulle sayi: " + AK74.CurrentBulletCount);
            }
            catch (InSufficientBulletCountException ex)
            {
                Console.WriteLine(ex.Message);
            }


            

            try
            {
                P92 P92 = new P92(60);
                P92.Reload();
                P92.Zoom();
                P92.Shoot();
                P92.Shoot();
                P92.Shoot();

                if (P92.CurrentBulletCount <= 0)
                {
                    throw new InSufficientBulletCountException("Gulle sayi sifirdan kicik ola bilmez");
                }
               
                Console.WriteLine("P-92 de qalan gulle sayi: " + P92.CurrentBulletCount);
            }
            catch (InSufficientBulletCountException ex)
            {
                Console.WriteLine(ex.Message);
            }






            try
            {
                AWP AWP = new AWP(10);
                AWP.Reload();
                AWP.Zoom();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                AWP.Shoot();
                if (AWP.CurrentBulletCount <= 0)
                {
                    throw new InSufficientBulletCountException("Gulle sayi sifirdan kicik ola bilmez");
                } 
                Console.WriteLine("AWP de qalan gulle sayi: " + AWP.CurrentBulletCount);
            }
            catch (InSufficientBulletCountException ex) 
            {
                Console.WriteLine(ex.Message);
            }
           

           
            Console.ReadLine();

        }
    }
}