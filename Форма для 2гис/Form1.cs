using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; // Шовы усыпить поток

namespace Форма_для_2гис
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CiteBox.SelectedIndexChanged += CiteBox_SelectedIndexChanged;
            GenderBox.SelectedIndexChanged += GenderBox_SelectedIndexChanged;
            string NUserPassword1 = Password.MagicZone();   // Генерую случайный пароль 1
            Thread.Sleep(20);
            string NUserPassword2 = Password.MagicZone();   // Генерую случайный пароль 2
            Thread.Sleep(20);
            string NUserPassword3 = Password.MagicZone();   // Генерую случайный пароль 3
            Thread.Sleep(20);
            string NUserPassword4 = Password.MagicZone();   // Генерую случайный пароль 4
            Thread.Sleep(20);
            string NUserPassword5 = Password.MagicZone();   // Генерую случайный пароль 5
            //Выводим пароли
            BoxPassword.Items.AddRange(new string[] { NUserPassword1, NUserPassword2, NUserPassword3, NUserPassword4, NUserPassword5 });

            CiteBox.SelectedItem = "Краснодар"; // Выбор по умолчанию для города
            GenderBox.SelectedItem = "Чувак"; // Выбор по умолчанию для пола
            BoxPassword.SelectedItem = NUserPassword1; // Указываем пароль по умолчанию
        }
        #region Закрываем и двигаем
        private void Form1_KeyDown(object sender, KeyEventArgs e) //Закрываем Esc
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public void Form1_MouseDown(object sender, MouseEventArgs e) // Двигаем форму
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            #region Вбираем
            string NUserCity = CiteBox.SelectedItem.ToString(); //Указать город
            string NUserFIO = FormFIO.Text.Trim(); // Name.Убираем пробелы
            string UserBirthdayElementary = FormDate.Text.Trim(); // Дата рождения.Убираем пробелы
            string UserGender = GenderBox.SelectedItem.ToString(); //Пол ToString()
            string LeaderNUser = FormLeader.Text.Trim();// Назначаем руководителя.Убираем пробелы
            string NUserPassword = BoxPassword.Text; // Пароль
            string NUserNomerVn = FormNomerVn.Text.Trim();// Внутренний номер.Убираем пробелы
            string NUserMT = FormMobNomer.Text.Trim(); ; //Мобильный номер.Убираем пробелы
            #endregion
            #region Генерим команды
            #region Дегенерация логина

            string[] NUserFIOParsing = NUserFIO.Split(' '); // Превращаем ФИО в массив по пробелу
            string Userfame = NUserFIOParsing[0].ToLower(); // Делаем фамилию в нижний регистр
            string Username = NUserFIOParsing[1].ToLower();// Делаем имя в нижний регистр
            //В латиницу
            Translit translit = new Translit(); // Ссылка на словарь
            string ENfame = translit.MagicZone(Userfame); // полуфамилия
            string ENname = translit.MagicZone(Username); // полулогин
            string subENname = "|"; // Нужна для разделителя
            ENname = ENname.Insert(2, subENname); // Вставляем палку после второго знака
            var login = ENname.Remove(ENname.IndexOf('|'));
            string NUserLogin = login + "." + ENfame;
            // Генерация пользаков в конце блока рядом с проверкой руководителя
            #endregion
            //Задаю пароль
            string pass = ("Set-ADAccountPassword " + NUserLogin + " -Reset -NewPassword (ConvertTo-SecureString -AsPlainText " + "”" +
            NUserPassword + "”" + " -Force -Verbose)");

            //Включаем акаунт
            string Vkl = ("Set-ADAccountControl " + NUserLogin + " -Enabled $True");

            //Указываем фамилию. Теперь точно ее
            string fame = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{sn=" + "”" +
                NUserFIOParsing[0] + "”" + "}");

            //Указываю Имя
            string name = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{givenName =" + "”" +
                NUserFIOParsing[1] + "”" + "}");

            //Указываем пол
            if (UserGender == "Чувак")
            {
                UserGender = "M";
            }
            if (UserGender == "Чувиха")
            {
                UserGender = "F";
            }
            // Генерируем команду на указание пола
            string Gender = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Gender=" + "”" +
                UserGender + "”" + "}");

            // Генерируем и Указываем день варенья
            string[] DateMass = UserBirthdayElementary.Split('.'); // формируем массив по точке
            string UserBirthday = "";
            if (DateMass[0].Length > 2) // Если в первом элементе больше 2х символов значит там год
            {
                if (DateMass[1].Length < 2) { DateMass[1] = "0" + DateMass[1]; } //Добавляем к месяцу 0 если нужно
                if (DateMass[2].Length < 2) { DateMass[2] = "0" + DateMass[2]; } // Добавляем к дню 0 если нужно

                UserBirthday = DateMass[0] + "-" + DateMass[1] + "-" + DateMass[2]; //В 1вом элементе год
            }
            else // Если первое число не больше 2 значит это день
            {
                if (DateMass[0].Length < 2) { DateMass[0] = "0" + DateMass[0]; } // Проверяем день, добавляем 0 если нужно
                if (DateMass[1].Length < 2) { DateMass[1] = "0" + DateMass[1]; } //Добавляем к месяцу 0 если нужно

                UserBirthday = DateMass[2] + "-" + DateMass[1] + "-" + DateMass[0]; // В 3ем элемнете год 
            }

            string Birthday = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Birthday =" + "”" + UserBirthday + "”" + "}");

            //Отображаемое фио
            string MainFIO = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{DisplayName =" + "”" +
                NUserFIO + "”" + "}");
            //Указываем отображаемый телефон
            string NUserNomerMain = "+7-800-25-023-25";
            if (NUserNomerVn != "") { NUserNomerMain = ("+7-800-25-023-25" + " доб. " + NUserNomerVn); } // Если параметр не пуст указываем с добавочным. Если нет то просто номер
            string MainNamber = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{telephoneNumber =" + "”" + NUserNomerMain + "”" + "}"); // Генерация команды

            //Указываем личный мобильный
            string Usermobile = "";
            if (NUserMT != "") // Если поле не пустое то указываем его значение
            {
                Usermobile = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{mobile =" + "”" + NUserMT + "”" + "}");
            }
            else { Usermobile = "\n"; } //если же пусто, то просто пробел

            //===================================== Проверка города и все такое ===========================================
            #region Проверка города
            string Leader = ""; // Передать руководителя 
            string NUserMaill = ""; //Передать почту
            string MailUser = ""; //Готовая команда
            string NUserGroup2 = ""; // Для указания группы продаж
            string NUserCityCommand = ""; // Чтобы отображался в нужном городе
            string NameCompany = ""; //Указываем организацию, она для каждого города своя
            //Указываем отдел. У всех МПП это коммерция
            string NameDepartment = ""; // Указываю переменная для указания названия группы
            string Department = ""; //Передаем команду
            // Переменные для хранения задания группа
            string Userl = ""; string NUserGroup1 = ""; string NUserGroup3 = ""; string NUserGroup5 = ""; string NUserGroup6 = "";
            if (NUserCity == "Краснодар") // Краснодар 1
            {
                NUserMaill = NUserLogin + "@krasnodar.2gis.ru"; //Гинерим почту конкатинацией логогина и собака города
                MailUser = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{mail =" + "”" + NUserMaill + "”" + "}"); //Команда бичес-кирпичес
                NUserCityCommand = "OU=Пользователи,OU=Краснодар,OU=Cities,DC=2gis,DC=local"; //Папку куда сохраняться
                Userl = "Краснодар"; //Город
                NameCompany = "'ООО" + " ”" + "ДубльГИС-Краснодар" + "”'"; // Нужено все взять в '
                //----------------------------------------Группы по городам-----------------------------------------------------
                NUserGroup5 = ("Add-ADGroupMember " + "”" + "KSDR.PR-03" + "” " + NUserLogin);
                NUserGroup3 = ("Add-ADGroupMember " + "”" + "Краснодар.Access.VPN" + "” " + NUserLogin);
                NUserGroup6 = ("Add-ADGroupMember " + "”" + "Краснодар.Менеджер по продажам" + "” " + NUserLogin);
                NUserGroup1 = ("Add-ADGroupMember " + "”" + "Краснодар.Пользователи" + "” " + NUserLogin);
                #region Проверка Руководителя Краснодар
                if (LeaderNUser == "Руководитель 1")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head1"); // Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Краснодар.Группа продаж Руководитель 1" + "” " + NUserLogin); // Группа продаж Руководитель 1


                    NameDepartment = (@"Отдел коммерции\Группа " + "Руководитель 1");
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                if (LeaderNUser == "Руководитель 2")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head2");// Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Краснодар.Группа продаж Руководитель 2" + "” " + NUserLogin);// Группа продаж


                    NameDepartment = (@"Отдел коммерции\Группа " + "Руководитель 2");
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                if (LeaderNUser == "Руководитель 3") //Руководитель 3
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head3");// Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Краснодар.Группа продаж Руководитель 3" + "” " + NUserLogin);// Группа продаж

                    NameDepartment = (@"Отдел коммерции\Группа " + "Руководитель 3");
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                if (LeaderNUser == "Руководитель 4")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head4");// Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Краснодар.Группа продаж Руководитель 4" + "” " + NUserLogin);// Группа продаж


                    NameDepartment = (@"Отдел коммерции\Группа " + "Руководитель 4");
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                #endregion // Краснодар 1
            }
            if (NUserCity == "Астрахань") //Астрахань 2
            {
                NUserMaill = NUserLogin + "@astrakhan.2gis.ru"; //Гинерим почту конкатинацией логогина и собака города
                MailUser = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{mail =" + "”" + NUserMaill + "”" + "}"); //Команда бичес-кирпичес
                NUserCityCommand = "OU=Пользователи,OU=Астрахань,OU=Cities,DC=2gis,DC=local";
                Userl = "Астрахань"; //Город
                NameCompany = "”" + "2ГИС - Астрахань" + "”"; // Нужено все взять в '
                //Группы по городам
                NUserGroup1 = ("Add-ADGroupMember " + "”" + "Астрахань.Пользователи" + "” " + NUserLogin);
                NUserGroup3 = ("Add-ADGroupMember " + "”" + "Астрахань.Access.VPN" + "” " + NUserLogin);
                NUserGroup5 = ("Add-ADGroupMember " + "”" + "Астрахань.Отдел коммерции" + "” " + NUserLogin); // У кого-то есть у когото нет. Ващет должен быть
                NUserGroup6 = ("\n"); // передаем энтер чтобы избежать всяких ошибок. Так, на всякий случай
                #region Проверка Руководителя Астрахань
                if (LeaderNUser == "Руководитель 1")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head1"); // Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Астрахань.Группа продаж 1" + "” " + NUserLogin); // Группа продаж 5

                    NameDepartment = (@"Отдел коммерции\Группа Охотники"); //группа Вдовина называеться Охотники
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                if (LeaderNUser == "Руководитель 2")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head2"); // Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Астрахань.Группа продаж 2" + "” " + NUserLogin); // Группа продаж 5

                    NameDepartment = (@"Отдел коммерции\Группа Хищники"); //группа называеться Хищники
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                    #endregion
                }
            if (NUserCity == "Сочи") // Сочи 3
            {
                NUserMaill = NUserLogin + "@sochi.2gis.ru"; //Гинерим почту конкатинацией логогина и собака города
                MailUser = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{mail =" + "”" + NUserMaill + "”" + "}"); //Команда бичес-кирпичес
                NUserCityCommand = "OU=Пользователи,OU=Сочи,OU=Cities,DC=2gis,DC=local";
                //NUserCityCommand = "OU=Сочи,OU=Lol,DC=for,DC=the,DC=horde";
                Userl = "Сочи"; //Город
                NameCompany = "'ООО" + " ”" + "2ГИС.Сочи" + "”'"; // Нужено все взять в '
                //Группы по городам
                NUserGroup1 = ("Add-ADGroupMember " + "”" + "Сочи.Пользователи" + "” " + NUserLogin);
                NUserGroup3 = ("Add-ADGroupMember " + "”" + "Сочи.Access.VPN" + "” " + NUserLogin); //
                NUserGroup5 = ("Add-ADGroupMember " + "”" + "Сочи.Менеджер по продажам" + "” " + NUserLogin); // У кого-то есть у когото нет. Ващет должен быть
                NUserGroup6 = ("\n"); // передаем энтер чтобы избежать всяких ошибок. Так, на всякий случай
                #region Проверка Руководителя Cочи
                if (LeaderNUser == "Руководитель 1")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head1");// Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Сочи.Группа продаж 2" + "” " + NUserLogin);// Группа продаж

                    NameDepartment = (@"Отдел коммерции"); //Для Сочи просто отдел коммерции
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                if (LeaderNUser == "Руководитель 2")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head2");// Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Сочи.Группа продаж 1" + "” " + NUserLogin);// Группа продаж

                    NameDepartment = (@"Отдел коммерции"); //Для Сочи просто отдел коммерции
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                if (LeaderNUser == "Руководитель 3")
                {
                    Leader = ("set-aduser " + NUserLogin + " -manager " + "Head3");// Указываем РПГ
                    NUserGroup2 = ("Add-ADGroupMember " + "”" + "Сочи.Группа продаж 3" + "” " + NUserLogin);// Группа продаж

                    NameDepartment = (@"Отдел коммерции"); //Для Сочи просто отдел коммерции
                    Department = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Department =" + "'" + NameDepartment + "'" + "}");
                }
                #endregion
            }
            #endregion

            //Создаю пользака.Важно сразу указать где он будет создан т.к по умолчанию попадет в поле вне нашей юрисдикции
            string FIO = ("New-ADUser -SamAccountName " + "'" + NUserLogin + "'" + " -Name " + "”" + NUserFIO + "”" +
            " -Path " + "”" + NUserCityCommand + "”");
            //===========================================================================================================

            //Должность
            string NUserPosition = "Менеджер по продажам";
            string NUserDol = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Title =" + "”" +
            NUserPosition + "”" + "}");
            
            //Указываем вэб-адрес
            string UserWedAdress = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{wWWHomePage =" + "”" + "http//2gis.ru" + "”" + "}");
            
            //Указываем Имя входа пользователя
            string UserPrincipalName = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{UserPrincipalName =" + "”" + NUserLogin + "@2gis.ru" + "”" + "}");
            
            //Сырок действия не ограничен.Отключен
            string PasswordNeverExpires = ("Set-ADAccountControl -Identity " + NUserLogin + " -PasswordNeverExpires " + "$False");

            //Указываем внутренний
            string ipPhone = "";
            if (NUserNomerVn != "") // Если параметр не пуст то указываем его
            {
                ipPhone = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{ipPhone =" + "”" + NUserNomerVn + "”" + "}");
            } // Если параметр не пуст то указываем его
            else { ipPhone = "\n"; } // Иначе ничего не делаем 

            //Указываем extensionAttribute5
            string UserEA5 = "+7-800-25-023-25";
            string extensionAttribute5 = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{extensionAttribute5 =" + "”" + UserEA5 + "”" + "}");

            //Указываем компанию. 
        
            string Company = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{Company =" + NameCompany  + "}");

            //Указываем cmTelephonyPartnerld
            string UsercmTelephonyPartnerld = @"\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0";
            string cmTelephonyPartnerld = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{crmTelephonyPartnerId =" + "”" + UsercmTelephonyPartnerld + "”" + "}");
            //Моя АД
            
            //Указываем город и страну
            #region Указываем город и страну
            // Город. Он указываеться в блоке выше
            string l = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{l =" + "”" + Userl + "”" + "}");
            //Страна
            string c = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{c =" + "”" + "RU" + "”" + "}");
            string co = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{co =" + "”" + "Россия" + "”" + "}");
            string countryCode = ("Set-ADUser -Identity " + "”" + NUserLogin + "”" + " -Replace  @{countryCode =" + "”" + "643" + "”" + "}");
            #endregion
            //Добавляем человека в группу NUserGroupS
            #region Добавляем в группы(NUserGroupS)
            string NUserGroupS = (
            NUserGroup1 + //Краснодар.Пользователи
            "\n" +
            NUserGroup2 + //Краснодар.Группа продаж N
            "\n" +
            NUserGroup3 + //Краснодар.Access.VPN
            "\n" +
            //NUserGroup4 +//Uk.Access.PBI.RLS.Sales.BulkUsers
             "\n" +
            NUserGroup5 +//KSDR.PR-03
             "\n" +
            NUserGroup6  //Краснодар.Менеджер по продажам
            );
            #endregion
            #endregion
            #region Загоняем
            string Pause = "\n"+"Pause *"; //Используеться когда нужно проверить.
            System.Diagnostics.Process.Start("powershell.exe", "-executionpolicy Unrestricted -Command " +
                FIO + // Создаю нового пользователя указывая ФИО
                "\n" +
                pass +// Задаю пароль
                "\n" +
                Vkl +//Включаю учетку
                "\n" +
                UserPrincipalName +//Имя входа пользака. Экей логин
                "\n" +
                PasswordNeverExpires +//Сырок годности не истекает
                "\n" +
                name +//Указываю имя
                "\n" +
                fame +//Указываю фамилию
                "\n" +
                Gender +//Указываю пол
                "\n" +
                Birthday +// День варенья
                "\n" +
                MainFIO +// Указываю полноре фио
                "\n" +
                NUserDol +// Должность
                "\n" +
                NUserGroupS +//Добавляем в группы
                "\n" +
                Department +// Указываем отдел
                "\n" +
                Leader +// Указываем руководителя
                "\n" +
                Company +//Название компании                                              ТУТ
                "\n" +
                l +// Город
                "\n" +
                co +// Указываем страну
                "\n" +
                c +//RU
                "\n" +
                countryCode +// Код страны
                "\n" +
                MainNamber +//Общий + внутренний
                "\n" +
                ipPhone +// Указываем рабочий тефончик
                "\n" +
                extensionAttribute5 +//который один для всех телефон
                "\n" +
                MailUser +//Рабочая почта юзера
                "\n" +
                UserWedAdress +//Общий вэб адрес
                "\n" +
                cmTelephonyPartnerld + //cmTelephonyPartnerld
                "\n" +
                Usermobile + //Личный пользорвателя
                "\n"
               //+Pause
               );
            #endregion
            #region Выводим
            FormAnswer.Text = NUserLogin + "\t" + "\t" + "\t" + NUserPassword
            + "\n" +
            NUserMaill + "\t" + NUserPassword
            + "\n" +
            NUserNomerVn;
            #endregion
            #region Новые пароли
            BoxPassword.Items.Clear(); // Очищаю
            string NUserPassword1 = Password.MagicZone();   // Генерую случайный пароль 1
            Thread.Sleep(20);
            string NUserPassword2 = Password.MagicZone();   // Генерую случайный пароль 2
            Thread.Sleep(20);
            string NUserPassword3 = Password.MagicZone();   // Генерую случайный пароль 3
            Thread.Sleep(20);
            string NUserPassword4 = Password.MagicZone();   // Генерую случайный пароль 4
            Thread.Sleep(20);
            string NUserPassword5 = Password.MagicZone();   // Генерую случайный пароль 5


            BoxPassword.Items.AddRange(new string[] { NUserPassword1, NUserPassword2, NUserPassword3, NUserPassword4, NUserPassword5 });
            BoxPassword.SelectedItem = NUserPassword1;
            #endregion
            #region Очищаем форму
            CiteBox.SelectedItem = "Краснодар"; // Выбор по умолчанию для города
            FormFIO.Clear(); // Очищаем ФИО
            FormDate.Clear(); // Дата рождения
            GenderBox.SelectedItem = "Чувак"; // Выбор по умолчанию для пола
            FormLeader.Clear();// Назначаем руководителя
            FormNomerVn.Clear();// Внутренний номер
            FormMobNomer.Clear(); //Мобильный номер
            #endregion
        }
        #region Прочие Функции

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Exit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CiteBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenderBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void HylaBox_Click(object sender, EventArgs e)
        {
            Hyla Frog = new Hyla();
            Frog.Show();
        }
        #endregion

        private void CopyButton_Click(object sender, EventArgs e) // Кнопка копировать
        {
            System.Windows.Forms.Clipboard.SetText(FormAnswer.Text);
        }
    }
}
