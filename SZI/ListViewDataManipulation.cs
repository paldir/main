﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SZI
{
    /// <summary>
    /// Klasa odpowiadająca za zarządzanie danym w listView.
    /// </summary>
    public static class ListViewDataManipulation
    {
        /// <summary>
        /// Metoda usuwająca rekordy odpowiadające zaznaczonym w przekazanym ListView itemom.
        /// </summary>
        /// <param name="listView">ListView, której zaznaczone itemy zostaną usunięte.</param>
        /// <param name="Table">Tabela, z której zostaną usunięte rekordy.</param>
        /// <returns>Wartość mówiąca o tym, czy użytkownik zdecydował się na usunięcie rekordów.</returns>
        public static bool DeleteItems(ListView listView, Tables Table)
        {
            List<string> ids = Auxiliary.CreateIdList(listView);
            bool idExists = false;
            string tableName = string.Empty;
            DialogResult choiceFromMessageBox = DialogResult.Yes;

            switch (Table)
            {
                case Tables.Collectors:
                    tableName = "Collector";
                    break;
                case Tables.Customers:
                    tableName = "Customer";
                    break;
                case Tables.Areas:
                    tableName = "Area";
                    break;
                case Tables.Addresses:
                    tableName = "Address";
                    break;
                case Tables.Counters:
                    tableName = "Counter";
                    break;
            }

            for (int i = 0; i < ids.Count; i++)
            {
                idExists = DBManipulator.IdExistsInOtherTable(tableName, ids.ElementAt(i));
                if (idExists)
                {
                    tableName = tableName.ToLower();
                    choiceFromMessageBox = MessageBox.Show(LangPL.IntegrityWarnings[tableName + "Removal"], "Ostrzeżenie", MessageBoxButtons.YesNo);
                    break;
                }
            }

            if (choiceFromMessageBox == DialogResult.Yes)
            {
                DBManipulator.DeleteFromDB(ids, Table, idExists);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Wypełnia ListView otwartą w danym momencie i dopisuje ją do tablicy IDataBase.
        /// </summary>
        /// <param name="MainForm">Główny formularz programu.</param>
        public static void ComplementListView(ConfigManagementForm MainForm)
        {
            switch (ConfigManagementForm.selectedTab)
            {
                case Tables.Collectors:
                    MainForm.UpdateStatusLabel((int)Tables.Collectors);
                    ConfigManagementForm.dataBase[(int)Tables.Collectors] = new Collectors();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Collectors], ConfigManagementForm.dataBase[(int)Tables.Collectors].itemList);
                    break;

                case Tables.Customers:
                    MainForm.UpdateStatusLabel((int)Tables.Customers);
                    ConfigManagementForm.dataBase[(int)Tables.Customers] = new Customers();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Customers], ConfigManagementForm.dataBase[(int)Tables.Customers].itemList);
                    break;

                case Tables.Areas:
                    MainForm.UpdateStatusLabel((int)Tables.Areas);
                    ConfigManagementForm.dataBase[(int)Tables.Areas] = new Areas();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Areas], ConfigManagementForm.dataBase[(int)Tables.Areas].itemList);
                    break;

                case Tables.Counters:
                    MainForm.UpdateStatusLabel((int)Tables.Counters);
                    ConfigManagementForm.dataBase[(int)Tables.Counters] = new Counters();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Counters], ConfigManagementForm.dataBase[(int)Tables.Counters].itemList);
                    break;

                case Tables.Addresses:
                    MainForm.UpdateStatusLabel((int)Tables.Addresses);
                    ConfigManagementForm.dataBase[(int)Tables.Addresses] = new Addresses();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Addresses], ConfigManagementForm.dataBase[(int)Tables.Addresses].itemList);
                    break;

                default:
                    break;
            }
            MainForm.UpdateStatusLabel(-1);
        }

        /// <summary>
        /// Wypełnia ListView otwartą w danym momencie i tworzy tablicę IDataBase.
        /// </summary>
        /// <param name="MainForm">Główny formularz programu.</param>
        private static void FillListView(ConfigManagementForm MainForm)
        {
            switch (ConfigManagementForm.selectedTab)
            {
                case Tables.Collectors:
                    MainForm.UpdateStatusLabel((int)Tables.Collectors);
                    ConfigManagementForm.dataBase = new IDataBase[5] { new Collectors(), null, null, null, null };
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Collectors], ConfigManagementForm.dataBase[(int)Tables.Collectors].itemList);
                    break;

                case Tables.Customers:
                    MainForm.UpdateStatusLabel((int)Tables.Customers);
                    ConfigManagementForm.dataBase = new IDataBase[5] { null, new Customers(), null, null, null };
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Customers], ConfigManagementForm.dataBase[(int)Tables.Customers].itemList);
                    break;

                case Tables.Areas:
                    MainForm.UpdateStatusLabel((int)Tables.Areas);
                    ConfigManagementForm.dataBase = new IDataBase[5] { null, null, new Areas(), null, null };
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Areas], ConfigManagementForm.dataBase[(int)Tables.Areas].itemList);
                    break;

                case Tables.Counters:
                    MainForm.UpdateStatusLabel((int)Tables.Counters);
                    ConfigManagementForm.dataBase = new IDataBase[5] { null, null, null, new Counters(), null };
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Counters], ConfigManagementForm.dataBase[(int)Tables.Counters].itemList);
                    break;

                case Tables.Addresses:
                    MainForm.UpdateStatusLabel((int)Tables.Addresses);
                    ConfigManagementForm.dataBase = new IDataBase[5] { null, null, null, null, new Addresses() };
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Addresses], ConfigManagementForm.dataBase[(int)Tables.Addresses].itemList);
                    break;

                default:
                    break;
            }
            MainForm.UpdateStatusLabel(-1);
            ConfigManagementForm.ListViewFilled[(int)ConfigManagementForm.selectedTab] = true;
        }

        /// <summary>
        /// Delegacja okreslająca wygląd nagłówka metody aktualizującej ProgressStatusStripa.
        /// </summary>
        /// <param name="MainForm">Instancja klasy ConfigManagementForm która zawiera aktualizowany ProgressStatusStrip.</param>
        /// <param name="i">Wartość ustawiana na ProgressStatusStripie.</param>
        /// <param name="max">Maksymalna dopuszczalna wartość.</param>
        private delegate void UpdateProgressStatusDelegate(ConfigManagementForm MainForm, int i, int max);

        /// <summary>
        /// Metoda aktualizująca stan ProgressStatusStripa.
        /// </summary>
        /// <param name="MainForm">Instancja klasy ConfigManagementForm która zawiera aktualizowany ProgressStatusStrip.</param>
        /// <param name="i">Wartość ustawiana na ProgressStatusStripie.</param>
        /// <param name="max">Maksymalna dopuszczalna wartość.</param>
        private static void UpdateProgressStatus(ConfigManagementForm MainForm, int i, int max)
        {
            String ProgressStatusName = "progressStatusMain";
            ProgressStatusStrip progressStatus = MainForm.Controls.Find(ProgressStatusName, true)[0] as ProgressStatusStrip;
            if (progressStatus.InvokeRequired)
            {
                UpdateProgressStatusDelegate del = new UpdateProgressStatusDelegate(UpdateProgressStatus);
                progressStatus.Invoke(del, MainForm, i, max);
                return;
            }
            progressStatus.Value = (i / (float)max) * 100;
            Application.DoEvents();
        }

        /// <summary>
        /// Odświeża wszystkie ListView, które były wcześniej wypełnione.
        /// </summary>
        /// <param name="MainForm">Główny formularz programu.</param>
        private static void RefreshFilledListViews(ConfigManagementForm MainForm)
        {
            int ListViewsToUpdate = 0; //liczba ListView do odświeżenia
            int k = 0; //numer odświeżanej listy

            for (int i = 0; i < ConfigManagementForm.ListViewFilled.Count(); i++)
                if (ConfigManagementForm.ListViewFilled[i] == true)
                    ListViewsToUpdate++;

            for (int i = 0; i < ConfigManagementForm.ListViewFilled.Count(); i++)
            {
                if (ConfigManagementForm.dataBase[i] != null)
                {
                    MainForm.UpdateStatusLabel(i);
                    UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                    ConfigManagementForm.dataBase[i].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[i], ConfigManagementForm.dataBase[i].itemList);
                    k++;
                }
            }
            MainForm.UpdateStatusLabel(-1);
            UpdateProgressStatus(MainForm, 0, ListViewsToUpdate);
        }

        /// <summary>
        /// Odświeża ListView w ConfigManagementForm.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący metodę.</param>
        /// <param name="Table">Tabela do odświeżenia.</param>
        public static void RefreshListView(object sender, Tables Table = Tables.Collectors)
        {
            if (sender.GetType() == typeof(Button)) //usunięto rekord
            {
                RefreshNecessaryTables(Table, sender);
                return;
            }

            IForm form = (IForm)sender;
            
            if (form.Modified) //jeśli dokonano modyfikacji lub dodania rekordu, to odśwież listę
            {
                if (form.GetType() == typeof(ConfigManagementForm)) //jeśli naciśnięto przycisk odśwież na formie
                {
                    if (ConfigManagementForm.dataBase != null)
                        RefreshFilledListViews((ConfigManagementForm)form);
                    else
                        FillListView((ConfigManagementForm)form);
                }
                else if (form.GetType() == typeof(InsertForm)) //jeśli wprowadzono rekord
                {
                    InsertForm insertForm = (InsertForm)form;
                    ConfigManagementForm.dataBase[(int)insertForm.InsertedTo].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)insertForm.InsertedTo], ConfigManagementForm.dataBase[(int)insertForm.InsertedTo].itemList);
                }
                else if (form.GetType() == typeof(ModifyForm))//zmodyfikowano rekord
                {
                    ModifyForm modifyForm = (ModifyForm)form;
                    RefreshNecessaryTables(modifyForm.Table, form);
                }
            }
        }


        /// <summary>
        /// Odświeża ListView odpowiadające zmodyfikowanej tabeli, a także powiązane z nią ListView, które zawierają klucze obce.
        /// </summary>
        /// <param name="ModifiedTable">Zmodyfikowana tabela.</param>
        public static void RefreshNecessaryTables(Tables ModifiedTable, object CallingObject)
        {
            int ListViewsToUpdate = 1;
            int k = 0;

            ConfigManagementForm MainForm;
            ModifyForm modifyForm;
            Button bt;

            if (CallingObject.GetType() == typeof(ModifyForm))
            {
                modifyForm = (ModifyForm)CallingObject;
                MainForm = (ConfigManagementForm)modifyForm.MainForm;
            }
            else
            {
                bt = (Button)CallingObject;
                MainForm = (ConfigManagementForm)bt.Parent;
            }

            switch (ModifiedTable)
            {
                case Tables.Collectors: //jeśli zmieniono coś w inkasentach, to odśwież inkasentów, tereny i adresy

                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Addresses])
                        ListViewsToUpdate++;
                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Addresses])
                        ListViewsToUpdate++;

                    MainForm.UpdateStatusLabel((int)Tables.Collectors);
                    UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                    k++;
                    ConfigManagementForm.dataBase[(int)Tables.Collectors].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Collectors], ConfigManagementForm.dataBase[(int)Tables.Collectors].itemList);

                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Areas])
                    {
                        MainForm.UpdateStatusLabel((int)Tables.Areas);
                        UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                        k++;
                        ConfigManagementForm.dataBase[(int)Tables.Areas].RefreshList();
                        ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Areas], ConfigManagementForm.dataBase[(int)Tables.Areas].itemList);
                    }

                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Addresses])
                    {
                        MainForm.UpdateStatusLabel((int)Tables.Addresses);
                        UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                        k++;
                        ConfigManagementForm.dataBase[(int)Tables.Addresses].RefreshList();
                        ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Addresses], ConfigManagementForm.dataBase[(int)Tables.Addresses].itemList);
                    }
                    break;

                case Tables.Customers: //jeśli zmieniono coś w klientach, to odświez klientów i liczniki
                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Counters])
                        ListViewsToUpdate++;

                    MainForm.UpdateStatusLabel((int)Tables.Customers);
                    UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                    k++;
                    ConfigManagementForm.dataBase[(int)Tables.Customers].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Customers], ConfigManagementForm.dataBase[(int)Tables.Customers].itemList);

                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Counters])
                    {
                        MainForm.UpdateStatusLabel((int)Tables.Counters);
                        UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                        k++;
                        ConfigManagementForm.dataBase[(int)Tables.Counters].RefreshList();
                        ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Counters], ConfigManagementForm.dataBase[(int)Tables.Counters].itemList);
                    }
                    break;

                case Tables.Areas: //jeśli zmieniono coś w terenach, to odświez tereny, liczniki i adresy
                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Counters])
                        ListViewsToUpdate++;
                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Addresses])
                        ListViewsToUpdate++;

                    MainForm.UpdateStatusLabel((int)Tables.Areas);
                    UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                    k++;
                    ConfigManagementForm.dataBase[(int)Tables.Areas].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Areas], ConfigManagementForm.dataBase[(int)Tables.Areas].itemList);

                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Counters])
                    {
                        MainForm.UpdateStatusLabel((int)Tables.Counters);
                        UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                        k++;
                        ConfigManagementForm.dataBase[(int)Tables.Counters].RefreshList();
                        ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Counters], ConfigManagementForm.dataBase[(int)Tables.Counters].itemList);
                    }

                    if (ConfigManagementForm.ListViewFilled[(int)Tables.Addresses])
                    {
                        MainForm.UpdateStatusLabel((int)Tables.Addresses);
                        UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                        k++;
                        ConfigManagementForm.dataBase[(int)Tables.Addresses].RefreshList();
                        ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Addresses], ConfigManagementForm.dataBase[(int)Tables.Addresses].itemList);
                    }
                    break;

                case Tables.Counters:
                    MainForm.UpdateStatusLabel((int)Tables.Counters);
                    UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                    ConfigManagementForm.dataBase[(int)Tables.Counters].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Counters], ConfigManagementForm.dataBase[(int)Tables.Counters].itemList);
                    break;

                case Tables.Addresses:
                    MainForm.UpdateStatusLabel((int)Tables.Addresses);
                    UpdateProgressStatus(MainForm, k, ListViewsToUpdate);
                    ConfigManagementForm.dataBase[(int)Tables.Addresses].RefreshList();
                    ListViewConfig.ListViewRefresh(ConfigManagementForm.listView[(int)Tables.Addresses], ConfigManagementForm.dataBase[(int)Tables.Addresses].itemList);
                    break;

                default:
                    break;
            }
            MainForm.UpdateStatusLabel(-1);
            UpdateProgressStatus(MainForm, 0, ListViewsToUpdate);
        }


        /// <summary>
        /// Wywoływana po naciśnięciu przycisku "Modyfikuj". Otwiera formularz umożliwiający modyfikację zaznaczonego rekordu.
        /// </summary>
        /// <param name="listView">ListView, w której dokonano modyfikacji.</param>
        /// <param name="Table">Tabela odpowiadająca modyfikowanej ListView.</param>
        /// <param name="MainForm">Główny formularz programu.</param>
        public static void ModifyRecord(ListView listView, Tables Table, ConfigManagementForm MainForm)
        {
            List<string> ids = Auxiliary.CreateIdList(listView);
            int selectedIndex = listView.SelectedIndices[0]; //index modyfikowanego itemu
            var modifyForm = new ModifyForm(ids, Table, MainForm);
            modifyForm.ShowDialog();
            listView.HideSelection = false;

            if (selectedIndex < listView.Items.Count)
                listView.Items[selectedIndex].Selected = true;
        }
    }
}
