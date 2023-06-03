using System;
using System.Collections.Generic;

namespace structures
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Katılımcı yeniKullanıcı=new Katılımcı("Ahmet Baki",Kategoriler.Teknoloji);
            UserInfos newUser=new UserInfos();
            newUser.AddUser("Durdu Ozan",Kategoriler.Ekonomi);
            newUser.AddUser("Ahmet Ozan",Kategoriler.Teknoloji);
            newUser.AddUser("Doruk Kiraz",Kategoriler.Film);
            newUser.AddUser("Ayse Han",Kategoriler.Ekonomi);
            newUser.AddUser("Baki Tan",Kategoriler.Müzik);
            newUser.AddUser("Tolga Han",Kategoriler.Film);

            newUser.TumUyeler();

            Console.WriteLine("Oylamak istediğiniz kategoriyi seçiniz:");   
            Console.WriteLine("Teknoloji=1"+" "+
                              "Ekonomi=2"+" "+
                              "Film=3"+" "+
                              "Dizi=4"+" "+
                              "Oyun=5"+" "+
                              "Müzik=6");
            oyla:
            int oy=Convert.ToInt32(Console.ReadLine());

            if(oy<1 || oy>6){
                Console.WriteLine("Hatalı seçim. 1-6 arasında tercih yapınız !");
                goto oyla;
            }else{
                
                
                Console.WriteLine("Kullanıcı adını giriniz :");
                string user=Console.ReadLine().ToString();
                //Console.WriteLine(newUser.GetKatılımcı(user));
                if(!newUser.KullanıcıListesi(user)){ // kullanıcı kayıtlı değil ise kaydet
                    Console.WriteLine("Lütfen kayıt olunuz ! Yeni kullanıcı adını giriniz :");
                    string nname=Console.ReadLine().ToString();
                    newUser.AddUser(nname,(Kategoriler)Enum.ToObject(typeof(Kategoriler),oy));
                    Console.WriteLine("KAYIT BASARILI...SONUCLAR");
                    newUser.GetKatılımcı(nname).UpdateKategori((Kategoriler)Enum.ToObject(typeof(Kategoriler),oy));

                    newUser.TumUyeler();
                    newUser.OylamaSonucu(oy);
                }else{//kayıtlı ise oylama geçerli
                    Console.WriteLine("Oylamanız KABUL edilmiştir.");
                    newUser.GetKatılımcı(user).UpdateKategori((Kategoriler)Enum.ToObject(typeof(Kategoriler),oy));
                    newUser.TumUyeler();
                    newUser.OylamaSonucu(oy);
                }


            }
        }
    }

    public enum Kategoriler{
        Teknoloji=1,Ekonomi,Film,Dizi,Oyun,Müzik
    }

    class Katılımcı{

        private string userName;
        private Kategoriler tercih;

        public Katılımcı(string name,Kategoriler t){
            this.userName=name;
            this.tercih=t;
            //this.Surname=surname;
        }

        public string GetName(){
            return userName;
        }
        public Kategoriler GetTercih(){
            return tercih;
        }

        public void UpdateKategori(Kategoriler t){
            this.tercih=t;
        }

        public string GetName2(){
            return userName+" "+Enum.GetName(typeof(Kategoriler),tercih);
        }
        

      /*  public string GetNameSurname(){
            return Name+" "+Surname;
        }*/
        

         

        public bool IsUser(string name){
            bool isUser=false;
            if(userName==name){
                isUser=true;

            }
            return isUser;
        }
    }

    class UserInfos{

        public static List<Katılımcı> users=new List<Katılımcı>();
        private bool isUser=false;
        public void AddUser(string name,Kategoriler kategoriler){
            users.Add(new Katılımcı(name,kategoriler));
        }

        public Katılımcı GetKatılımcı(string name){
            return users.Find(x=>x.GetName()==name);
        }

        public Katılımcı GetKatılımcıTercih(Kategoriler kat){
            return users.Find(x=>x.GetTercih()==kat);
        }

        public bool KullanıcıListesi(string s){

            foreach(var a in users){
                if(a.GetName()==s){
                    isUser=true;
                   // Console.WriteLine(a.GetName()+"**"+a.GetTercih());
                    break;
                }
                
            }

            return isUser;

        }
        public void TumUyeler(){

            for(int i=0;i<users.Count;i++){
                Console.WriteLine(users[i].GetName2());
            }
                
                    //isUser=true;
                    //Console.WriteLine(a.GetName()+"/"+a.GetTercih());
                    //users.ge
                
        }
        public void OylamaSonucu(int kat){
            int counter=0;
            foreach(var o in users){
                if((Kategoriler)Enum.ToObject(typeof(Kategoriler),kat)==o.GetTercih()){
                    counter++;
                }

            }
            Console.WriteLine("{0} / {1}",counter,users.Count()+">> %"+((float)counter/(float)users.Count())*100+" {2} oylanmıstır.");
        }
    
    }

   


}