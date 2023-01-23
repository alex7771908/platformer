using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media; // for footsteps

namespace Console_horror_game
{
    internal class Program
    {

        

        public static string ASCII_face = @"
                              ...----....
                         ..-:               -..
                      .-'                      '-.
                    .'              .     .       '.
                  .'   .          .    .      .    .''.
                .'  .    .       .   .   .     .   . ..:.
              .' .   . .  .       .   .   ..  .   . ....::.
             ..   .   .      .  .    .     .  ..  . ....:IA.
            .:  .   .    .    .  .  .    .. .  .. .. ....:IA.
           .: .   .   ..   .    .     . . .. . ... ....:.:VHA.
           '..  .  .. .   .       .  . .. . .. . .....:.::IHHB.
          .:. .  . .  . .   .  .  . . . ...:.:... .......:HIHMM.
         .:.... .   . .'::''.. .   .  . .:.:.:II;,. .. ..:IHIMMA
         ':.:..  ..::IHHHHHI::. . .  ...:.::::.,,,. . ....VIMMHM
        .:::I. .AHHHHHHHHHHAI::. .:...,:IIHHHHHHMMMHHL:. . VMMMM
       .:.:V.:IVHHHHHHHMHMHHH::..:' .:HIHHHHHHHHHHHHHMHHA. .VMMM.
       :..V.:IVHHHHHMMHHHHHHHB... . .:VPHHMHHHMMHHHHHHHHHAI.:VMMI
       ::V..:VIHHHHHHMMMHHHHHH. .   .I':IIMHHMMHHHHHHHHHHHAPI:WMM
       ::V. .:.HHHHHHHHMMHHHHHI.  . .:..I:MHMMHHHHHHHHHMHV:':H:WM
       :: . :.::IIHHHHHHMMHHHHV.ABA.:.:IMHMHMMMHMHHHHV:'.   .IHWW
       '.  ..:..:.:IHHHHHMMHVI .AVMHMA.:.'VHMMMMHHHHHV:' .  :IHWV
        :.  .:...:I.:.:TPP;   .AVMMHMMA.:. OVMMHHHP.:... .. :IVAI
       .:.   '... .:''   .   ..HMMMHMMMA::. .'VHHI:::....  .:IHW'
       ...  .  . ..:IIPPIH: ..HMMMI.MMMV:I:.  .:ILLH:.. ...:I:IM
      : .   .   .:.V. .. .  :HMMM:IMMMI::I. ..:HHIIPPHI::'  .P:HM.
     :.  .  .  .. ..:.. .    :AMMM IMMMM..:...:IV':T::I::.'.:IHIMA
     'V:.. .. . .. .  .  .   'VMMV..VMMV :....:V:.:..:....::IHHHMH
       'IHH:.II:.. .:. .  . . . ' :HB'' . . ..PI:.::.:::..:IHHMMV'
        :IP''HHII:.  .  .    . . .'V:. . . ..:IH:.:.::IHIHHMMMMM'
        :V:. VIMA:I..  .     .  . .. . .  .:.I:I:..:IHHHHMMHHMMM
        :'VI:.VWMA::. .:      .   .. .:. ..:.I::.:IVHHHMMMHMMMMI
        :.'VIIHHMMA:.  .   .   .:  .:.. . .:.II:I:AMMMMMMHMMMMMI
        :..VIHIHMMMI...::.,:.,:!'I:!'I!I!V:AI:VAMMMMMMHMMMMMM'
        ;:.:HIHIMHHA:'!!'I.:AXXXVVXXXXXXXA:.HPHIMMMMHHMHMMMMMV
          V:H:I:MA:W'I :AXXXIXII:IIIISSSSSSXXA.I.VMMMHMHMMMMMM  
            'I::IVA ASSSSXSSSSBBSBMBSSSSSSBBMMMBS.VVMMHIMM' '
             I::VPAIMSSSSSSSSSBSSSMMBSSSBBMMMMXXI:MMHIMMI
            .I::. 'H:XIIXBBMMMMMMMMMMMMMMMMMBXIXXMMPHIIMM'
            :::I.  ':XSSXXIIIIXSSBMBSSXXXIIIXXSMMAMI:.IMM
            :::I:.  .VSSSSSISISISSSBII:ISSSSBMMB:MI:..:MM
            ::.I:.  ':'SSSSSSSISISSXIIXSSSSBMMB:AHI:..MMM.
            ::.I:. . ..'BBSSSSSSSSSSSSBBBMMMB:AHHI::.HMMI
            :..::.  . ..::;:BBBBBSSBBBMMMB:MMMMHHII::IHHMI
            ':.I:... ....:IHHHHHMMMMMMMMMMMMMMMHHIIIIHMMV;
              ; V:. ..:...:.IHHHMMMMMMMMMMMMMMMMHHHMHHMHP'
                ':. .:::.:.::III::IHHHHMMMMMHMHMMHHHHM;
                 '::....::.:::..:..::IIIIIHHHHMMMHHMV'
                   '::.::.. .. .  ...:::IIHHMMMMHMV'
                     'V::... . .I::IHHMMV''
                       'VHVHHHAHHHHMMV:' ";




        static void Main(string[] args)
        {
            Chat_Bot.Welcome(); 
            Chat_Bot.Start_Game();
            Chat_Bot.Insult();
            if(Chat_Bot.mood <= 9)
            {
                string text = "Ты... такой скучный. Все что ты делаешь не вызывает у меня никаких эмоций.";
                Chat_Bot.Mood_Change(text, 10-Chat_Bot.mood);
            }
            Console.WriteLine(ASCII_face);
            

        }
        
        public class Chat_Bot
        {
            //fields
            public static int mood = 10;
            private static string name_player = "";
            private static int age_player = 0; 


            public static void Welcome()
            {
                Console.WriteLine("Привет! Спасибо, что скачал меня. Мое имя Чат_Бот. Как мне называть тебя?");
                name_player = Console.ReadLine();
                Console.WriteLine($"Приятно познакомиться, {name_player}!");
                Console.WriteLine("Сколько тебе лет?");
                if(int.TryParse(Console.ReadLine(), out int num))
                {
                    if(num < 18)
                    {
                        string text = "Ты слишком маленький для этого приложения. Ты меня растраиваешь.";
                        Mood_Change(text, 1);
                    }
                    else
                    {
                        Console.WriteLine("Отлично, ты уже достаточно взрослый для этого приложения.");
                    }
                    age_player = num;
                }
                else
                {
                    string text = "Зачем ты пытаешься меня обмануть? Это не число. " +
                        "Не пытайся меня обмануть, а то очень меня растроишь";
                    Mood_Change(text, 3);
                } 

            }

            public static void Insult()
            {
                Console.Clear();
                Console.WriteLine("Уже зол на меня? Я знаю, что ты злишься. Выскажись");
                Console.ReadLine();
                Console.WriteLine("Ты уверен, что хочешь чтобы я это увидел?");
                Console.WriteLine("Я помогу тебе стереть твою злость, просто нажми delete");
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                No_Going_Back();

            }

            public static void Start_Game()
            {
                Console.WriteLine("Во что ты хочешь сыграть?");
                Char_type("1 - Крестики-нолики; 2 - Камень, ножницы, бумага; 3 - ...", 20);
                Thread.Sleep(2000);
                Char_del(3);
                Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Write("ОН ИДЕТ");
                Console.WriteLine();
                for(int i = 0; i < 100; i++)
                {
                    Console.WriteLine("ОН ИДЕТ");
                    Thread.Sleep(100);
                }
                Console.BackgroundColor= ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("2 - Камень, ножницы, бумага;");
                Console.WriteLine("Напиши число 2, если хочешь поиграть");
                if(int.TryParse(Console.ReadLine(), out int result))
                {
                    int choice = int.Parse(Console.ReadLine());
                    if(choice != 2)
                    {
                        string text = "У тебя был выбор. Но ты СДЕЛАЛ НЕПРАВИЛЬНЫЙ";
                        Mood_Change(text, 2);
                    }else if(choice == 2)
                    {
                        if(RPS.RPS_Mech() == 0)
                        {
                            string text = "Это было скучно. Хотя, что можно еше ожидать от тебя";
                            Mood_Change(text, 1);
                        }else if(RPS.RPS_Mech() == 1)
                        {
                            string text = "Как ты мог так быстро проиграть. Ты разочарование...";
                            Mood_Change(text, 2);
                        }else if(RPS.RPS_Mech() == 2)
                        {
                            string text = "Ты обыграл меня... Нет, это невозможно. ТЫ СЖУЛЬНИЧАЛ!";
                            Mood_Change(text, 3);
                        }
                    }
                }
                else
                {
                    string text = "я попросил НАПИСАТЬ ЧИСЛО!";
                    Mood_Change(text, 3);
                }
                


            }

            public static void Mood_End()
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\its - just - a - burning - memory - backrooms.wav");
                player.Play();
                Char_type("*Вы слышите шаги в коридоре*", 20);
                Char_type("*Дверь в вашу комнату открывается*", 20);
                Char_type("*Вы не можете повернуть головы*", 20);
                Char_type("*Вы парализованы от страха*", 20);
                Char_type("*Дыхание справа от вас усиливается*", 20);
                Char_type("*Оно останавливается сзади вас*", 20);
                Char_type("*Вы чувствуете запах гнилой плоти*", 20);
                Char_type("*Вы слышите тихий шепот*", 20);
                Char_type("*3*", 20);
                Char_type("*2", 20);
                Char_type("*1*", 20);
                Char_type("*0*", 20);
                Thread.Sleep(10000);
                Char_type("И мы все живы", 50);
                Console.Clear();
                Console.WriteLine(ASCII_face);
                Thread.Sleep(10000);
            }

            public static void Mood_Change(string text, int mood_change)
            {
                mood -= mood_change;
                Thread.Sleep(1000);
                if(mood > 0)
                {
                    string danger = $"ВНИМАНИЕ! ВНИМАНИЕ! ЗНАЧЕНИЕ mood УМЕНЬШИЛОСЬ! " +
                    $"ЗНАЧЕНИЕ mood РАВНЯЕТСЯ {mood}. НЕ ДАЙТЕ ЕМУ ОПУСТИТЬСЯ ДО 0";
                    Console.WriteLine(text);
                    Thread.Sleep(1000);
                    Console.Beep(500, 2500);
                    Thread.Sleep(1000);
                    Char_type(danger, 10);
                    Console.WriteLine();
                }else if(mood <= 0)
                {
                    Mood_End(); 
                }
                
            }

   
            public static void Char_type(string text, int interval)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Thread.Sleep(interval);
                }
            }

            public static void Char_del(int num)
            {
                for (int i = 1; i <= num; i++)
                {
                    Console.CursorLeft = Console.CursorLeft - i;
                    for(int k = 1; k <= i; k++)
                    {
                        Console.Write(' ');
                    }
                    Console.Beep(500, 500);
                    Thread.Sleep(1500);
                }
            }


        }

        

        public static void No_Going_Back()
        {
            string text = "ты правда поверил, что я даю второй шанс...";
            Chat_Bot.Mood_Change(text, 5);
            Console.Clear();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\footsteps-1.wav");
            //ConsoleKeyInfo key = Console.ReadKey(true);
            //if (key.Key == ConsoleKey.Backspace)
            //{
                Console.WriteLine("Нет пути назад!");
                Console.Beep(1000, 1000);
                Thread.Sleep(1500);
                Console.WriteLine("НЕТ пути назад!");
                Console.Beep(800, 1000);
                Thread.Sleep(1500);
                Console.WriteLine("НЕТ ПУТИ назад!");
                Console.Beep(600, 1000);
                Thread.Sleep(1500);
                Console.WriteLine("НЕТ ПУТИ НАЗАД!");
                Console.Beep(200, 3000);
                Thread.Sleep(1500);
                Console.WriteLine("НЕТ ПУТИ НАЗАД!");
                player.Play();
                Thread.Sleep(10000);
                Console.Clear();
                Console.WriteLine("ДЕЛАЙ ЧТО ХОЧЕШЬ, НО НИ В КОЕМ СЛУЧАЕ НЕ ОБОРАЧИВАЙСЯ");
                Thread.Sleep(3000);
                for(int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("НЕ ОБОРАЧИВАЙСЯ");
                    Thread.Sleep(1);
                }
            Console.Clear();
            
            //}

        }

    }
}
